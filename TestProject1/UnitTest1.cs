using ConsoleApp10;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAircraft1()
        {
            
            Aircraft aircraft = new Aircraft(TypeAircraft.BusinessJet,"Boeing 747", "Boeing", 2020, new Engine("V8","����������",100000),new List<Pilot> {new Pilot("PIB",50,10000) },new Airport("tt", "Kyiv"), "AN-222",1);


            aircraft.move();

            Assert.IsTrue(aircraft.id == 1);

            Assert.IsTrue(aircraft.pilot.First().age == 50);
            Assert.IsTrue(aircraft.producer == "Boeing");
        }

        [TestMethod]
        public void TestAircraft()
        {

            Aircraft aircraft = new Aircraft(TypeAircraft.BusinessJet, "Boeing 747", "Boeing", 2020, new Engine("V8", "����������", 100000), new List<Pilot> { new Pilot("PIB", 50,10000) }, new Airport("tt", "Kyiv"), "AN-222", 1);

            Assert.IsTrue(aircraft.airport.name == "tt");
            Assert.IsTrue(aircraft.airport.location == "Kyiv");
            aircraft.move(new Airport("ff","Kharciv"));

            Assert.IsTrue(aircraft.airport.name == "ff");
            Assert.IsTrue(aircraft.airport.location == "Kharciv");

        }


    }

    [TestClass]
    public class TestEngine
    {
        [TestMethod]
        public void TestEngines()
        {
           
            Engine ������ = new Engine("V8","���������������", 5000);

            // Act & Assert
            Assert.IsNotNull(������);
            Assert.AreEqual("���������������",������.type);
            Assert.AreEqual(5000, ������.power);
        }
    }

    [TestClass]
    public class TestPilot
    {
        [TestMethod]
        public void TestPilots()
        {
         
            Pilot ���� = new Pilot("John Doe",28, 5);

           
            Assert.IsNotNull(����);
            Assert.AreEqual("John Doe", ����.pib);
    
            Assert.AreEqual(5, ����.flightTimes);
        }
    }
}