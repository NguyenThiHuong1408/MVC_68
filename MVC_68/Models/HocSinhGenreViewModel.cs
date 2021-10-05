using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_68.Models
{
    public class HocSinhGenreViewModel
    {
        public List<HocSinh> HocSinhs { get; set; }
        public SelectList DiaChi { get; set; }
        public string HocSinhGenre { get; set; }
        public string SearchString { get; set; }
    }
}
