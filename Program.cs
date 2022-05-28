using System;
using CadastroDeSeries.Classes;
using CadastroDeSeries.Enum;

namespace CadastroDeSeries
{
  class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(String[] args)
    {
      string opcaoUsuario = MenuOpcoes();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarSeries();
            break;
          case "2":
            InserirSerie();
            break;
          case "3":
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = MenuOpcoes();
      }

    }

    private static void ListarSeries()
    {
      Console.WriteLine();
      System.Console.WriteLine("Listar Series");

      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        System.Console.WriteLine("Nenhua série cadastrada");
        return;
      }

      foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluido();
        System.Console.WriteLine("#ID {0}: - {1} - Estatus exclusao: {2}",
                                  serie.retornaId(), serie.retornaTitulo(),
                                  (excluido ? "Excluido" : "Não excluido"));
      }
      Console.WriteLine();
    }

    private static void InserirSerie()
    {
      Console.WriteLine();
      System.Console.WriteLine("Inserir Nova Serie");
      Console.WriteLine();

      foreach (int i in Enum.Genero.GetValues(typeof(Genero)))
      {
        System.Console.WriteLine("{0} - {1}", i, Enum.Genero.GetName(typeof(Genero), i));
      }

      System.Console.WriteLine("Escolha o gênero de acordo com as opções dadas acima");
      int entradaGenero = int.Parse(Console.ReadLine());

      System.Console.WriteLine("Digite o titulo da série");
      string nomeTitulo = Console.ReadLine();

      System.Console.WriteLine("Digite o ano de incio da série");
      int anoSerie = int.Parse(Console.ReadLine());

      System.Console.WriteLine("Digite a descrição da série");
      string descricaoSerie = Console.ReadLine();

      Series novaSerie = new Series(id: repositorio.ProximoId(),
                                  genero: (Genero)entradaGenero,
                                  titulo: nomeTitulo,
                                  descricao: descricaoSerie,
                                  ano: anoSerie);

      repositorio.Insere(novaSerie);
      Console.WriteLine();
    }

    private static void AtualizarSerie()
    {
      Console.WriteLine();
      Console.WriteLine("Qual id deseja atualizar?");
      int idSerie = int.Parse(Console.ReadLine());

      foreach (int i in Enum.Genero.GetValues(typeof(Genero)))
      {
        System.Console.WriteLine("{0} - {1}", i, Enum.Genero.GetName(typeof(Genero), i));
      }

      System.Console.WriteLine("Escolha o gênero de acordo com as opções dadas acima");
      int entradaGenero = int.Parse(Console.ReadLine());

      System.Console.WriteLine("Digite o titulo da série");
      string nomeTitulo = Console.ReadLine();

      System.Console.WriteLine("Digite o ano de incio da série");
      int anoSerie = int.Parse(Console.ReadLine());

      System.Console.WriteLine("Digite a descrição da série");
      string descricaoSerie = Console.ReadLine();

      Series serieAtualizada = new Series(id: idSerie,
                                  genero: (Genero)entradaGenero,
                                  titulo: nomeTitulo,
                                  descricao: descricaoSerie,
                                  ano: anoSerie);

      repositorio.Atualiza(idSerie, serieAtualizada);
    }


    private static void ExcluirSerie()
    {
      System.Console.WriteLine("Qual id da série que deseja remover?");
      int idSerieRemocao = int.Parse(Console.ReadLine());

      repositorio.Excluir(idSerieRemocao);
    }

    private static void VisualizarSerie()
    {
      System.Console.WriteLine("Digite o id da série que deseja visualizar");
      int idVisualiza = int.Parse(Console.ReadLine());

      var serie = repositorio.RetornaPorId(idVisualiza);

      System.Console.WriteLine(serie);
    }
    public static string MenuOpcoes()
    {
      System.Console.WriteLine();
      System.Console.WriteLine("SeriesDio ao seu dispor!!!");
      System.Console.WriteLine("Informa a opção cuja ação desejada");
      System.Console.WriteLine();
      System.Console.WriteLine("1 - Listar séries");
      System.Console.WriteLine("2 - Inserir nova série");
      System.Console.WriteLine("3 - Atualizar série");
      System.Console.WriteLine("4 - Excluir série");
      System.Console.WriteLine("5 - Visualizar série");
      System.Console.WriteLine("C - Limpar tela");
      System.Console.WriteLine("X - Sair da aplicação");

      Console.WriteLine();
      string opcaoUsuario = Console.ReadLine().ToUpper();
      System.Console.WriteLine();
      return opcaoUsuario;
    }
  }

}