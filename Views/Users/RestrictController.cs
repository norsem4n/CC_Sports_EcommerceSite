using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CC_Sports.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CC_Sports.Views.Users
{
    public class RestrictController : Controller
    {
        private readonly CCSportsContext _context;

        public RestrictController(CCSportsContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> AccountInformation()
        {
            int userID = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

            var accountInformation = _context.Users
                .Where(u => u.UserId == userID);

            return View(await accountInformation.ToListAsync());
        }


        
    }
}
