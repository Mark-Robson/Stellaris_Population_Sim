using System;

/*namespace for all dataTypes */
namespace dataTypes{

    /*namespace for the Calendar datatype */
    namespace Event{
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
            public ulong id{get; private set;}
            /*the human readable name of the event
              non-unique*/
            public String name {get; private set;}
            /*the Event Type*/
            public EventType type {get; private set;}
            /*internal constructor will not validate ids*/
            internal Event(ulong eventId, string eventName, EventType eventType){
                this.id = eventId;
                this.name = eventName;
                this.type = eventType;
            }
            /*override the toString methord*/
            public override string ToString()
            {
                return base.ToString() +
                    ": " +
                    String.Format("{0,8} : {1} : {2}",id,type,name);
            }
        }
    }
}