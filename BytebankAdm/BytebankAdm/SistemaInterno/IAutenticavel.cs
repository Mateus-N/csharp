namespace BytebankAdm.SistemaInterno
{
    public interface IAutenticavel
    {
        public string Senha { get; set; }

        public bool Autenticar(string senha);
    }
}
