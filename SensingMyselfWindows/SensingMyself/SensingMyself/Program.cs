using System;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using Microsoft.Azure.Devices;

namespace SensingMyself
{
    static class Program
    {
        private static HeartService heartService;
        private static ServiceClient serviceClient;

        private static NotifyIcon trayIcon;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var menu = new ContextMenuStrip();
            menu.Items.Add("View today's summary", null, TodayClick);
            menu.Items.Add("Take a reading", null, ReadingClick);
            menu.Items.Add("About", null, AboutClick);
            menu.Items.Add("Exit", null, ExitClick);

            trayIcon = new NotifyIcon
            {
                Visible = true,
                Text = "Sensing Myself",
                Icon = Properties.Resources.Heart,
                ContextMenuStrip = menu
            };

            var timer = new Timer { Interval = 10000, Enabled = true };
            timer.Tick += Timer_Tick;

            Application.Run();

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
           if (HaveNaggedRecently())
                return;

            if (HaveTakenReadingRecently())
                return;

            TakeReading();
        }

        private static bool HaveNaggedRecently()
        {
            DateTime lastNagged;
            if (DateTime.TryParse(ConfigurationManager.AppSettings["LastNagged"], out lastNagged))
                return (DateTime.Now.Subtract(lastNagged) < TimeSpan.FromMinutes(60));
            else
                return false;
        }

        private static bool HaveTakenReadingRecently()
        {
            DateTime? lastReadingDateTime = GetHeartService().GetLastReadingDateTime();

            return (lastReadingDateTime.HasValue && DateTime.Now.Subtract(lastReadingDateTime.Value) < TimeSpan.FromMinutes(120));
        }

        private static void TakeReading()
        {
            trayIcon.BalloonTipTitle = "Hi";
            trayIcon.BalloonTipText = "Please take a heart rate and blood oxygen reading";
            trayIcon.ShowBalloonTip(5000);

            GetServiceClient().SendAsync(
                "SensingMe",
                new Microsoft.Azure.Devices.Message(Encoding.ASCII.GetBytes("Read")),
                TimeSpan.FromSeconds(10)).Wait();

            // Set last nagged
            ConfigurationManager.AppSettings.Set("LastNagged",DateTime.Now.ToString());
        }

        private static void ReadingClick(object sender, EventArgs e)
        {
            TakeReading();
        }


        private static void TodayClick(object sender, EventArgs e)
        {
            var today = new Today();
            today.ShowDialog();
        }

        private static void AboutClick(object sender, EventArgs e)
        {
            var about = new About();
            about.ShowDialog();
        }
        private static void ExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static HeartService GetHeartService()
        {
            return heartService ?? (heartService = new HeartService());
        }

        private static ServiceClient GetServiceClient()
        {
            return serviceClient ?? (serviceClient = ServiceClient.CreateFromConnectionString(
                ConfigurationManager.ConnectionStrings["iotHub"].ConnectionString,
                TransportType.Amqp
                ));
        }
    }
}
