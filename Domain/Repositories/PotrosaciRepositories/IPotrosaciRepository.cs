using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.PotrosaciRepositories
{
    public interface IPotrosaciRepository
    {
        public bool DodajPotrosaca(Potrosac p);

        public Potrosac PotrosacPoId(Guid id);

        public IEnumerable<Potrosac> SviPotrosaci();
    }
}
