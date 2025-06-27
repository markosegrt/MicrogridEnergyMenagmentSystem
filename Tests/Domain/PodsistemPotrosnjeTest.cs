using Domain.Models;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class PodsistemPotrosnjeTests
    {
        [Test]
        public void Konstruktor_BazicnaProvera()
        {
            var sistem = new PodsistemPotrosnje("Južna Mreža", "JP-001");

            Assert.That(sistem.Naziv, Is.EqualTo("Južna Mreža"));
            Assert.That(sistem.Sifra, Is.EqualTo("JP-001"));
        }

        [Test]
        public void DefaultKonstruktor_PostavljaPodrazumevaneVrednosti()
        {
            var sistem = new PodsistemPotrosnje();

            Assert.That(sistem.Naziv, Is.EqualTo(string.Empty));
            Assert.That(sistem.Sifra, Is.EqualTo(string.Empty));
        }

        [TestCase("", "ABC")]
        [TestCase("Severna Mreža", "")]
        [TestCase("", "")]
        [TestCase("Naziv sa specijalnim znakovima !@#$%", "ŠIFRA-123")]
        public void Konstruktor_EkstremneVrednosti(string naziv, string sifra)
        {
            var sistem = new PodsistemPotrosnje(naziv, sifra);

            Assert.That(sistem.Naziv, Is.EqualTo(naziv));
            Assert.That(sistem.Sifra, Is.EqualTo(sifra));
        }
    }
}
