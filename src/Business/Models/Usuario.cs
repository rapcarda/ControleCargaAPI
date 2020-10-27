namespace Business.Models
{
    public class Usuario: EntityBase
    {
        public int Codigo { get; set; }
        public string Nome  { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
