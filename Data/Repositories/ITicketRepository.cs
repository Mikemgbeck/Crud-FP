using Crud_FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.Data.Repositories
{
    public interface ITicketRepository
    {
        Task<List<Flowpoint_Support_Ticket>> GetAllTickets(string searchText);
        Task<List<Flowpoint_Support_Ticket>> GetTicketByID(int ticketID);
        Flowpoint_Support_Ticket GetTicket(int ticketID);
        Task AddTicket(Flowpoint_Support_Ticket newVTicket);
        void UpdateTicket(Flowpoint_Support_Ticket editedTicket);
        void DeleteTicket(int ticketID);
    }
}
