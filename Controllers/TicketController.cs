using Crud_FP.Data;
using Crud_FP.Data.Repositories;
using Crud_FP.Models;
using Crud_FP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketRepository _ticketRepository;

        private readonly ApplicationDBContext _db;

        public TicketController(ITicketRepository ticketRepository, ApplicationDBContext db)
        {
            _ticketRepository = ticketRepository;
            _db = db;
        }
        public async Task<IActionResult> Index(string searchText, int searchID)
        {
            ViewData["searchText"] = searchText;
            ViewData["searchID"] = searchID;

            List<Flowpoint_Support_Ticket> tickets = null;
            List<Flowpoint_Support_Ticket> ticket = null;

            if (searchID != 0)
            {
                ticket = await _ticketRepository.GetTicketByID(searchID);
                TicketIndexViewModel model = new TicketIndexViewModel()
                {
                    Tickets = ticket,
                };

                return View(model);
            }
            else
            {
                tickets = await _ticketRepository.GetAllTickets(searchText);

                TicketIndexViewModel model = new TicketIndexViewModel()
                {
                    Tickets = tickets

                };

                return View(model);
            }


        }
        public IActionResult Create()
        {
            TicketDetailViewModel viewModel = new TicketDetailViewModel()
            {
                VendorDropDown = _db.Flowpoint_Support_Vendors.Select(i => new SelectListItem
                {
                    Text = i.VVendorName,
                    Value = i.ICompanyID.ToString()
                })
            };

            return View(viewModel);
        }

        // POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TicketDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                Flowpoint_Support_Ticket createTicket = new Flowpoint_Support_Ticket()
                {
                    ITicketID = model.ITicketID,
                    VTicketMessage = model.VTicketMessage,
                    DtCreatedDate = model.DtCreatedDate,
                    DtModifiedDate = model.DtModifiedDate,
                    ICreatedBy = model.ICreatedBy,
                    IModifiedBy = model.IModifiedBy,
                    BlsActive = model.BlsActive,
                    IVendorID = model.IVendorID
                };

                _ticketRepository.AddTicket(createTicket);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            Flowpoint_Support_Ticket ticket = _ticketRepository.GetTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }

            TicketDetailViewModel viewmodel = new TicketDetailViewModel()
            {
                ITicketID = ticket.ITicketID,
                VTicketMessage = ticket.VTicketMessage,
                DtCreatedDate = ticket.DtCreatedDate,
                DtModifiedDate = ticket.DtModifiedDate,
                ICreatedBy = ticket.ICreatedBy,
                IModifiedBy = ticket.IModifiedBy,
                BlsActive = ticket.BlsActive,
                IVendorID = ticket.IVendorID
            };
            return View(viewmodel);

        }

        //Post Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            _ticketRepository.DeleteTicket(id);
            return RedirectToAction("Index");
        }

        // get update
        public IActionResult Update(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            Flowpoint_Support_Ticket ticket = _ticketRepository.GetTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }

            TicketDetailViewModel viewmodel = new TicketDetailViewModel()
            {
                ITicketID = ticket.ITicketID,
                VTicketMessage = ticket.VTicketMessage,
                DtCreatedDate = ticket.DtCreatedDate,
                DtModifiedDate = ticket.DtModifiedDate,
                ICreatedBy = ticket.ICreatedBy,
                IModifiedBy = ticket.IModifiedBy,
                BlsActive = ticket.BlsActive,
                IVendorID = ticket.IVendorID,

                VendorDropDown = _db.Flowpoint_Support_Vendors.Select(i => new SelectListItem
                {
                    Text = i.VVendorName,
                    Value = i.IVendorID.ToString()
                })
            };
            return View(viewmodel);

        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(TicketDetailViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {

                Flowpoint_Support_Ticket ticket = new Flowpoint_Support_Ticket()
                {
                    ITicketID = viewmodel.ITicketID,
                    VTicketMessage = viewmodel.VTicketMessage,
                    DtCreatedDate = viewmodel.DtCreatedDate,
                    DtModifiedDate = viewmodel.DtModifiedDate,
                    ICreatedBy = viewmodel.ICreatedBy,
                    IModifiedBy = viewmodel.IModifiedBy,
                    BlsActive = viewmodel.BlsActive,
                    IVendorID = viewmodel.IVendorID
                };

                _ticketRepository.UpdateTicket(ticket);
                return RedirectToAction("Index");

            }
            return View(viewmodel);

        }
        //get detail
        public IActionResult Detail(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            var ticket = _ticketRepository.GetTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }

            TicketDetailViewModel viewmodel = new TicketDetailViewModel()
            {
                ITicketID = ticket.ITicketID,
                VTicketMessage = ticket.VTicketMessage,
                DtCreatedDate = ticket.DtCreatedDate,
                DtModifiedDate = ticket.DtModifiedDate,
                ICreatedBy = ticket.ICreatedBy,
                IModifiedBy = ticket.IModifiedBy,
                BlsActive = ticket.BlsActive,
                IVendorID = ticket.IVendorID,
            };
            return View(viewmodel);

        }
    }
}
