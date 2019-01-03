using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_ef6_example.Models;

namespace mvc_ef6_example.Controllers
{
    public class homeController : Controller
    {
        mydbcontext db = new mydbcontext();
       public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(loginviewmodel model)
        {
            if(ModelState.IsValid)
            {
                /*  var count = (from c in db.customers where c.customerid == model.loginid && c.customerpassword == model.password select c).Count();*/

                var count = db.customers.Count(c => c.customerid == model.loginid && c.customerpassword == model.password);
                if(count>0)
                {
                    Session["loginid"] = model.loginid;
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ViewBag.msg = "invalid id or password";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult addcustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addcustomer(customermodel model)
        {
            db.customers.Add(model);
            db.SaveChanges();
            ViewBag.msg = "customer added :  " + model.customerid;
            return View();
        }

        public ActionResult search()
        {
            List<customermodel> list = new List<customermodel>();
            return View(list);
        }
        [HttpPost]
        public ActionResult search(string key)
        {
            /* var data=from c in db.customers where c.customerid.ToString().Contains(key)
                      ||c.customername.Contains(key)
                      ||c.customeremailid.Contains(key)
                      select c).ToList();*/
            var data = db.customers.Where(c => c.customerid.ToString().Contains(key)
             || c.customername.Contains(key)
             || c.customeremailid.Contains(key)).ToString();
            return View();
        }

        public ActionResult find(int id)
        {
            /* var model = (from c in db.customers where c.customerid == id select c).FirstOrDefault();*/
            var model = db.customers.FirstOrDefault(c => c.customerid == id);
            return View();
        }
        public ActionResult delete(int id)
        {
            /*var model = (from c in db.customers where c.customerid == id select c).FirstOrDefault();*/
            var model = db.customers.FirstOrDefault(c => c.customerid == id);
            db.customers.Remove(model);
            db.SaveChanges();
            return View("v_customerdeleted");
        }

        public ActionResult edit(int id)
        {
            /* var model = (from c in db.customers where c.customerid == id select c).FirstOrDefault();*/
            var model = db.customers.FirstOrDefault(c => c.customerid == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult edit(customermodel model)
        {
            /*var dbmodel = (from c in db.customers
                           where c.customerid == model.customerid
                           select c).FirstOrDefault();*/
            var dbmodel = db.customers.FirstOrDefault(c => c.customerid == model.customerid);
            dbmodel.customercity = model.customercity;
            dbmodel.customeremailid = model.customeremailid;
            db.SaveChanges();
            return View("v_update");
        }
    }
}