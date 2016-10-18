using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Cezium.SmartHome.UI.Models;
using Cezium.SmartHome.UI.Models.VM.Accounts;
using Cezium.SmartHome.UI.Models.DB;
using NLog;

namespace Cezium.SmartHome.UI.Controllers
{
    [Authorize]
    public class ManageController : BaseController
    {
        public ManageController(ApplicationDbContext dbContext, ILogger logger)
            : base(dbContext, logger)
        {
        }

        public async Task<ActionResult> Index()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<string>());

            var model = new ManageViewModel
            {
                Email = user.Email,
                UserName = user.UserName
            };

            return View(model);
        }


        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = "Password was changed" });
            }
            AddErrors(result);
            return View(model);
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}