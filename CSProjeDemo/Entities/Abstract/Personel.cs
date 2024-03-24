using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo.Entities.Abstract;

public abstract class Personel
{
    public string Ad { get; set; }
    public decimal SaatlikUcret { get; set; }
    public int MaksCalismaSaati { get; set; }
    public abstract decimal MaasHesapla(int calismaSaati);
}
