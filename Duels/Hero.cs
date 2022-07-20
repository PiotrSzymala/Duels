using System;
using System.Collections.Generic;
using System.Text;

namespace Duels
{
    enum Colors
    {
        Blue,
        Gray,
        Purple
    }

    interface IspecialAttack
    {
        void SpecialAttack(Hero hero);
    }
    abstract class Hero
    {

        public Hero(string name, int fullHp, Colors color)
        {
            Name = name;
            FullHp = fullHp;
            ActualHP = FullHp;
            Color = color;
        }
        public string Name { get; }
        public int FullHp { get; }

        private int actualHp;
        public int ActualHP
        {
            get { return actualHp; }
            set
            {
                if (value < 0)
                {
                    actualHp = 0;
                }
                else if (value > FullHp)
                {
                    actualHp = FullHp;
                }
                else
                {
                    actualHp = value;
                }
            }
        }
        public Colors Color { get; set; }

        protected Random rnd = new Random();
        public bool usedSpecialAttack { get; set; } = false;

        public abstract void DefaultAttack(Hero hero);
        public abstract void Heal();
        public override string ToString()
        {
            return $"{Name} - {ActualHP}/{FullHp}";
        }

        internal static bool ChooseHero(out Hero hero, int player, List<Hero> heroes)
        {
            Console.Clear();
            Console.WriteLine($"Player {player} chooses his character:");

            for (int i = 0; i < heroes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {heroes[i].Name}");
            }


            int.TryParse(Console.ReadLine(), out int num);

            if (num >= 1 && num <= heroes.Count)
            {
                hero = heroes[num - 1];
                heroes.Remove(hero);
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong choice detected");
                Console.ResetColor();
                Console.ReadKey();
                hero = null;
                return false;
            }
        }
        internal static List<Hero> GenerateHeroes()
        {
            List<Hero> heroes = new List<Hero>();
            heroes.Add(new Wizard("Wizard", 500, Colors.Blue));
            heroes.Add(new Knight("Knight", 650, Colors.Gray));
            heroes.Add(new Rogue("Rogue", 450, Colors.Purple));
            return heroes;
        }
    }
}
