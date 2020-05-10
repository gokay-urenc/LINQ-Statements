using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Ifadeleri
{
    public class Ogrenci
    {
        public Ogrenci(string ad, int yas, char cinsiyet) // Instance anında çalışır(Constructor).
        {
            this.ad = ad;
            this.yas = yas;
            this.cinsiyet = cinsiyet;
        }

        public Ogrenci()
        {

        }

        public string ad { get; set; }
        public int yas { get; set; }
        public char cinsiyet { get; set; }
        public float Vize { get; set; }
        public float Final { get; set; }
        public float Ortalama
        {
            get
            {
                return Vize * 0.4f + Final * 0.6f;
            }
        }
    }
}