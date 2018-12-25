using NUnit.Framework;
using System;
using dataTypes.EventSystem;
using System.Collections.Generic;
/*namespace for all tests in the project*/
namespace Tests{
    /*name space for datatype tests*/
    namespace DatatypeTests{
        /*namespace for all Event Tests*/
        namespace EventManagerTests{
            /*Class to test functions of the EventManager */
            [TestFixture]
            class EventManagerTest{
                private List<Event> events ;
                private List<String> eventNames ;
                private List<DateTime> eventDates;
                private EventManager eventManager;
                
                /*called befor each test
                  creats events with knowen values
                */
                [SetUp]
                public void SetUp(){
                    events = new List<Event>();
                    eventNames = new List<string>();
                    eventDates = new List<DateTime>();
                    eventManager = new EventManager();
                    for(int i  =0 ; i < 260 ; i ++){
                        Random r = new Random();
                        eventNames.Add("event "+i);
                        DateTime newDate = new DateTime(r.Next(2000,2002),r.Next(1,5),r.Next(1,5));
                        eventDates.Add(newDate);
                    }
                    for (int i = 0; i < 260; i++)
                    {
                        events.Add(new Event(eventManager,eventNames[i],eventDates[i]));
                    }
                }
                /*test that all events are different */
                [Test]
                public void EventManager_differentID_ReturnsDifferentEvent(){
                    HashSet<int> eventIDs = new HashSet<int>();
                    foreach (Event e in events){
                        Assert.False(eventIDs.Contains(e.id));
                        eventIDs.Add(e.id);
                    }
                }
                /*test that the number of events is reported correctly */
                [Test]
                public void EventManager_totalNumbers_ReturnsNumberOfEvent(){
                    Assert.AreEqual(260,eventManager.numberOfEvents);
                    for(int i  =0 ; i < 260 ; i ++){
                        Random r = new Random();
                        string name =  "event "+(260+i);
                        DateTime newDate = new DateTime(r.Next(2000,2001),r.Next(1,5),r.Next(1,5));
                        events.Add(new Event(eventManager,name,newDate));
                        Assert.AreEqual(261+i,eventManager.numberOfEvents);
                    }
                }
            }
        }
    }
}