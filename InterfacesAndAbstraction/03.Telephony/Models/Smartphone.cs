using _03.Telephony.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony.Models
{
    public class Smartphone : IBrowsable, ICallable
    {
        public string Browse(string url)
        {
            if(url.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {phoneNumber}";
        }
    }
}
