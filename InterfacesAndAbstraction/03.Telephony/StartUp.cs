using _03.Telephony.Models;
using System;
using System.Linq;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartPhone = new Smartphone();
            string[] phoneNumbers = Console.ReadLine().Split().ToArray();
            string[] sites = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                try
                {
                    if (phoneNumbers[i].Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(phoneNumbers[i]));
                    }
                    else if (phoneNumbers[i].Length == 10)
                    {
                        Console.WriteLine(smartPhone.Call(phoneNumbers[i]));
                    }
                    else
                    {
                        throw new ArgumentException("Invalid number!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            for (int i = 0; i < sites.Length; i++)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browse(sites[i]));
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                } 
            }
        }
    }
}
