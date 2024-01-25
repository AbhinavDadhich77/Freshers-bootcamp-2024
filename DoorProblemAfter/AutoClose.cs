using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorProblem
{
    public class AutoClose
    {
        public void AutoCloseFun(SmartDoor door) 
        {
            Console.WriteLine("20 sec have passsed door is autoclosed");
            door.Close();
            
        }
    }
}
