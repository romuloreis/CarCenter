namespace CarCenter.Models.ViewModels
{
    public class NotaViewModel
    {
        public Nota Nota { get; set; }
        public List<Carro> Carros { get; set; }
        public List<Vendedor> Vendedores { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}
