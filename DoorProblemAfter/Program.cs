using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DoorProblem
{

    internal class Program
    { 
        static void Main(string[] args)
        {
            SimpleDoor simpleDoor = new SimpleDoor();
            SmartDoor smartDoor = new SmartDoor();

            simpleDoor.Open();
            simpleDoor.Close();

      
            NoiseNotifier noise = new NoiseNotifier();
            NotificationNotifier notification = new NotificationNotifier();
            AutoClose autoClose = new AutoClose();

          
            smartDoor.TimerForEvent += autoClose.AutoCloseFun;
            smartDoor.TimerForEvent += noise.Update;
            smartDoor.TimerForEvent += notification.Update;


            smartDoor.Open();

            Timer timer = new Timer(state => TimerElapsed(smartDoor), null, 20000, Timeout.Infinite);

            Console.ReadKey();
        }


        private static void TimerElapsed(SmartDoor smartDoor)
        {
            if(smartDoor.CurrentState == State.OPEN)
            {
                Thread notificationTHread = new Thread(() =>
                {
                    Thread.Sleep(20000);
                    Console.WriteLine("20 sec have passed,triggering events...");
                    smartDoor.TriggerTimerEvent();
                });
                
            }
        }
    }
    
}

