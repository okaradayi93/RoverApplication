using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RoverApp.Enum;

namespace RoverApp
{
    public class ParameterConfig
    {
        public Dictionary<char, RoverDirectionMap> RoverDirectionMapDictionary;
        public Dictionary<DirectionValue, Direction> DirectionMapDictionary;
    }
}
