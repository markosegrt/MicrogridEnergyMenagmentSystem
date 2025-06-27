using Domain.Enums;
using Domain.Models;
using Domain.Repositories.PotrosaciRepositories;
using Services.PotrosnjeServisi;
using Moq;
using NUnit.Framework;
using Services.PotrosacServisi;

namespace Tests.Services.PotrosacServisiTests
{
    [TestFixture]
    public class PotrosacServisTests
    {
        private Mock<IPotrosaciRepository> _mockRepo = new();
        private PotrosacServis _servis = null!;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IPotrosaciRepository>();
            _servis = new PotrosacServis(_mockRepo.Object);
        }

        // -------------------------
        // ✅ BAZIČNI SLUČAJEVI
        // -------------------------
        [Test]
        public void DodajNovogPotrosaca_ValidanPotrosac_VracaTrue()
        {
            var potrosac = new Potrosac("Petar Petrović", "UG-001", Tip_Snabdevanja.KOMERCIJALNO, 0, 0);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(true);

            bool rezultat = _servis.DodajNovogPotrosaca(potrosac);

            Assert.IsTrue(rezultat);
        }

        [Test]
        public void DodajNovogPotrosaca_PotrosacVecPostoji_VracaFalse()
        {
            var potrosac = new Potrosac("Petar Petrović", "UG-001", Tip_Snabdevanja.KOMERCIJALNO, 0, 0);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(false);

            bool rezultat = _servis.DodajNovogPotrosaca(potrosac);

            Assert.IsFalse(rezultat);
        }

        [Test]
        public void DodajNovogPotrosaca_NullVrednostiUImenu_VracaFalse()
        {
            var potrosac = new Potrosac("", "UG-004", Tip_Snabdevanja.KOMERCIJALNO, 0, 0);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(false);

            bool rezultat = _servis.DodajNovogPotrosaca(potrosac);

            Assert.IsFalse(rezultat);
        }

        [Test]
        public void DodajNovogPotrosaca_NullBrojUgovora_VracaFalse()
        {
            var potrosac = new Potrosac("Ana", "", Tip_Snabdevanja.KOMERCIJALNO, 0, 0);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(false);

            bool rezultat = _servis.DodajNovogPotrosaca(potrosac);

            Assert.IsFalse(rezultat);
        }

        // -------------------------
        // ✅ GRANIČNI SLUČAJEVI
        // -------------------------
        [Test]
        public void DodajNovogPotrosaca_GranicaDugovanja0_VracaTrue()
        {
            var potrosac = new Potrosac("Marko", "UG-007", Tip_Snabdevanja.GARANTOVANO, 0, 0);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(true);

            Assert.IsTrue(_servis.DodajNovogPotrosaca(potrosac));
        }

        [Test]
        public void DodajNovogPotrosaca_NegativnaPotrosnja_VracaTrue()
        {
            var potrosac = new Potrosac("Test", "UG-009", Tip_Snabdevanja.KOMERCIJALNO, -50, 0);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(true);

            Assert.IsTrue(_servis.DodajNovogPotrosaca(potrosac));
        }

        [Test]
        public void DodajNovogPotrosaca_NegativnoZaduzenje_VracaTrue()
        {
            var potrosac = new Potrosac("Test", "UG-010", Tip_Snabdevanja.KOMERCIJALNO, 0, -100);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(true);

            Assert.IsTrue(_servis.DodajNovogPotrosaca(potrosac));
        }

        [Test]
        public void DodajNovogPotrosaca_GranicaTipaSnabdevanja_Komercijalno()
        {
            var potrosac = new Potrosac("Test", "UG-011", Tip_Snabdevanja.KOMERCIJALNO, 0, 0);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(true);

            Assert.IsTrue(_servis.DodajNovogPotrosaca(potrosac));
        }

        [Test]
        public void DodajNovogPotrosaca_GranicaTipaSnabdevanja_Garantovano()
        {
            var potrosac = new Potrosac("Test", "UG-012", Tip_Snabdevanja.GARANTOVANO, 0, 0);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(true);

            Assert.IsTrue(_servis.DodajNovogPotrosaca(potrosac));
        }

        [Test]
        public void DodajNovogPotrosaca_VelikiTekstImePrezime()
        {
            var potrosac = new Potrosac(new string('A', 300), "UG-013", Tip_Snabdevanja.KOMERCIJALNO, 0, 0);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(true);

            Assert.IsTrue(_servis.DodajNovogPotrosaca(potrosac));
        }

        // -------------------------
        // ✅ PROIZVOLJNI SLUČAJEVI
        // -------------------------
        [Test]
        public void DodajNovogPotrosaca_ProizvoljniSlucaj1()
        {
            var potrosac = new Potrosac("Milica", "UG-020", Tip_Snabdevanja.KOMERCIJALNO, 230.5, 5000);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(true);

            Assert.IsTrue(_servis.DodajNovogPotrosaca(potrosac));
        }

        [Test]
        public void DodajNovogPotrosaca_ProizvoljniSlucaj2()
        {
            var potrosac = new Potrosac("Jovan", "UG-021", Tip_Snabdevanja.GARANTOVANO, 125, 1800);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(true);

            Assert.IsTrue(_servis.DodajNovogPotrosaca(potrosac));
        }

        [Test]
        public void DodajNovogPotrosaca_ProizvoljniSlucaj3()
        {
            var potrosac = new Potrosac("Marija", "UG-022", Tip_Snabdevanja.GARANTOVANO, 0, 0);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(true);

            Assert.IsTrue(_servis.DodajNovogPotrosaca(potrosac));
        }

        [Test]
        public void DodajNovogPotrosaca_ProizvoljniSlucaj4()
        {
            var potrosac = new Potrosac("Darko", "UG-023", Tip_Snabdevanja.KOMERCIJALNO, 700, 20000);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(true);

            Assert.IsTrue(_servis.DodajNovogPotrosaca(potrosac));
        }

        [Test]
        public void DodajNovogPotrosaca_ProizvoljniSlucaj5()
        {
            var potrosac = new Potrosac("Luka", "UG-024", Tip_Snabdevanja.GARANTOVANO, 10, 0);
            _mockRepo.Setup(x => x.DodajPotrosaca(potrosac)).Returns(true);

            Assert.IsTrue(_servis.DodajNovogPotrosaca(potrosac));
        }
    }
}
