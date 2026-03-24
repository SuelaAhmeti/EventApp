using Models;
using Data;

namespace Services
{
    public class TicketService
    {
        public void BuyTicket(Ticket ticket)
        {
            AppDb.Tickets.Add(ticket);
        }
    }
}
