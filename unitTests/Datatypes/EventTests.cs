using NUnit.Framework;
using System;
using dataTypes.Event;

/*namespace for all tests in the project*/
namespace Tests{
    /*name space for datatype tests*/
    namespace DatatypeTests{
        /*namespace for all Event Tests*/
        namespace EventTests{
            /*Class to test functions of the Event to String */
            [TestFixture]
            class EventTests{
                /*two events used in testing the constructor*/
                private Event eventA;
                private Event eventB;
                /*called befor each test
                  creats events with knowen values
                */
                [SetUp]
                public void SetUp(){
                    eventA = new Event(1,"EventA",EventType.Generic);
                    eventB = new Event(1,"EventA",EventType.Generic);
                }
                /*test the constructor correctly sets the values*/
                [Test]
                public void Event_Correct_ReturnsEvent(){
                    Assert.AreEqual(eventA.type,EventType.Generic);
                    Assert.AreEqual(eventA.id,1);
                    Assert.AreEqual(eventA.name,"EventA");
                }
                /*tests the toString methord returns the corrent output*/
                [Test]
                [TestCase(1,"EventA",EventType.Generic,     "dataTypes.Event.Event:        1 : Generic : EventA")]
                [TestCase(12345,"EventA",EventType.Generic, "dataTypes.Event.Event:    12345 : Generic : EventA")]
                [TestCase(1,"EventB",EventType.Generic,     "dataTypes.Event.Event:        1 : Generic : EventB")]
                [TestCase(0,"EventA",EventType.StartingPop, "dataTypes.Event.Event:        0 : StartingPop : EventA")]
                public void toString_StandordImput_ReturnsString(int id,string name,EventType et,string stringResult){
                    eventA = new Event(Convert.ToUInt64(id),name,et);
                    Assert.AreEqual(stringResult,eventA.ToString());
                }
            }
        }
    }
}