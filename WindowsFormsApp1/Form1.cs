using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;

namespace SensorMonitoring
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            InitCharts();

            // 5초마다 센서값 갱신
            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void InitCharts()
        {
            chartTemp.Series = new SeriesCollection
            {
                new LineSeries { Title = "온도(°C)", Values = new ChartValues<double>() }
            };
            chartTemp.AxisX.Add(new Axis { Title = "시간", Labels = new List<string>() });
            chartTemp.AxisY.Add(new Axis { Title = "온도(°C)" });

            chartHumi.Series = new SeriesCollection
            {
                new LineSeries { Title = "습도(%)", Values = new ChartValues<double>() }
            };
            chartHumi.AxisX.Add(new Axis { Title = "시간", Labels = new List<string>() });
            chartHumi.AxisY.Add(new Axis { Title = "습도(%)" });

            chartDust.Series = new SeriesCollection
            {
                new LineSeries { Title = "미세먼지(㎍/m³)", Values = new ChartValues<double>() }
            };
            chartDust.AxisX.Add(new Axis { Title = "시간", Labels = new List<string>() });
            chartDust.AxisY.Add(new Axis { Title = "미세먼지㎍/m³" });
            }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // 센서값 랜덤 (실제에선 시리얼/네트워크 값으로 교체)
            double temp = rand.Next(15, 35);
            double humi = rand.Next(20, 80);
            double dust = rand.Next(10, 150);

            AddSensorData(chartTemp, temp);
            AddSensorData(chartHumi, humi);
            AddSensorData(chartDust, dust);

            CheckThreshold(temp, humi, dust);
        }

        private void AddSensorData(LiveCharts.WinForms.CartesianChart chart, double value)
        {
            var series = chart.Series[0] as LineSeries;
            series.Values.Add(value);

            // 최근 20개만 유지
            if (series.Values.Count > 20)
                series.Values.RemoveAt(0);

            chart.AxisX[0].Labels.Add(DateTime.Now.ToString("HH:mm:ss"));
            if (chart.AxisX[0].Labels.Count > 20)
                chart.AxisX[0].Labels.RemoveAt(0);

            chart.Update();
        }

        private void CheckThreshold(double temp, double humi, double dust)
        {
            bool alarm = false;
            string msg = $"온도:{temp}°C, 습도:{humi}%, 미세먼지:{dust}";

            if (temp < 18 || temp > 28)
            {
                alarm = true;
                treeViewLog.Nodes.Add($"{DateTime.Now} - 온도 이상치 감지! ({temp}°C)");
            }
            if (humi < 30 || humi > 60)
            {
                alarm = true;
                treeViewLog.Nodes.Add($"{DateTime.Now} - 습도 이상치 감지! ({humi}%)");
            }
            if (dust > 100)
            {
                alarm = true;
                treeViewLog.Nodes.Add($"{DateTime.Now} - 미세먼지 이상치 감지! ({dust})");
            }

            if (alarm)
            {
                lblAlarm.Text = "⚠ 이상치 감지됨!";
                lblAlarm.ForeColor = Color.Red;
            }
            else
            {
                lblAlarm.Text = "현재 상태: 정상입니다.";
                lblAlarm.ForeColor = Color.Green;
            }
        }
    }
}
