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
    public class sub_taskController : Controller
    {
        private Model1 db = new Model1();

        // GET: sub_task
        public ActionResult Index()
        {
            return View(db.sub_task.ToList());
        }

        // GET: sub_task/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sub_task sub_task = db.sub_task.Find(id);
            if (sub_task == null)
            {
                return HttpNotFound();
            }
            return View(sub_task);
        }

        // GET: sub_task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sub_task/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,imagepath,start_date,actual_cost,total_budget,budget_variance,end_date")] sub_task sub_task)
        {
            if (ModelState.IsValid)
            {
                db.sub_task.Add(sub_task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sub_task);
        }

        // GET: sub_task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sub_task sub_task = db.sub_task.Find(id);
            if (sub_task == null)
            {
                return HttpNotFound();
            }
            return View(sub_task);
        }

        // POST: sub_task/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,imagepath,start_date,actual_cost,total_budget,budget_variance,end_date")] sub_task sub_task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sub_task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sub_task);
        }

        // GET: sub_task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sub_task sub_task = db.sub_task.Find(id);
            if (sub_task == null)
            {
                return HttpNotFound();
            }
            return View(sub_task);
        }

        // POST: sub_task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sub_task sub_task = db.sub_task.Find(id);
            db.sub_task.Remove(sub_task);
            db.SaveChanges();
            return RedirectToAction("Index");
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
