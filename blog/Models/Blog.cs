using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string BlogAdi { get; set; }
        public string KisaAciklama { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public bool Yayin { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
        public Yazar Yazar { get; set; }
        public int YazarId { get; set; }
        public Kategori Kategori { get; set; }
        public int KategoriId { get; set; }
    }
}
