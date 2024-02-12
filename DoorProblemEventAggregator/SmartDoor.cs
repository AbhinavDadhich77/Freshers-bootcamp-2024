using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorProblemEventAggregator
{
    public class SmartDoor : SimpleDoor
    {
        private bool Noisenotifier { get; set; }
        private bool Notificationnotifier { get; set; }
        private bool Autoclose { get; set; }


        public event Action<SmartDoor> TimerForEvent;


        public void TriggerTimerEvent()
        {
            TimerForEvent?.Invoke(this);
        }

        public void Open()
        {
            base.Open();
            
            Action<SmartDoor> action = door => EventAggregator.Instance.Publish(door);
            action(this);


        }

    }
}
