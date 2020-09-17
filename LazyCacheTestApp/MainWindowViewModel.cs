using Core.Interfaces;
using DataSourceConsumerPrj;
using DataSourceProj;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using LazyCache;
using System;
using System.Windows;

namespace LazyCacheTestApp
{
    public class MainWindowViewModel : ViewModelBase
    {
        private DataSourceConsumer dataSourceConsumer;

        private IAppCache cache = new CachingService() { DefaultCacheDuration = 10 };
        
        public MainWindowViewModel()
        {
            SimpleIoc.Default.Register<IDataSource>(
                () => new DataSource()
                );
            dataSourceConsumer = new DataSourceConsumer();
            //SimpleIoc.Default.Register<IDataSource>(
            //    () => new DataSourceBis()
            //    );
        }

        private int _number=1; public int Number { get => _number; set { Set(() => Number, ref _number, value); } }

        private RelayCommand _getLettersCmd;
        public RelayCommand GetLettersCmd => _getLettersCmd ?? (_getLettersCmd = new RelayCommand(
            () => getLetters(),
            () => Number!=0,
            keepTargetAlive: true
            ));
        private void getLetters()
        {
            Func<string> retrieveCachedLetters = () => dataSourceConsumer.GetLetters(Number);
            string letters= cache.GetOrAdd(Number.ToString(), retrieveCachedLetters);
                //string letters = dataSourceConsumer.GetLetters(Number);
                MessageBox.Show(letters, Number.ToString(), MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

}

