using System;
using System.Globalization;
using Banco.Entities;
using Banco.Entities.Exceptions;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ENTER ACCOUNT DATA:");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Holder: ");
            string holder = Console.ReadLine();
            Console.Write("Initial Limit: ");
            double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Withdrawlimit: ");
            double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Account acc = new Account(number, holder, balance, withdrawLimit);

            Console.WriteLine();
            Console.Write("ENTER AMOUNT FOR WITHDRAW: ");
            double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            try
            {
                acc.WithDraw(amount);
                Console.WriteLine("NEW BALANCE: " + acc.Balance.ToString("F2", CultureInfo.InvariantCulture));

            }
            catch(DomainException e)
            {
                Console.WriteLine("WITHDRAW ERROR: " + e.Message);
            }

        }
    }
}
