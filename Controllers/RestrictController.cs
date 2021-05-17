using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using CC_Sports.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CC_Sports.Controllers
{
    public class RestrictController : Controller
    {
        private readonly CCSportsContext _context;

        public RestrictController(CCSportsContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> MyOrders()
        {
            // retrieve the user's PK from the Claims collection
            // since the PK is stored as a string, it has to be parsed to an integer

            int userID = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

            // retrieve the user's orders

            var orderDetail = _context.Invoices
                .Include(od => od.OrderIdfkNavigation)
                .Include(od => od.ProductIdfkNavigation)
                .Where(u => u.OrderIdfkNavigation.UserId == userID)
                .OrderBy(d => d.OrderIdfkNavigation.OrderDate);

            return View(await orderDetail.ToListAsync());
        }

        //[Authorize]
        public IActionResult CheckOut()
        {
            return View(nameof(LoginNeeded));
            //return RedirectToAction("LoginNeeded", "Restrict");
        }

        [Authorize]
        public IActionResult PlaceOrder()
        {
            Cart aCart = GetCart();

            if (aCart.CartItems().Any())
            {
                int userID = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

                // insert order
                Order aOrder = new Order { UserId = userID, OrderDate = DateTime.Now }; 

                _context.Add(aOrder);
                _context.SaveChanges();

                // get the PK of the newly inserted order
                int orderPK = aOrder.OrderId;

                // insert a orderdetail for each item in the cart
                foreach (CartItem aItem in aCart.CartItems())
                {
                    Invoice aDetail = new Invoice { ProductIdfk = aItem.Product.ProductId, OrderQty = aItem.Quantity, OrderIdfk = orderPK };
                    _context.Add(aDetail);
                }

                _context.SaveChanges();

                // remove all items from cart
                aCart.ClearCart();

                SaveCart(aCart);

                return View(nameof(OrderConfirmation));
            }

            //return RedirectToAction("Search", "Shop");
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> DeleteOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = await _context.Invoices
                .FirstOrDefaultAsync(m => m.OrderIdfk == id);
            if (order == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Invoices.FindAsync(id);
            _context.Invoices.Remove(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        private IActionResult OrderConfirmation()
        {
            return View();
        }

        private Cart GetCart()
        {
            Cart aCart = HttpContext.Session.GetObject<Cart>("Cart") ?? new Cart();
            return aCart;
        }

        private void SaveCart(Cart aCart)
        {
            HttpContext.Session.SetObject("Cart", aCart);
        }

        public IActionResult LoginNeeded()
        {
            return View();
        }

        //private Order MyOrder()
        //{
        //    Order aOrder = HttpContext.Session.GetObject<Order>("Order") ?? new Order();
        //    return aOrder;
        //}

    }
}
