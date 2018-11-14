using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using chatapp.Models;

namespace chatapp.Controllers
{
    public class GroupInfosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /GroupInfos/
        public ActionResult Index()
        {
            return View(db.GroupInfos.ToList());
        }

        // GET: /GroupInfos/Details/5
         [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupInfo groupinfo = db.GroupInfos.Find(id);
            if (groupinfo == null)
            {
                return HttpNotFound();
            }
            return View(groupinfo);
        }

        // GET: /GroupInfos/Create
         [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GroupInfos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include="Id,GroupName")] GroupInfo groupinfo)
        {
            if (ModelState.IsValid)
            {
                db.GroupInfos.Add(groupinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupinfo);
        }

        // GET: /GroupInfos/Edit/5
         [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupInfo groupinfo = db.GroupInfos.Find(id);
            if (groupinfo == null)
            {
                return HttpNotFound();
            }
            return View(groupinfo);
        }

        // POST: /GroupInfos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include="Id,GroupName")] GroupInfo groupinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupinfo);
        }

        // GET: /GroupInfos/Delete/5
         [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupInfo groupinfo = db.GroupInfos.Find(id);
            if (groupinfo == null)
            {
                return HttpNotFound();
            }
            return View(groupinfo);
        }

        // POST: /GroupInfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupInfo groupinfo = db.GroupInfos.Find(id);
            db.GroupInfos.Remove(groupinfo);
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
