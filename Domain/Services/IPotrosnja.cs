using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services
{
    public interface IPotrosnja
    {
        void ZahtevajPotrosnju(Guid potrosacId, double kolicina);
        void DodajPotrosackiSistem(PodsistemPotrosnje sistem);
    }
}
