using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task.Models;

namespace Task.Controllers
{

    public class LoginController : Controller
    {
        private Model1 db = new Model1();

        // GET: Login
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
                var tasks = db.tasks.Include(t => t.sub_task).Include(t => t.user);
                return View(tasks.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        

       
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {


                var data = db.users.Where(s => s.username.Equals(username) && s.password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["username"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["email"] = data.FirstOrDefault().email;
                    Session["id"] = data.FirstOrDefault().id;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        public ActionResult Details(int? id)
        {
            if (Session["id"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                task task = db.tasks.Find(id);
                if (task == null)
                {
                    return HttpNotFound();
                }
                return View(task);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Create()
        {
            if (Session["id"] != null)
            {
                ViewBag.task_sub = new SelectList(db.sub_task, "id", "title");
                ViewBag.sub = new SelectList(db.users, "id", "username");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            }

        // POST: tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,start_date,actual_cost,total_budget,budget_variance,end_date,imagepath,task_sub,sub")] task task)
        {
            if (Session["id"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.tasks.Add(task);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.task_sub = new SelectList(db.sub_task, "id", "title", task.task_sub);
                ViewBag.sub = new SelectList(db.users, "id", "username", task.sub);
                return View(task);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["id"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                task task = db.tasks.Find(id);
                if (task == null)
                {
                    return HttpNotFound();
                }
                ViewBag.task_sub = new SelectList(db.sub_task, "id", "title", task.task_sub);
                ViewBag.sub = new SelectList(db.users, "id", "username", task.sub);
                return View(task);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // POST: tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,start_date,actual_cost,total_budget,budget_variance,end_date,imagepath,task_sub,sub")] task task)
        {
            if (Session["id"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(task).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.task_sub = new SelectList(db.sub_task, "id", "title", task.task_sub);
                ViewBag.sub = new SelectList(db.users, "id", "username", task.sub);
                return View(task);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["id"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                task task = db.tasks.Find(id);
                if (task == null)
                {
                    return HttpNotFound();
                }
                return View(task);
            }
            else
            {
                return RedirectToAction("Login");
            }
            }

        // POST: tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)

        {
            if (Session["id"] != null)
            {
                task task = db.tasks.Find(id);
                db.tasks.Remove(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
      


    