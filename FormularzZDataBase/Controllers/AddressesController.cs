using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FormularzZDataBase.BusinessLogic;
using FormularzZDataBase.Interfaces;
using FormularzZDataBase.Models;
using FormularzZDataBase.Repository;

namespace FormularzZDataBase.Controllers
{
    public class AddressesController : Controller
    {

        private readonly IAddressRepository _addressRepository;
        

        public AddressesController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            
        }

        // GET: Addresses
        public ActionResult Index()
        {
            return View(_addressRepository.GetWhere(x=>x.Id>0));
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = _addressRepository.GetWhere(x=>x.Id == id).FirstOrDefault();
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PostCode,City,Street,BuildingNr")] Address address)
        {
            var validator = new AddressValidator();
            var result = validator.Validate(address);
            if (result.IsValid)
            {
                _addressRepository.Create(address);
                
                return RedirectToAction("Index");
            }

            ModelState.Clear();
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.ErrorMessage);
            }

            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = _addressRepository.GetWhere(x=>x.Id== id).FirstOrDefault();
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PostCode,City,Street,BuildingNr")] Address address)
        {
            if (ModelState.IsValid)
            {
                _addressRepository.Update(address);
               
                return RedirectToAction("Index");
            }
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = _addressRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = _addressRepository.GetWhere(x => x.Id == id).FirstOrDefault();
           _addressRepository.Delete(address);
            return RedirectToAction("Index");
        }

    }
}
