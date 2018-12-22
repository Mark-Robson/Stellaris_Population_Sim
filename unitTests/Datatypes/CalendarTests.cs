using NUnit.Framework;
using System;
using dataTypes.Calendar;

/*namespace for all tests in the project*/
namespace Tests{
    /*name space for datatype tests*/
    namespace DatatypeTests{
        /*namespace for all Calendar Tests */
        namespace CalendarTests{

            /*tests for the constructor of the calendar datatype*/
            [TestFixture]
            public class ConstructorTest
            {
                /*dates commonly used in the tests
                  set in the setup methord befor each test
                */
                DateTime start;
                DateTime end;
                Calendar testCalendar;
                /*called befor each test
                  sets start and end to known values
                */
                [SetUp]
                public void SetUp(){
                    start = new DateTime(2000,1,1);
                    end = new DateTime(2200,1,1);
                }
                /*Tests that valid dates works correctly*/
                [Test]
                public void Calendar_validDates_ReturnsCalender(){
                    testCalendar = new Calendar(start,end);
                    Assert.AreEqual(start,testCalendar.startDate);
                    Assert.AreEqual(end,testCalendar.endDate);
                }
                /*Tests that invalid dates throws an exception*/
                [Test]
                public void Calendar_StartAfterEnd_ArgumentException(){
                    ArgumentException ex = Assert.Throws<ArgumentException>( delegate {testCalendar = new Calendar(end,start);} );
                    Assert.AreEqual( ex.Message,"startDate cannot be set to after endDate\r\nParameter name: start" );
                }
                /*Tests that both dates being the same works correctly*/
                [Test]
                public void Calendar_StartEqualsEnd_ReturnsCalender(){
                    testCalendar = new Calendar(start,start);
                    Assert.AreEqual(start,testCalendar.startDate);
                    Assert.AreEqual(start,testCalendar.endDate);
                }

            }
            /*tests for the SetStartdate and Set endDate of the calendar datatype*/
            [TestFixture]
            public class SetdateTests
            {
                /*dates commonly used in the tests
                  set in the setup methord befor each test
                */
                DateTime earlyerStartDate;
                DateTime startDate;
                DateTime betweenDate;
                DateTime endDate;
                DateTime laterEndDate;
                Calendar testCalendar;
                /*called befor each test
                  sets dates to known values
                */
                [SetUp]
                public void SetUp(){
                    earlyerStartDate = new DateTime(1995,7,14);
                    startDate        = new DateTime(2000,1,1);
                    betweenDate      = new DateTime(2100,5,4);
                    endDate          = new DateTime(2200,1,1);
                    laterEndDate     = new DateTime(2356,12,27);
                    testCalendar = new Calendar(startDate,endDate);
                }
                /*Tests that seting startDate to a earlyer valid dates works correctly*/
                [Test]
                public void setStart_EarlyerDate_valueUpdated(){
                    testCalendar.startDate = earlyerStartDate;
                    Assert.AreEqual(earlyerStartDate,testCalendar.startDate);
                }
                
                /*Tests that seting startDate to the same dates works correctly*/
                [Test]
                public void setStart_SameDate_valueUnchanged(){
                    testCalendar.startDate = startDate;
                    Assert.AreEqual(startDate,testCalendar.startDate);
                }
                /*Tests that seting startDate to a later valid dates works correctly*/
                [Test]
                public void setStart_ValidLaterDate_valueUpdated(){
                    testCalendar.startDate = betweenDate;
                    Assert.AreEqual(betweenDate,testCalendar.startDate);
                }
                /*Tests that seting startDate to endDates works correctly*/
                [Test]
                public void setStart_endDate_valueUpdated(){
                    testCalendar.startDate = endDate;
                    Assert.AreEqual(endDate,testCalendar.startDate);
                }
                /*Tests that seting startDate after endDates throws exception*/
                [Test]
                public void setStart_InvalidLaterDate_ArgumentException(){
                    ArgumentException ex = Assert.Throws<ArgumentException>( delegate {testCalendar.startDate = laterEndDate;} );
                    Assert.AreEqual(ex.Message, "startDate cannot be set to after endDate\r\nParameter name: value" );
                }
                /*Tests that seting endDate to befor startDates throws exception*/
                [Test]
                public void setend_InvalidEarlyerDate_valueUpdated(){
                    ArgumentException ex = Assert.Throws<ArgumentException>( delegate {testCalendar.endDate = earlyerStartDate;} );
                    Assert.AreEqual(ex.Message, "endDate cannot be set to befor startDate\r\nParameter name: value" );

                }
                /*Tests that seting enddate to a startdate works correctly*/
                [Test]
                public void setend_startDate_valueUpdated(){
                    testCalendar.endDate = startDate;
                    Assert.AreEqual(startDate,testCalendar.endDate);
                }
                
                /*Tests that seting enddate to a earlyer valid date works correctly*/
                [Test]
                public void setend_ValidEarlyerDate_valueUpdated(){
                    testCalendar.endDate = betweenDate;
                    Assert.AreEqual(betweenDate,testCalendar.endDate);
                }
                /*Tests that seting enddate to the same date works correctly*/
                [Test]
                public void setend_SameDate_valueUnchanged(){
                    testCalendar.endDate = endDate;
                    Assert.AreEqual(endDate,testCalendar.endDate);
                }
                /*Tests that seting enddate to a later date works correctly*/
                [Test]
                public void setend_LaterDate_valueUpdated(){
                    testCalendar.endDate = laterEndDate;
                    Assert.AreEqual(laterEndDate,testCalendar.endDate);
                }

            }
        }
    }
}