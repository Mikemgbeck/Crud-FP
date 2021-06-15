using Crud_FP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDBContext _context;
        public TicketRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task AddTicket(Flowpoint_Support_Ticket newVTicket)
        {
            throw new NotImplementedException();
        }

        public void DeleteTicket(int ticketID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Flowpoint_Support_Ticket>> GetAllTickets(string searchText)
        {
            List<Flowpoint_Support_Ticket> tickets = null;

            if (string.IsNullOrEmpty(searchText))
            {
                tickets = await _context.Flowpoint_Support_Tickets.Include(v => v.Flowpoint_Support_Vendor).ToListAsync();
            }
            else
            {
                tickets = await _context.Flowpoint_Support_Tickets
                                    .Where(x => x.Flowpoint_Support_Vendor.VVendorName.ToLower()
                                    .Contains(searchText.ToLower()))
                                    .Include(c => c.Flowpoint_Support_Vendor)
                                    .ToListAsync();
            }

            return tickets;
        }

        public Flowpoint_Support_Ticket GetTicket(int ticketID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Flowpoint_Support_Ticket>> GetTicketByID(int ticketID)
        {
            List<Flowpoint_Support_Ticket> ticket = null;
            ticket = await _context.Flowpoint_Support_Tickets.Where(x => x.ITicketID.Equals(ticketID)).Include(v => v.Flowpoint_Support_Vendor).ToListAsync();

            if (ticket == null)
            {
                throw new Exception("No Ticket found under the provided ID");
            }

            return ticket;
        }

        public void UpdateTicket(Flowpoint_Support_Ticket editedTicket)
        {
            throw new NotImplementedException();
        }
    }
}
