using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var motosSource = new[]
            {
                new Moto
                {
                    EngineVolume = 12,
                    Mark = "z",
                    Model = "model1",
                    Price = 250000
                },
                new Moto
                {
                    EngineVolume = 14,
                    Mark = "a",
                    Model = "model2",
                    Price = 350000
                },
                new Moto
                {
                    EngineVolume = 7,
                    Mark = "c",
                    Model = "model3",
                    Price = 150000
                },
                new Moto
                {
                    EngineVolume = 9,
                    Mark = "b",
                    Model = "model4",
                    Price = 200000
                },
                new Moto
                {
                    EngineVolume = 9,
                    Mark = "b",
                    Model = "model5",
                    Price = 100000
                },
            };

            var sortedByPrice = motosSource.ToArray();
            Array.Sort(sortedByPrice, new MotoInversePriceComparer());

            var sortedByMark = motosSource.ToArray();
            Array.Sort(sortedByMark, new MotoMarkComparer());

            foreach (var moto in sortedByPrice)
                Console.WriteLine(moto);

            Console.WriteLine();
            foreach (var moto in sortedByMark)
                Console.WriteLine(moto);

            Console.ReadLine();
        }
    }

    public struct Moto
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public decimal EngineVolume { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Mark: {Mark}, Model: {Model}, EngineVolume: {EngineVolume}, Price: {Price}";
        }
    }

    public class MotoInversePriceComparer : IComparer<Moto>
    {
        public int Compare(Moto x, Moto y)
        {
            return y.Price.CompareTo(x.Price);
        }
    }

    public class MotoMarkComparer : IComparer<Moto>
    {
        public int Compare(Moto x, Moto y)
        {
            return String.Compare(x.Mark, y.Mark, StringComparison.Ordinal);
        }
    }
}