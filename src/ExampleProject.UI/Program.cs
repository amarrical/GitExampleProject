using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.UI
{
    using SampleProject;

    class Program
    {
        static void Main(string[] args)
        {
            var cup = new Cup();
            while (true)
            {

                var answer = MainMenu();
                switch (answer)
                {
                    case 1:
                        Console.WriteLine(cup.Roll());
                        break;
                    case 2:
                        DieMenu(cup);
                        break;
                    case 3:
                        cup.Empty();
                        break;
                }
            }
        }

        private static int MainMenu()
        {
            int result;
            do
            {
                Console.WriteLine("1: Roll the dice");
                Console.WriteLine("2. Add a Die");
                Console.WriteLine("3: Empty the cup");
                var answer = Console.ReadLine();
                Int32.TryParse(answer, out result);
            } while (result < 1 || result > 3);

            return result;
        }

        private static void DieMenu(Cup cup)
        {
            int result;
            do
            {
                Console.WriteLine("1: Normal die");
                Console.WriteLine("2: Loaded die");
                var answer = Console.ReadLine();
                Int32.TryParse(answer, out result);
            } while (result < 1 || result > 2);

            switch (result)
            {
                case 1:
                    NormalDieMenu(cup);
                    break;
                case 2:
                    LoadedDieMenu(cup);
                    break;
            }
        }

        private static void NormalDieMenu(Cup cup)
        {
            int result;

            do
            {
                Console.WriteLine("How many sides?");
                var answer = Console.ReadLine();
                Int32.TryParse(answer, out result);

            } while (result < 0);

            cup.Add(new Die(result));
        }

        private static void LoadedDieMenu(Cup cup)
        {
            int sides;
            int load;

            do
            {
                Console.WriteLine("How many sides?");
                var answer = Console.ReadLine();
                Int32.TryParse(answer, out sides);

            } while (sides < 0);

            do
            {
                Console.WriteLine("What value is loaded?");
                var answer = Console.ReadLine();
                Int32.TryParse(answer, out load);

            } while (load < 0 && load <= sides);

            cup.Add(new LoadedDie(sides, load));
        }
    }
}
