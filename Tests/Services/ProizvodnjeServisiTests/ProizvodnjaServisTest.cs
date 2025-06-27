using Domain.Services;
using Moq;
using NUnit.Framework;
using Services.ProizvodnjeServisi;

namespace Tests.Services.ProizvodnjeServisiTests
{
    [TestFixture]
    public class ProizvodnjaServisTests
    {
        private Mock<ISnabdevanjeServis> _mockSnabdevanje = new();

        [SetUp]
        public void Setup()
        {
            _mockSnabdevanje = new Mock<ISnabdevanjeServis>();
        }

        [Test]
        public void ObradiZahtev_SaValidnomKolicinom_VracaTrue()
        {
            _mockSnabdevanje.Setup(x => x.IzdajEnergiju(It.IsAny<double>())).Returns(true);

            var servis = new ProizvodnjaServis(_mockSnabdevanje.Object);
            var rezultat = servis.ObradiZahtev(100);

            Assert.That(rezultat, Is.True);
        }

        [Test]
        public void ObradiZahtev_KadaNemaDovoljnoEnergije_VracaFalse()
        {
            _mockSnabdevanje.Setup(x => x.IzdajEnergiju(It.IsAny<double>())).Returns(false);

            var servis = new ProizvodnjaServis(_mockSnabdevanje.Object);
            var rezultat = servis.ObradiZahtev(1000);

            Assert.That(rezultat, Is.False);
        }

        [TestCase(0)]      // granična vrednost
        [TestCase(0.0001)] // granična - vrlo mala količina
        [TestCase(999999)] // granična - jako velika količina
        public void ObradiZahtev_GranicneVrednosti(double kolicina)
        {
            _mockSnabdevanje.Setup(x => x.IzdajEnergiju(It.IsAny<double>())).Returns(true);

            var servis = new ProizvodnjaServis(_mockSnabdevanje.Object);
            var rezultat = servis.ObradiZahtev(kolicina);

            Assert.That(rezultat, Is.True);
        }

        [TestCase(50)]
        [TestCase(75)]
        [TestCase(200.5)]
        [TestCase(430.7)]
        [TestCase(1.23)]
        public void ObradiZahtev_ProizvoljneVrednosti(double kolicina)
        {
            _mockSnabdevanje.Setup(x => x.IzdajEnergiju(kolicina)).Returns(true);

            var servis = new ProizvodnjaServis(_mockSnabdevanje.Object);
            var rezultat = servis.ObradiZahtev(kolicina);

            Assert.That(rezultat, Is.True);
        }
    }
}
