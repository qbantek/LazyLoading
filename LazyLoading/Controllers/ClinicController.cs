using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LazyLoading.Models;

namespace LazyLoading.Controllers
{
    public class ClinicController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClinicController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ClinicController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View(_db.Clinics.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = _db.Clinics.Find(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClinicId,Name")] Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                _db.Clinics.Add(clinic);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clinic);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = _db.Clinics.Find(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClinicId,Name")] Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(clinic).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clinic);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = _db.Clinics.Find(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clinic clinic = _db.Clinics.Find(id);
            _db.Clinics.Remove(clinic);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}