using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_68.Models
{
    public class GiaoVien
    {
        [Key]
        public int MGV { get; set; }
        public string TenGV { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        [StringLength(15, MinimumLength = 3)]
        public string DiaChi { get; set; }
    }
}
