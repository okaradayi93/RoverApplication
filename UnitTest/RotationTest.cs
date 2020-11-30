using NUnit.Framework;

namespace RoverApp
{
    public class Tests
    {
        public ParameterConfig ParameterConfig { get; set; }
        [SetUp]
        public void Setup()
        {
            ParameterConfig = new ParameterConfig {
                RoverDirectionMapDictionary = new System.Collections.Generic.Dictionary<char, RoverDirectionMap> {
                    { 'L', new RoverDirectionMap { DirectionValue = Enum.ControlAction.Left }}
                },
                DirectionMapDictionary = new System.Collections.Generic.Dictionary<Enum.DirectionValue, Direction> {
                    { Enum.DirectionValue.North, new Direction { HorizontalValue = Enum.MoveValue.Stay, VerticalValue = Enum.MoveValue.Next } } 
                }
            };
            ParameterConfig.RoverDirectionMapDictionary.Add('M', new RoverDirectionMap { PosionValue= Enum.PosionValue.Move } );
        }

        [Test]
        public void DirectionTest_ReturnLeft_True()
        {
            Rover rover = new Rover{ 
                LimitX= 3,
                LimitY=3, 
                CurrentDirection= Enum.DirectionValue.North,
                XCoordinate= 1,
                YCoordinate= 2,
                ParameterConfig= ParameterConfig
            };
            
            rover.SetRoverDirection('L');
            Assert.AreEqual(rover.CurrentDirection, Enum.DirectionValue.West);
        }

        [Test]
        public void PosionTest_Move_True()
        {
            Rover rover = new Rover
            {
                LimitX = 3,
                LimitY = 3,
                CurrentDirection = Enum.DirectionValue.North,
                XCoordinate = 1,
                YCoordinate = 2,
                ParameterConfig = ParameterConfig
            };

            rover.SetRoverPosition('M');
            Assert.AreEqual(rover.YCoordinate, 3);
        }
    }
}