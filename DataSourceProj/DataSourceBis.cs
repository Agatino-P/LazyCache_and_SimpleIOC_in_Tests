using Core.Interfaces;
using System.Collections.Generic;

namespace DataSourceProj
{
    public class DataSourceBis : IDataSource
    {
        private Dictionary<int, string> _inLetters = new Dictionary<int, string>();
        public DataSourceBis()
        {
            _inLetters.Add(1, "ONE");
            _inLetters.Add(2, "TWO");
            _inLetters.Add(3, "THREE");

        }
        public string GetString(int number)
        {
            if (_inLetters.ContainsKey(number))
            {
                return _inLetters[number];
            }
            else
            {
                return "NotPresent";
            }
        }
    }
}
