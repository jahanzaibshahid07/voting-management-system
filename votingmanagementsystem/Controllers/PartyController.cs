using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using votingmanagementsystem.Models;
using votingmanagementsystem.Repository;

namespace votingmanagementsystem.Controllers
{
    public class PartyController : Controller
    {
        // GET: Employee/GetAllEmpDetails

        public ActionResult GetParty()
        {

            Partyrepo EmpRepo = new Partyrepo();
            ModelState.Clear();
            return View(EmpRepo.GetParty());
        }


        // GET: Employee/AddEmployee
        public ActionResult AddParty()
        {
            return View();
        }

        // POST: Employee/AddEmployee
        [HttpPost]
        public ActionResult AddParty(Partymodel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Partyrepo EmpRepo = new Partyrepo();

                    if (EmpRepo.AddParty(Emp))
                    {
                        ViewBag.Message = "Party details added successfully";
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
        public ActionResult EditParty(int id)
        {
            Partyrepo EmpRepo = new Partyrepo();



            return View(EmpRepo.GetParty().Find(Emp => Emp.party_id == id));

        }
        // POST: Employee/EditEmpDetails/5
        [HttpPost]
        public ActionResult EditParty(int id, Partymodel obj)
        {
            try
            {
                Partyrepo EmpRepo = new Partyrepo();

                EmpRepo.UpdateParty(obj);
                return RedirectToAction("GetParty");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/DeleteEmp/5
        public ActionResult DeleteParty(int id)
        {
            try
            {
                Partyrepo EmpRepo = new Partyrepo();
                if (EmpRepo.DeleteParty(id))
                {
                    ViewBag.AlertMsg = "Party details deleted successfully";

                }
                return RedirectToAction("GetParty");

            }
            catch
            {
                return View();
            }
        }
	}
}