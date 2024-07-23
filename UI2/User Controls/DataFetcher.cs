///////////
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using PISDK;
using System.Linq;
using PITimeServer;
using System.Globalization;
using System.Reflection.PortableExecutable;
namespace UI2.UserControls
{
    public class HistoricalData
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public double Value { get; set; }
    }
    public class HistoricalData2
    {
        public string Name2 { get; set; }
        public DateTime Time2 { get; set; }
        public double Value2 { get; set; }
    }
    public class DataFetcher : INotifyPropertyChanged
    {
        public ObservableCollection<HistoricalData> HistoricalData { get; private set; }
        public ObservableCollection<HistoricalData2> HistoricalData2 { get; private set; }
        private PISDK.PISDK _piSdk;
        private PISDK.Server _piServer;
        private DispatcherTimer _dataFetchTimer;
        public ObservableCollection<string> Machines { get; private set; }

        // Chart data
        public SeriesCollection LineSeriesCollection { get; private set; }
        public ObservableCollection<string> Labels { get; private set; }

        private string _selectedMachine;
        public string SelectedMachine
        {
            get { return _selectedMachine; }
            set
            {
                if (_selectedMachine != value)
                {
                    _selectedMachine = value;
                    OnPropertyChanged(nameof(SelectedMachine));
                    UpdateTags(_selectedMachine); // Update tags based on the selected machine
                }
            }
        }
        private string _bagger1Speed;
        public string Bagger1Speed
        {
            get { return _bagger1Speed; }
            set
            {
                if (_bagger1Speed != value)
                {
                    _bagger1Speed = value;
                    OnPropertyChanged(nameof(Bagger1Speed));
                }
            }
        }
        private string _bagger2Speed;
        public string Bagger2Speed
        {
            get { return _bagger2Speed; }
            set
            {
                if (_bagger2Speed != value)
                {
                    _bagger2Speed = value;
                    OnPropertyChanged(nameof(Bagger2Speed));
                }
            }
        }

        // TextBlock data
        private string _stackerSpeed;
        public string StackerSpeed
        {
            get { return _stackerSpeed; }
            set
            {
                if (_stackerSpeed != value)
                {
                    _stackerSpeed = value;
                    OnPropertyChanged(nameof(StackerSpeed));
                }
            }
        }
        //VNBD_BD03_CurrentShift_StopNumber
        private string _stopNumber;
        public string StopNumber
        {
            get { return _stopNumber; }
            set
            {
                if (_stopNumber != value)
                {
                    _stopNumber = value;
                    OnPropertyChanged(nameof(StopNumber));
                }
            }
        }

        //VNBD_BD03_PrevDownTime
        private string _PrevDownTime;
        public string PrevDownTime
        {
            get { return _PrevDownTime; }
            set
            {
                if (_PrevDownTime != value)
                {
                    _PrevDownTime = value;
                    OnPropertyChanged(nameof(PrevDownTime));
                }
            }
        }

        private string _actualSpeed;
        public string ActualSpeed
        {
            get { return _actualSpeed; }
            set
            {
                if (_actualSpeed != value)
                {
                    _actualSpeed = value;
                    OnPropertyChanged(nameof(ActualSpeed));
                }
            }
        }
        private string _oee;
        public string OEE
        {
            get { return _oee; }
            set
            {
                if (_oee != value)
                {
                    _oee = value;
                    OnPropertyChanged(nameof(OEE));
                }
            }
        }

        private string _waste;
        public string Waste
        {
            get { return _waste; }
            set
            {
                if (_waste != value)
                {
                    _waste = value;
                    OnPropertyChanged(nameof(Waste));
                }
            }
        }

        public DataFetcher()
        {
            // Initialize LiveCharts
            LineSeriesCollection = new SeriesCollection
        {
            new LineSeries
            {
                Title="Actual speed",
                Values = new ChartValues<ObservableValue>()
            }
        };
            Labels = new ObservableCollection<string>();           
            InitializePISDK();            
            _dataFetchTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(5)
            };
            _dataFetchTimer.Tick += DataFetchTimer_Tick;
            _dataFetchTimer.Start();
            Machines = new ObservableCollection<string> { "BD04", "BD05" };
            SelectedMachine = Machines.FirstOrDefault(); 
            HistoricalData = new ObservableCollection<HistoricalData>();
            HistoricalData2 = new ObservableCollection<HistoricalData2>();

        }

        private void InitializePISDK()
        {
            // Create an instance of PISDK
            _piSdk = new PISDK.PISDK();
            _piServer = _piSdk.Servers["vnbda020"];
            _piServer.Open();
        }
        private string actualSpeedTag;
        private string stackerSpeedTag;
        private string oeeTag;
        private string wasteTag;
        private string bagger1Tag;
        private string bagger2Tag;
        public void UpdateTags(string _selectedMachine)
        {
            if (string.IsNullOrEmpty(_selectedMachine))
                return;

            // Define tags for each machine
            switch (_selectedMachine)
            {
                case "BD04":
                    actualSpeedTag = "VNBD_BD04_MMC1_OSI_ProductionData.ActualSpeed";
                    stackerSpeedTag = "VNBD_BD04_MMC1_OSI_ProductionData.StackerSpeed";
                    oeeTag = "VNBD_BD04_OSI_Production Data.OEE1";
                    wasteTag = "VNBD_BD04_OSI_Production Data.Waste";
                    bagger1Tag = "VNBD_BD04_MMC1_OSI_ProductionData.Bagger1Speed";
                    bagger2Tag = "VNBD_BD04_MMC1_OSI_ProductionData.Bagger2Speed";
                    break;
                case "BD05":
                    actualSpeedTag = "VNBD_BD05_MMC1_OSI_ProductionData.ActualSpeed";
                    stackerSpeedTag = "VNBD_BD05_MMC1_OSI_ProductionData.StackerSpeed";
                    oeeTag = "VNBD_BD05_OSI_Production Data.OEE1";
                    wasteTag = "VNBD_BD05_OSI_Production Data.Waste";
                    bagger1Tag = "VNBD_BD05_MMC1_OSI_ProductionData.Bagger1Speed";
                    bagger2Tag = "VNBD_BD05_MMC1_OSI_ProductionData.Bagger2Speed";
                    break;
                case "BD06":
                    actualSpeedTag = "VNBD_BD06_MMC1_OSI_ProductionData.ActualSpeed";
                    stackerSpeedTag = "VNBD_BD06_MMC1_OSI_ProductionData.StackerSpeed";
                    oeeTag = "VNBD_BD06_OSI_Production Data.OEE1";
                    wasteTag = "VNBD_BD06_OSI_Production Data.Waste";
                    bagger1Tag = "VNBD_BD05_MMC1_OSI_ProductionData.Bagger1Speed";
                    bagger2Tag = "VNBD_BD05_MMC1_OSI_ProductionData.Bagger2Speed";
                    break;
                case "BD07":
                    actualSpeedTag = "VNBD_BD07_MMC2_OSI_ProductionData.ActualSpeed";
                    stackerSpeedTag = "VNBD_BD07_MMC2_OSI_ProductionData.StackerSpeed";
                    oeeTag = "VNBD_BD07_OSI_Production Data.OEE1";
                    wasteTag = "VNBD_BD07_OSI_Production Data.Waste";
                    bagger1Tag = "VNBD_BD07_MMC2_OSI_ProductionData.Bagger1Speed";
                    bagger2Tag = "VNBD_BD07_MMC2_OSI_ProductionData.Bagger2Speed";
                    break;
                case "BD08":
                    actualSpeedTag = "VNBD_BD08_MMC4_OSI_ProductionData.ActualSpeed";
                    stackerSpeedTag = "VNBD_BD08_MMC4_OSI_ProductionData.StackerSpeed";
                    oeeTag = "VNBD_BD08_OSI_Production Data.OEE1";
                    wasteTag = "VNBD_BD08_OSI_Production Data.Waste";
                    bagger1Tag = "VNBD_BD08_MMC4_OSI_ProductionData.Bagger1Speed";
                    bagger2Tag = "VNBD_BD08_MMC4_OSI_ProductionData.Bagger2Speed";
                    break;
                case "BD09":
                    actualSpeedTag = "VNBD_BD09_MMC4_OSI_ProductionData.ActualSpeed";
                    stackerSpeedTag = "VNBD_BD09_MMC4_OSI_ProductionData.StackerSpeed";
                    oeeTag = "VNBD_BD09_OSI_Production Data.OEE1";
                    wasteTag = "VNBD_BD09_OSI_Production Data.Waste";
                    bagger1Tag = "VNBD_BD09_MMC4_OSI_ProductionData.Bagger1Speed";
                    bagger2Tag = "VNBD_BD09_MMC4_OSI_ProductionData.Bagger2Speed";
                    break;
                case "BD10":
                    actualSpeedTag = "VNBD_BD10_MMC5_OSI_ProductionData.ActualSpeed";
                    stackerSpeedTag = "VNBD_BD10_MMC5_OSI_ProductionData.StackerSpeed";
                    oeeTag = "VNBD_BD10_OSI_Production Data.OEE1";
                    wasteTag = "VNBD_BD10_OSI_Production Data.Waste";
                    bagger1Tag = "VNBD_BD10_MMC5_OSI_ProductionData.Bagger1Speed";
                    bagger2Tag = "VNBD_BD10_MMC5_OSI_ProductionData.Bagger2Speed";
                    break;
                    
            }
        }
        public void DataFetchTimer_Tick(object sender, EventArgs e)
        {
            // Retrieve real-time data from PI Server
            try
            {
                // Fetch ActualSpeed, OEE, Waste from PI Server
                PISDK.PIPoint actualSpeedPoint = _piServer.PIPoints[actualSpeedTag];
                PISDK.PIPoint oeePoint = _piServer.PIPoints[oeeTag];
                PISDK.PIPoint wastePoint = _piServer.PIPoints[wasteTag];
                PISDK.PIPoint stackerSpeedPoint = _piServer.PIPoints[stackerSpeedTag];
                PISDK.PIPoint bagger1Point = _piServer.PIPoints[bagger1Tag];
                PISDK.PIPoint bagger2Point = _piServer.PIPoints[bagger2Tag];
                // Update TextBlock values
                UpdateTextBlockValues(stackerSpeedPoint, oeePoint, wastePoint);

                UpdateHistoricalData(bagger1Point, bagger2Point);

                // Update chart values
                UpdateChartValues(actualSpeedPoint);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"Error fetching data: {ex.Message}");
            }
        }
        private void UpdateHistoricalData(PISDK.PIPoint bagger1Point, PISDK.PIPoint bagger2Point)
        {
            // Update historical data collection
            if (bagger1Point != null)
            {
                
                PISDK.PIValue bagger1Value = bagger1Point.Data.Snapshot;
                PISDK.PIValue bagger2Value = bagger2Point.Data.Snapshot;

                if (bagger1Value != null)
                {
                   
                    double bagger1value = Convert.ToDouble(bagger1Value.Value);
                    double Bagger1scaledValue = Math.Min(bagger1value, 2000); 
                    double bagger2value = Convert.ToDouble(bagger2Value.Value);
                    double Bagger2scaledValue = Math.Min(bagger2value, 2000); 


                    HistoricalData.Add(new HistoricalData
                    {
                        Name = "Bagger 1 Speed",
                        Time = DateTime.Now,
                        Value = Bagger1scaledValue
                    });

                    HistoricalData.Add(new HistoricalData
                    {
                        Name = "Bagger 2 Speed",
                        Time = DateTime.Now,
                        Value = Bagger2scaledValue
                    });


                    // Limit number of records (adjust as needed)
                    const int maxRecords = 100;
                    if (HistoricalData.Count > maxRecords)
                    {
                        HistoricalData.RemoveAt(0);
                    }
                }
            }
        }
        private void UpdateTextBlockValues(PISDK.PIPoint stackerSpeedPoint, PISDK.PIPoint oeePoint, PISDK.PIPoint wastePoint)
        {
            // Update ActualSpeed
            if (stackerSpeedPoint != null)
            {
                PISDK.PIValue stackerSpeedValue = stackerSpeedPoint.Data.Snapshot;
                if (stackerSpeedValue != null)
                {
                    double value = Convert.ToDouble(stackerSpeedValue.Value);
                    double scaledValue = Math.Min(value, 2000); 
                    StackerSpeed = scaledValue.ToString();
                }
            }

            // Update OEE
            if (oeePoint != null)
            {
                PISDK.PIValue oeeValue = oeePoint.Data.Snapshot;
                if (oeeValue != null)
                {
                    double value = Convert.ToDouble(oeeValue.Value);
                    double scaledValue = Math.Min(value, 2000);
                    OEE = scaledValue.ToString(); 
                }
            }

            // Update Waste
            if (wastePoint != null)
            {
                PISDK.PIValue wasteValue = wastePoint.Data.Snapshot;
                if (wasteValue != null)
                {
                    double value = Convert.ToDouble(wasteValue.Value);
                    double scaledValue = Math.Min(value, 2000); 
                    Waste = scaledValue.ToString();
                }
            }
        }
        private void UpdateChartValues(PISDK.PIPoint actualSpeedPoint)
        {
            // Update series values for chart
            try
            {
                if (actualSpeedPoint != null)
                {
                    PISDK.PIValue actualSpeedValue = actualSpeedPoint.Data.Snapshot;
                    if (actualSpeedValue != null)
                    {
                        double value = Convert.ToDouble(actualSpeedValue.Value);
                        double scaledValue = Math.Min(value, 2000); 

                        // Update chart values
                        LineSeriesCollection[0].Values.Add(new ObservableValue(scaledValue));
                        Labels.Add(DateTime.Now.ToString("HH:mm:ss"));
                        
                        const int maxPoints = 7;
                        if (LineSeriesCollection[0].Values.Count > maxPoints)
                        {
                            LineSeriesCollection[0].Values.RemoveAt(0);
                            Labels.RemoveAt(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"Error fetching data for chart: {ex.Message}");
            }
        }
        public void FetchHistoricalData(DateTime startTime, DateTime endTime, bool isMonthly)
        {
            HistoricalData.Clear();
            LineSeriesCollection.Clear();
            Labels.Clear();

            try
            {
                var piPoints = _piServer.PIPoints;
                var point = piPoints[actualSpeedTag];
                var values = point.Data.RecordedValues(startTime, endTime, BoundaryTypeConstants.btInside);

                // Add data to HistoricalData
                foreach (PIValue value in values)
                {
                    
                    if (value != null && value.Value != null)
                    {
                        double numericValue;
                        if (double.TryParse(value.Value.ToString(), out numericValue))
                        {
                            HistoricalData.Add(new HistoricalData
                            {
                                Name = point.Name,
                                Time = value.TimeStamp.LocalDate,
                                Value = numericValue
                            });
                        }
                    }
                }

                // Process data according to day or week
                if (isMonthly)
                {
                    // week
                    var weeklyData = HistoricalData
                        .GroupBy(d => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(d.Time, CalendarWeekRule.FirstDay, DayOfWeek.Monday))
                        .Select(g => new
                        {
                            Week = g.Key,
                            StartDate = g.Min(d => d.Time),
                            AverageValue = g.Average(d => d.Value)
                        })
                        .ToList();

                    // Add label and data to Chart
                    foreach (var week in weeklyData)
                    {
                        Labels.Add($"Week of {week.StartDate:MM/dd}");
                        var lineSeries = new LineSeries
                        {
                            Title = "Weekly Data",
                            Values = new ChartValues<ObservableValue>(weeklyData.Select(d => new ObservableValue(d.AverageValue)))
                        };
                        LineSeriesCollection.Add(lineSeries);
                    }
                }
                else
                {
                    // Daily
                    var dailyData = HistoricalData
                        .GroupBy(d => d.Time.Date)
                        .Select(g => new
                        {
                            Date = g.Key,
                            AverageValue = g.Average(d => d.Value)
                        })
                        .ToList();

                    // 
                    foreach (var day in dailyData)
                    {
                        Labels.Add(day.Date.ToString("MM/dd"));
                        var lineSeries = new LineSeries
                        {
                            Title = "Daily Data",
                            Values = new ChartValues<ObservableValue>(dailyData.Select(d => new ObservableValue(d.AverageValue)))
                        };
                        LineSeriesCollection.Add(lineSeries);
                    }
                }

                OnPropertyChanged(nameof(HistoricalData));
                OnPropertyChanged(nameof(LineSeriesCollection));
                OnPropertyChanged(nameof(Labels));

                _dataFetchTimer?.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching historical data: {ex.Message}");
            }
        }
        private int GetWeekOfYear(DateTime date)
        {
            var calendar = System.Globalization.CultureInfo.InvariantCulture.Calendar;
            return calendar.GetWeekOfYear(date, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        private DateTime GetWeekStartDate(int week, int year)
        {
            var jan1 = new DateTime(year, 1, 1);
            var daysOffset = (week - 1) * 7;
            return jan1.AddDays(daysOffset).AddDays(-(int)jan1.DayOfWeek + (int)DayOfWeek.Monday);
        }


        public void FetchLast7DaysData() => FetchHistoricalData(DateTime.Now.AddDays(-7), DateTime.Now, false);
        public void FetchLast14DaysData() => FetchHistoricalData(DateTime.Now.AddDays(-14), DateTime.Now, false);
        public void FetchLastMonthData() => FetchHistoricalData(DateTime.Now.AddMonths(-1), DateTime.Now, true);
        public void StartRealTimeFetching()
        {
            HistoricalData.Clear();
            //HistoricalData2.Clear();
            LineSeriesCollection.Clear();
            LineSeriesCollection.Add(new LineSeries
            {
                Title = "Actual Speed",
                Values = new ChartValues<ObservableValue>()
            });
            Labels.Clear();
           

            // Start fetching real-time data
            _dataFetchTimer?.Start();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void StopFetching()
        {
            _dataFetchTimer?.Stop();
            //_piServer?.Close();
        }
    }
    
}
