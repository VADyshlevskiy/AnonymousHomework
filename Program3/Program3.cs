using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Program3
{
    class Program3
    {
        static void Main(string[] args)
        {
            var planetOne = new Planet("Венера", 1, 38025, null);
            var planetTwo = new Planet("Земля", 2, 40075, planetOne);
            var planetThree = new Planet("Марс", 3, 21326, planetTwo);
            var planetFour = new Planet("Венера", 1, 38025, planetThree);

            var counter = 0;

            var planets = new CatalogPlanet(planetOne, planetTwo, planetThree);
            List<string> findPlanetsList = new List<string>() { "Земля", "Лимония", "Марс", "Земля" };

            foreach (var findPlanet in findPlanetsList)
            {
                var getPlanet = planets.GetPlanet(findPlanet, i =>
                {
                    if (counter < 2)
                    {
                        counter++;
                        return null;
                    }
                    return "Вы спрашиваете слишком часто!";
                });
                Console.WriteLine(getPlanet.Message == "" ? $"Порядковый номер в солнечной системе: {getPlanet.Id}; Длина экватора: {getPlanet.EquatorLenght} км" : getPlanet.Message);
            }

            Console.WriteLine("\n\tЗадание со звездочкой\n");

            foreach (var findPlanet in findPlanetsList) // Задание со *
            {
                var getPlanet = planets.GetPlanet(findPlanet, i =>
                {
                    if (findPlanet == "Лимония")
                    {
                        return "Это запретная планета!"; 
                    }
                    return null;
                });
                Console.WriteLine(getPlanet.Message == "" ? $"Порядковый номер в солнечной системе: {getPlanet.Id}; Длина экватора: {getPlanet.EquatorLenght} км" : getPlanet.Message);
            }
        }

        class Planet
        {
            public Planet(string name, int id, int equatorLength, object previous)
            {
                Name = name;
                Id = id;
                EquatorLength = equatorLength;
                Previous = previous;
            }

            public string Name { get; }
            public int Id { get; }
            public int EquatorLength { get; }
            public Object Previous { get; }

        }

        class CatalogPlanet
        {
            public CatalogPlanet(Planet planetOne, Planet planetTwo, Planet planetThree)
            {
                Planets = new List<object> { planetOne, planetTwo, planetThree };
            }

            public (int Id, int EquatorLenght, string Message) GetPlanet(string planet, Func<string, string> PlanetValidator)
            {
                Planet findPlanet = null;
                if (PlanetValidator(planet) == null)
                {
                    foreach (Planet item in Planets)
                    {
                        if (item.Name == planet)
                        {
                            findPlanet = item;
                            break;
                        }
                        else
                            findPlanet = null;
                    }
                    return findPlanet == null ? (0, 0, "Не удалось найти планету!") : (findPlanet.Id, findPlanet.EquatorLength, "");
                }
                return (0, 0, PlanetValidator(planet));
            }
        
            public List<object> Planets { get; }
            public int counter = 0;

        }
    }
}