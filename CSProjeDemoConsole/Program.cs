using CSProjeDemo.Entities;
using CSProjeDemo.Entities.Abstract;

string jsonDosyaYolu = "personel.json";
string raporKlasoru = "MaasRaporlari";

DosyaOku dosyaOku = new DosyaOku();
List<Personel> personelListesi = dosyaOku.JsonOku(jsonDosyaYolu);

if (personelListesi.Count > 0)
{
    Directory.CreateDirectory(raporKlasoru);

    MaasBordro maasBordro = new MaasBordro();
    maasBordro.BordroOlustur(personelListesi, raporKlasoru);
    maasBordro.OzetYazdir(personelListesi);
}
else
{
    Console.WriteLine("JSON dosyasında personel verisi bulunamadı.");
}
