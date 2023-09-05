int escolha;
bool running = true;
int codigo = 0;
Dictionary<int, string> tasks = new Dictionary<int, string>();
string filePath = "C:\\Users\\gabri\\source\\repos\\TaskFlow\\taskflow.txt";

void BoasVindas(String palavra) {
    int qtd_letras = palavra.Length;
    String caractere = string.Empty.PadLeft(qtd_letras, '*');

    Console.WriteLine(caractere);
    Console.WriteLine(palavra);
    Console.WriteLine(caractere);
}


void Menu() {
    Console.Clear();
    Console.WriteLine("Selecione uma opção");
    Console.WriteLine(@"
        1) Criar uma tarefa.
        2) Visualizar todas as tarefas.
        3) Editar tarefas.
        4) Remover tarefas;
        0) Sair
    ");

}

void CriarTarefa() {

    Console.Clear();
    BoasVindas("Criando Nova Tarefa");
    Console.WriteLine("\n\n");
    Console.WriteLine("Forneça o título da tarefa : ");
    string tituloTask = Console.ReadLine()!;
    Console.WriteLine("\n");
    Console.WriteLine("Forneça uma descrição da tarefa :");
    string descricaoTask = Console.ReadLine()!;



    Tarefa tarefa = new Tarefa(tituloTask, descricaoTask, "em andamento");
    tasks.Add(codigo++, tarefa.toString());


    try {
        if (File.Exists(filePath)) {
            StreamWriter escritor = new StreamWriter(filePath, true);
            escritor.WriteLine(tarefa.toString());
            escritor.Close();
        } else {
            StreamWriter escritor = new StreamWriter(filePath);
            escritor.WriteLine(tarefa.toString());
            escritor.Close();
        }

    } catch (Exception e) {
        Console.WriteLine(e.Message);
    }


    Console.WriteLine("\n");

    Console.WriteLine("Tarefa adicionada com sucesso !!");
    Console.WriteLine("Digite Qualquer tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    Menu();

}

void LerTarefas() {
    Console.Clear();
    BoasVindas("Visualizando todas as tarefas");
    Console.WriteLine("\n");

    /*foreach(var tarefa in tasks) {
        Console.WriteLine($"{tarefa}");
    } */

    try {
        if (File.Exists(filePath)) {
            StreamReader leitor = new StreamReader(filePath);
            string linha;
            while ((linha = leitor.ReadLine()) != null) {
                Console.WriteLine(linha);
            }
            leitor.Close();
        } else {
            Console.WriteLine("Arquivo Inexistente, verifique e tente novamente !");
        }
    } catch (Exception e) {
        Console.WriteLine(e.Message);
    }

    Console.WriteLine("\n");
    Console.WriteLine("Digite qualquer tecla para voltar ao menu principal");
    Console.ReadKey();
    Menu();
}

void EditarTarefas() {

    Console.Clear();
    BoasVindas("Editando tarefas");
    Console.WriteLine("\n\n");
    Console.WriteLine("Digite o código da tarefa que deseja editar: ");
    int codigoEdit = int.Parse(Console.ReadLine()!);

    if (tasks.ContainsKey(codigoEdit)) {
        tasks.Remove(codigoEdit);

        Console.WriteLine("\n\nEditando...\n\n");
        Console.WriteLine("Atualize o título da tarefa : ");
        string tituloTask = Console.ReadLine()!;
        Console.WriteLine("\n");
        Console.WriteLine("Atualize a descrição da tarefa :");
        string descricaoTask = Console.ReadLine()!;
        Console.WriteLine("Atualize o status da tarefa :");
        string status = Console.ReadLine();

        Tarefa tarefa = new Tarefa(tituloTask, descricaoTask, status);
        tasks.Add(codigoEdit, tarefa.toString());

        Console.WriteLine("Tarefa Atualizada !!\n");
        Console.WriteLine("Digite Qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        Menu();
    } else {
        Console.WriteLine("Tarefa Não existe !!\n");
        Console.WriteLine("Digite Qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
}

void RemoverTarefas() {
    Console.Clear();
    BoasVindas("Removendo Tarefas !!!");
    Console.WriteLine("\n\n");

    Console.WriteLine("Digite o código da tarefa que deseja remover : ");
    int codigoTarefa = int.Parse(Console.ReadLine()!);



    if (tasks.ContainsKey(codigoTarefa)) {
        tasks.Remove(codigoTarefa);
        Console.WriteLine("Tarefa removida com sucesso !!!");
        Console.WriteLine("Aperte uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    } else {
        Console.WriteLine("Não existe esse código !!!");
        Console.WriteLine("Aperte uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }

}



BoasVindas("Seja Bem Vindo ao TaskFlow !!!");
while (running) {
    Menu();
    escolha = int.Parse(Console.ReadLine()!);
    switch (escolha) {
        case 1: CriarTarefa(); break;
        case 2: LerTarefas(); break;
        case 3: EditarTarefas(); break;
        case 4: RemoverTarefas(); break;
        case 0: running = false; break;
    }
}




