using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoorProblem
{
    public class SmartDoor : SimpleDoor
    {
        private bool Noisenotifier {  get; set; }
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
            if (TimerForEvent != null)
            {
                TimerForEvent.Invoke(this);
            }
        }

    }
}


