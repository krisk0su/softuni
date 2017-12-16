using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DefiningClassesLab
{
    public class StartUp
    {
        public static void Main()
        {
            var myData = new Dictionary<int, BankAccount>();


            while (true)
            {
                string input = Console.ReadLine();
                if (input=="End")
                {
                    break;
                }
                string[] commands = input.Split();

                switch (commands[0])
                {
                    case "Create":
                        Create(int.Parse(commands[1]), myData);
                        break;
                    case "Deposit":
                        Deposit(commands, myData);
                        break;
                    case "Withdraw":
                        Withdraw(commands, myData);
                        break;
                    case "Print":
                        Print(commands, myData);
                        break;
                }
            }

        }

        private static void Print(string[] commands, Dictionary<int, BankAccount> myData)
        {
            int id = int.Parse(commands[1]);

            ExistValidation(id, myData);
            if (!myData.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                Console.WriteLine($"Account ID{myData[id].ID}, balance {myData[id].Balance:F2}");
            }
        }

        private static void ExistValidation(int id, Dictionary<int, BankAccount> myData)
        {
            
        }

        private static void Withdraw(string[] commands, Dictionary<int, BankAccount> myData)
        {
            int id = int.Parse(commands[1]);
            double amount = double.Parse(commands[2]);

            if (!myData.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                if (myData[id].Balance < amount)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    myData[id].Withdraw(amount);
                }
            }

        }

        private static void Deposit(string[] commands, Dictionary<int, BankAccount> myData)
        {
            int id = int.Parse(commands[1]);
            double amount = double.Parse(commands[2]);

            if (!myData.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                myData[id].Deposit(amount);
            }
        }

        private static void Create(int id,  Dictionary<int, BankAccount> myData )
        {
            if (!myData.ContainsKey(id))
            {
                myData.Add(id, new BankAccount());

                myData[id].ID = id;
                myData[id].Balance = 0;
            }
            else
            {
                Console.WriteLine("Account already exists");
            }
        }
    }
}
