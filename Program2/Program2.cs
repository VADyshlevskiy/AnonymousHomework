using System;
using System.Collections.Generic;

namespace Program2
{
    internal class Program2
    {
        static void Main(string[] args)
        {

            var planetOne = new Planet("Венера", 1, 38025, null);
            var planetTwo = new Planet("Земля", 2, 40075, planetOne);
            var planetThree = new Planet("Марс", 3, 21326, planetTwo);
            var planetFour = new Planet("Венера", 1, 38025, planetThree);

            var planets = new CatalogPlanet(planetOne, planetTwo, planetThree);
            List<string> findPlanetsList = new List<string>() { "Земля", "Лимония", "Марс", "Земля" };

            foreach (var findPlanet in findPlanetsList)
            {
                var getPlanet = planets.GetPlanet(findPlanet);
                Console.WriteLine(getPlanet.Message == "" ? $"Порядковый номер в солнечной системе: {getPlanet.Id}; Длина экватора: {getPlanet.EquatorLenght} км" : getPlanet.Message);
            }

            //var getEarth = planets.GetPlanet("Земля");
            //Console.WriteLine(getEarth.Message == "" ? $"{getEarth.Id} {getEarth.EquatorLenght}" : getEarth.Message);
            //var getLimonia = planets.GetPlanet("Лимония");
            //Console.WriteLine(getLimonia.Message == "" ? $"{getLimonia.Id} {getLimonia.EquatorLenght}" : getLimonia.Message);
            //var getMars = planets.GetPlanet("Марс");
            //Console.WriteLine(getMars.Message == "" ? $"{getMars.Id} {getMars.EquatorLenght}" : getMars.Message);
            //var getEarth2 = planets.GetPlanet("Земля");
            //Console.WriteLine(getEarth2.Message == "" ? $"{getEarth2.Id} {getEarth2.EquatorLenght}" : getEarth2.Message);

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

            public (int Id, int EquatorLenght, string Message) GetPlanet(string planet)
            {
                Planet findPlanet = null;
                if (counter < 2)
                {
                    counter++;
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
                return (0, 0, "Вы спрашиваете слишком часто!");
            }

            public List<object> Planets { get; }
            public int counter = 0;

        }
    }
}