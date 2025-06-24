using Domain.Models;
//nisi koristiooo
namespace Domain.Services
{
    public interface IOdabirProizvodnjeServis
    {

        public PodsistemProizvodnje? OdaberiNajbolji();//? znaci da moze da vrati null
    }
}
