using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intalk_220117.Data
{
    public class Ember
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nev { get; set; }
        [Required]
        public string Nem { get; set; }
        [Required]
        public DateTime SzuletesiDatum { get; set; }
    }
}
