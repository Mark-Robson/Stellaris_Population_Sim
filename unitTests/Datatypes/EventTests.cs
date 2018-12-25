using NUnit.Framework;
using System;
using dataTypes.EventSystem;

/*namespace for all tests in the project*/
namespace Tests{
    /*name space for datatype tests*/
    namespace DatatypeTests{
        /*namespace for all Event Tests*/
        namespace EventTests{
            /*Class to test functions of the Event to String */
            [TestFixture]
            class EventTests{
                /*two events used in testing */
                private Event eventA;
                private Event eventB;
                /*two dateTimes used in testing */
                private DateTime timeA;
                private DateTime timeB;
                /*called befor each test
                  creats events with knowen values
                */
                [SetUp]
                public void SetUp(){
                    timeA = new DateTime(2000,1,1);
                    timeB = new DateTime(2200,1,1);
                    eventA = new Event(1,"EventA",EventType.Generic,timeA);
                    eventB = new Event(1,"EventA",EventType.Generic,timeB);
                }
                /*test the constructor correctly sets the values*/
                [Test]
                public void Event_Correct_ReturnsEvent(){
                    Assert.AreEqual(EventType.Generic,eventA.type);
                    Assert.AreEqual(1,eventA.id);
                    Assert.AreEqual("EventA",eventA.name);
                    Assert.AreEqual(timeA,eventA.time);
                }
                /*tests the toString methord returns the corrent output*/
                [Test]
                [TestCase(1,"EventA",EventType.Generic,    'A',"dataTypes.EventSystem.Event:        1 :              Generic : 01/01/2000 00:00:00 : EventA")]
                [TestCase(12345,"EventA",EventType.Generic,'A',"dataTypes.EventSystem.Event:    12345 :              Generic : 01/01/2000 00:00:00 : EventA")]
                [TestCase(1,"EventB",EventType.Generic,    'A',"dataTypes.EventSystem.Event:        1 :              Generic : 01/01/2000 00:00:00 : EventB")]
                [TestCase(0,"EventA",EventType.StartingPop,'B',"dataTypes.EventSystem.Event:        0 :          StartingPop : 01/01/2200 00:00:00 : EventA")]
                public void toString_StandordImput_ReturnsString(int id,string name,EventType et,char t, string stringResult){
                    DateTime time = t=='A' ? timeA : timeB;
                    eventA = new Event(Convert.ToUInt64(id),name,et,time);
                    Assert.AreEqual(stringResult,eventA.ToString());
                }
            }
        }
    }
}