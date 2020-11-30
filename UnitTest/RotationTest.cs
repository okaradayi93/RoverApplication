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
                { 'L', new RoverDirectionMap { DirectionValue = Enum.ControlAction.Left } }
                }
            };
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
    }
}