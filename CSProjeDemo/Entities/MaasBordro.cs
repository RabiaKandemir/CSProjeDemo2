using CSProjeDemo.Entities.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo.Entities;

public class MaasBordro
{
    int calismaSaati = 180; 

    public void BordroOlustur(List<Personel> personelListesi, string raporKlasoru)
    {
        foreach (var personel in personelListesi)
        {
            decimal maas = personel.MaasHesapla(calismaSaati);
            string json = JsonConvert.SerializeObject(new { PersonelAdi = personel.Ad, Maas = maas }, Formatting.Indented);
            string dosyaAdi = $"{personel.Ad}_Maas_{DateTime.Now:yyyyMMddHHmmss}.json";
            string dosyaYolu = Path.Combine(raporKlasoru, dosyaAdi);
            File.WriteAllText(dosyaYolu, json);
        }
    }

    public void OzetYazdir(List<Personel> personelListesi)
    {
        Console.WriteLine("Maas Raporu:");
        List<Personel> azCalisanPersoneller = new List<Personel>(); 
        foreach (var personel in personelListesi)
        {
            decimal maas = personel.MaasHesapla(calismaSaati);
            Console.WriteLine($"{personel.Ad}: {maas}");

            if (maas < 150 * personel.SaatlikUcret) 
            {
                azCalisanPersoneller.Add(personel); 
            }
        }
        if (azCalisanPersoneller.Count > 0)
        {
            Console.WriteLine("\n150 saatten az çalışan personeller:");
            foreach (var azCalisan in azCalisanPersoneller)
            {
                Console.WriteLine($"{azCalisan.Ad}");
            }
        }
    }
}
