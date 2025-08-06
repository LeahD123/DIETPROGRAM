using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietP.Core.Entities
{

    public class Calendar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // המפתח לא ייגנרר אוטומטית
        public int UserId { get; set; } // מפתח ראשי ומפתח זר

        [Required]
        [Column("Date")]
        public DateTime Date { get; set; } // תאריך

        [Required]
        [Column("success")]
        public bool Success { get; set; } // tinyint(1) - ייצוג של boolean
    }
}
