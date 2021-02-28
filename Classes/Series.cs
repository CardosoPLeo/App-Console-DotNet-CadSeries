using System;
namespace DIO.Series
{
    public class Series : EntidadeBase
    {
        public Series(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        private  Genero Genero { get; set; } 
        private  string Titulo { get; set; } ="";
        private string Descricao { get; set; }="";
        private int Ano { get; set; }= 0;
        private bool Excluido { get; set; } = false;

        public override string ToString()
        {
            string retorno ="";
            retorno += "Gênero" + this.Genero + Environment.NewLine;
            retorno += "Título" + this.Genero + Environment.NewLine;
            retorno += "Descrição" + this.Genero + Environment.NewLine;
            retorno += "Ano de Início" + this.Genero + Environment.NewLine;
            retorno += "Excluído" + this.Excluido + Environment.NewLine;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;

        }
        public bool RetornaExcluido()
        {
            return this.Excluido;

        }
    }

}