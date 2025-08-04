namespace sistemaDeTarefasT2m.Entity
{
    public class Tarefas
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public int UserId { get; set; }
        public StatusEnum Status { get; set; }
        public Tarefas()
        {
            DataCriacao = DateTime.Now;
            Status = StatusEnum.Pendente;
        }
        public Tarefas(int id, string descricao, DateTime dataConclusao)
        {
            Id = id;
            Descricao = descricao;
            DataCriacao = DateTime.Now;
            DataConclusao = dataConclusao;
            Status = StatusEnum.Pendente;
        }
        public Tarefas( string descricao, DateTime dataConclusao, int userId)
        {            
            Descricao = descricao;
            DataCriacao = DateTime.Now;
            DataConclusao = dataConclusao;
            Status = StatusEnum.Pendente;
            UserId = userId;
        }
    }
}
