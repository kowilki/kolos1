using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish
{
    class Program
    {
        /// <summary>
        /// Metoda fish zwraca liczbe ryb ktore przezyly
        /// </summary>
        /// <param name="a">tablica z wielkosciami ryb</param>
        /// <param name="b">tablica z kierunkiem ryb</param>
        /// <returns></returns>
        public static int fish(int[] a, int[] b)
        {
            Stack<int> zywe = new Stack<int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (zywe.Count == 0)
                    zywe.Push(i);
                else
                {
                    while (zywe.Count != 0
                        && b[i] - b[zywe.Peek()] == -1
                        && a[i] > a[zywe.Peek()])
                    {
                        zywe.Pop();
                    }
                    if (zywe.Count != 0)
                    {
                        if (b[i] - b[zywe.Peek()] != -1)
                            zywe.Push(i);
                    }
                    else
                    {
                        zywe.Push(i);
                    }
                }
            }
            return zywe.Count;
        }
        static void Main(string[] args)
        {
            Random next = new Random();
            Console.WriteLine("Podaj ilosc ryb: ");
            int size = Console.Read();
            int[] a = new int[size], b = new int[size];
            for (int i = 0; i < size; i++)
            {
                a[i] = next.Next(101);
                b[i] = next.Next(2);
                Console.WriteLine("Wielkosc ryby {0} = {1}, kierunek = {2}", i, a[i], b[i]);
            }
            Console.WriteLine("Przezylo: {0}", fish(a, b));
            Console.ReadKey();
        }
    }
    [TestClass]
    public class TestFishClass
    {
        [TestMethod]
        public void TestFishMethod()
        {
            int[] a = { 4, 3, 2, 1, 5 }, b = { 0, 1, 0, 0, 0 };
            Assert.AreEqual(2, Program.fish(a, b));
        }
    }
}