using FinancieraAcme.PrestaFacil.Domain.Entities;
using FinancieraAcme.PrestaFacil.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancieraAcme.PrestaFacil.UI.Web.Controllers
{
    public class LoanApplicationSPsController : Controller
    {
        private readonly ILoanApplication _repo;
        //.net core will pass repo internally
        public LoanApplicationSPsController(ILoanApplication repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<LoanApplication> solicitudes = _repo.TraerTodos().ToList();
            //ViewData["Lista"] = solicitudes;
            return View(solicitudes);
        }
        public IActionResult Details(int id)
        {
            LoanApplication loan = _repo.TraerPorId(id);
            if (loan == null)
            {
                return NotFound();//returns 404 by default
            }
            return View(loan);
        }
        public IActionResult Edit(int id)
        {
            LoanApplication loan = _repo.TraerPorId(id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LoanApplication loan)
        {
            if (ModelState.IsValid == false)
            {
                return View(loan);
            }
            try
            {
                await _repo.EditarSPAsync(loan);
            }
            catch (Exception)
            {
                if (_repo.TraerPorId(loan.Id) == null)
                    return NotFound();
                else
                    throw;
            }
            //otra option
            //ViewData["Mensaje"]="sasa";
            //return View(loan)
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LoanApplication loan)
        {
            if(ModelState.IsValid==false)
            {
                return View();
            }
            await _repo.AgregarSPAsync(loan);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            LoanApplication loan = _repo.TraerPorId(id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteLoanApplication(int id)
        {

            await _repo.EliminarSPAsync(id);            
            return RedirectToAction("Index");
        }
    }
}
