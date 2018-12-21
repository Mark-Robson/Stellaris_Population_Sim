using NUnit.Framework;
using System;
using dataTypes.Calendar;

namespace Tests{
    namespace CalendarTests{
        [TestFixture]
        public class ConstructorTest
        {
            DateTime start;
            DateTime end;
            Calendar c;
            [SetUp]
            public void SetUp(){
                start = new DateTime(2000,1,1);
                end = new DateTime(2200,1,1);
                c = new Calendar(start,end);
            }
            [Test]
            public void Calendar_validDates_ReturnsCalender(){
                Assert.AreEqual(start,c.startDate);
                Assert.AreEqual(end,c.endDate);
            }
            [Test]
            public void Calendar_StartAfterEnd_ArgumentException(){
                ArgumentException ex = Assert.Throws<ArgumentException>( delegate {c = new Calendar(end,start);} );
                Assert.AreEqual( ex.Message,"startDate cannot be set to after endDate\r\nParameter name: start" );
            }
            [Test]
            public void Calendar_StartEqualsEnd_ReturnsCalender(){
                c = new Calendar(start,start);
                Assert.AreEqual(start,c.startDate);
                Assert.AreEqual(start,c.endDate);
            }

        }
        [TestFixture]
        public class SetdateTests
        {
            DateTime earlyerStart;
            DateTime start;
            DateTime betweenDate;
            DateTime end;
            DateTime laterEnd;
            Calendar c;
            [SetUp]
            public void SetUp(){
                earlyerStart = new DateTime(1995,7,14);
                start = new DateTime(2000,1,1);
                betweenDate = new DateTime(2100,5,4);
                end = new DateTime(2200,1,1);
                laterEnd = new DateTime(2356,12,27);
                c = new Calendar(start,end);
            }
            [Test]
            public void setStart_EarlyerDate_valueUpdated(){
                c.startDate = earlyerStart;
                Assert.AreEqual(earlyerStart,c.startDate);
            }
            [Test]
            public void setStart_SameDate_valueUnchanged(){
                c.startDate = start;
                Assert.AreEqual(start,c.startDate);
            }
            [Test]
            public void setStart_ValidLaterDate_valueUpdated(){
                c.startDate = betweenDate;
                Assert.AreEqual(betweenDate,c.startDate);
            }
            [Test]
            public void setStart_endDate_valueUpdated(){
                c.startDate = end;
                Assert.AreEqual(end,c.startDate);
            }
            [Test]
            public void setStart_InvalidLaterDate_ArgumentException(){
                ArgumentException ex = Assert.Throws<ArgumentException>( delegate {c.startDate = laterEnd;} );
                Assert.AreEqual(ex.Message, "startDate cannot be set to after endDate\r\nParameter name: value" );
            }
            [Test]
            public void setend_InvalidEarlyerDate_valueUpdated(){
                ArgumentException ex = Assert.Throws<ArgumentException>( delegate {c.endDate = earlyerStart;} );
                Assert.AreEqual(ex.Message, "endDate cannot be set to befor startDate\r\nParameter name: value" );

            }
            [Test]
            public void setend_startDate_valueUpdated(){
                c.endDate = start;
                Assert.AreEqual(start,c.endDate);
            }
            [Test]
            public void setend_ValidEarlyerDate_valueUpdated(){
                c.endDate = betweenDate;
                Assert.AreEqual(betweenDate,c.endDate);
            }
            [Test]
            public void setend_SameDate_valueUnchanged(){
                c.endDate = end;
                Assert.AreEqual(end,c.endDate);
            }
            [Test]
            public void setend_LaterDate_valueUpdated(){
                c.endDate = laterEnd;
                Assert.AreEqual(laterEnd,c.endDate);
            }

        }
    }
}