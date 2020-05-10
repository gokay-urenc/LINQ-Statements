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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            OgrencileriGetir();
        }

        List<Ogrenci> ogrenciler = new List<Ogrenci>();
        public void OgrencileriGetir()
        {
            Random rnd = new Random();
            ogrenciler.Add(new Ogrenci { ad = "qyz", cinsiyet = 'E', yas = 28, Vize = rnd.Next(0, 101), Final = rnd.Next(0, 101)});
            ogrenciler.Add(new Ogrenci { ad = "abc", cinsiyet = 'K', yas = 25, Vize = rnd.Next(0, 101), Final = rnd.Next(0, 101) });
            ogrenciler.Add(new Ogrenci { ad = "agh", cinsiyet = 'K', yas = 26, Vize = rnd.Next(0, 101), Final = rnd.Next(0, 101) });
            ogrenciler.Add(new Ogrenci { ad = "qwe", cinsiyet = 'E', yas = 24, Vize = rnd.Next(0, 101), Final = rnd.Next(0, 101) });
            ogrenciler.Add(new Ogrenci { ad = "klm", cinsiyet = 'E', yas = 22, Vize = rnd.Next(0, 101), Final = rnd.Next(0, 101) });
            ogrenciler.Add(new Ogrenci { ad = "klo", cinsiyet = 'K', yas = 26, Vize = rnd.Next(0, 101), Final = rnd.Next(0, 101) });
        }

        bool durum = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!durum)
            {
                List<Ogrenci> ogrler = (from a in ogrenciler where a.cinsiyet == 'K' select a).ToList();
                dataGridView1.DataSource = ogrler;
                durum = true;
            }
            else
            {
                List<Ogrenci> ogrler = (from a in ogrenciler where a.cinsiyet == 'E' select a).ToList();
                dataGridView1.DataSource = ogrler;
                durum = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Ortalaması, sınıf ortalamasının üstünde olan erkek öğrencilerin listesi
            // Sınıf ortalamasını bulmak için listeyi açıp öğrencilerin ortalamalarını toplayıp  daha sonra öğrenci sayısına(list uzunluğuna) bölmek gerekir.
            // Linq ile Average() numeric değerleri toplam ve ortalamayı verir.
            float sinif_ortalamasi = (from a in ogrenciler select a.Ortalama).Average();
            List<Ogrenci> gecen_erkekler = (from erk in ogrenciler where erk.cinsiyet == 'E' && erk.Ortalama >= sinif_ortalamasi select erk).ToList();
            dataGridView1.DataSource = gecen_erkekler;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Ogrenci> ogrler = (from a in ogrenciler orderby a.Ortalama ascending select a).ToList();
            dataGridView1.DataSource = ogrler;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Ogrenci> ogrler = (from a in ogrenciler orderby a.Ortalama descending select a).ToList();
            dataGridView1.DataSource = ogrler;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Ogrenci> aranan_ogrenciler = (from a in ogrenciler where a.ad.ToLower().Contains(textBox1.Text.ToLower()) select a).ToList();
            dataGridView1.DataSource = aranan_ogrenciler;
        }
    }
}
// Average(): Ortalama hesaplayan methoddur.
// orderby: Sıralama komutudur. Koleksiyonları belirlenen alana göre sıralar.
// İki alt komutu vardır.
// ascending: Artan(A-Z)
// descending: Azalan(Z-A)
// orderby'ın default(varsayılan) sıralama türü ascending'tir.