//Aprendendo C#

//List<string> listaDeBandas = new List<string>();
Dictionary<string, List<int>> listaDeBandas = new Dictionary<string, List<int>>();


void ExibirLogo (){
      Console.WriteLine(@"
░█████╗░██████╗░██████╗░███████╗███╗░░██╗██████╗░███████╗███╗░░██╗██████╗░░█████╗░ ░█████╗░░░░██╗░██╗░
██╔══██╗██╔══██╗██╔══██╗██╔════╝████╗░██║██╔══██╗██╔════╝████╗░██║██╔══██╗██╔══██╗  ██╔══██╗██████████╗
███████║██████╔╝██████╔╝█████╗░░██╔██╗██║██║░░██║█████╗░░██╔██╗██║██║░░██║██║░░██║  ██║░░╚═╝╚═██╔═██╔═╝
██╔══██║██╔═══╝░██╔══██╗██╔══╝░░██║╚████║██║░░██║██╔══╝░░██║╚████║██║░░██║██║░░██║  ██║░░██╗██████████╗
██║░░██║██║░░░░░██║░░██║███████╗██║░╚███║██████╔╝███████╗██║░╚███║██████╔╝╚█████╔╝  ╚█████╔╝╚██╔═██╔══╝
╚═╝░░╚═╝╚═╝░░░░░╚═╝░░╚═╝╚══════╝╚═╝░░╚══╝╚═════╝░╚══════╝╚═╝░░╚══╝╚═════╝░░╚════╝░  ░╚════╝░░╚═╝░╚═╝░░░ ");
}

void MenuInicial ()
{
  int dados = 0;
  do{
      ExibirLogo();
      Console.WriteLine ("\n1 - Cadastrar bandas");
      Console.WriteLine ("2 - Mostrar todas as bandas");
      Console.WriteLine ("3 - Avaliar bandas");
      Console.WriteLine("4 - Calcular media de avaliação");
      Console.WriteLine("5 - Sair da aplicação");
      Console.Write ("\nDigite a opção: ");
      dados = int.Parse(Console.ReadLine()!);

      switch (dados)
      {
        case 1: RegistroBandas();
          break;
        case 2: MostrarBandasRegistradas();
          break;
        case 3: AvaliarBanda();
          break;
        case 4: CalcularMediaBanda();
          break;
         case 5: Console.WriteLine("Aplicação finalizada");
          break;
        default: Console.WriteLine("Opção invalida");
        break;
      }
  }while(dados != 5);
}


void RegistroBandas(){
  Console.Clear();
  TituloDoMenu("Registro de bandas");
  Console.Write("Digite o nome da banda: ");
  listaDeBandas.Add(Console.ReadLine()!, new List<int>());
  Console.WriteLine("A banda foi cadastrada com sucesso!");
  Thread.Sleep(2000);
  Console.Clear();
  MenuInicial();
}

void MostrarBandasRegistradas(){
  Console.Clear();
  TituloDoMenu("Exibindo bandas registradas");
    foreach(string banda in listaDeBandas.Keys)
    {
      Console.WriteLine($"{banda}");
    }
  
  Console.Write("\nDigite qualquer tecla para retornar ao menu principal: ");
  Console.ReadKey();

}

void TituloDoMenu (string titulo){
  int tamanhoTitulo = titulo.Length;
  string asterisco = string.Empty.PadLeft(tamanhoTitulo, '*');
  Console.WriteLine(asterisco);
  Console.WriteLine(titulo);
  Console.WriteLine(asterisco);
}

void AvaliarBanda(){
  Console.Clear();
  TituloDoMenu("Avaliar banda");
  Console.Write("Digite o nome da banda a qual deseja avaliar: ");
  string bandaNome = Console.ReadLine()!;
  if (listaDeBandas.ContainsKey(bandaNome)){
    Console.Write($"Qual a nota que a banda {bandaNome} merece: ");
    int nota = int.Parse(Console.ReadLine()!);
    listaDeBandas[bandaNome].Add(nota);
    Console.WriteLine($"\nA nota foi registrada com sucesso para a banda {bandaNome}");
    Thread.Sleep(4000);
    Console.Clear();
    MenuInicial();

  } else{
    Console.WriteLine($"\nA banda {bandaNome} não foi encontrada");
    Console.Write("Digite qualquer tecla para retornar ao menu principal: ");
    Console.ReadKey();
    Console.Clear();
    MenuInicial();
  }

}

 void CalcularMediaBanda(){
    Console.Clear();
    TituloDoMenu("Calcular Media da Banda");
    Console.WriteLine("Digite o nome da banda a qual deseja calcular a media");
    string bandaNome = Console.ReadLine()!;
    double mediaBanda = 0.0;
    if (listaDeBandas.ContainsKey(bandaNome)){
      
      foreach(int nota in listaDeBandas[bandaNome]){
          mediaBanda = mediaBanda + nota;
      }
        mediaBanda = mediaBanda/ listaDeBandas[bandaNome].Count;
        Console.WriteLine($"\nA media foi {mediaBanda}");
        Thread.Sleep(4000);
        Console.Clear();
        MenuInicial();
      } else{
        Console.WriteLine($"\nA banda {bandaNome} não foi encontrada");
        Console.Write("Digite qualquer tecla para retornar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        MenuInicial();
      }
 }    
MenuInicial();