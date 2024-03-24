using CSProjeDemo.Entities.Abstract;
using CSProjeDemo.Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo.Entities;

public class DosyaOku
{
    public List<Personel> JsonOku(string dosyaYolu)
    {
        List<Personel> personelListesi = new List<Personel>();

        try
        {
            string jsonData = File.ReadAllText(dosyaYolu);
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonData);

            foreach (var item in jsonObj)
            {
                string unvan = item["title"];
                string isim = item["name"];

                Personel personel;

                if (unvan == "Yonetici")
                {
                    personel = new Yonetici();
                }
                else if (unvan == "Memur")
                {
                    personel = new Memur();
                }
                else
                {
                    throw new Exception("JSON dosyasında geçersiz unvan belirtilmiş.");
                }

                personel.Ad = isim;
                personelListesi.Add(personel);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("JSON dosyasından okuma yapılırken bir hata oluştu: " + ex.Message);
        }

        return personelListesi;
    }
}
