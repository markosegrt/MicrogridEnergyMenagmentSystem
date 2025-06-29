using Domain.Repositories.EvidencijaRepositories;
using Domain.Services;
using Moq;
using NUnit.Framework;
using Services.EvidencijeServisi;

namespace Tests.Services.EvidencijeServisiTests
{
    [TestFixture]
    public class EvidencijaUListiServisTests
    {
        private Mock<IEvidencijaRepository> _mockRepo = new();
        private IEvidencijaServis _servis = null!;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IEvidencijaRepository>();
            _servis = new EvidencijaUListiServis(_mockRepo.Object);
        }

        //bazicni slucaj

        [Test]
        public void Zapisi_ValidnaKolicina_VracaTrue()
        {
            _mockRepo.Setup(r => r.DodajEvidenciju(It.IsAny<string>())).Returns(true);
            bool rezultat = _servis.Zapisi(150);
            Assert.That(rezultat, Is.True);
        }

        [Test]
        public void Zapisi_NegativnaKolicina_IpakVracaTrueJerNeValidira()
        {
            _mockRepo.Setup(r => r.DodajEvidenciju(It.IsAny<string>())).Returns(true);
            bool rezultat = _servis.Zapisi(-100);
            Assert.That(rezultat, Is.True);
        }

        [Test]
        public void Zapisi_KolicinaNula_VracaTrueJerNeValidira()
        {
            _mockRepo.Setup(r => r.DodajEvidenciju(It.IsAny<string>())).Returns(true);
            bool rezultat = _servis.Zapisi(0);
            Assert.That(rezultat, Is.True);
        }

        [Test]
        public void Zapisi_RepoVracaFalse_VracaTrueJerSeNeProverava()
        {
            _mockRepo.Setup(r => r.DodajEvidenciju(It.IsAny<string>())).Returns(false);
            bool rezultat = _servis.Zapisi(200);
            Assert.That(rezultat, Is.True);
        }

        //Granicni

        [TestCase(double.MaxValue)]
        [TestCase(double.MinValue)]
        [TestCase(double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity)]
        [TestCase(double.NaN)]
        [TestCase(0.0000001)]
        public void Zapisi_EkstremneVrednosti_VracaTrue(double kolicina)
        {
            _mockRepo.Setup(r => r.DodajEvidenciju(It.IsAny<string>())).Returns(true);
            bool rezultat = _servis.Zapisi(kolicina);
            Assert.That(rezultat, Is.True);
        }

        //Dodatni slucajevi

        [Test]
        public void VratiEvidenciju_VracaFormatiranTekst()
        {
            _mockRepo.Setup(r => r.VratiEvidenciju()).Returns(new List<string> { "log1", "log2" });

            string rezultat = _servis.VratiEvidenciju();

            Assert.That(rezultat, Contains.Substring("log1"));
            Assert.That(rezultat, Contains.Substring("log2"));
        }

        [Test]
        public void VratiEvidenciju_PraznaLista_VracaPrazanString()
        {
            _mockRepo.Setup(r => r.VratiEvidenciju()).Returns(new List<string>());
            string rezultat = _servis.VratiEvidenciju();
            Assert.That(rezultat, Is.EqualTo(""));
        }

        [Test]
        public void Zapisi_RepoBacaException_VracaFalse()
        {
            _mockRepo.Setup(r => r.DodajEvidenciju(It.IsAny<string>())).Throws(new Exception());
            bool rezultat = _servis.Zapisi(100);
            Assert.That(rezultat, Is.False);
        }

        [Test]
        public void Zapisi_PozivaDodajEvidenciju()
        {
            _mockRepo.Setup(r => r.DodajEvidenciju(It.IsAny<string>())).Returns(true);
            _servis.Zapisi(200);
            _mockRepo.Verify(r => r.DodajEvidenciju(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Zapisi_FormatZapisaSadrziKW()
        {
            string? logPoruka = null;
            _mockRepo.Setup(r => r.DodajEvidenciju(It.IsAny<string>()))
                     .Callback<string>(unos => logPoruka = unos)
                     .Returns(true);

            _servis.Zapisi(99.5);

            Assert.That(logPoruka, Does.Contain("kW"));
            Assert.That(logPoruka, Does.Contain("Izdato je"));
        }
    }
}
