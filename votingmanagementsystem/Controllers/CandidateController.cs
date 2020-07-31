using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using votingmanagementsystem.Models;
using votingmanagementsystem.Repository;

namespace votingmanagementsystem.Controllers
{
    public class CandidateController : Controller
    {
        // GET: Employee/GetAllEmpDetails

        public ActionResult GetCandidate()
        {

            Candidaterepo EmpRepo = new Candidaterepo();
            ModelState.Clear();
            return View(EmpRepo.GetCandidate());
        }


        // GET: Employee/AddEmployee
        public ActionResult AddCandidate()
        {
            return View();
        }

        // POST: Employee/AddEmployee
        [HttpPost]
        public ActionResult AddCandidate(Candidatemodel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Candidaterepo EmpRepo = new Candidaterepo();

                    if (EmpRepo.AddCandidate(Emp))
                    {
                        ViewBag.Message = "Candidate details added successfully";
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
        public ActionResult EditCandidate(int id)
        {
            Candidaterepo EmpRepo = new Candidaterepo();


            return View(EmpRepo.GetCandidate().Find(Emp => Emp.candidate_id == id));

        }
        // POST: Employee/EditEmpDetails/5
        [HttpPost]
        public ActionResult EditCandidate(int id, Candidatemodel obj)
        {
            try
            {
                Candidaterepo EmpRepo = new Candidaterepo();

                EmpRepo.UpdateCandidate(obj);
                return RedirectToAction("GetCandidate");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/DeleteEmp/5
        public ActionResult DeleteCandidate(int id)
        {
            try
            {
                Candidaterepo EmpRepo = new Candidaterepo();
                if (EmpRepo.DeleteCandidate(id))
                {
                    ViewBag.AlertMsg = "Candidate details deleted successfully";

                }
                return RedirectToAction("GetCandidate");

            }
            catch
            {
                return View();
            }
        }
	}
}