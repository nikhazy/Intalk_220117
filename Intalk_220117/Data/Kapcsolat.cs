using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intalk_220117.Data
{
    public class Kapcsolat
    {
        [Key]
        public int EmberId { get; set; }
        [Required]
        public int ApjaId { get; set; }
        [Required]
        public int AnyjaId { get; set; }
    }
}
