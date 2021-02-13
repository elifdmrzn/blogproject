
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace adminblog.Models
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options): base(options)
        {

        }

        public DbSet<Yazar> Yazar { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Blog> Blog { get; set; }
    }
}
