using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using CC_Sports.Models;

namespace CC_Sports.Controllers
{
    //public class ShopController : Controller
    //{
    //    private readonly CCSportsContext _context;
    //    public ShopController(CCSportsContext context)
    //    {
    //        _context = context;
    //    }

    //    public IActionResult Search(string searchSport, string searchBrand, string searchModel, string conditions, string gender, decimal? priceMin, decimal? priceMax)
    //    {
    //        var products = from p in _context.Products select p;

    //        //skiing or snowboarding
    //        if (!string.IsNullOrEmpty(searchSport))
    //        {
    //            products = products.Where(p => p.Sport.Contains(searchSport));
    //        }

    //        //favorite brand
    //        if (!string.IsNullOrEmpty(searchBrand))
    //        {
    //            products = products.Where(p => p.Brand.Contains(searchBrand));
    //        }

    //        //model
    //        if (!string.IsNullOrEmpty(searchModel))
    //        {
    //            products = products.Where(p => p.Model.Contains(searchModel));
    //        }

    //        if (!string.IsNullOrEmpty(conditions))
    //        {
    //            products = products.Where(p => p.Conditions.Contains(conditions));
    //        }

    //        //gender
    //        if (!string.IsNullOrEmpty(gender))
    //        {
    //            products = products.Where(p => p.Conditions.Contains(conditions));
    //        }

    //        //price minimum
    //        if (priceMin != null)
    //        {
    //            products = products.Where(p => p.UnitPrice >= priceMin);
    //        }

    //        //price maximum
    //        if (priceMax != null)
    //        {
    //            products = products.Where(p => p.UnitPrice <= priceMax);
    //        }

    //        ViewData["SportFilter"] = searchSport;
    //        ViewData["BrandFilter"] = searchBrand;
    //        ViewData["ModelFilter"] = searchModel;
    //        ViewData["ConditionsFilter"] = conditions;
    //        ViewData["GenderFilter"] = gender;
    //        ViewData["PriceMinFilter"] = priceMin;
    //        ViewData["PriceMaxFilter"] = priceMax;

    //        return View(products.OrderBy(p => p.Model).ThenBy(p => p.Conditions).ThenBy(p => p.UnitPrice).ToList());
    //    }

    //    // prepare output to display details for a product
    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return RedirectToAction(nameof(Search));
    //        }

    //        var product = await _context.Products
    //            .Include(p => p.BrandNavigation)
    //            //.Include(p => p.ProductIdfkNavigation)
    //            .FirstOrDefaultAsync(m => m.ProductId == id);

    //        if (product == null)
    //        {
    //            return RedirectToAction(nameof(Search));
    //        }

    //        return View(product);
    //    }

    //    // add a product to shopping cart
    //    public IActionResult AddToCart(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return RedirectToAction(nameof(Search));
    //        }

    //        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

    //        if (product == null)
    //        {
    //            return RedirectToAction(nameof(Search));
    //        }

    //        // call to method to retrieve cart object from session state

    //        Cart aCart = GetCart();

    //        aCart.AddItem(product);

    //        // call to method to save cart object to session state

    //        SaveCart(aCart);

    //        return RedirectToAction(nameof(MyCart));
    //    }

    //    // prepare output to display items in cart object
    //    public IActionResult MyCart()
    //    {
    //        Cart aCart = GetCart();

    //        if (aCart.CartItems().Any())
    //        {
    //            return View(aCart);
    //        }

    //        // if the cart is empty
    //        return RedirectToAction(nameof(Search));
    //    }

    //    // update cart - i.e., the quantity for a product in the cart
    //    public IActionResult UpdateCart(int? productPK, int qty)
    //    {
    //        if (productPK == null)
    //        {
    //            return RedirectToAction(nameof(Search));
    //        }

    //        var product = _context.Products.FirstOrDefault(p => p.ProductId == productPK);

    //        if (product == null)
    //        {
    //            return RedirectToAction(nameof(Search));
    //        }

    //        Cart aCart = GetCart();

    //        aCart.UpdateItem(product, qty);

    //        SaveCart(aCart);

    //        return RedirectToAction(nameof(MyCart));
    //    }

    //    // remove an item from the cart
    //    public IActionResult RemoveFromCart(int? productPK)
    //    {
    //        if (productPK == null)
    //        {
    //            return RedirectToAction(nameof(Search));
    //        }

    //        var product = _context.Products.FirstOrDefault(p => p.ProductId == productPK);

    //        if (product == null)
    //        {
    //            return RedirectToAction(nameof(Search));
    //        }

    //        Cart aCart = GetCart();

    //        aCart.RemoveItem(product);

    //        SaveCart(aCart);

    //        return RedirectToAction(nameof(MyCart));
    //    }

    //    //method to retrieve cart object from session state
    //    private Cart GetCart()
    //    {
    //        // call the session extension method GetObject
    //        // if a cart object doesn't exist, create a new cart object

    //        Cart aCart = HttpContext.Session.GetObject<Cart>("Cart") ?? new Cart();
    //        return aCart;
    //    }

    //    //method to save cart object to session state
    //    private void SaveCart(Cart aCart)
    //    {
    //        // call the session extension method SetObject

    //        HttpContext.Session.SetObject("Cart", aCart);
    //    }
    //} 
}
