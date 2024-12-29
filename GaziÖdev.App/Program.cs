using System.Collections.Concurrent;
using System.ComponentModel.Design;
using System.Drawing;

namespace GaziÖdev.App
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int ogrencisayi = (int)Gecerlisayi("Kaç öğrenci kaydetmek istiyorsunuz ?");

            string[,] ogrencibilgileri = new string[ogrencisayi, 7];
            double[] ogrencinotları = new double[ogrencisayi];

            double sınıfortalama = 0, enyükseknot = double.MinValue, endüşüknot = double.MaxValue;


            for (int i = 0; i < ogrencisayi; i++)
            {
                
                double ogrencinumara = Gecerlisayi($"{i + 1}. öğrencinin numarasını giriniz.");
                while (ogrencinumara.ToString().Length != 11)
                {
                    ogrencinumara = Gecerlisayi("Lütfen 11 basamaklı bir sayı giriniz.");
                }

                Console.WriteLine($"{i + 1}. öğrencinin adını giriniz.");
                string ogrenciadı = Console.ReadLine();

                Console.WriteLine($"{i + 1}. öğrencinin soyadını giriniz.");
                string ogrencisoyad = Console.ReadLine();

                double vizenotu = Gecerlisayi($"{i + 1}. öğrencinin vize notunu giriniz.");

                while (vizenotu < 0 || vizenotu > 100)
                {
                    vizenotu = Gecerlisayi("Lütfen geçerli bir not değeri giriniz.");
                }


                double finalnotu = Gecerlisayi($"{i + 1}. öğrencinin final notunu giriniz.");
                while (finalnotu < 0 || finalnotu > 100)
                {
                    finalnotu = Gecerlisayi("Lütfen geçerli bir not değeri giriniz.");
                }


                double ortalama = (vizenotu * 0.4) + (finalnotu * 0.6);
                string harfnotu = HarfNotuHesapla(ortalama);

                ogrencibilgileri[i, 0] = ogrencinumara.ToString();
                ogrencibilgileri[i, 1] = ogrenciadı;
                ogrencibilgileri[i, 2] = ogrencisoyad;
                ogrencibilgileri[i, 3] = vizenotu.ToString("F2");
                ogrencibilgileri[i, 4] = finalnotu.ToString("F2");
                ogrencibilgileri[i, 5] = ortalama.ToString("F2");
                ogrencibilgileri[i, 6] = harfnotu;

                ogrencinotları[i] = ortalama;

                sınıfortalama += ortalama;
                enyükseknot = Math.Max(enyükseknot, ortalama);
                endüşüknot = Math.Min(endüşüknot, ortalama);


            }
            Console.WriteLine($"{"Numarası",-15} {" Adı",-10} {"Soyadı",-10} {"Vize Notu",-15} {"Final Notu",-15} {"Ortalama",-15} {"Harf Notu",-15}");
            Console.WriteLine(new string('-', 30));

            for (int i = 0; i < ogrencisayi; i++)
            {
                Console.WriteLine($"{ogrencibilgileri[i, 0],-15} {ogrencibilgileri[i, 1],-10} {ogrencibilgileri[i, 2],-10} {ogrencibilgileri[i, 3],-15} {ogrencibilgileri[i, 4],-15} {ogrencibilgileri[i, 5],-15} {ogrencibilgileri[i, 6],-15}");
            }






            double ortalamasınıf = sınıfortalama / ogrencisayi;
            Console.WriteLine($"\n Sınıf Ortalaması: {ortalamasınıf:F2}");
            Console.WriteLine($"\n En Düşük Not: {endüşüknot:F2}");
            Console.WriteLine($"\n En Yüksek Not: {enyükseknot:F2}");







        }



        static string HarfNotuHesapla(double ortalama)
        {
            if (ortalama >= 85) return "AA";
            if (ortalama >= 75) return "BA";
            if (ortalama >= 60) return "BB";
            if (ortalama >= 50) return "CB";
            if (ortalama >= 40) return "CC";
            if (ortalama >= 30) return "DC";
            if (ortalama >= 20) return "DD";
            if (ortalama >= 10) return "FD";
            return "FF";


        }
        static double Gecerlisayi(string prompt)
        {
            Console.WriteLine(prompt);
            while (true)

            {
                try
                {

                    return double.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lütfen bir sayı giriniz.");
                }
                
            }
        }
    }
}