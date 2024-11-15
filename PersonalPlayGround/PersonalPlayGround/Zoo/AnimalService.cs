
namespace PersonalPlayGround.Zoo
{
    public class AnimalService
    {
        public bool CanTransportToAnotherZoo(IAminal animal)
        {
            if (animal.IsAlive())
            {
                if (animal.IsHealthy())
                {
                    if (animal.IsFriendly())
                    {
                        if (animal.IsYoung())
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        public bool CanTransportToAnotherZoo2(IAminal animal)
        {
            if (!animal.IsAlive())
            {
                return false;
            }

            if (!animal.IsHealthy())
            {
                return false;
            }

            if (!animal.IsFriendly())
            {
                return false;
            }

            if (!animal.IsYoung())
            {
                return false;
            }

            return true;
        }
    }
}