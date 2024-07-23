using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using PISDK;
using UI2.UserControls;

namespace UI2
{
    public partial class MainWindow : Window
    {
        private readonly DataFetcher _dataFetcher;

        public MainWindow()
        {
            InitializeComponent();
            _dataFetcher = new DataFetcher(); 
            DataContext = _dataFetcher;
        }

        private void Today_Click(object sender, RoutedEventArgs e)
        {
            _dataFetcher.StartRealTimeFetching();
        }

        private void Last7Days_Click(object sender, RoutedEventArgs e)
        {
            _dataFetcher.FetchLast7DaysData();
            
        }

        private void Last14Days_Click(object sender, RoutedEventArgs e)
        {
            _dataFetcher.FetchLast14DaysData();
        }

        private void LastMonth_Click(object sender, RoutedEventArgs e)
        {
            _dataFetcher.FetchLastMonthData();
        }
        private void MachineComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (MachineComboBox.SelectedItem is ComboBoxItem selectedItem && selectedItem != PlaceholderItem)
            {
                string selectedMachine = selectedItem.Content.ToString();

                
                _dataFetcher.UpdateTags(selectedMachine);
                _dataFetcher.StartRealTimeFetching();

                
                if (MachineComboBox.Items.Contains(PlaceholderItem))
                {
                    MachineComboBox.Items.Remove(PlaceholderItem);
                }
            }
            else
            {
                MachineComboBox.SelectedIndex = -1;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _dataFetcher.StopFetching();
        }

    }

}





