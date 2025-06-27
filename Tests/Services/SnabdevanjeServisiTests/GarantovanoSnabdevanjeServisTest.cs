using Domain.Models;
using Domain.Enums;
using Domain.Repositories.ProizvodnjaRepositories;
using NUnit.Framework;
using Moq;
using Services.SnabdevanjaServisi;

namespace Tests.Services.SnabdevanjeServisiTests
{
    [TestFixture]
    public class GarantovanoSnabdevanjeServisTests
    {
        private Mock<IProizvodnjaRepository> _mockRepo = null!;
        private GarantovanoSnabdevanjeServis _servis = null!;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IProizvodnjaRepository>();
            _servis = new GarantovanoSnabdevanjeServis(_mockRepo.Object);
        }

        [Test]
        public void DopuniEnergiju_KadaImaManjeOd100_VracaTrue()
        {
            var lista = new List<PodsistemProizvodnje>
            {
                new PodsistemProizvodnje("X1", Tip_Proizvodnje.ECOGREEN, "NS", 90)
            };
            _mockRepo.Setup(r => r.Svi()).Returns(lista);

            var rezultat = _servis.DopuniEnergiju();

            Assert.That(rezultat, Is.True);
            Assert.That(lista[0].PreostalaKolicina, Is.GreaterThan(90));
        }

        [Test]
        public void DopuniEnergiju_KadaNemaNiJednogIspod100_VracaFalse()
        {
            _mockRepo.Setup(r => r.Svi()).Returns(new List<PodsistemProizvodnje>
            {
                new PodsistemProizvodnje("X2", Tip_Proizvodnje.ECOGREEN, "BG", 150)
            });

            var rezultat = _servis.DopuniEnergiju();

            Assert.That(rezultat, Is.False);
        }

        [Test]
        public void IzdajEnergiju_KadaImaDovoljno_VracaTrue()
        {
            var sistem = new PodsistemProizvodnje("A1", Tip_Proizvodnje.HIDROELEKTRANA, "Dj", 200);
            _mockRepo.Setup(r => r.Svi()).Returns(new[] { sistem });

            var rezultat = _servis.IzdajEnergiju(100);

            Assert.That(rezultat, Is.True);
            Assert.That(sistem.PreostalaKolicina, Is.LessThan(200));
        }

        [Test]
        public void IzdajEnergiju_KadaNemaDovoljno_VracaFalse()
        {
            var sistem = new PodsistemProizvodnje("A2", Tip_Proizvodnje.CVRSTOGORIVO, "Bg", 50);
            _mockRepo.Setup(r => r.Svi()).Returns(new[] { sistem });

            var rezultat = _servis.IzdajEnergiju(100);

            Assert.That(rezultat, Is.False);
        }
    }
}
