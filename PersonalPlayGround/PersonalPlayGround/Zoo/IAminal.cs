using System;

namespace PersonalPlayGround.Zoo
{
    public interface IAminal
    {
        int Age { get; set; }
        DateTime Birthday { get; set; }
        double Weight { get; set; }
        bool IsAlive();
        bool IsHealthy();
        bool IsFriendly();
        bool IsYoung();
    }
}
