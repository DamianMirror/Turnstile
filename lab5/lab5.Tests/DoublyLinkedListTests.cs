using System;
using System.IO;
using NUnit.Framework;

namespace lab32.Tests
{
    [TestFixture]
    public class DoublyLinkedListTests
    {
        private DoublyLinkedList _list;
        private TurnstileLogInfo _logInfo1;
        private TurnstileLogInfo _logInfo2;

        [SetUp]
        public void SetUp()
        {
            _list = new DoublyLinkedList();
            var passBuilder = new PassInfoBuilder();
            var pass1 = passBuilder
                .SetName("John Doe")
                .SetStatus(Status.Customer)
                .SetPassType(PassTypes.Temporary)
                .SetSecurityLevel(5)
                .Build();
            
            var pass2 = passBuilder
                .SetName("Jane Smith")
                .SetStatus(Status.Worker)
                .SetPassType(PassTypes.Permanent)
                .SetSecurityLevel(5)
                .Build();


            _logInfo1 = new TurnstileLogInfo(pass1, GateAction.Enter);
            _logInfo2 = new TurnstileLogInfo(pass2, GateAction.Exit);
        }

        [Test]
        public void Add_ShouldAddElementToList()
        {
            _list.Add(_logInfo1);
            Assert.AreEqual(1, _list.Count());

            _list.Add(_logInfo2);
            Assert.AreEqual(2, _list.Count());
        }

        [Test]
        public void Count_ShouldReturnCorrectCount()
        {
            Assert.AreEqual(0, _list.Count());

            _list.Add(_logInfo1);
            Assert.AreEqual(1, _list.Count());

            _list.Add(_logInfo2);
            Assert.AreEqual(2, _list.Count());
        }

        [Test]
        public void Display_ShouldOutputCorrectLogs()
        {
            _list.Add(_logInfo1);
            _list.Add(_logInfo2);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                _list.Display();

                var result = sw.ToString().Trim();
                Assert.IsTrue(result.Contains("1. Time:"));
                Assert.IsTrue(result.Contains("Action: Enter"));
                Assert.IsTrue(result.Contains("Pass Name: John Doe"));
                Assert.IsTrue(result.Contains("2. Time:"));
                Assert.IsTrue(result.Contains("Action: Exit"));
                Assert.IsTrue(result.Contains("Pass Name: Jane Smith"));
            }
        }

        [Test]
        public void Display_WithActionFilter_ShouldOutputCorrectLogs()
        {
            _list.Add(_logInfo1);
            _list.Add(_logInfo2);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                _list.Display(GateAction.Enter);

                var result = sw.ToString().Trim();
                Assert.IsTrue(result.Contains("1. Time:"));
                Assert.IsTrue(result.Contains("Action: Enter"));
                Assert.IsTrue(result.Contains("Pass Name: John Doe"));
                Assert.IsFalse(result.Contains("Action: Exit"));

                sw.GetStringBuilder().Clear();

                _list.Display(GateAction.Exit);

                result = sw.ToString().Trim();
                Assert.IsTrue(result.Contains("1. Time:"));
                Assert.IsTrue(result.Contains("Action: Exit"));
                Assert.IsTrue(result.Contains("Pass Name: Jane Smith"));
                Assert.IsFalse(result.Contains("Action: Enter"));
            }
        }
    }
}
