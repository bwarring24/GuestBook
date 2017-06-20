using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using WcfService.Contracts;

namespace WcfService.Repositories
{
    public class TicketRepository
    {
        private readonly GuestBookEntities _guestBookEntities;

        public TicketRepository(GuestBookEntities guestBookEntities)
        {
            _guestBookEntities = guestBookEntities;
        }

        public List<TicketContract> GetAllHousekeeping()
        {
            List<TicketContract> tickets = new List<TicketContract>();

            foreach(Ticket ticket in _guestBookEntities.Set<Ticket>().Where(x => x.TicketType.ticket_type == "Housekeeping").ToList())
            {
                TicketContract ticketContract = new TicketContract()
                {
                    ticket_number = ticket.ticket_number,
                    opened_by = ticket.opened_by,
                    assigned_to = ticket.assigned_to,
                    closed_by = ticket.closed_by,
                    title = ticket.title,
                    description = ticket.description,
                    date_opened = ticket.date_opened,
                    date_closed = ticket.date_closed,
                    priority = ticket.priority,
                    completed = ticket.completed
                };

                tickets.Add(ticketContract);
            }

            return tickets;
        }


        public List<TicketContract> GetAllMaintenance()
        {
            List<TicketContract> tickets = new List<TicketContract>();

            foreach (Ticket ticket in _guestBookEntities.Set<Ticket>().Where(x => x.TicketType.ticket_type == "Maintenance").ToList())
            {
                TicketContract ticketContract = new TicketContract()
                {
                    ticket_number = ticket.ticket_number,
                    opened_by = ticket.opened_by,
                    assigned_to = ticket.assigned_to,
                    closed_by = ticket.closed_by,
                    title = ticket.title,
                    description = ticket.description,
                    date_opened = ticket.date_opened,
                    date_closed = ticket.date_closed,
                    priority = ticket.priority,
                    completed = ticket.completed
                };

                tickets.Add(ticketContract);
            }

            return tickets;
        }

        public List<TicketContract> GetUserHousekeeping(string idStr)
        {
            int id;
            int.TryParse(idStr, out id);

            List<TicketContract> tickets = new List<TicketContract>();

            foreach (Ticket ticket in _guestBookEntities.Set<Ticket>().Where(x => x.TicketType.ticket_type == "Housekeeping" && x.opened_by == id).ToList())
            {
                TicketContract ticketContract = new TicketContract()
                {
                    ticket_number = ticket.ticket_number,
                    room_number = ticket.Rooms.ToList(),
                    opened_by = ticket.opened_by,
                    assigned_to = ticket.assigned_to,
                    closed_by = ticket.closed_by,
                    title = ticket.title,
                    description = ticket.description,
                    date_opened = ticket.date_opened,
                    date_closed = ticket.date_closed,
                    priority = ticket.priority,
                    completed = ticket.completed
                };

                tickets.Add(ticketContract);
            }

            return tickets;
        }


        public List<TicketContract> GetUserMaintenance(string idStr)
        {
            int id;
            int.TryParse(idStr, out id);

            List<TicketContract> tickets = new List<TicketContract>();

            foreach (Ticket ticket in _guestBookEntities.Set<Ticket>().Where(x => x.TicketType.ticket_type == "Maintenance" && x.opened_by == id).ToList())
            {
                TicketContract ticketContract = new TicketContract()
                {
                    ticket_number = ticket.ticket_number,
                    room_number = ticket.Rooms.ToList(),
                    opened_by = ticket.opened_by,
                    assigned_to = ticket.assigned_to,
                    closed_by = ticket.closed_by,
                    title = ticket.title,
                    description = ticket.description,
                    date_opened = ticket.date_opened,
                    date_closed = ticket.date_closed,
                    priority = ticket.priority,
                    completed = ticket.completed
                };

                tickets.Add(ticketContract);
            }

            return tickets;
        }


        public void Create(TicketContract userTicket)
        {
            var ticket = _guestBookEntities.Tickets.Create();

            ticket.ticket_type = userTicket.ticket_type;
            ticket.Rooms = ticket.Rooms;
            ticket.opened_by = userTicket.opened_by;
            ticket.title = userTicket.title;
            ticket.description = userTicket.description;
            ticket.date_opened = userTicket.date_opened;
            ticket.completed = false;

            _guestBookEntities.Entry(ticket).State = EntityState.Added;
            _guestBookEntities.SaveChanges();

            throw new WebFaultException(HttpStatusCode.Created);
        }

        public void Delete(string ticketNumberStr)
        {
            int ticketNumber;
            int.TryParse(ticketNumberStr, out ticketNumber);

            var ticket = _guestBookEntities.Tickets.FirstOrDefault(x => x.ticket_number == ticketNumber);

            _guestBookEntities.Entry(ticket).State = EntityState.Deleted;
            _guestBookEntities.SaveChanges();

            throw new WebFaultException(HttpStatusCode.Accepted);
        }

        private int GetTicketRoom(int ticketNumber)
        {
            return 0;
        }

        private void CreateTicketRoom(int ticketNumber)
        {
            
        }
    }
}