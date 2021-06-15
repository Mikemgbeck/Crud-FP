using Crud_FP.Data;
using Crud_FP.Data.Repositories;
using Crud_FP.Models;
using Crud_FP.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
    }
}
