using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using votingmanagementsystem.Models;
using votingmanagementsystem.Repository;

namespace votingmanagementsystem.Controllers
{
    public class ConstituencyController : Controller
    {
        // GET: Employee/GetAllEmpDetails

        public ActionResult GetConstituency()
        {

            Constituencyrepo EmpRepo = new Constituencyrepo();
            ModelState.Clear();
            return View(EmpRepo.GetConstituency());
        }


        // GET: Employee/AddEmployee
        public ActionResult AddConstituency()
        {
            return View();
        }

        // POST: Employee/AddEmployee
        [HttpPost]
        public ActionResult AddConstituency(Constituencymodel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Constituencyrepo EmpRepo = new Constituencyrepo();

                    if (EmpRepo.AddConstituency(Emp))
                    {
                        ViewBag.Message = "Constituency details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/EditEmpDetails/5
        public ActionResult EditConstituency(int id)
        {
            Constituencyrepo EmpRepo = new Constituencyrepo();


            return View(EmpRepo.GetConstituency().Find(Emp => Emp.constituent_id == id));

        }
        // POST: Employee/EditEmpDetails/5
        [HttpPost]
        public ActionResult EditConstituency(int id, Constituencymodel obj)
        {
            try
            {
                Constituencyrepo EmpRepo = new Constituencyrepo();

                EmpRepo.UpdateConstituency(obj);
                return RedirectToAction("GetConstituency");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/DeleteEmp/5
        public ActionResult DeleteConstituency(int id)
        {
            try
            {
                Constituencyrepo EmpRepo = new Constituencyrepo();
                if (EmpRepo.DeleteConstituency(id))
                {
                    ViewBag.AlertMsg = "Constituency details deleted successfully";

                }
                return RedirectToAction("GetConstituency");

            }
            catch
            {
                return View();
            }
        }
	}
}