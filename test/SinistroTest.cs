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
            int UPS = 1;
            SinistroStub sinistroStub = new();

            Sinistro sinistroComUps1 = sinistroStub.Ups1();

            sinistroComUps1.CalcularUps();

            Assert.Equal(UPS, sinistroComUps1.Ups);
        }

        [Fact]
        public void CalcularUps_QuandoMetodoForChamado_DeveCalcularUps4()
        {
            int UPS = 4;
            SinistroStub sinistroStub = new();

            Sinistro sinistroComUps1 = sinistroStub.Ups4();

            sinistroComUps1.CalcularUps();

            Assert.Equal(UPS, sinistroComUps1.Ups);
        }

        [Fact]
        public void CalcularUps_QuandoMetodoForChamado_DeveCalcularUps6()
        {
            int UPS = 6;
            SinistroStub sinistroStub = new();

            Sinistro sinistroComUps1 = sinistroStub.Ups6();

            sinistroComUps1.CalcularUps();

            Assert.Equal(UPS, sinistroComUps1.Ups);
        }

        [Fact]
        public void CalcularUps_QuandoMetodoForChamado_DeveCalcularUps13()
        {
            int UPS = 13;
            SinistroStub sinistroStub = new();

            Sinistro sinistroComUps1 = sinistroStub.Ups13();

            sinistroComUps1.CalcularUps();

            Assert.Equal(UPS, sinistroComUps1.Ups);
        }
    }
}
