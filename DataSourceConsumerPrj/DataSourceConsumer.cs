using Core.Interfaces;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSourceConsumerPrj
{
    public class DataSourceConsumer
    {
        public string GetLetters(int number)
        {
            IDataSource iDS= SimpleIoc.Default.GetInstance<IDataSource>();
            return iDS.GetString(number);
        }
    }
}
