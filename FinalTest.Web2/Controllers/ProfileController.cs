using FinalTest.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalTest.Web2.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display(int id)
        {
            var profil = profileService.Get(id);

            return View(profil);

        }
    }
}