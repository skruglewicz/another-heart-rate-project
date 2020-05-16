using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensingMyself
{
    public partial class Today : Form
    {
        public Today()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Today_Load(object sender, EventArgs e)
        {
            try
            {
                var service = Program.GetHeartService();
                var readings = service.GetToday();

                var readingWord = (readings.Count == 1 ? "reading" : "readings");
                summaryLabel.Text = $"You have taken {readings.Count} {readingWord} for {DateTime.Today.ToLongDateString()}";

                if (readings.Any())
                {
                    var latestReading = readings.Max(r => r.TimeStamp);
                    recentlabel.Text = $"Your most recent reading was taken at {latestReading:HH:mm}";
                    recentlabel.ForeColor = (latestReading < DateTime.Now.AddHours(-2) ? Color.Red : Color.Black);

                    var minHeartRate = readings.Min(r => r.HeartRate);
                    minHeartRateLabel.Text = $"{minHeartRate} bpm";
                    minHeartRateLabel.ForeColor = (minHeartRate > 60 ? Color.Black : Color.Red);

                    var maxHeartRate = readings.Max(r => r.HeartRate);
                    maxHeartRateLabel.Text = $"{maxHeartRate} bpm";
                    maxHeartRateLabel.ForeColor = (maxHeartRate < 100 ? Color.Black : Color.Red);

                    var minO2 = readings.Min(r => r.SpO2);
                    minO2Label.Text = $"{minO2:#.00}%";
                    minO2Label.ForeColor = (minO2 > 95 ? Color.Black : Color.Red);

                    var maxO2 = readings.Max(r => r.SpO2);
                    maxO2Label.Text = $"{maxO2:#.00}%";
                    maxO2Label.ForeColor = (minO2 <= 100 ? Color.Black : Color.Red);
                }
                else
                {
                    minHeartRateLabel.Text = maxHeartRateLabel.Text = minO2Label.Text = maxO2Label.Text = "-";
                    minHeartRateLabel.ForeColor = maxHeartRateLabel.ForeColor = minO2Label.ForeColor = maxO2Label.ForeColor = Color.Red;
                    recentlabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Getting readings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
