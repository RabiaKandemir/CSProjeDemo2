using CSProjeDemo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo.Entities.Concrete;

public class Memur:Personel
{
    public decimal MesaiKatsayisi { get; set; }
    public Memur()
    {
        SaatlikUcret = 500.00m;
        MesaiKatsayisi = 1.5m;
        MaksCalismaSaati = 180;
    }
    public override decimal MaasHesapla(int calismaSaati)
    {
        decimal varsayilanSaatlikUcret = this.SaatlikUcret;
        decimal mesaiUcretiKatSayisi = this.MesaiKatsayisi;
        int maksimumNormalCalismaSaat = this.MaksCalismaSaati;
        decimal normalOdeme;
        decimal mesaiOdemesi = 0;

        if (calismaSaati > maksimumNormalCalismaSaat)
        {
            normalOdeme = varsayilanSaatlikUcret * maksimumNormalCalismaSaat;
            mesaiOdemesi = varsayilanSaatlikUcret * mesaiUcretiKatSayisi * (calismaSaati - maksimumNormalCalismaSaat);
        }
        else
        {
            normalOdeme = varsayilanSaatlikUcret * calismaSaati;
        }

        return Math.Round(normalOdeme + mesaiOdemesi, 2);
    }
}
