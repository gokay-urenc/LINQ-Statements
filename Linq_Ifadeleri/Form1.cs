using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_Ifadeleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       private void button1_Click(object sender, EventArgs e)
        {
            // 100 elemanlı bir dizinin tek sayı elemanlarını başka bir diziye alma.
            List<int> sayilar = new List<int>();
            // sayilar[0] = 13; // Hatalı eleman ekleme. Dizide eleman sayısı belirtilmemiştir.
            for (int i = 1; i <= 100; i++)
            {
                sayilar.Add(i);
            }

            List<int> tek_sayilar = new List<int>();
            foreach (var sayi in sayilar)
            {
                if (sayi % 2 == 1)
                {
                    tek_sayilar.Add(sayi);
                }
            }

            List<int> tekler = (from a in sayilar where a % 2 == 1 select a).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ogrenci ogr1 = new Ogrenci("Negan", 52, 'E');
            Ogrenci ogr2 = new Ogrenci("Rick", 47, 'E');
            Ogrenci ogr3 = new Ogrenci("Daryl", 45, 'E');
            Ogrenci ogr4 = new Ogrenci("Morgan", 49, 'E');
            Ogrenci ogr5 = new Ogrenci("Rosita", 32, 'K');
            Ogrenci ogr6 = new Ogrenci("Alicia", 24, 'K');
            List<Ogrenci> ogrenci_listesi = new List<Ogrenci>();
            ogrenci_listesi.Add(ogr1);
            ogrenci_listesi.Add(ogr2);
            ogrenci_listesi.Add(ogr3);
            ogrenci_listesi.Add(ogr4);
            ogrenci_listesi.Add(ogr5);
            ogrenci_listesi.Add(ogr6);

            // Sınıftaki öğrencilerin cinsiyetlerini bir dizi içerisinde tutma.
            List<char> ogrenci_cinsiyetleri = (from c in ogrenci_listesi select c.cinsiyet).ToList();

            // Cinsiyeti K olan öğrenciler.
            List<Ogrenci> kadin_ogrenciler = (from o in ogrenci_listesi where o.cinsiyet == 'K' select o).ToList();
        }
    }
}
/* Linq(Language Integrated Query): Dil ile bütünleşik sorgulama dili, sile entegre edilmiş      sorgulama dilidir.
   Sorgulama dili veriler üzerinde koşulsuz, döngüsüz filtreleme yapmak için kullanılır.
   Bu yapı olmadan programlama dilinde karar mekanizmaları, döngüler ve algoritmalar kullanılır.
   ToList: Bir veri kümesinden seçilen elemanı yeni atanacak dizinin tipine uygun formatta çevirip atamaya yarar.
*/