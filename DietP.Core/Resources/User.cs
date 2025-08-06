using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietP.Core.Entities
{
    public class UserResources
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CalPerDay { get; set; } 
        public float BMI { get; set; } 
        public float Weight { get; set; } 
        public float WishWeight { get; set; } 
        public float Height { get; set; } 
        public int? DaysForDiet { get; set; } 
    }

}
