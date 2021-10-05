using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_68.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_68.Models
{
    public class SeedData
    {
        
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVC_68Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MVC_68Context>>()))
            {
                // Look for any movies.
                if (context.HocSinh.Any())
                {
                    return;   // DB has been seeded
                }

                context.HocSinh.AddRange(
                    new HocSinh
                    {
                        HoaTen = "Vũ Thanh",
                        NamSinh = DateTime.Parse("2000-06-29"),
                        DiaChi = "Nam Dinh",
                        Email = "vuthanh2906@gmail.com",
                        SDT = "0123"

                    },

                    new HocSinh
                    {
                        HoaTen = "Vũ Nam",
                        NamSinh = DateTime.Parse("2000-05-29"),
                        DiaChi = "Nam Dinh",
                        Email = "VuNam@gmail.com",
                        SDT = "01234"
                    },

                    new HocSinh
                    {
                        HoaTen = "Nguyễn Nguyệt",
                        NamSinh = DateTime.Parse("2000-06-29"),
                        DiaChi = "Hà Nội",
                        Email = "vuthanh2906@gmail.com",
                        SDT = "0126"
                    },

                    new HocSinh
                    {
                        HoaTen = "Nguyễn Thị Thu",
                        NamSinh = DateTime.Parse("2000-06-29"),
                        DiaChi = "HCM",
                        Email = "VTH@gmail.com",
                        SDT = "0129"
                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}

