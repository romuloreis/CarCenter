namespace CarCenter.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string Matricula { get; set; }
        
        public double Salario { get; set; }
    }
}
