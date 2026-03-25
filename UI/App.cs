using System;
using Services;
using Models;
using Data;

namespace UI
{
    public class App
    {
        private readonly UserService userService;
        private readonly IRepository<Event> eventRepo;
        private readonly EventService eventService;

        public App()
        {
            userService = new UserService();
            eventRepo = new FileRepository();
            eventService = new EventService(eventRepo);
        }

        public void Run()
        {
            Console.WriteLine("STARTED");
            Console.WriteLine("APP RUNNING...");

            while (true)
            {
                Console.WriteLine("\n=== EVENT SYSTEM ===");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");

                Console.Write("Zgjedh: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        Register();
                        break;

                    case "2":
                        Login();
                        break;

                    case "3":
                        return;
                }
            }
        }

        void Register()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Password: ");
            string password = Console.ReadLine()!;

            userService.Register(new User
            {
                Id = new Random().Next(1, 1000),
                Name = name,
                Email = email,
                Password = password,
                Role = "User"
            });

            Console.WriteLine("Registered successfully!");
        }

        void Login()
        {
            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Password: ");
            string password = Console.ReadLine()!;

            var user = userService.Login(email, password);

            if (user != null)
            {
                Console.WriteLine("Login success!");
                EventMenu();
            }
            else
            {
                Console.WriteLine("Login failed!");
            }
        }

        void EventMenu()
        {
            Console.WriteLine(">>> ENTERED EVENT MENU <<<");

            while (true)
            {
                Console.WriteLine("\n=== EVENTS MENU ===");
                Console.WriteLine("1. View Events");
                Console.WriteLine("2. Create Event");
                Console.WriteLine("3. Logout");
                Console.WriteLine("4. Find Event by ID");

                Console.Write("Zgjedh: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        ViewEvents();
                        break;

                    case "2":
                        CreateEvent();
                        break;

                    case "3":
                        return;

                    case "4":
                       FindEventById();
                       break;
                }
            }

        }

        void ViewEvents()
        {
            var events = eventService.GetByCategory(1);

            if (events == null || events.Count == 0)
            {
                Console.WriteLine("No events found.");
                return;
            }

            foreach (var ev in events)
            {
                Console.WriteLine($"{ev.Id} | {ev.Title} | {ev.Date} | {ev.Price}");
            }
        }

        void CreateEvent()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine()!);

            eventService.CreateEvent(new Event
            {
                Id = new Random().Next(1, 1000),
                Title = title,
                Price = price,
                Date = DateTime.Now,
                CategoryId = 1,
                OrganizerId = 1
            });

            Console.WriteLine("Event created!");
        }
        void FindEventById()
{
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine()!);

            var ev = eventService.GetById(id);

            if (ev == null)
             {
               Console.WriteLine("Event not found.");
               return;
             }

            Console.WriteLine($"{ev.Id} | {ev.Title} | {ev.Date} | {ev.Price}");
        }
    }
}