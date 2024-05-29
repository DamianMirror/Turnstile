using System;
using System.IO;
using NUnit.Framework;

namespace lab32.Tests
{
    [TestFixture]
    public class TurnstileTests
    {
        private Turnstile _turnstile;
        private PassInfo _validPass;
        private PassInfo _invalidPass;
        private StringWriter _stringWriter;

        [SetUp]
        public void SetUp()
        {
            // Initialize a new turnstile for each test to ensure a clean state
            _turnstile = new Turnstile(Status.Worker, PassTypes.Permanent, 1);

            // Initialize valid pass
            _validPass = new PassInfo
            (
                "John Doe",
                Status.Worker,
                PassTypes.Permanent,
                3
            );

            // Initialize invalid pass
            _invalidPass = new PassInfo
            (
                "Jane Doe",
                Status.Customer,
                PassTypes.Temporary,
                0
            );

            // Set up StringWriter for capturing console output
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }

        [TearDown]
        public void TearDown()
        {
            // Reset the console output
            _stringWriter.Dispose();
            Console.SetOut(Console.Out);
        }

        [Test]
        public void PassThrough_ValidPass_Enter()
        {
            _turnstile.PassThrough(_validPass, GateAction.Enter);

            var result = _stringWriter.ToString().Trim();
            Assert.IsTrue(result.Contains("Pass is allowed"));
            Assert.IsTrue(result.Contains("Worker John Doe entered at"));
            Assert.AreEqual(1, _turnstile.Logs.Count());
            Assert.AreEqual(1, _turnstile.countTotalPeopleInside);
        }

        [Test]
        public void PassThrough_ValidPass_Exit()
        {
            // Ensure valid pass enters first
            _turnstile.PassThrough(_validPass, GateAction.Enter);
            _stringWriter.GetStringBuilder().Clear(); // Clear the previous output

            // Then test the exit
            _turnstile.PassThrough(_validPass, GateAction.Exit);

            var result = _stringWriter.ToString().Trim();
            Assert.IsTrue(result.Contains("Pass is allowed"));
            Assert.IsTrue(result.Contains("Worker John Doe exited at"));
            Assert.AreEqual(2, _turnstile.Logs.Count());
            Assert.AreEqual(0, _turnstile.countTotalPeopleInside);
        }

        [Test]
        public void PassThrough_InvalidPass_Enter()
        {
            _turnstile.PassThrough(_invalidPass, GateAction.Enter);

            var result = _stringWriter.ToString().Trim();
            Assert.IsTrue(result.Contains("Pass is not allowed for Jane Doe: Wrong pass type."));
            Assert.AreEqual(0, _turnstile.Logs.Count());
            Assert.AreEqual(1, _turnstile.countTotalNotAllowedPasses);
        }

        [Test]
        public void PrintPasses_ShouldOutputCorrectLogs()
        {
            _turnstile.PassThrough(_validPass, GateAction.Enter);
            _turnstile.PassThrough(_validPass, GateAction.Exit);
            _stringWriter.GetStringBuilder().Clear(); // Clear the previous output

            _turnstile.PrintPasses();

            var result = _stringWriter.ToString().Trim();
            Assert.IsTrue(result.Contains("1. Time:"), "Expected log entry 1.");
            Assert.IsTrue(result.Contains("Action: Enter"), "Expected action 'Enter'.");
            Assert.IsTrue(result.Contains("Pass Name: John Doe"), "Expected pass name 'John Doe'.");
            Assert.IsTrue(result.Contains("2. Time:"), "Expected log entry 2.");
            Assert.IsTrue(result.Contains("Action: Exit"), "Expected action 'Exit'.");
            Assert.IsTrue(result.Contains("Pass Name: John Doe"), "Expected pass name 'John Doe'.");
        }

        [Test]
        public void PrintNotAllowedPasses_ShouldOutputCorrectCount()
        {
            _turnstile.PassThrough(_invalidPass, GateAction.Enter);
            _stringWriter.GetStringBuilder().Clear(); // Clear the previous output

            _turnstile.PrintNotAllowedPasses();

            var result = _stringWriter.ToString().Trim();
            Assert.AreEqual("Passes not allowed: 1", result);
        }

        [Test]
        public void PrintPeopleInside_ShouldOutputCorrectCount()
        {
            _turnstile.PassThrough(_validPass, GateAction.Enter);
            _turnstile.PassThrough(_validPass, GateAction.Exit);
            _stringWriter.GetStringBuilder().Clear(); // Clear the previous output

            _turnstile.PrintPeopleInside();

            var result = _stringWriter.ToString().Trim();
            Assert.AreEqual("People inside: 0", result);
        }
    }
}
