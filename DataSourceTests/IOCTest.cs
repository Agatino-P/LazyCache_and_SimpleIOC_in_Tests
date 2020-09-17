using System;
using Core.Interfaces;
using DataSourceConsumerPrj;
using DataSourceProj;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataSourceTests
{
    [TestClass]
    public class IOCTest
    {
        [TestMethod]
        public void GetOne()
        {
            SimpleIoc.Default.Register<IDataSource>(()=>new DataSourceBis());
            IDataSource tDS = SimpleIoc.Default.GetInstance<IDataSource>();

            string result1 = tDS.GetString(2);
            DataSourceConsumer dataSourceConsumer = new DataSourceConsumer();
            string result2 = dataSourceConsumer.GetLetters(2);
            Assert.IsTrue(result1== result2);
        }
    }
}
