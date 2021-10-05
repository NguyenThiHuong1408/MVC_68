using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_68.Models;

namespace MVC_68.Data
{
    public class MVC_68Context : DbContext
    {
        public MVC_68Context (DbContextOptions<MVC_68Context> options)
            : base(options)
        {
        }

        public DbSet<MVC_68.Models.HocSinh> HocSinh { get; set; }

        public DbSet<MVC_68.Models.GiaoVien> GiaoVien { get; set; }
    }
}
