using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//אובייקטי DAO  
namespace DietP.Core.Entities
{
    public class SportResources
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int LoseCalPerHour { get; set; }
    }
}
