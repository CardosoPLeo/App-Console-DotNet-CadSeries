using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> listaDeSeries = new List<Series>();
        public void Atualiza(int id, Series objeto)
        {
            listaDeSeries[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaDeSeries[id].Excluir();
        }

        public void Insere(Series objeto)
        {
            listaDeSeries.Add(objeto);
        }

        public List<Series> Lista()
        {
            return listaDeSeries;
        }

        public int ProximoId()
        {
            return listaDeSeries.Count;
        }

        public Series RetornaId(int id)
        {
            return listaDeSeries[id];
        }
    }
}