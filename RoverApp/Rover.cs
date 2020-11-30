using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RoverApp.Enum;

namespace RoverApp
{
    public class Rover
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int LimitX { get; set; }
        public int LimitY { get; set; }
        public DirectionValue CurrentDirection { get; set; }
        public ParameterConfig ParameterConfig { get; set; }

        public void SetRoverPosition(char action)
        {
            int xCoordinate = XCoordinate + (int)ParameterConfig.DirectionMapDictionary[CurrentDirection].HorizontalValue * (int)ParameterConfig.RoverDirectionMapDictionary[action].PosionValue;
            int yCoordinate = YCoordinate + (int)ParameterConfig.DirectionMapDictionary[CurrentDirection].VerticalValue * (int)ParameterConfig.RoverDirectionMapDictionary[action].PosionValue;

            if (xCoordinate < 0 || xCoordinate > LimitX)
            {
                Console.WriteLine("You cannot go out of plane.");
                Console.ReadLine();
                throw new System.ArgumentException("You cannot go out of plane.");
            } else
            {
                XCoordinate = xCoordinate;
            }

            if (yCoordinate < 0 || yCoordinate > LimitY)
            {
                Console.WriteLine("You cannot go out of plane.");
                Console.ReadLine();
                throw new System.ArgumentException("You cannot go out of plane.");
            }
            else
            {
                YCoordinate = yCoordinate;
            }
        }

        public void SetRoverDirection(char action)
        {
            DirectionValue newDirection = (DirectionValue) (((int)CurrentDirection + (int)ParameterConfig.RoverDirectionMapDictionary[action].DirectionValue) % 4);
            CurrentDirection = newDirection;
        }
    }
}
