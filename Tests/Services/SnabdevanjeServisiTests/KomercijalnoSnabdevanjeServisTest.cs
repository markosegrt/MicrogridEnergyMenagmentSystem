using Domain.Models;
using Domain.Repositories.ProizvodnjaRepositories;
using NUnit.Framework;
using Moq;
using Services.SnabdevanjaServisi;
using Domain.Enums;

namespace Tests.Services.SnabdevanjeServisiTests
{
    [TestFixture]
    public class KomercijalnoSnabdevanjeServisTests
    {
        private Mock<IProizvodnjaRepository> _mockRepo = null!;
        private KomercijalnoSnabdevanjeServis _servis = null!;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IProizvodnjaRepository>();
            _servis = new KomercijalnoSnabdevanjeServis(_mockRepo.Object);
        }

        [Test]
        public void DopuniEnergiju_KadaJeIspod100_VracaTrue()
        {
            var lista = new List<PodsistemProizvodnje>
            {
                new PodsistemProizvodnje("K1", Tip_Proizvodnje.ECOGREEN, "Lok1", 70)
            };
            _mockRepo.Setup(r => r.Svi()).Returns(lista);

            var rezultat = _servis.DopuniEnergiju();

            Assert.That(rezultat, Is.True);
            Assert.That(lista[0].PreostalaKolicina, Is.GreaterThan(70));
        }

        [Test]
        public void DopuniEnergiju_KadaNemaIspod100_VracaFalse()
        {
            _mockRepo.Setup(r => r.Svi()).Returns(new[]
            {
                new PodsistemProizvodnje("K2", Tip_Proizvodnje.CVRSTOGORIVO, "Lok2", 150)
            });

            var rezultat = _servis.DopuniEnergiju();

            Assert.That(rezultat, Is.False);
        }

        [Test]
        public void IzdajEnergiju_KadaImaDovoljno_VracaTrue()
        {
            var sistem = new PodsistemProizvodnje("K3", Tip_Proizvodnje.HIDROELEKTRANA, "Lok3", 300);
            _mockRepo.Setup(r => r.Svi()).Returns(new[] { sistem });

            var rezultat = _servis.IzdajEnergiju(120);

            Assert.That(rezultat, Is.True);
            Assert.That(sistem.PreostalaKolicina, Is.LessThan(300));
        }

        [Test]
        public void IzdajEnergiju_KadaNemaDovoljno_VracaFalse()
        {
            var sistem = new PodsistemProizvodnje("K4", Tip_Proizvodnje.HIDROELEKTRANA, "Lok4", 90);
            _mockRepo.Setup(r => r.Svi()).Returns(new[] { sistem });

            var rezultat = _servis.IzdajEnergiju(200);

            Assert.That(rezultat, Is.False);
        }
    }
}
