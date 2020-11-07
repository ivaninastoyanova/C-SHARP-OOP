using _04.BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Models
{
    public class Pet :IBirthday
    {
        public Pet(string name , string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
        public string Name { get; set; }
        public string Birthday { get; set; }
    }
}
