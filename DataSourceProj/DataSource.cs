using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSourceProj
{
    public class DataSource : IDataSource
    {
        private Dictionary<int, string> _inLetters = new Dictionary<int, string>();
        public DataSource()
        {
            _inLetters.Add(1, "One");
            _inLetters.Add(2, "Two");
            _inLetters.Add(3, "Three");

        }
        public string GetString(int number)
        {
            if (_inLetters.ContainsKey(number))
                return _inLetters[number];
            else
                return "NotPresent";
        }
    }
}
