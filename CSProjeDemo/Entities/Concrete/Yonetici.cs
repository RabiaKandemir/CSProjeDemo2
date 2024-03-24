using CSProjeDemo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo.Entities.Concrete;

public class Yonetici:Personel
{
    public decimal YoneticiKatsayisi { get; set; }
    public decimal Bonus { get; set; }
    public Yonetici()
    {
        Bonus = 1100;
        YoneticiKatsayisi = 1.50m;
        SaatlikUcret = Math.Max(500, 500 * YoneticiKatsayisi);
    }
    public override decimal MaasHesapla(int calismaSaati)
    {
        decimal bonus = this.Bonus;
        return Math.Round(this.SaatlikUcret * calismaSaati + bonus, 2);
    }
}
