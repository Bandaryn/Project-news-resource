using FinalTest.Domain.Contracts;
using FinalTest.Web3.Filters;
using FinalTest.Web3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalTest.Web3.Controllers
{
    [Authorize(Roles ="admin")]
    [Culture]
    public class AdminController : Controller
    {
        private readonly IPostService postService;
        private readonly IProfileService profileService;


        public AdminController(IPostService postService, IProfileService profileService)
        {
            this.postService = postService;
            this.profileService = profileService;

        }

        // GET: Admin
        public ActionResult GodMode()
        {
            return View();
        }

        public ActionResult Users()
        {
            var profileList = profileService.GetList();
            return View(profileList);
        }

        public ActionResult Posts()
        {
            var postList = postService.GetList();
            return View(postList);
        }

        public ActionResult ManageRoles(string id)
        {
            IList<string> roles = new List<string> { "Роль не определена" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindById(id);
            
            if (user != null)
                roles = userManager.GetRoles(user.Id);

            var profil = profileService.Get(id);
            profil.Roles = roles;

            return View(profil);
        }

        public ActionResult SetAdmin(string id)
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindById(id);

            userManager.AddToRole(id, "admin");

            return RedirectToAction("ManageRoles", new { id = id });
        }

        public ActionResult SetWriter(string id)
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindById(id);

            userManager.AddToRole(id, "writer");

            return RedirectToAction("ManageRoles", new { id = id });
        }



        public ActionResult SetReader(string id)
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindById(id);

            userManager.AddToRole(id, "reader");

            return RedirectToAction("ManageRoles", new { id = id });
        }

        public ActionResult RemoveAdmin(string id)
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindById(id);

            userManager.RemoveFromRole(id, "admin");

            return RedirectToAction("ManageRoles", new { id = id });
        }

        public ActionResult RemoveWriter(string id)
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindById(id);

            userManager.RemoveFromRole(id, "writer");

            return RedirectToAction("ManageRoles", new { id = id });
        }

        public ActionResult Ban(string id)
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindById(id);

            
            userManager.RemoveFromRole(id, "admin");
            userManager.RemoveFromRole(id, "writer");
            userManager.RemoveFromRole(id, "reader");

            return RedirectToAction("ManageRoles", new { id = id });
        }

    }
}