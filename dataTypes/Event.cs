using System;

/*namespace for all dataTypes */
namespace dataTypes{

    /*namespace for the Calendar datatype */
    namespace EventSystem{
        /*Types of events that the system is aware of*/
        enum EventType
        {
            Generic,
            StartingPop,
        }
        /*base class for an event*/
        class Event
        {
            /*the EventID is 
              a unique int used to adress the event*/
            public int id{get; private set;}
            /*the human readable name of the event
              non-unique*/
            public String name {get; private set;}
            /*the Event Type*/
            public EventType type {get; private set;}
            /*time of the event */
            public DateTime time{get; private set;}
            /*internal constructor will not validate ids*/
            internal Event(int eventId, string eventName, EventType eventType, DateTime eventTime){
                this.id = eventId;
                this.name = eventName;
                this.type = eventType;
                this.time = eventTime;
            }
            /*Creates a event and regesters it in the EventManager*/
            public Event(EventManager eventManager, string eventName, DateTime eventTime){
                this.id = eventManager.getNextId(this , eventTime);
                this.name = eventName;
                this.type = EventType.Generic;
            }
            /*override the toString methord*/
            public override string ToString()
            {
                return base.ToString() +
                    ": " +
                    String.Format("{0,8} : {1,20} : {2} : {3}",id,type,time,name);
            }
        }
    }
}