class Tarefa {

    private String titulo { get; set; }
    private String descricao { get; set; }
    private String status { get; set; }

    private String dataHoraAtual{ get; }


        // DateTime.Now;
    

    //futuramente data de conclusão

    public Tarefa(string titulo,
                  string descricao,
                  string status) {
        this.titulo = titulo;
        this.descricao = descricao;
        this.status = status;

        DateTime onTimeDate = DateTime.Now;
        string formatoHoraData = "dd/MM/yyyy HH:mm:ss";
        this.dataHoraAtual = onTimeDate.ToString(formatoHoraData);
    }

    public String toString() {
        return $@"
        
            Título da tarefa : {this.titulo},
            Descrição da tarefa : {this.descricao},
            Status da tarefa : {this.status},
            Data de criação da tarefa : {this.dataHoraAtual}
        
        ";
    }

    

}