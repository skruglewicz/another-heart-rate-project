using System;

namespace SensingMyself
{
    /// <summary>
    /// Holds a heart rate and SpO2 reading
    /// </summary>
    public class Reading
    {
        public DateTime? TimeStamp { get; set; }
        public int HeartRate { get; set; }
        public double SpO2 { get; set; }
    }
}
