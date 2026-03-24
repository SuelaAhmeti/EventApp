# UML Class Diagram – Event Management System

## Classes

### User
- Id: int
- Name: string
- Email: string
- Password: string
- Role: string

---

### Event
- Id: int
- Title: string
- Date: DateTime
- Price: double
- CategoryId: int
- OrganizerId: int

---

### Category
- Id: int
- Name: string

---

### Ticket
- Id: int
- EventId: int
- UserId: int
- Quantity: int

---

## Services

### UserService
- Register(User user)
- Login(string email, string password)

### EventService
- CreateEvent(Event ev)
- GetByCategory(int categoryId)

### TicketService
- BuyTicket(Ticket ticket)

---

## Data Layer

### AppDb
- Users
- Events
- Categories
- Tickets

---

## Relationships

- User 1 --- * Ticket
- Event 1 --- * Ticket
- Category 1 --- * Event
- User (Organizer) 1 --- * Event

- UI → Services
- Services → Data/Models
