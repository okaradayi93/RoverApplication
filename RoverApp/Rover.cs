using System;
using System.Collections.Generic;
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

        public Dictionary<char, RoverDirectionMap> RoverDirectionMapDictionary;
        public Dictionary<DirectionValue, Direction> DirectionMapDictionary;
        public Rover()
        {
            InitializeRover();
        }

        private void InitializeRover()
        {
            RoverDirectionMapDictionary = new Dictionary<char, RoverDirectionMap>();
            DirectionMapDictionary = new Dictionary<DirectionValue, Direction>();
            RoverDirectionMapDictionary.Add('L', new RoverDirectionMap { DirectionValue = ControlAction.Left, PosionValue = PosionValue.Left });
            RoverDirectionMapDictionary.Add('R', new RoverDirectionMap { DirectionValue = ControlAction.Right, PosionValue = PosionValue.Right });
            RoverDirectionMapDictionary.Add('M', new RoverDirectionMap { DirectionValue = ControlAction.Move, PosionValue = PosionValue.Move });
            DirectionMapDictionary.Add(DirectionValue.North, new Direction { HorizontalValue = MoveValue.Stay, VerticalValue = MoveValue.Next });
            DirectionMapDictionary.Add(DirectionValue.South, new Direction { HorizontalValue = MoveValue.Stay, VerticalValue = MoveValue.Previous });
            DirectionMapDictionary.Add(DirectionValue.East, new Direction { HorizontalValue = MoveValue.Next, VerticalValue = MoveValue.Stay });
            DirectionMapDictionary.Add(DirectionValue.West, new Direction { HorizontalValue = MoveValue.Previous, VerticalValue = MoveValue.Stay });
        }
        public void SetRoverPosition(char action)
        {
            int xCoordinate = XCoordinate + (int)DirectionMapDictionary[CurrentDirection].HorizontalValue * (int)RoverDirectionMapDictionary[action].PosionValue;
            int yCoordinate = YCoordinate + (int)DirectionMapDictionary[CurrentDirection].VerticalValue * (int)RoverDirectionMapDictionary[action].PosionValue;

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
            DirectionValue newDirection = (DirectionValue) (((int)CurrentDirection + (int)RoverDirectionMapDictionary[action].DirectionValue) % 4);
            CurrentDirection = newDirection;
        }
    }
}
