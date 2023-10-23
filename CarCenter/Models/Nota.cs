namespace CarCenter.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string DataEmissao { get; set; }
        public DateTime Garantia { get; set; }
        public double ValorVenda { get; set; }
        public int IdCliente { get; set; }
        public Cliente Comprador{ get; set; }
        public int IdVendedor { get; set; }
        public Vendedor Vendedor { get; set; }
        public int IdCarro { get; set; }
        public Carro Carro { get; set; }
    }
}
