using System;
using System.Collections.Generic;
using System.Text;

namespace Duels
{
    internal class Rogue : Hero, IspecialAttack
    {
        public Rogue(string name, int fullHp, Colors color) : base(name, fullHp, color)
        {
        }

        public override void DefaultAttack(Hero hero)
        {
            int hp = rnd.Next(50, 131);
            hero.ActualHP -= hp;
            Console.WriteLine($"\n{Name} hits {hp} damage points to the {hero.Name}.");
        }

        public override void Heal()
        {
            int hp = rnd.Next(50, 121);
            ActualHP += hp;
            Console.WriteLine($"\n{Name} healed himself for {hp} health points.");
        }

        public void SpecialAttack(Hero hero)
        {
            int hp = rnd.Next(50, 110);
            hero.ActualHP -=hp;
            ActualHP += hp;
            Console.WriteLine($"\n{Name} steals {hp} health points from {hero.Name} and healed.");
        }
    }
}
