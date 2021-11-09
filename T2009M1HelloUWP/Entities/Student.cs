using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2009M1HelloUWP.Entities
{
    public class Student
    {
        public string Rollnumber { get; set; }
        public string Fullname { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Status { get; set; }

        /*public override string ToString()
        {
            return $"Rollnumber {Rollnumber}, Fullname {Fullname}, Avatar {Avatar}, Email {Email}, Birthday {Birthday}, Phone {Phone}, Address {Address}, Gender {Gender}, CreatedAt {CreatedAt}, UpdatedAt {UpdatedAt}, Status {Status}";
        }*/
    } 
}
