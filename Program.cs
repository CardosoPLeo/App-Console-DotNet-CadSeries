using System;
using System.Globalization;
using DIO.Series.Classes;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoDoUsuario = ObterOpcaoDoUsuario();

            while(opcaoDoUsuario.ToUpper() != "X")
            {
                switch(opcaoDoUsuario)
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
                opcaoDoUsuario = ObterOpcaoDoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nosso serviço!");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries", CultureInfo.InvariantCulture);

             var lista = repositorio.Lista();

             if(lista.Count == 0)
             {
                Console.WriteLine("Nenhuma série cadastrada", CultureInfo.InvariantCulture);    
                return;
             }
             
             foreach(var serie in lista)
             {
                 var excluido = serie.RetornaExcluido();

                 Console.WriteLine(" {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluído" : ""), CultureInfo.InvariantCulture);
             }

        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir série", CultureInfo.InvariantCulture);

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("#ID {0}: - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Digite o gênero da série listado acima: ", CultureInfo.InvariantCulture);
            int digitandoGenero  = int .Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da série", CultureInfo.InvariantCulture);
            string digitandoTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano da série", CultureInfo.InvariantCulture);
            int digitandoAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descricação da série", CultureInfo.InvariantCulture);
            string digitandoDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(), 
                                           genero: (Genero)digitandoGenero, 
                                           titulo:digitandoTitulo, 
                                           ano:digitandoAno, 
                                           descricao:digitandoDescricao);
            

             repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Digite o Id da série", CultureInfo.InvariantCulture);
            int indiceSerie = int.Parse(Console.ReadLine());
            
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("#ID {0}: - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Digite o gênero da série listado acima: ", CultureInfo.InvariantCulture);
            int digitandoGenero  = int .Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da série", CultureInfo.InvariantCulture);
            string digitandoTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano da série", CultureInfo.InvariantCulture);
            int digitandoAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descricação da série", CultureInfo.InvariantCulture);
            string digitandoDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie, 
                                              genero: (Genero)digitandoGenero, 
                                              titulo:digitandoTitulo, 
                                              ano:digitandoAno, 
                                              descricao:digitandoDescricao);
            

             repositorio.Atualiza(indiceSerie, atualizaSerie);

        }
        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Digite o Id da série que deseja deletar");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Digite o Id da série que de deseja visualizar");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaId(indiceSerie);
            System.Console.WriteLine(serie);
        } 

        private static string ObterOpcaoDoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Dio Séries ao seu dispor!!", CultureInfo.InvariantCulture);
            System.Console.WriteLine("Informe a opção desejada:", CultureInfo.InvariantCulture);

            System.Console.WriteLine("1- Listar séries ", CultureInfo.InvariantCulture);
            System.Console.WriteLine("2- Inserir uma nova série", CultureInfo.InvariantCulture);
            System.Console.WriteLine("3- Atualizar série", CultureInfo.InvariantCulture);
            System.Console.WriteLine("4- Excluir uma série", CultureInfo.InvariantCulture);
            System.Console.WriteLine("5- Visualizar uma série", CultureInfo.InvariantCulture);
            System.Console.WriteLine("C- Limpar tela", CultureInfo.InvariantCulture);
            System.Console.WriteLine("X- Sair", CultureInfo.InvariantCulture);
            System.Console.WriteLine();

            string opcaoDoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoDoUsuario;
        }


    }
}
