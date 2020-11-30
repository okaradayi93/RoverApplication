using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverApp
{
    public class Enum
    {
        public enum DirectionValue
        {
            East = 0,
            North = 1,
            West = 2,
            South = 3
        }

        public enum ControlAction
        {
            Left = 5,
            Right = 3,
            Move = 0
        }

        public enum PosionValue
        {
            Left = 0,
            Right = 0,
            Move = 1
        }

        public enum MoveValue
        {
            Stay = 0,
            Next = 1,
            Previous = -1
        }
    }    
}
