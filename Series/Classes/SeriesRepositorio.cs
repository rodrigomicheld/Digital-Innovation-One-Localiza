using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series
{
    public class SeriesRepositorio : IRepositorio<Series>
    {
        private List<Series> _listSeries = new List<Series>();
        public void Delete(int id)
        {
            _listSeries[id].delete();
        }

        public void Insert(Series entidade)
        {
            _listSeries.Add(entidade);
        }

        public List<Series> List()
        {
            return _listSeries;
        }

        public int NextId()
        {
            return _listSeries.Count;
        }

        public Series ReturnPerId(int id)
        {
            return _listSeries[id];
        }

        public void Update(int id, Series entidade)
        {
            _listSeries[id] = entidade;
        }

        
    }
}