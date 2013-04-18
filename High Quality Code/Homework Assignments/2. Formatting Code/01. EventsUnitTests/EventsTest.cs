// ********************************
// <copyright file="EventsTest.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace EventsUnitTests
{
    using System;
    using Events;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Contains methods testing the events functionality.
    /// </summary>
    [TestClass]
    public class EventsTest
    {
        [TestMethod]
        public void TestEventConstructor1()
        {
            Event seminar = new Event(new DateTime(2013, 4, 9, 10, 0, 0), "ASP.NET MVC", "Telerik Academy");
            Assert.AreEqual("2013-04-09T10:00:00", seminar.DateAndTime.ToString("yyyy-MM-ddTHH:mm:ss"));
        }

        [TestMethod]
        public void TestEventConstructor2()
        {
            Event seminar = new Event(new DateTime(2013, 4, 9, 10, 0, 0), "Trees & Graphs", "Telerik Academy");
            Assert.AreEqual("Trees & Graphs", seminar.Title);
        }

        [TestMethod]
        public void TestEventConstructor3()
        {
            Event seminar = new Event(new DateTime(2013, 4, 9, 10, 0, 0), "JavaScript Part II", "Ultimate Hall");
            Assert.AreEqual("Ultimate Hall", seminar.Location);
        }

        [TestMethod]
        public void TestEventToString1()
        {
            Event seminar = new Event(new DateTime(2013, 4, 9, 10, 0, 0), "OOP", "Enterprise Hall");
            Assert.AreEqual("2013-04-09T10:00:00 | OOP | Enterprise Hall", seminar.ToString());
        }

        [TestMethod]
        public void TestEventToString2()
        {
            Event seminar = new Event(new DateTime(2013, 4, 9, 9, 0, 0), "Algorithms & Data Structures", string.Empty);
            Assert.AreEqual("2013-04-09T09:00:00 | Algorithms & Data Structures", seminar.ToString());
        }

        [TestMethod]
        public void TestEventCompareTo1()
        {
            Event seminar = new Event(new DateTime(2013, 5, 9, 9, 0, 0), "Humanware", "Telerik Academy");
            Event lecture = new Event(new DateTime(2013, 5, 19, 19, 0, 0), "CMS", "Telerik Academy");

            Assert.AreEqual(true, seminar.CompareTo(lecture) < 0);
        }

        [TestMethod]
        public void TestEventCompareTo2()
        {
            Event seminar = new Event(new DateTime(2013, 5, 9, 9, 0, 0), "Humanware", "Telerik Academy");
            Event lecture = new Event(new DateTime(2013, 5, 9, 9, 0, 0), "CMS", "Telerik Academy");

            Assert.AreEqual(true, seminar.CompareTo(lecture) > 0);
        }

        [TestMethod]
        public void TestEventCompareTo3()
        {
            Event seminar = new Event(new DateTime(2013, 5, 9, 9, 0, 0), "Humanware", "Enterprise Hall");
            Event lecture = new Event(new DateTime(2013, 5, 9, 9, 0, 0), "Humanware", "Telerik Academy");

            Assert.AreEqual(true, seminar.CompareTo(lecture) < 0);
        }

        [TestMethod]
        public void TestAddEvent1()
        {
            EventHolder eventHolder = new EventHolder();
            eventHolder.AddEvent(new DateTime(2013, 4, 21, 11, 30, 0), "3D Graphics", "Ultimate Hall");

            Assert.AreEqual("Event added" + Environment.NewLine, eventHolder.Log);
        }

        [TestMethod]
        public void TestListEvents1()
        {
            EventHolder eventHolder = new EventHolder();
            eventHolder.ListEvents(new DateTime(2013, 4, 21, 11, 30, 0), 10);

            Assert.AreEqual(true, eventHolder.Log.EndsWith("No events found" + Environment.NewLine));
        }

        [TestMethod]
        public void TestDeleteEvents1()
        {
            EventHolder eventHolder = new EventHolder();
            eventHolder.AddEvent(new DateTime(2013, 6, 21, 11, 30, 0), "WPF", "Ultimate Hall");
            eventHolder.DeleteEvents("WPF");
            Assert.AreEqual(true, eventHolder.Log.EndsWith("1 event(s) deleted" + Environment.NewLine));
        }
    }
}
