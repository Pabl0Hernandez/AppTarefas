namespace AppTarefas.Models
{
    public class Tarefa
    {
        // Nome da chave primaria deve ser Nome da Classe + "ID"
        public int TarefaID { get; set; } // ID é a chave primaria
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public bool Concluida { get; set; }

    }
}
