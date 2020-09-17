using Core.Interfaces;
using GalaSoft.MvvmLight.Ioc;

namespace DataSourceConsumerPrj
{
    public class DataSourceConsumer
    {
        private IDataSource _iDS;
        public DataSourceConsumer()
        {
            _iDS = SimpleIoc.Default.GetInstance<IDataSource>();
        }
        public string GetLetters(int number)
        {
            return _iDS.GetString(number);
        }
    }
}
