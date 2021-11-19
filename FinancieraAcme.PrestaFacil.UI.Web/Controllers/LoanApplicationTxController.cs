using FinancieraAcme.PrestaFacil.Domain.Entities;
using FinancieraAcme.PrestaFacil.Domain.Interfaces;
using FinancieraAcme.PrestaFacil.UI.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancieraAcme.PrestaFacil.UI.Web.Extensions;

using FinancieraAcme.PrestaFacil.Domain;


namespace FinancieraAcme.PrestaFacil.UI.Web.Controllers
{
    public class LoanApplicationTxController : Controller
    {
        private readonly ILoanApplicationParentRepository _repoMain;
        private readonly IClient _repoClient;
        private readonly IUnitOfWork _ouw;
        //.net core will pass repo internally
        public LoanApplicationTxController(ILoanApplicationParentRepository repoMain,IClient repoClient, IUnitOfWork ouw)
        {
            _repoMain = repoMain;
            _repoClient = repoClient;
            _ouw = ouw;
        }
        public IActionResult EnterApplication()
        {
            LoanApplicationParentViewModel vm = new LoanApplicationParentViewModel(_repoClient.TraerTodos().ToList());
            //vm.Clientes = new List<SelectListItem>(_repoClient.TraerTodos().) 
            //List<LoanApplicationMain> solicitudes = _repoMain.TraerTodos().ToList();
            //ViewData["Lista"] = solicitudes;
            return View(vm);
        }
        [HttpPost]
        public  IActionResult EnterApplication(LoanApplicationParentViewModel vm)
        {

            //will save in a session
            //HttpContext.Session.Set("LoanApplicationMain", vm.LoanApplicationMain)
            HttpContext.Session.Set<LoanApplicationParent>("LoanApplicationParent", vm.LoanApplicationParent);
            var la = HttpContext.Session.Get<LoanApplicationParent>("LoanApplicationParent");

            //Start Deatils List
            HttpContext.Session.Set<List<LoanApplicationChild>>("ListLoanApplicationChild", new List<LoanApplicationChild>());
            ViewBag.Detalles = HttpContext.Session.Get<List<LoanApplicationChild>>("ListLoanApplicationChild");

            //Fill to the next view to fill in Details
            var cliente = _repoClient.TraerPorId(la.ClientId);
            //ViewBag.Client = $"{cliente.Apellidos},{cliente.Nombres} (Id: {cliente.Id})";  //dynamic , all es defined when it is programed
            ViewBag.Client = cliente;
            ViewBag.Date = la.FechaSolicitud.ToLongDateString();

            return View("EnterApplicationDetail");
        }
        [HttpPost]
        public IActionResult EnterApplicationDetail(LoanApplicationChild appDetail)
        {
            List<LoanApplicationChild> details = HttpContext.Session.Get<List<LoanApplicationChild>>("ListLoanApplicationChild");

            details.Add(appDetail);
            HttpContext.Session.Set<List<LoanApplicationChild>>("ListLoanApplicationChild", details);
            ViewBag.Detalles = HttpContext.Session.Get<List<LoanApplicationChild>>("ListLoanApplicationChild");

            var la = HttpContext.Session.Get<LoanApplicationParent>("LoanApplicationParent");
            var cliente = _repoClient.TraerPorId(la.ClientId);
            ViewBag.Client = cliente;
            ViewBag.Date = la.FechaSolicitud.ToLongDateString();
            ModelState.Clear();
            return View();
        }
        public async Task<IActionResult> SaveApplicationDetails()
        {
            LoanApplicationParent main = HttpContext.Session.Get<LoanApplicationParent>("LoanApplicationParent");
            List<LoanApplicationChild> details = HttpContext.Session.Get<List<LoanApplicationChild>>("ListLoanApplicationChild");
;
            
            _ouw.LoanApplicationParentRepository.Agregar(main);
            foreach (var detail in details)
            {
                _ouw.LoanApplicationChildRepository.Agregar(detail);

            }
            await _ouw.GuardarAsync();
            ViewBag.Mensaje = "Saved";
            return View();
        }
    }
}
