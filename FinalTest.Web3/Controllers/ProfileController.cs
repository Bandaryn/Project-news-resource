using FinalTest.Domain.Contracts;
using FinalTest.Domain.Contracts.ViewModels;
using FinalTest.Web3.Filters;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalTest.Web2.Controllers
{
    [Culture]
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
            var currentIds = User.Identity.GetUserId();
            var isAdmin = User.IsInRole("admin");
            
            var profil = profileService.Get(id);

            if(profil.Ids == currentIds || isAdmin == true)
            {
                profil.IsEditable = true;
            }
            else
            {
                profil.IsEditable = false;
            }
            return View(profil);

        }

        [Authorize]
        public ActionResult MyProfile()
        {

            var ids = User.Identity.GetUserId();
                       
            

            if (profileService.Get(ids) == null)
            {
                var profil = new ProfileViewModel();
                profil.Email = User.Identity.GetUserName();
                profil.Ids = User.Identity.GetUserId();
                return View("CreateProfile",profil);
            }
            else
            {
                var profil = profileService.Get(ids);
                return RedirectToAction("Display", new { id = profil.Id });
            }
            
            

        }

        [HttpPost]
        public ActionResult MyProfile(ProfileViewModel viewModel)
        {
            if (viewModel.Id == 0)
            {
                for(int i=1; ; i++)
                {
                    if(profileService.Get(i)==null)
                    {
                        viewModel.Id = i;
                        profileService.Add(viewModel);
                        break;
                    }
                }
                
            }
            
                profileService.Update(viewModel);
            

            return RedirectToAction("Display", new { id = viewModel.Id });
        }

        [HttpPost]
        public ActionResult Update(string name, int pk,string value)
        {
            var post = profileService.Get(pk);

            switch (name)
            {
                case "FirstName":
                    post.FirstName = value;
                    break;
                case "LastName":
                    post.LastName = value;
                    break;
                case "UserName":
                    post.UserName = value;
                    break;
                default:
                    break;
            }

            

            profileService.Update(post);

            return new HttpStatusCodeResult(200);
        }

    }
}