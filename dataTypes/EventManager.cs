using System;
using dataTypes.EventSystem;
using System.Collections.Generic;

/*namespace for all dataTypes */
namespace dataTypes{

    /*namespace for the Calendar datatype */
    namespace EventSystem{

        /*base class for an event*/
        class EventManager
        {
            /*Holds a master list of all events created with the manager */
            private List<Event> eventList = new List<Event>();
            /*holds the Events by day */
            private Dictionary<DateTime,List<Event>> eventsByTime = new Dictionary<DateTime, List<Event>>();
            /*holds the total number of events in the manager */
            private int _numberOfEvents;
            
            public int numberOfEvents{
                get{
                    return _numberOfEvents;
                }
                private set{
                    _numberOfEvents=value;
                }
            }
            
            /*adds a new Event to the system */
            private void addEvents (Event newEvent){
                if (newEvent.time == null){
                    throw new System.ArgumentException("time cannot be null", "newEvent.time");
                }
                eventList.Add(newEvent);
                /*creates the SortedList<DateTime,Event>> if needed */
                if(!eventsByTime.ContainsKey(newEvent.time)){
                    List<Event> newEventList = new List<Event>();
                    eventsByTime.Add(newEvent.time.Date,newEventList);
                }
                eventsByTime[newEvent.time.Date].Add(newEvent);
                numberOfEvents++;
            }
            /*Given a event and a datetime log the event in the manager
             returns a event ID*/
            public int getNextId(Event newEvent){
                if (newEvent.time == null){
                    throw new System.ArgumentException("time cannot be null", "newEvent.time");
                }
                addEvents(newEvent);
                return numberOfEvents;
            }
            /*override the toString methord*/
            public override string ToString()
            {
                return base.ToString();
            }
        }
    }
}