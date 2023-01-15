using System;

namespace AnonymousHomework
{
    class Program1
    {
        static void Main(string[] args)
        {
            var PlanetOne = new
            {
                Name = "Венера",
                ID = 0,
                EquatorLength = 38025,
                Previous = (object)null,
            };
            var PlanetTwo = new
            {
                Name = "Земля",
                ID = 1,
                EquatorLength = 40075,
                Previous = PlanetOne,
            };
            var PlanetThree = new
            {
                Name = "Марс",
                ID = 2,
                EquatorLength = 21326,
                Previous = PlanetTwo,
            };
            var PlanetFour = new
            {
                Name = "Венера",
                ID = 1,
                EquatorLength = 38025,
                Previous = PlanetThree,
            };

            Console.WriteLine("Венера: " + PlanetOne);
            Console.WriteLine("Эквивалентность Венере = " + PlanetOne.Equals(PlanetOne));
            Console.WriteLine("Земля: " + PlanetTwo);
            Console.WriteLine("Эквивалентность Венере = " + PlanetTwo.Equals(PlanetOne));
            Console.WriteLine("Марс: " + PlanetThree);
            Console.WriteLine("Эквивалентность Венере = " + PlanetThree.Equals(PlanetOne));
            Console.WriteLine("Венера: " + PlanetFour);
            Console.WriteLine("Эквивалентность Венере = " + PlanetFour.Equals(PlanetOne));
        }
    }
}
