namespace sistemaDeTarefasT2m.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public User()
        {
            
        }
        public User(int id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            DataCadastro = DateTime.Now;
        }

        internal static User? FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
