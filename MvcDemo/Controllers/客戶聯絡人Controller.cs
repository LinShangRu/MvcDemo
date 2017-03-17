using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class 客戶聯絡人Controller : Controller
    {
        private 客戶資料Entities db_old = new 客戶資料Entities();
        private 客戶聯絡人Repository db = RepositoryHelper.Get客戶聯絡人Repository();

        // GET: 客戶聯絡人
        //public ActionResult Index()
        //{
        //    //var 客戶聯絡人 = db.客戶聯絡人.Include(客 => 客.客戶資料);
        //    var 客戶聯絡人 = db.All().Include(客 => 客.客戶資料);
        //    return View(客戶聯絡人.ToList());
        //}

        public ActionResult Index(string SortBy, string Keyword)
        {
            var MyResult = db.All().AsQueryable();
            if (!String.IsNullOrEmpty(Keyword))
            { MyResult = MyResult.Where(
                m => m.姓名.Contains(Keyword) ||
                m.職稱.Contains(Keyword) ||
                m.Email.Contains(Keyword) ||
                m.電話.Contains(Keyword) ||
                m.手機.Contains(Keyword) ||
                m.客戶資料.客戶名稱.Contains(Keyword)
                ); }
            if (String.IsNullOrEmpty(SortBy))
                SortBy = "+Price";
            if (SortBy.Equals("+Price"))
                MyResult = MyResult.OrderBy(m => m.姓名);
            else if (SortBy.Equals("-Price"))
            {
                MyResult = MyResult.OrderByDescending(m => m.姓名);
            }
            ViewBag.Keyword = Keyword;
            return View(MyResult.Take(10));
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = db.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(db_old.客戶資料, "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        public ActionResult Create(客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                //db.客戶聯絡人.Add(客戶聯絡人);
                //db.SaveChanges();


                //方法一
                //if (db.檢查同一個客戶下的聯絡人電子郵件不可重複(客戶聯絡人.客戶Id, 客戶聯絡人.Email))
                //{
                //    db.Add(客戶聯絡人);
                //    db.UnitOfWork.Commit();
                //    return RedirectToAction("Index");
                //}
            }

            ViewBag.客戶Id = new SelectList(db_old.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(db_old.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                db_old.Entry(客戶聯絡人).State = EntityState.Modified;
                //db.SaveChanges();
                db.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(db_old.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = db.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = db.Find(id);
            db.Delete(客戶聯絡人);
            db.UnitOfWork.Commit();
            //db.客戶聯絡人.Remove(客戶聯絡人);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
