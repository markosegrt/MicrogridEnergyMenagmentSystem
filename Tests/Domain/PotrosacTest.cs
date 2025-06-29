using Domain.Enums;
using Domain.Models;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class PotrosacTests
    {
        [Test]
        public void Potrosac_Konstruktor_BazicnaProvera()
        {
            var potrosac = new Potrosac("Petar Petrović", "UG-001", Tip_Snabdevanja.KOMERCIJALNO, 0, 0);

            Assert.That(potrosac, Is.Not.Null);
            Assert.That(potrosac.JedinstveniId, Is.Not.EqualTo(Guid.Empty));
            Assert.That(potrosac.ImePrezime, Is.EqualTo("Petar Petrović"));
            Assert.That(potrosac.BrPotrosackogUgovora, Is.EqualTo("UG-001"));
            Assert.That(potrosac.TipSnabdevanja, Is.EqualTo(Tip_Snabdevanja.KOMERCIJALNO));
            Assert.That(potrosac.UkupnaPotrosnja, Is.Zero);
            Assert.That(potrosac.TrenutnoZaduzenje, Is.Zero);
        }

        [Test]
        public void Potrosac_DefaultKonstruktor_PostavljaPodrazumevaneVrednosti()
        {
            var potrosac = new Potrosac();

            Assert.That(potrosac.ImePrezime, Is.EqualTo(string.Empty));
            Assert.That(potrosac.BrPotrosackogUgovora, Is.EqualTo(string.Empty));
            Assert.That(potrosac.TipSnabdevanja, Is.EqualTo(default(Tip_Snabdevanja)));
            Assert.That(potrosac.UkupnaPotrosnja, Is.EqualTo(0));
            Assert.That(potrosac.TrenutnoZaduzenje, Is.EqualTo(0));
        }

        // za ekstremne vrednosti
        [TestCase("Marko Markovic", "UG-999", Tip_Snabdevanja.KOMERCIJALNO, -100, 0)]
        [TestCase("Maja Majic", "UG-123", Tip_Snabdevanja.GARANTOVANO, 0, -250)]
        [TestCase("Test Testic", "UG-001", (Tip_Snabdevanja)999, 100, 200)] // nepostojeci enum
        [TestCase("", "", Tip_Snabdevanja.KOMERCIJALNO, 500000, 999999)]     // ekstremno veliki iznosi
        [TestCase("Ana Anaic", "UG-000", Tip_Snabdevanja.GARANTOVANO, double.MaxValue, double.MinValue)]
        public void Potrosac_ProizvoljniTestovi(string ime, string ugovor, Tip_Snabdevanja tip, double ukupno, double zaduzenje)
        {
            var potrosac = new Potrosac(ime, ugovor, tip, ukupno, zaduzenje);

            Assert.That(potrosac, Is.Not.Null);
            Assert.That(potrosac.ImePrezime, Is.EqualTo(ime));
            Assert.That(potrosac.BrPotrosackogUgovora, Is.EqualTo(ugovor));
            Assert.That(potrosac.TipSnabdevanja, Is.EqualTo(tip));
            Assert.That(potrosac.UkupnaPotrosnja, Is.EqualTo(ukupno));
            Assert.That(potrosac.TrenutnoZaduzenje, Is.EqualTo(zaduzenje));
        }
    }
}
