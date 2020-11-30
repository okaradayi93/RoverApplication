using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RoverApp.Enum;

namespace RoverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, DirectionValue> directionDictionary = new Dictionary<char, DirectionValue>();
            directionDictionary.Add('N', DirectionValue.North);
            directionDictionary.Add('S', DirectionValue.South);
            directionDictionary.Add('E', DirectionValue.East);
            directionDictionary.Add('W', DirectionValue.West);

            Console.WriteLine("Enter Plateau Max Limit");
            string limitCoordinates = Console.ReadLine();
            string[] plateauLimitCoordinates = limitCoordinates.Split(' ');
            int limitX = Convert.ToInt32(plateauLimitCoordinates[0]);
            int limitY = Convert.ToInt32(plateauLimitCoordinates[1]);

            List<Rover> roverList = new List<Rover>();
            roverList.Add(new Rover { LimitX = limitX, LimitY = limitY });
            roverList.Add(new Rover { LimitX = limitX, LimitY = limitY });

            foreach (var item in roverList)
            {
                Console.WriteLine("Enter Initial Position For First Rover");
                string initialPosition = Console.ReadLine();
                string[] initialPositionArray = initialPosition.Split(' ');
                item.XCoordinate = Convert.ToInt32(initialPositionArray[0]);
                item.YCoordinate = Convert.ToInt32(initialPositionArray[1]);
                char initialDirection = Convert.ToChar(initialPositionArray[2]);
                item.CurrentDirection = directionDictionary[initialDirection];

                Console.WriteLine("Enter Movement Command");
                string moveList = Console.ReadLine();
                char[] moveArray = moveList.ToCharArray();

                foreach (var command in moveArray)
                {
                    item.SetRoverDirection(command);
                    item.SetRoverPosition(command);
                }
            }

            foreach (var item in roverList)
            {
                Console.WriteLine("{0} {1} {2}", item.XCoordinate, item.YCoordinate, directionDictionary.FirstOrDefault(x => x.Value == item.CurrentDirection).Key);
            }

            Console.ReadLine();
        }
    }
}
