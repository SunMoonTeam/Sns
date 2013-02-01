using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using System.IO;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using SunMoon.Blog.DataAccess.EntityFramework;
using SunMoon.Blog.Mvc3Razor.Models;

namespace SunMoon.Blog.Mvc3Razor.Controllers {

    public class AccountController : Controller {

        public IFormsAuthenticationService FormsService { get; set; }

        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext) {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn() {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl) {
            try {
                using (blogEntities ct = new blogEntities()) {
                    var result = ct.Users.Find(model.UserName);

                    if (result != null && result.Passwrod.Equals(model.Password)) {
                        //登录成功。
                        Passport pp = new Passport();

                        pp.AccountID = model.UserName;
                        pp.LoginTime = System.DateTime.Now;
                        pp.IP = Request.UserHostAddress;

                        Session.Add("passport", pp);

                        return RedirectToAction("Index", "Home");
                    }
                    else {
                        //用户名或者密码错误。
                        ModelState.AddModelError("", "提供的用户名或密码不正确。");
                    }
                }

                // 如果我们进行到这一步时某个地方出错，则重新显示表单
                return RedirectToAction("LogOn");
            }
            catch (Exception ex) {
                string path = AppDomain.CurrentDomain.BaseDirectory + "log.txt";

                StreamWriter sw = null;

                if (!System.IO.File.Exists(path))
                    sw = System.IO.File.CreateText(path);
                else
                    sw = System.IO.File.AppendText(path);

                sw.WriteLine(ex.Message);

                sw.Close();
            }
            return View();
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff() {
            Session.Remove("passport");

            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register() {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;

            RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model) {
            using (blogEntities en = new blogEntities()) {
                User user = new User();

                user.UserID = model.UserName;
                user.Passwrod = model.Password;
                user.Mail = model.Email;

                en.Users.Add(user);
                en.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword() {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model) {
            if (ModelState.IsValid) {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword)) {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else {
                    ModelState.AddModelError("", "当前密码不正确或新密码无效。");
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess() {
            return View();
        }
    }
}