using System.ComponentModel;
using BuildingManager.Enums;
using BuildingManager.Models;
using BuildingManager.Services;
using BuildingManager.Services.SearchHandler;

namespace BuildingManager.Menu
{
    public class MenuHandler
    {
        private BuildingLog log;
        private SearchHandler search;
        private LogStorage storage;
        private ResidentLog residentLog;
        private ApartmentLog apartmentLog;
        public MenuHandler(BuildingLog log, SearchHandler search, LogStorage storage, ResidentLog residentLog, ApartmentLog apartmentLog)
        {
            this.log = log;
            this.search = search;
            this.storage = storage;
            this.residentLog = residentLog;
            this.apartmentLog = apartmentLog;
        }
        public void Start()
        {
            PrintWelcome();
            while (true)
            {
                PrintMainMenu();
                string input = Console.ReadLine();
                Console.Clear();
                if (!HandleChoiceMain(input))
                {
                    break;
                }
            }
        }
        private void PrintWelcome()
        {
            Console.WriteLine("Welcome to our Building Manager Log System!");
            Console.WriteLine("Here you can log entries, show the available entries, search from these entries and save/load them to and from a file.");
        }
        private void PrintMainMenu()
        {
            Console.WriteLine("Main menu: ");
            Console.WriteLine("1. Building Log");
            Console.WriteLine("2. Residents Log");
            Console.WriteLine("3. Apartments Log");
            Console.WriteLine("0. EXIT");
            Console.Write("Please, enter your choice: ");
        }
        private void PrintMenuEntries()
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Log a new entry");
            Console.WriteLine("2. Show all entries");
            Console.WriteLine("3. Search for an entry");
            Console.WriteLine("4. Save log to file");
            Console.WriteLine("5. Load log from file");
            Console.WriteLine("0. GO BACK");
            Console.Write("Please, enter your choice: ");
        }
        private void PrintMenuApartments()
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Show all apartments");
            Console.WriteLine("2. Search for an apartment");
            Console.WriteLine("3. Save log to file");
            Console.WriteLine("4. Load log from file");
            Console.WriteLine("0. GO BACK");
            Console.Write("Please, enter your choice: ");
        }
        private void PrintMenuResidents()
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Add a resident");
            Console.WriteLine("2. Show all residents");
            Console.WriteLine("3. Search for resident");
            Console.WriteLine("4. Save log to file");
            Console.WriteLine("5. Load log from file");
            Console.WriteLine("0. GO BACK");
            Console.Write("Please, enter your choice: ");
        }
        private bool HandleChoiceMain(string input)
        {
            string secondaryInput;
            bool quit = true;
            while (quit)
            {
                switch (input)
                {
                    case "1":
                        PrintMenuEntries();
                        secondaryInput = Console.ReadLine();
                        Console.Clear();
                        
                        if (!HandleChoiceEntry(secondaryInput))
                        {
                            quit = false;
                        }
                        
                        break;
                    case "2":
                        PrintMenuResidents();
                        secondaryInput = Console.ReadLine();
                        Console.Clear();
                        
                        if (!HandleChoiceResidents(secondaryInput))
                        {
                            quit = false;
                        }
                        
                        break;
                    case "3":
                        PrintMenuApartments();
                        secondaryInput = Console.ReadLine();
                        Console.Clear();
                        
                        if (!HandleChoiceApartment(secondaryInput))
                        {
                            quit = false;
                        }
                        
                        break;
                    case "0":
                        Console.WriteLine("Exiting...");
                        return false;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
            return true;
        }
        private bool HandleChoiceEntry(string input)
        {
            switch (input)
            {
                case "1":
                    AddEntry();
                    break;
                case "2":
                    ShowAllEntries();
                    break;
                case "3":
                    SearchEntries();
                    break;
                case "4":
                    storage.SaveLog(log);
                    Console.WriteLine("Log saved.");
                    break;
                case "5":
                    var loadedEntries = storage.LoadEntries();
                    log.LoadFromList(loadedEntries);
                    Console.WriteLine("Log loaded.");
                    break;
                case "0":
                    Console.WriteLine("Going Back...");
                    return false;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
            Console.Clear();
            return true;
        }
        private bool HandleChoiceApartment(string input)
        {
            switch (input)
            {
                case "1":
                    ShowAllApartments();
                    break;
                case "2":
                    SearchApartment();
                    break;
                case "3":
                    storage.SaveApartmentLog(apartmentLog);
                    Console.WriteLine("Log saved.");
                    break;
                case "4":
                    var loadedApartments = storage.LoadApartments();
                    apartmentLog.LoadFromList(loadedApartments);
                    Console.WriteLine("Log loaded.");
                    break;
                case "0":
                    Console.WriteLine("Going Back...");
                    return false;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
            Console.Clear();
            return true;
        }
        private bool HandleChoiceResidents(string input)
        {
            switch (input)
            {
                case "1":
                    AddResident();
                    break;
                case "2":
                    ShowAllResidents();
                    break;
                case "3":
                    SearchResidents();
                    break;
                case "4":
                    storage.SaveLog(log);
                    Console.WriteLine("Log saved.");
                    break;
                case "5":
                    var loadedResidents = storage.LoadResidents();
                    residentLog.LoadFromList(loadedResidents);
                    Console.WriteLine("Log loaded.");
                    break;
                case "0":
                    Console.WriteLine("Going Back...");
                    return false;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
            Console.Clear();
            return true;
        }
        private void AddEntry()
        {
            Console.Write("Enter name of creator of entry: ");
            string addedBy = Console.ReadLine();

            Console.WriteLine("Select type of entry: ");
            Console.WriteLine("1. Maintenance");
            Console.WriteLine("2. Meeting");
            Console.WriteLine("3. Complaint");
            Console.WriteLine("4. Notice");
            string input = Console.ReadLine();
            EntryType entryType = EntryType.Notice;

            switch (input)
            {
                case "1":
                    entryType = EntryType.Maintenance;
                    break;
                case "2":
                    entryType = EntryType.Meeting;
                    break;
                case "3":
                    entryType = EntryType.Complaint;
                    break;
                case "4":
                    entryType = EntryType.Notice;
                    break;
                default:
                    Console.WriteLine("Using default value: Notice");
                    break;
            }

            Console.Write("Please, enter a description for the entry: ");
            string description = Console.ReadLine();
            Console.Clear();

            var entry = new Entry { AddedBy = addedBy, Date = DateTime.Now, Type = entryType, Description = description };
            log.AddEntry(entry);
            Console.WriteLine("Entry added.");
        }

        private void AddResident()
        {
            Console.Write("Enter name of resident: ");
            string name = Console.ReadLine();

            Console.Write("Enter phone number of resident: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Is the resident the owner? (y/n): ");
            string input = Console.ReadLine().ToLower();
            bool isOwner;

            switch (input)
            {
                case "y":
                    isOwner = true;
                    break;
                case "n":
                    isOwner = false;
                    break;
                default:
                    isOwner = true;
                    Console.WriteLine("Character not one of the requested, using default value.");
                    break;
            }

            Console.Write("Enter apartment number: ");
            int apartmentNumber = int.Parse(Console.ReadLine());

            var resident = new Resident(name, phoneNumber, isOwner);
            resident.AssignApartmentNumber(apartmentNumber);
            residentLog.AddEntry(resident);
            Console.WriteLine("Resident added");
        }

        private void ShowAllEntries()
        {
            var entries = log.GetAllEntries();
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries found!");
                return;
            }

            Console.WriteLine("All logged entries: ");
            foreach (var entry in entries)
            {
                entry.PrintDetails();
            }
        }

        private void ShowAllResidents()
        {
            var residents = residentLog.GetAllEntries();
            if (residents.Count == 0)
            {
                Console.WriteLine("No residents found!");
                return;
            }

            Console.WriteLine("All logged residents: ");
            foreach (var resident in residents)
            {
                Console.WriteLine(resident.ToString());
            }
        }

        private void ShowAllApartments()
        {
            var apartments = apartmentLog.GetAllEntries();
            if (apartments.Count == 0)
            {
                Console.WriteLine("No apartments found!");
                return;
            }

            Console.WriteLine("All logged apartments: ");
            foreach (var apartment in apartments)
            {
                Console.WriteLine(apartment.ToString());
            }
        }

        private void SearchEntries()
        {
            Console.Write("Search by Date (leave blank to skip): ");
            string date = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(date))
            {
                date = null;
            }

            Console.Write("Search by Type (leave blank to skip): ");
            string type = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(type))
            {
                type = null;
            }

            Console.Write("Search by name of creator of entry (leave blank to skip): ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                name = null;
            }

            NameMatchType newMatchType = SelectSearchType();

            var results = search.SearchEntry(date: date, type: type, addedBy: name, matchType: newMatchType);
            Console.WriteLine($"\nFound {results.Count} matching entries: ");

            foreach (var entry in results)
            {
                entry.PrintDetails();
            }
        }
        private void SearchResidents()
        {
            Console.Write("Search by Apartment Number (leave blank to skip): ");
            int apartmentNumber = int.Parse(Console.ReadLine());

            Console.Write("Search by Name (leave blank to skip): ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                name = null;
            }

            Console.Write("Search by Phone Number (leave blank to skip): ");
            string phoneNumber = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                phoneNumber = null;
            }

            NameMatchType matchType = SelectSearchType();

            var results = search.SearchResident(phoneNumber: phoneNumber, name: name, apartmentNumber: apartmentNumber, matchType: matchType);
            Console.WriteLine($"\nFound {results.Count} matching entries: ");

            foreach (var resident in results)
            {
                Console.WriteLine(resident.ToString());
            }
        }

        private void SearchApartment()
        {
            Console.Write("Search by Apartment Number (leave blank to skip): ");
            int apartmentNumber = int.Parse(Console.ReadLine());

            Console.Write("Search by Floor Number (leave blank to skip): ");
            int floorNumber = int.Parse(Console.ReadLine());

            var results = search.SearchApartment(number: apartmentNumber, floor: floorNumber);
            Console.WriteLine($"\nFound {results.Count} matching entries: ");

            foreach (var apartment in results)
            {
                Console.WriteLine(apartment.ToString());
                apartment.PrintResidents();
            }
        }

        private NameMatchType SelectSearchType()
        {
            Console.WriteLine("If searching by name/number, please select type of searching: (Enter the number to select or leave blank to skip) ");
            Console.WriteLine("1. Exact");
            Console.WriteLine("2. Contains");
            Console.WriteLine("3. Starts With");
            string matchType = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(matchType))
            {
                matchType = null;
            }
            var newMatchType = NameMatchType.Contains;
            switch (matchType)
            {
                case "1":
                    newMatchType = NameMatchType.Exact;
                    break;
                case "2":
                    newMatchType = NameMatchType.Contains;
                    break;
                case "3":
                    newMatchType = NameMatchType.StartsWith;
                    break;
                default:
                    Console.WriteLine("Default value selected.");
                    break;
            }
            return newMatchType;
        }
    }
}
