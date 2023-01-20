using System;

namespace UpSchool_SignalR_Api2.Models
{
    public enum ECity
    {
        istanbul=1,
        ankara=2,
        imzir=3,
        konya=4,
        trabzon=5
    }
    public class Electric
    {
        public int ElectricID { get; set; }
        public ECity City { get; set; }
        public int Count { get; set; }
        public DateTime ElectricDate { get; set; }
    }
}
