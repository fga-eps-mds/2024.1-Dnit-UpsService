using Entidades;
using test.Stub;
using Xunit;

namespace test
{
    public class SinistroTest
    {
        [Fact]
        public void CalcularUps_QuandoMetodoForChamado_DeveCalcularUps1()
        {
            var sinistro = SinistroStub.Ups1();

            sinistro.CalcularUps();

            Assert.True(1 == sinistro.Ups);
        }

        [Fact]
        public void CalcularUps_QuandoMetodoForChamado_DeveCalcularUps4()
        {
            var sinistro = SinistroStub.Ups4();

            sinistro.CalcularUps();

            Assert.True(4 == sinistro.Ups);
        }

        [Fact]
        public void CalcularUps_QuandoMetodoForChamado_DeveCalcularUps6()
        {
            var sinistro = SinistroStub.Ups6();

            sinistro.CalcularUps();

            Assert.True(6 == sinistro.Ups);
        }

        [Fact]
        public void CalcularUps_QuandoMetodoForChamado_DeveCalcularUps13()
        {
            var sinistro = SinistroStub.Ups13();

            sinistro.CalcularUps();

            Assert.True(13 == sinistro.Ups);
        }
    }
}
