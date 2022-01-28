using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult AddOrEdit( int id = 0)
        {
            Table user = new Table();

            return View(user);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Table user)
        {
            using (DBModels db = new DBModels())
            {
                if (db.Tables.Any(x => x.UserName == user.UserName))
                {
                    ViewBag.DuplicateMessage = "User Name Already Exists.";
                    return View("AddOrEdit", user);

                        }
                else
                {
                    db.Tables.Add(user);
                    db.SaveChanges();
                }
                
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
                return View("AddOrEdit",new Table());

        }
    }
}