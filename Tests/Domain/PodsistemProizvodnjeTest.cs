using Domain.Models;
using Domain.Enums;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class PodsistemProizvodnjeTests
    {
        [Test]
        public void Konstruktor_BazicnaProvera()
        {
            var sistem = new PodsistemProizvodnje("NS-001", Tip_Proizvodnje.ECOGREEN, "Novi Sad", 1500);

            Assert.That(sistem.Sifra, Is.EqualTo("NS-001"));
            Assert.That(sistem.Tip, Is.EqualTo(Tip_Proizvodnje.ECOGREEN));
            Assert.That(sistem.Lokacija, Is.EqualTo("Novi Sad"));
            Assert.That(sistem.PreostalaKolicina, Is.EqualTo(1500));
        }

        [Test]
        public void DefaultKonstruktor_PostavljaPodrazumevaneVrednosti()
        {
            var sistem = new PodsistemProizvodnje();

            Assert.That(sistem.Sifra, Is.EqualTo(string.Empty));
            Assert.That(sistem.Lokacija, Is.EqualTo(string.Empty));
            Assert.That(sistem.Tip, Is.EqualTo(default(Tip_Proizvodnje)));
            Assert.That(sistem.PreostalaKolicina, Is.EqualTo(0));
        }

        [TestCase("BG-002", Tip_Proizvodnje.CVRSTOGORIVO, "Beograd", -500)]
        [TestCase("DJ-003", Tip_Proizvodnje.HIDROELEKTRANA, "Djerdap", double.MaxValue)]
        [TestCase("NS-123", (Tip_Proizvodnje)999, "Novi Sad", 1234)] // Nepostojeći enum
        public void Konstruktor_EkstremneVrednosti(string sifra, Tip_Proizvodnje tip, string lokacija, double kolicina)
        {
            var sistem = new PodsistemProizvodnje(sifra, tip, lokacija, kolicina);

            Assert.That(sistem.Sifra, Is.EqualTo(sifra));
            Assert.That(sistem.Tip, Is.EqualTo(tip));
            Assert.That(sistem.Lokacija, Is.EqualTo(lokacija));
            Assert.That(sistem.PreostalaKolicina, Is.EqualTo(kolicina));
        }
    }
}
