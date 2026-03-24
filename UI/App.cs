using System;
using Services;
using Models;

namespace UI
{
    public class App
    {
        UserService userService = new UserService();
        EventService eventService = new EventService();

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
    EventMenu(); // 🔴 KJO DUHET ME EKZISTU PATJETËR
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
                }
            }
        }

        void ViewEvents()
        {
            var events = eventService.GetByCategory(1);

            if (events.Count == 0)
        {
           Console.WriteLine("No events found.");
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
    }
}