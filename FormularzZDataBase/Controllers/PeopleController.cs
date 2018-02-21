using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FormularzZDataBase.BusinessLogic;
using FormularzZDataBase.Models;
using FormularzZDataBase.Repository;

namespace FormularzZDataBase.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleRepository _peopleRepository;

        public PeopleController()
        {
            _peopleRepository = new PeopleRepository();
        }

        // GET: People
        public ActionResult Index()
        {
            return View(_peopleRepository.GetWhere(x => x.Id > 0));
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People man = _peopleRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (man == null)
            {
                return HttpNotFound();
            }
            return View(man);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PostCode,City,Street,BuildingNr")] People man)
        {
            var validator = new PeopleValidator();
            var result = validator.Validate(man);
            if (result.IsValid)
            {
                _peopleRepository.Create(man);

                return RedirectToAction("Index");
            }

            ModelState.Clear();
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.ErrorMessage);
            }

            return View(man);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People man = _peopleRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (man == null)
            {
                return HttpNotFound();
            }
            return View(man);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PostCode,City,Street,BuildingNr")] People man)
        {
            if (ModelState.IsValid)
            {
                _peopleRepository.Update(man);

                return RedirectToAction("Index");
            }
            return View(man);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People man = _peopleRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (man == null)
            {
                return HttpNotFound();
            }
            return View(man);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            People man = _peopleRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _peopleRepository.Delete(man);
            return RedirectToAction("Index");
        }
    }
}
