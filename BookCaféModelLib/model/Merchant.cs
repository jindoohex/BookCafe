using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCaféModelLib.model
{
    public class Merchant
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Merchant()
        {

        }

        public Merchant(int id, string name, string email, string phoneNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"ID = {Id} \nName = {Name} \nEmail = {Email} \nPhone Number = {PhoneNumber}";
        }
    }
}
