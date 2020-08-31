using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;

namespace ConsoleApp
{
    public class Printer: IPrinter
    {
        private IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
            InitData();
        }

        void InitData()
        {
            var pet1 = new Pet()
            {
                Name = "Bob",
                Type = "Dog",
                Birthdate = new DateTime(2019, 05, 05),
                SoldDate = new DateTime(2020, 05, 05),
                Color = "Brown",
                PreviousOwner = "Some guy",
                Price = 5000.00
            };
            _petService.CreatePet(pet1);

            var pet2 = new Pet()
            {
                Name = "Billy",
                Type = "Cat",
                Birthdate = new DateTime(2018, 05, 04),
                SoldDate = new DateTime(2019, 04, 04),
                Color = "Black",
                PreviousOwner = "Some other guy",
                Price = 50.00
            };
            _petService.CreatePet(pet2);

        }


        public void StartUI()
        {
            string[] menuItems = {
                "List All Pets",
                "Add Pet",
                "Delete Pet",
                "Edit Pet",
                "Search Pets By Type",
                "Sort Pets By Price",
                "Get 5 Cheapest Pets Available",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.GetAllPets();
                        ListPets(pets);
                        break;
                    case 2:
                        var name = AskQuestion("Name: ");
                        var type = AskQuestion("Type: ");
                        var birthDate = AskQuestion("Birthdate: ");
                        var soldDate = AskQuestion("SoldDate: ");
                        var color = AskQuestion("Color: ");
                        var previousOwner = AskQuestion("PreviousOwner: ");
                        var price = AskQuestion("Price: ");
                        var pet = _petService.NewPet(name, type, DateTime.Parse(birthDate), DateTime.Parse(soldDate), color, previousOwner, double.Parse(price));
                        _petService.CreatePet(pet);
                        break;
                    case 3:
                        var idForDelete = PrintFindPetById();
                        _petService.DeletePet(idForDelete);
                        break;
                    case 4:
                        var idForEdit = PrintFindPetById();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        Console.WriteLine("Updating " + petToEdit.Name);
                        var newName = AskQuestion("Name: ");
                        var newType = AskQuestion("Type: ");
                        var newBirthDate = AskQuestion("Birthdate: ");
                        var newSoldDate = AskQuestion("SoldDate: ");
                        var newColor = AskQuestion("Color: ");
                        var newPreviousOwner = AskQuestion("Previous Owner: ");
                        var newPrice = AskQuestion("Price: ");
                        _petService.UpdatePet(new Pet()
                        {
                            Id = idForEdit,
                            Name = newName,
                            Type = newType,
                            Birthdate = DateTime.Parse(newBirthDate),
                            SoldDate = DateTime.Parse(newSoldDate),
                            Color = newColor,
                            PreviousOwner = newPreviousOwner,
                            Price = double.Parse(newPrice)
                        });
                        break;
                    case 5:
                        var typeToSearch = AskQuestion("Type: ");
                        var petSearch = _petService.GetAllByType(typeToSearch);
                        ListPets(petSearch);
                        break;
                    case 6:
                        var sortedByPrice = _petService.GetAllByPrice();
                        ListPets(sortedByPrice);
                        break;
                    case 7:
                        var fiveCheapestPets = _petService.ShowFiveCheapest();
                        ListPets(fiveCheapestPets);
                        break;
                    default:
                        break;
                }

                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Goodbye!");
            Console.ReadLine();
        }

        void ListPets(List<Pet> pets)
        {
            Console.WriteLine("\nList of Pets");
            foreach (var pet in pets)
            {
                Console.WriteLine("Id: " + pet.Id + " Name: " + pet.Name + " Type: " + pet.Type + " Color: " + pet.Color +
                                  " Price: " + pet.Price);
            }
            Console.WriteLine("\n");

        }


        int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 8)
            {
                Console.WriteLine("Please select a number between 1-8");
            }

            return selection;
        }

        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        int PrintFindPetById()
        {
            Console.WriteLine("Insert Pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }

    }
}
