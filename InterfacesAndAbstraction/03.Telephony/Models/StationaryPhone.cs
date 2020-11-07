using _03.Telephony.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if(!phoneNumber.All(x =>char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Dialing... {phoneNumber}";
        }
    }
}
