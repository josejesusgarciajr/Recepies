using System;

namespace PersonalPlayGround.Zoo
{
    public class Animal : IAminal
    {
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public double Weight { get; set; }

        public bool IsAlive()
        {
            return true;
        }

        public bool IsHealthy()
        {
            return true;
        }

        public bool IsFriendly()
        {
            return true;
        }

        public bool IsYoung()
        {
            return true;
        }
    }
}