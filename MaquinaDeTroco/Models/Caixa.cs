using System.Collections.Generic;
using System.Linq;

namespace MaquinaDeTroco.Models
{
    public class Caixa
    {
        public int Id { get; private set; }
        public List<Moeda> Moeda { get; private set; }
        public double Saldo { get; private set; }


        public void AbrirCaixa()
        {
            foreach (var item in Moeda)
            {
                Saldo += item.Valor * item.Quantidade;
            }
        }

        public void AbastecerCaixa(Moeda moeda)
        {
            
        }
    }

}
