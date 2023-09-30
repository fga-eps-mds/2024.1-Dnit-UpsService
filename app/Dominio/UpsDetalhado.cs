namespace Entidades
{
    public class UpsDetalhado
    {
        public int Ups2022 { get; set; }
        public int Ups2021 { get; set; }
        public int Ups2020 { get; set; }
        public int Ups2019 { get; set; }
        public int Ups2018 { get; set; }
        public int UpsGeral { get; set; }

        public void CalcularUpsGeral()
        {
            UpsGeral = Ups2022 + Ups2021 + Ups2020 + Ups2019 + Ups2018;
        }

    }
}
