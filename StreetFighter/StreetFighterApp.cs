using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ConsoleApplication2
{
    class Program
    {
        static String ChooseCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_____________________Choose your hero, bitch_____________________");
            Console.WriteLine("Press the button match the number of character you want to choose");
            Console.Write("{0}", Environment.NewLine);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1 - Ksander Yary");
            Console.Write("{0}", Environment.NewLine);
            Console.WriteLine("2 - Ivan Zovsky");
            Console.Write("{0}", Environment.NewLine);
            Console.WriteLine("3 - Samuel O'Banan");
            Console.Write("{0}", Environment.NewLine);
            Console.WriteLine("4 - Nikolas the Downshifter");
            Console.Write("{0}{0}", Environment.NewLine);
            Console.CursorSize = 100;
            Console.SetCursorPosition(12, 15);
            String Num = Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}{0}{0}{0}", Environment.NewLine);
            switch (Num)
            {
                case "1":
                    Console.WriteLine("__________________You choise is: Ksander Yary__________________"); Num = "Ksander Yary";
                    break;
                case "2":
                    Console.WriteLine("__________________You choise is: Ivan Zovsky___________________"); Num = "Ivan Zovsky";
                    break;
                case "3":
                    Console.WriteLine("_________________You choise is: Samuel O'Banan_________________"); Num = "Samuel O'Banan";
                    break;
                case "4":
                    Console.WriteLine("_____________You choise is: Nikolas the Downshifter____________"); Num = "Nikolas the Downshifter";
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("{0}{0}{0}{0}", Environment.NewLine);
                    Console.WriteLine("Fuck you, little dodger, choose the right value (1, 2, 3, or 4)!");
                    Console.WriteLine("__________________Press any key and try again__________________");
                    Console.ReadKey();
                    Console.Clear();
                    Num = ChooseCharacter();
                    break;
            }
            return Num;
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo WhatToDo;
            do
            {
                Console.Clear();
                Warrior Player1 = new Warrior();
                Warrior Player2 = new Warrior();
                String GetPlayer1 = " ";
                String GetPlayer2 = " ";
                GetPlayer1 = ChooseCharacter();
                Console.CursorSize = 1;
                Console.Write("{0}", Environment.NewLine);
                Console.WriteLine("_______________Press any key to choose second hero_______________");
                Console.ReadKey();
                Console.Clear();
                GetPlayer2 = ChooseCharacter();
                Console.CursorSize = 1;
                Console.Write("{0}", Environment.NewLine);
                Console.WriteLine("______________________Press any key to continue_____________________");
                Console.ReadKey();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0}{0}{0}{0}", Environment.NewLine);
                Console.Write("_______________ ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0}", GetPlayer1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("   VS   ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("{0}", GetPlayer2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" _______________");
                Console.Write("{0}", Environment.NewLine); Console.WriteLine();
                Console.WriteLine("______________________LET THE BATTLE BEGINS!!!______________________");
                Console.Write("{0}", Environment.NewLine);
                Console.WriteLine("______________________Press any key to continue_____________________");
                Console.ReadKey();
                Console.Clear();

                if (GetPlayer1 == "Ksander Yary") { Player1.Danserker(); };
                if (GetPlayer1 == "Ivan Zovsky") { Player1.Forester(); };
                if (GetPlayer1 == "Samuel O'Banan") { Player1.Elf(); };
                if (GetPlayer1 == "Nikolas the Downshifter") { Player1.Robobard(); };
                if (GetPlayer2 == "Ksander Yary") { Player2.Danserker(); };
                if (GetPlayer2 == "Ivan Zovsky") { Player2.Forester(); };
                if (GetPlayer2 == "Samuel O'Banan") { Player2.Elf(); };
                if (GetPlayer2 == "Nikolas the Downshifter") { Player2.Robobard(); };


                /* BATTLE */

                BattleAction BA;
                BA = new BattleAction();

                while (Player1.Health > 0 && Player2.Health > 0)
                {
                    if (GetPlayer1 == "Ksander Yary") { Player1.Power = Player1.DanserkerPower(); };
                    if (GetPlayer1 == "Ivan Zovsky") { Player1.Power = Player1.ForesterPower(); ; };
                    if (GetPlayer1 == "Samuel O'Banan") { Player1.Power = Player1.ElfPower(); };
                    if (GetPlayer1 == "Nikolas the Downshifter") { Player1.Power = Player1.RobobardPower(); };
                    if (GetPlayer2 == "Ksander Yary") { Player2.Power = Player2.DanserkerPower(); };
                    if (GetPlayer2 == "Ivan Zovsky") { Player2.Power = Player2.ForesterPower(); ; };
                    if (GetPlayer2 == "Samuel O'Banan") { Player2.Power = Player2.ElfPower(); };
                    if (GetPlayer2 == "Nikolas the Downshifter") { Player2.Power = Player2.RobobardPower(); };
                    Int32[] newRandomMassive;
                    newRandomMassive = new Int32[4];
                    newRandomMassive = BA.Check(newRandomMassive);
                    if (newRandomMassive[2] < Player1.Luck) { Player1.Power += 2; }
                    if (newRandomMassive[0] > Player1.Accuracy) { Player1.Power = 0; }
                    if (newRandomMassive[3] < Player2.Luck) { Player2.Power += 2; }
                    if (newRandomMassive[1] > Player2.Accuracy) { Player2.Power = 0; }
                    Player1.Health = (Player1.Health - Player2.Power);
                    Player2.Health = (Player2.Health - Player1.Power);
                    if (Player1.Health < 0) { Player1.Health = 0; };
                    if (Player2.Health < 0) { Player2.Health = 0; };
                    Console.Clear();

                    Console.Write("{0}{0}{0}{0}", Environment.NewLine);
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (Player1.Power == 0) { Console.WriteLine("{0} missed", GetPlayer1); }
                    else { Console.WriteLine("{0} hit {1}", GetPlayer1, Player1.Power); };
                    Console.WriteLine("Health left {0}", Player1.Health);
                    Console.Write("{0}", Environment.NewLine);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (Player2.Power == 0) { Console.WriteLine("{0} missed", GetPlayer2); }
                    else { Console.WriteLine("{0} hit {1}", GetPlayer2, Player2.Power); };
                    Console.WriteLine("Health left {0}", Player2.Health);
                    Console.Write("{0}", Environment.NewLine);
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Threading.Thread.Sleep(500);
                }
                if (Player1.Health == 0 && Player2.Health == 0) { Console.WriteLine("___________Nobody wins___________"); }
                else
                {
                    Console.Write("{0}{0}{0}{0}", Environment.NewLine);
                    if (Player1.Health > Player2.Health) { Console.WriteLine("________Yeah, {0} has won________", GetPlayer1); } else { Console.WriteLine("________Yeah, {0} has won________", GetPlayer2); }
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0}", Environment.NewLine);
                Console.WriteLine("Press any key to continue, or Esc to exit");
                WhatToDo = Console.ReadKey();
            } while (WhatToDo.Key != ConsoleKey.Escape);
        }
    }

    public class Warrior
    {
        public Int32 Health;
        public Int32 Accuracy;
        public Int32 Luck;
        public Int32 Power;
        Random rnd = new Random(Guid.NewGuid().GetHashCode());

        public Int32 DanserkerPower()
        {
            Int32[] P = { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            Int32 pwr = rnd.Next(P.Length);
            Power = P[pwr];
            return Power;
        }

        public void Danserker()
        {
            Health = 100;
            Accuracy = 50;
            Luck = 30;
        }

        public Int32 ElfPower()
        {
            Int32[] P = { 3, 4, 5, 6, 7 };
            Int32 pwr = rnd.Next(P.Length);
            Power = P[pwr];
            return Power;
        }

        public void Elf()
        {
            Health = 90;
            Accuracy = 70;
            Luck = 40;
        }

        public Int32 ForesterPower()
        {
            Int32[] P = { 3, 4, 5, 6, 7, 8 };
            Int32 pwr = rnd.Next(P.Length);
            Power = P[pwr];
            return Power;
        }

        public void Forester()
        {
            Health = 85;
            Accuracy = 70;
            Luck = 50;
        }

        public Int32 RobobardPower()
        {
            Int32[] P = { 4, 5, 6 };
            Int32 pwr = rnd.Next(P.Length);
            Power = P[pwr];
            return Power;
        }

        public void Robobard()
        {
            Health = 80;
            Accuracy = 80;
            Luck = 20;
        }
    }

    public class BattleAction
    {
        public Int32[] Check(Int32[] ran)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            ran = new Int32[4];
            ran[0] = rnd.Next(101);
            ran[1] = rnd.Next(101);
            ran[2] = rnd.Next(101);
            ran[3] = rnd.Next(101);
            return ran;
        }
    }
}

