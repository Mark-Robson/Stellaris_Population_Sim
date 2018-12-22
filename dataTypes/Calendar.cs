
using System;

/*namespace for all dataTypes */
namespace dataTypes{

    /*namespace for the Calendar datatype */
    namespace Calendar{

        /*class used to store date and time infomation for the simulator */
        class Calendar{

            /*holds the real value of the start date of the calendar */
            private DateTime _startDate;
            /*handles the interface, checking that the startdate is always befor enddate */
            public DateTime startDate{
                /*returns the true value of the startDate */
                get{
                    return _startDate;
                }
                /*Sets the startDate to a new value
                  throws an exception if it is after the enddate
                */
                set{
                    if (value > endDate){
                        throw new System.ArgumentException("startDate cannot be set to after endDate", "value");
                    }
                    _startDate = value;
                }
            }
            /*holds the real value of the end date of the calendar */
            private DateTime _endDate;
            /*handles the interface, checking that the enddate is always after the startdate */
            public DateTime endDate{ 
                /*returns the true value of the endDate */
                get{
                    return _endDate;
                }
                /*Sets the endDate to a new value
                  throws an exception if it is befor the enddate
                */
                set{
                    if (value < startDate){
                        throw new System.ArgumentException("endDate cannot be set to befor startDate", "value");
                    }
                    _endDate = value;
                }
            }
            /*Creates a new Calendar with a given start and end date
              throws exception if the start is after the end date */
            public Calendar(DateTime start, DateTime end){
                if (start > end){
                        throw new System.ArgumentException("startDate cannot be set to after endDate", "start");
                }
                _startDate = start;
                _endDate = end;
            }
        }
    }
}
