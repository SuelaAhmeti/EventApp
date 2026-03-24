# Architecture - Event Management System

## Layers

### Models
Përfaqësojnë të dhënat e sistemit:
- User
- Event
- Category
- Ticket

---

### Services
Përmbajnë logjikën e biznesit:
- UserService
- EventService
- TicketService

---

### Data (Repository Layer)
Menaxhon ruajtjen e të dhënave në file:
- IRepository<T>
- FileRepository

---

### UI
Ndërfaqja e përdoruesit (Console):
- Menutë
- Input/Output

---

## Design Decisions

- Përdorëm Repository Pattern për ndarje të pastër të logjikës
- CSV file për ruajtje të thjeshtë
- Layered Architecture për mirëmbajtje më të lehtë

---

## SOLID (Bonus)

- S: Çdo klasë ka vetëm një përgjegjësi
- D: Services përdorin interface (IRepository)
