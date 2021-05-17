using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CC_Sports.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CC_Sports.Controllers
{
    public class UsersController : Controller
    {
        private readonly CCSportsContext _context;

        public UsersController(CCSportsContext context)
        {
            _context = context;
        }

        // GET: Users
        public IActionResult Index()
        {
            return Redirect("~/");
        }

        public IActionResult Login(string returnURL)
        {
            returnURL = String.IsNullOrEmpty(returnURL) ? "~/" : returnURL;

            return View(new LoginInput { ReturnURL = returnURL });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("userName, userPassword, ReturnURL")] LoginInput loginInput)
        {
            if (ModelState.IsValid)
            {
                var aUser = await _context.Users.FirstOrDefaultAsync(u => u.UserLogin == loginInput.userName && u.UserPassword == loginInput.userPassword);

                if (aUser != null)
                {
                    var claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Name, aUser.UserLogin));
                    claims.Add(new Claim(ClaimTypes.Sid, aUser.UserId.ToString()));

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return Redirect(loginInput?.ReturnURL ?? "~/");
                }
                else
                {
                    ViewData["message"] = "Invalid credentials";
                }
            }

            return View(loginInput);
        }
                

        // GET: Users/SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([Bind("UserLogin,UserPassword,FirstName,LastName,StreetAddress,City,State,Zip,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                var aUser = await _context.Users.FirstOrDefaultAsync(u => u.UserLogin == user.UserLogin);

                if (aUser is null)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();

                    TempData["success"] = "Account Created";

                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    ViewData["message"] = "Choose a different user name";
                }                
            }
            return View(user);
        }

        public async Task<RedirectToActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        // GET: Users/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            //var aUser = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            //var user = _context.Users
            //     .Where(u => u.UserId == userID);


            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserLogin,UserPassword,FirstName,LastName,StreetAddress,City,State,Zip,Email")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Account Updated";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["success"] = "Account Updated";
                return RedirectToAction(nameof(Edit));
            }
            return View();


        }

        // GET: Users/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");

        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        // GET: Users/Details/5
       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


    }
}
