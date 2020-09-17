using Core.Interfaces;
using DataSourceConsumerPrj;
using DataSourceProj;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Windows;

namespace LazyCacheTestApp
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            SimpleIoc.Default.Register<IDataSource>(
                () => new DataSource()
                );
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
            DataSourceConsumer dataSourceConsumer = new DataSourceConsumer();
                string letters = dataSourceConsumer.GetLetters(Number);
                MessageBox.Show(letters, Number.ToString(), MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

}

