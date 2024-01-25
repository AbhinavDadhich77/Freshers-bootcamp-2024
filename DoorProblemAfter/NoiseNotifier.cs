using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorProblem
{
    public class NoiseNotifier
    {
        public void Update(SmartDoor door)
        {
            Console.WriteLine($"State is: {door.CurrentState}");
        }
    }
}