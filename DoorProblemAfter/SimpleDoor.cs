using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorProblem
{
    public enum State
    {
        OPEN, CLOSE
    }
    
    public class SimpleDoor
    {
        public State CurrentState = State.CLOSE;
        public void Open()
        {
            Console.WriteLine("The door is opened");
            CurrentState = State.OPEN;
        }

        public void Close() 
        {
            Console.WriteLine("The door is closed");
            CurrentState = State.CLOSE;

        }
    }
}
