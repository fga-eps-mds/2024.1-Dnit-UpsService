namespace api
{
    public class ListaPaginada<T>
    {
        public int Pagina { get; set; }
        public int ItemsPorPagina { get; set; }
        public int Total { get; set; }
        public int TotalPaginas { get; set; }
        public List<T> Items { get; set; }

        public ListaPaginada(List<T> items, int pagina, int itemsPorPagina, int total)
        {
            Pagina = pagina;
            ItemsPorPagina = itemsPorPagina;
            Total = total;
            TotalPaginas = (int)Math.Ceiling(Total / (double)itemsPorPagina);
            Items = items;
        }
    }
}