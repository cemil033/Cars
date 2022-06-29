using Cars.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Cars.ViewModels
{
    public class MainViewModel:ViewModelBase
    {

        #region Fields
        public ObservableCollection<Car> Cars { get; set; }= new ObservableCollection<Car>();

        private bool single;
        public bool Single { get => single; set 
            { 
                single = value; 
                RaisePropertyChanged();
            } }
        #endregion

        #region Timer
        private string timer;
        public string Timer
        {
            get => timer; set
            {
                timer = value;
                RaisePropertyChanged();
            }
        }

        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch sw = new Stopwatch();
        string currentTime = string.Empty;
        void dt_Tick(object sender, EventArgs e)
        {
            if (sw.IsRunning)
            {
                TimeSpan ts = sw.Elapsed;
                currentTime = String.Format("{0:00}:{0:00}:{1:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Timer = currentTime;
            }
        }
        #endregion

        #region Thread
        public Thread thread;
        private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
        CancellationTokenSource cts = new CancellationTokenSource();
        #endregion

        #region Functions
        public void ReadAll()
        {
            sw.Start();
            dt.Start();
            var jsonStr = File.ReadAllText("Mercedes.json");
            foreach (var car in JsonConvert.DeserializeObject<ObservableCollection<Car>>(jsonStr))
            {
                dispatcher.Invoke(() => Cars.Add(car));
            }
            Thread.Sleep(1000);
            jsonStr = File.ReadAllText("BMW.json");
            foreach (var car in JsonConvert.DeserializeObject<ObservableCollection<Car>>(jsonStr))
            {
                dispatcher.Invoke(() => Cars.Add(car));
            }
            Thread.Sleep(1000);
            jsonStr = File.ReadAllText("AUDI.json");
            foreach (var car in JsonConvert.DeserializeObject<ObservableCollection<Car>>(jsonStr))
            {
                dispatcher.Invoke(() => Cars.Add(car));
            }
            Thread.Sleep(1000);
            jsonStr = File.ReadAllText("LandRover.json");
            foreach (var car in JsonConvert.DeserializeObject<ObservableCollection<Car>>(jsonStr))
            {
                dispatcher.Invoke(() => Cars.Add(car));
            }
            Thread.Sleep(1000);
            jsonStr = File.ReadAllText("Bentley.json");
            foreach (var car in JsonConvert.DeserializeObject<ObservableCollection<Car>>(jsonStr))
            {
                dispatcher.Invoke(() => Cars.Add(car));
            }
            Thread.Sleep(1000);
            if (sw.IsRunning)
            {
                sw.Stop();
                dt.Stop();
            }
        }
        #endregion

        #region Commands
        public RelayCommand StartCommand
        {
            get => new RelayCommand(
            () =>
            { 
                if (Single == true)
                {                    
                    thread = new Thread(ReadAll);                    
                    thread.Start();
                }
                else
                {                     
                    var thr1 = ThreadPool.QueueUserWorkItem((e) =>
                    {                        
                        lock (Cars)
                        {
                            sw.Start();
                            dt.Start();
                            var jsonStr = File.ReadAllText("Mercedes.json");
                            foreach (var car in JsonConvert.DeserializeObject<ObservableCollection<Car>>(jsonStr))
                            {
                                dispatcher.Invoke(() => Cars.Add(car));
                                if (cts.IsCancellationRequested)
                                {
                                    MessageBox.Show("Canceled");
                                    return;
                                }
                            }
                            Thread.Sleep(1000);
                        }
                    });
                    var thr2 = ThreadPool.QueueUserWorkItem((e) =>
                    {

                        lock (Cars)
                        {
                            var jsonStr = File.ReadAllText("BMW.json");
                            foreach (var car in JsonConvert.DeserializeObject<ObservableCollection<Car>>(jsonStr))
                            {
                                dispatcher.Invoke(() => Cars.Add(car));
                                if (cts.IsCancellationRequested)
                                {
                                    MessageBox.Show("Canceled");
                                    return;
                                }
                            }
                            Thread.Sleep(1000);
                        }
                    });
                    var thr3 = ThreadPool.QueueUserWorkItem((e) =>
                    {

                        lock (Cars)
                        {
                            var jsonStr = File.ReadAllText("AUDI.json");
                            foreach (var car in JsonConvert.DeserializeObject<ObservableCollection<Car>>(jsonStr))
                            {
                                dispatcher.Invoke(() => Cars.Add(car));
                                if (cts.IsCancellationRequested)
                                {
                                    MessageBox.Show("Canceled");
                                    return;
                                }
                            }
                            Thread.Sleep(1000);
                        }
                    });
                    var thr4 = ThreadPool.QueueUserWorkItem((e) =>
                    {
                        lock (Cars)
                        {
                            var jsonStr = File.ReadAllText("LandRover.json");
                            foreach (var car in JsonConvert.DeserializeObject<ObservableCollection<Car>>(jsonStr))
                            {
                                dispatcher.Invoke(() => Cars.Add(car));
                                if (cts.IsCancellationRequested)
                                {
                                    MessageBox.Show("Canceled");
                                    return;
                                }
                            }
                            Thread.Sleep(1000);
                        }
                    });
                    var thr5 = ThreadPool.QueueUserWorkItem((e) =>
                    {
                        lock (Cars)
                        {
                            var jsonStr = File.ReadAllText("Bentley.json");
                            foreach (var car in JsonConvert.DeserializeObject<ObservableCollection<Car>>(jsonStr))
                            {
                                dispatcher.Invoke(() => Cars.Add(car));
                                if (cts.IsCancellationRequested)
                                {
                                    MessageBox.Show("Canceled");
                                    return;
                                }
                                Thread.Sleep(1000);
                            }
                            if (sw.IsRunning)
                            {
                                sw.Stop();
                                dt.Stop();
                            }
                        }
                    }); 
                }
            });
        }
        public RelayCommand CancelCommand
        {
            get => new RelayCommand(
            () =>
            {
                if (Single)
                {
                    thread.Abort();
                }
                else
                {
                    cts.Cancel();
                }
            });
        }
        #endregion


        public MainViewModel()
        {
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
            //ReadAll();
        }
        
    }
}
