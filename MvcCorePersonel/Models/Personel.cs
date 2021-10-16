using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePersonel.Models
{
    public class Personel
    {
        [Key]
        public int ID { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public string Sehir { get; set; }
    }
}
