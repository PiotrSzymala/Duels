using System;
using System.Collections.Generic;
using System.Text;

namespace Duels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = Hero.GenerateHeroes();            

            Hero player1;
            Hero player2;

            bool isChosed;
            do
            {
                isChosed = Hero.ChooseHero(out player1, 1, heroes);
            } while (!isChosed);

            do
            {
                isChosed = Hero.ChooseHero(out player2, 2, heroes);
            } while (!isChosed);

            bool isPlayer1Turn = true;

            do
            {
                Console.Clear();
                switch (player1.Color)
                {
                    case Colors.Blue:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case Colors.Gray:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case Colors.Purple:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Player 1");
                Console.WriteLine(player1);


                switch (player2.Color)
                {
                    case Colors.Blue:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case Colors.Gray:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case Colors.Purple:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    default:
                        break;
                }
                Console.CursorTop = 0;
                Console.CursorLeft = 25;
                Console.WriteLine("Player 2");
                Console.CursorTop = 1;
                Console.CursorLeft = 25;
                Console.WriteLine(player2);
                Console.ResetColor();

                Hero actualPlayer = isPlayer1Turn ? player1 : player2;
                Hero otherPlayer = isPlayer1Turn ? player2 : player1;


                Console.WriteLine($"\nPlayer {(isPlayer1Turn ? 1 : 2)} turn");
                Console.WriteLine("What you want to do?");
                Console.WriteLine("1. Melee atack");
                Console.WriteLine("2. Heal yourself");

                if (actualPlayer is IspecialAttack && !actualPlayer.usedSpecialAttack)
                {
                    Console.WriteLine("3. Special Attack");
                }
                ConsoleKey key;
                do
                {
                    key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.D1:
                            actualPlayer.DefaultAttack(otherPlayer);
                            break;
                        case ConsoleKey.D2:
                            actualPlayer.Heal();
                            break;
                        case ConsoleKey.D3:
                            if (actualPlayer is IspecialAttack && !actualPlayer.usedSpecialAttack)
                            {
                                ((IspecialAttack)actualPlayer).SpecialAttack(otherPlayer);
                                if (actualPlayer is Knight && actualPlayer == player1)
                                {
                                    isPlayer1Turn = false;
                                }
                                else
                                {
                                    isPlayer1Turn = true;
                                }
                                actualPlayer.usedSpecialAttack = true;
                            }
                            else
                            {
                                actualPlayer.DefaultAttack(otherPlayer);
                            }
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong choice detected!");
                            Console.ResetColor();
                            break;

                    }
                } while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3);

                if (player1.ActualHP == 0 || player2.ActualHP == 0)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Player {(isPlayer1Turn ? 2 : 1)} died!");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Player {(isPlayer1Turn ? 1 : 2)} won!");
                    Console.ResetColor();
                }
                else
                {

                    isPlayer1Turn = !isPlayer1Turn;
                }

                Console.ReadKey();

            } while (player1.ActualHP > 0 && player2.ActualHP > 0);

        }

    }
}
