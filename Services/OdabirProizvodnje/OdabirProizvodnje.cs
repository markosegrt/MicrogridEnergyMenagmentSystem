using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;

namespace Services.OdabirProizvodnje
{
    public class OdabirProizvodnje : IOdabirProizvodnje
    {
        private readonly List<PodsistemProizvodnje> _sistemi = new();

        public void DodajPodsistem(PodsistemProizvodnje sistem)
        {
            _sistemi.Add(sistem);
        }

        public PodsistemProizvodnje? OdaberiNajbolji(double potrebnaKolicina)
        {
            return _sistemi
                .Where(s => s.PreostalaKolicina >= potrebnaKolicina)
                .OrderByDescending(s => s.PreostalaKolicina)
                .FirstOrDefault();
        }
    }
}
