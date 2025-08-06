using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietP.Core.Entities
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // או Identity אם זה צריך להיות auto-increment
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(45)]
        public string LastName { get; set; }

        [Required]
        [StringLength(45)]
        public string Email { get; set; }

        [Required]
        [StringLength(45)]
        public string Password { get; set; }

        [Required]
        public int CalPerDay { get; set; }

        [Required]
        public float BMI { get; set; }

        [Required]
        public float Weight { get; set; }

        [Required]
        public float Height { get; set; }

        public float WishWeight { get; set; }

        public int? DaysForDiet { get; set; }
    }
}
