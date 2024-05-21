using System;
using NUnit.Framework;

namespace lab32
{
    [TestFixture]
    public class TurnstileTests
    {
        private Turnstile _turnstile;
        private PassInfo _validPass;
        private PassInfo _invalidPass;

        [SetUp]
        public void SetUp()
        {
            _turnstile = new Turnstile(Status.Worker, PassTypes.Permanent, 1);

            // Initialize valid pass
            _validPass = new PassInfo
            (
                "John Doe",
                Status.Worker,
                PassTypes.Permanent,
                3,
                5
            );

            // Initialize invalid pass
            _invalidPass = new PassInfo
            (
                "Jane Doe",
                Status.Customer,
                PassTypes.Temporary,
                1,
                0
            );
        }

        [Test]
        public void PassThrough_ValidPass_Enter()
        {
            _turnstile.PassThrough(_validPass, GateAction.Enter);

            // Check logs and people count
            Assert.AreEqual(1, _turnstile.Logs.Count());
            Assert.AreEqual(1, _turnstile.countTotalPeopleInside);
        }

        [Test]
        public void PassThrough_ValidPass_Exit()
        {
            _turnstile.PassThrough(_validPass, GateAction.Exit);

            // Check logs and people count
            Assert.AreEqual(2, _turnstile.Logs.Count());
            Assert.AreEqual(0, _turnstile.countTotalPeopleInside);
        }

        [Test]
        public void PassThrough_InvalidPass_Enter()
        {
            _turnstile.PassThrough(_invalidPass, GateAction.Enter);

            // Check logs and not allowed passes count
            Assert.AreEqual(3, _turnstile.Logs.Count());
            Assert.AreEqual(0, _turnstile.countTotalNotAllowedPasses);
        }

        [Test]
        public void PassThrough_InsufficientPassesRemaining()
        {
            
            _turnstile.PassThrough(_invalidPass, GateAction.Enter);

            // Check logs and not allowed passes count
            Assert.AreEqual(4, _turnstile.Logs.Count());
            Assert.AreEqual(0, _turnstile.countTotalNotAllowedPasses);
        }

        [Test]
        public void LogEntryExit_InvalidAction()
        {
            _turnstile.LogEntryExit(_validPass, (GateAction)999);

            // Check logs and people count
            Assert.AreEqual(0, _turnstile.Logs.Count);
            Assert.AreEqual(0, _turnstile.countTotalPeopleInside);
        }
    }

    
}
