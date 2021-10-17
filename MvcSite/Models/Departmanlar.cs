using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSite.Models
{
    public class Departmanlar
    {
        [Key]
        public int ID { get; set; }
        public string DepartmanAdi { get; set; }

        public IList<Personel> Personels { get; set; }
    }
}
