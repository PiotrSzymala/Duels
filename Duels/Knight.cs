
using System;
using System.Collections.Generic;
using System.Text;

namespace Duels
{
    internal class Knight : Hero, IspecialAttack
    {
        public Knight(string name, int fullHp, Colors color) : base(name, fullHp, color)
        {
        }

        public override void DefaultAttack(Hero hero)
        {
            int hp = rnd.Next(50, 191);
            hero.ActualHP -= hp;
            Console.WriteLine($"\n{Name} hits {hp} damage points to the {hero.Name}.");
        }

        public override void Heal()
        {
            int hp = rnd.Next(50, 101);
            ActualHP += hp;
            Console.WriteLine($"\n{Name} healed himself for {hp} health points.");
        }

        public void SpecialAttack(Hero hero)
        {
            int hp = rnd.Next(50, 81);
            hero.ActualHP -= hp;
            Console.WriteLine($"\n{Name} hits {hp} damage points and stun the opponent.");
        }
    }
}
