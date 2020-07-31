using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using votingmanagementsystem.Models;
using votingmanagementsystem.Repository;

namespace votingmanagementsystem.Controllers
{
    public class CitizenController : Controller
    {

        // GET: Employee/GetAllEmpDetails

        public ActionResult GetCitizen()
        {

            Citizenrepo EmpRepo = new Citizenrepo();
            ModelState.Clear();
            return View(EmpRepo.GetCitizen());
        }


        // GET: Employee/AddEmployee
        public ActionResult AddCitizen()
        {
            return View();
        }

        // POST: Employee/AddEmployee
        [HttpPost]
        public ActionResult AddCitizen(Citizenmodel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Citizenrepo EmpRepo = new Citizenrepo();

                    if (EmpRepo.AddCitizen(Emp))
                    {
                        ViewBag.Message = "Citizen details added successfully";
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
        public ActionResult EditCitizen(int id)
        {
            Citizenrepo EmpRepo = new Citizenrepo();



            return View(EmpRepo.GetCitizen().Find(Ele => Ele.citizen_id == id));

        }
        // POST: Employee/EditEmpDetails/5
        [HttpPost]
        public ActionResult EditCitizen(int id, Citizenmodel obj)
        {
            try
            {
                Citizenrepo EmpRepo = new Citizenrepo();

                EmpRepo.UpdateCitizen(obj);
                return RedirectToAction("GetCitizen");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/DeleteEmp/5
        public ActionResult DeleteCitizen(int id)
        {
            try
            {
                Citizenrepo EmpRepo = new Citizenrepo();
                if (EmpRepo.DeleteCitizen(id))
                {
                    ViewBag.AlertMsg = "Citizen details deleted successfully";

                }
                return RedirectToAction("GetCitizen");

            }
            catch
            {
                return View();
            }
        }
	}
}