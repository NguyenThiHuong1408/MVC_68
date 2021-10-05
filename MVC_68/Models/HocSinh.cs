using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_68.Models
{
    public class HocSinh
    {
        [Key]
        public int MaSV { get; set; }
        [Display(Name = "Họ Tên")]
        public String HoaTen { get; set; }
        [DataType(DataType.Date)]
        public DateTime NamSinh { get; set; }
        [Required(ErrorMessage = "DiaChi is Required")]
        [StringLength(15, MinimumLength = 3)]
        public string DiaChi { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

    }
}
