using System;
using System.Collections.Generic;
using System.Text;

namespace Duels
{
    internal class Wizard : Hero, IspecialAttack
    {
        public Wizard(string name, int fullHp, Colors color) : base(name, fullHp, color)
        {

        }

        public override void DefaultAttack(Hero hero)
        {
            int hp = rnd.Next(100, 151);
            hero.ActualHP -= hp;
            Console.WriteLine($"\n{Name} hits {hp} damage points to the {hero.Name}.");
        }

        public override void Heal()
        {
            int hp = rnd.Next(100, 201);
            ActualHP += hp;
            Console.WriteLine($"\n{Name} healed himself for {hp} health points.");
        }

        public void SpecialAttack(Hero hero)
        {
            int hp = rnd.Next(250, 301);
            hero.ActualHP -= hp;
            Console.WriteLine($"\n{Name} casts fireball and deal {hp} damage points to the {hero.Name}.");
        }
    }
}
