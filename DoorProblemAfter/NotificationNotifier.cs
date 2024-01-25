using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorProblem
{
    public class NotificationNotifier
    {
        public void Update(SmartDoor door)
        {
            Console.WriteLine($"State : {door.CurrentState}");
        }
    }
}
