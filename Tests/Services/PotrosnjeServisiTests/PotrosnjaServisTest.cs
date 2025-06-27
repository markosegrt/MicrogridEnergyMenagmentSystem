using Domain.Enums;
using Domain.Models;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;
using Moq;
using NUnit.Framework;
using Services.PotrosnjeServisi;

namespace Tests.Services.PotrosnjeServisiTests
{
    [TestFixture]
    public class PotrosnjaServisTest
    {
        private Mock<IProizvodnjaServis> _mockProizvodnja = new(); 
        private Mock<IPotrosaciRepository> _mockRepo = new();
        private PotrosnjaServis _servis = null!;

        [SetUp]
        public void Setup()
        {
            _mockProizvodnja = new Mock<IProizvodnjaServis>();
            _mockRepo = new Mock<IPotrosaciRepository>();
            _servis = new PotrosnjaServis(_mockProizvodnja.Object, _mockRepo.Object);
        }

        // 1. BAZIČNI SLUČAJ – uspešno snabdevanje komercijalnog potrošača
        [Test]
        public void ZahtevajPotrosnju_KomercijalniPotrosac_Uspesno()
        {
            var potrosac = new Potrosac("Petar Petrović", "UG-001", Tip_Snabdevanja.KOMERCIJALNO, 0, 0);

            _mockRepo.Setup(r => r.PotrosacPoId(potrosac.JedinstveniId)).Returns(potrosac);
            _mockProizvodnja.Setup(p => p.ObradiZahtev(100)).Returns(true);

            var rezultat = _servis.ZahtevajPotrosnju(potrosac.JedinstveniId, 100);

            Assert.IsTrue(rezultat);
            Assert.AreEqual(100, potrosac.UkupnaPotrosnja);
            Assert.AreEqual(4302, potrosac.TrenutnoZaduzenje, 0.01);
        }

        // 2. BAZIČNI SLUČAJ – uspešno snabdevanje garantovanog potrošača
        [Test]
        public void ZahtevajPotrosnju_GarantovaniPotrosac_Uspesno()
        {
            var potrosac = new Potrosac("Ana Anić", "UG-002", Tip_Snabdevanja.GARANTOVANO, 0, 0);

            _mockRepo.Setup(r => r.PotrosacPoId(potrosac.JedinstveniId)).Returns(potrosac);
            _mockProizvodnja.Setup(p => p.ObradiZahtev(50)).Returns(true);

            var rezultat = _servis.ZahtevajPotrosnju(potrosac.JedinstveniId, 50);

            Assert.IsTrue(rezultat);
            Assert.AreEqual(50, potrosac.UkupnaPotrosnja);
            Assert.AreEqual(1136, potrosac.TrenutnoZaduzenje, 0.01);
        }

        // 3. GRAČNI SLUČAJ – potrošač ne postoji
        [Test]
        public void ZahtevajPotrosnju_PotrosacNePostoji_VracaFalse()
        {
            _mockRepo.Setup(r => r.PotrosacPoId(It.IsAny<Guid>())).Returns(() => null!);
            var rezultat = _servis.ZahtevajPotrosnju(Guid.NewGuid(), 100);
            Assert.IsFalse(rezultat);
        }

        // 4. GRAČNI SLUČAJ – neuspešno snabdevanje (nema energije)
        [Test]
        public void ZahtevajPotrosnju_NemaEnergije_VracaFalse()
        {
            var potrosac = new Potrosac("Marko Marković", "UG-003", Tip_Snabdevanja.KOMERCIJALNO, 0, 0);

            _mockRepo.Setup(r => r.PotrosacPoId(potrosac.JedinstveniId)).Returns(potrosac);
            _mockProizvodnja.Setup(p => p.ObradiZahtev(500)).Returns(false);

            var rezultat = _servis.ZahtevajPotrosnju(potrosac.JedinstveniId, 500);

            Assert.IsFalse(rezultat);
        }

        // 5. PROIZVOLJAN SLUČAJ – zahtev za 0 kWh
        [Test]
        public void ZahtevajPotrosnju_NulaKilovata_VracaTrue()
        {
            var potrosac = new Potrosac("Test Testović", "UG-004", Tip_Snabdevanja.GARANTOVANO, 0, 0);
            _mockRepo.Setup(r => r.PotrosacPoId(potrosac.JedinstveniId)).Returns(potrosac);
            _mockProizvodnja.Setup(p => p.ObradiZahtev(0)).Returns(true);

            var rezultat = _servis.ZahtevajPotrosnju(potrosac.JedinstveniId, 0);

            Assert.IsTrue(rezultat);
            Assert.AreEqual(0, potrosac.TrenutnoZaduzenje);
        }

        // 6. PROIZVOLJAN SLUČAJ – proveri zaduženje ako potrošač ne postoji
        [Test]
        public void VratiZaduzenje_PotrosacNePostoji_VracaNulu()
        {
            _mockRepo.Setup(r => r.PotrosacPoId(It.IsAny<Guid>())).Returns(() => null!);

            var rezultat = _servis.VratiZaduzenje(Guid.NewGuid());

            Assert.AreEqual(0, rezultat);
        }

        // 7. BAZIČNI SLUČAJ – proveri zaduženje validnog potrošača
        [Test]
        public void VratiZaduzenje_ValidanPotrosac()
        {
            var potrosac = new Potrosac("Jana Janić", "UG-005", Tip_Snabdevanja.KOMERCIJALNO, 0, 1234.56);
            _mockRepo.Setup(r => r.PotrosacPoId(potrosac.JedinstveniId)).Returns(potrosac);

            var rezultat = _servis.VratiZaduzenje(potrosac.JedinstveniId);

            Assert.AreEqual(1234.56, rezultat);
        }

        // 8. GRAČNI SLUČAJ – negativna količina (ne bi trebalo da se desi)
        [Test]
        public void ZahtevajPotrosnju_NegativnaKolicina_VracaFalse()
        {
            var potrosac = new Potrosac("Testni", "UG-006", Tip_Snabdevanja.KOMERCIJALNO, 0, 0);
            _mockRepo.Setup(r => r.PotrosacPoId(potrosac.JedinstveniId)).Returns(potrosac);

            _mockProizvodnja.Setup(p => p.ObradiZahtev(-50)).Returns(false);

            var rezultat = _servis.ZahtevajPotrosnju(potrosac.JedinstveniId, -50);

            Assert.IsFalse(rezultat);
        }

        // 9. GRAČNI SLUČAJ – potrošač sa praznim imenom (nevalidan)
        [Test]
        public void ZahtevajPotrosnju_PraznoIme_VracaFalse()
        {
            var potrosac = new Potrosac("", "UG-007", Tip_Snabdevanja.KOMERCIJALNO, 0, 0);
            _mockRepo.Setup(r => r.PotrosacPoId(potrosac.JedinstveniId)).Returns(potrosac);

            var rezultat = _servis.ZahtevajPotrosnju(potrosac.JedinstveniId, 50);

            Assert.IsFalse(rezultat);
        }

        // 10. PROIZVOLJAN SLUČAJ – potrošač ima već postojeće zaduženje
        [Test]
        public void ZahtevajPotrosnju_PotrosacImaZaduzenje_DodajeNaPostojece()
        {
            var potrosac = new Potrosac("Petar", "UG-008", Tip_Snabdevanja.KOMERCIJALNO, 200, 1000);
            _mockRepo.Setup(r => r.PotrosacPoId(potrosac.JedinstveniId)).Returns(potrosac);
            _mockProizvodnja.Setup(p => p.ObradiZahtev(100)).Returns(true);

            var rezultat = _servis.ZahtevajPotrosnju(potrosac.JedinstveniId, 100);

            Assert.IsTrue(rezultat);
            Assert.AreEqual(300, potrosac.UkupnaPotrosnja);
            Assert.AreEqual(1000 + (100 * 43.02), potrosac.TrenutnoZaduzenje, 0.01);
        }
    }
}
