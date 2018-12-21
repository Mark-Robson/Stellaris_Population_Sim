
using System;
namespace dataTypes{
    namespace Calendar{
        class Calendar{

            private DateTime _startDate;
            public DateTime startDate{ 
                get{
                    return _startDate;
                }
                set{
                    if (value > endDate){
                        throw new System.ArgumentException("startDate cannot be set to after endDate", "value");
                    }
                    _startDate = value;
                }
            }
            private DateTime _endDate;
            public DateTime endDate{ 
                get{
                    return _endDate;
                }
                set{
                    if (value < startDate){
                        throw new System.ArgumentException("endDate cannot be set to befor startDate", "value");
                    }
                    _endDate = value;
                }
            }

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
