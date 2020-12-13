using NUnit.Framework;
using ReneWiersma.Commands;

namespace ReneWiersma.CommandsTests
{
    public class CompositeCommandTests
    {
        [Test]
        public void ConstructWithNull()
        {
            Assert.That(() => new CompositeCommand(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ConstructWithMultipleNulls()
        {
            Assert.That(() => new CompositeCommand(new TestCommand(), null), Throws.ArgumentNullException);
        }

        [Test]
        public void ConstructTWithNull()
        {
            Assert.That(() => new CompositeCommand<string>(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ConstructTWithMultipleNulls()
        {
            Assert.That(() => new CompositeCommand<string>(new TestStringCommand(), null), Throws.ArgumentNullException);
        }

        [Test]
        public void CommandIsExecuted()
        {
            var testCommand = new TestCommand();
            var sut = new CompositeCommand(testCommand);

            sut.Execute();

            Assert.IsTrue(testCommand.IsExecuted);
        }

        [Test]
        public void CommandTIsExecuted()
        {
            var testCommand = new TestStringCommand();
            var sut = new CompositeCommand<string>(testCommand);

            sut.Execute("isExecuted");

            Assert.AreEqual("isExecuted", testCommand.Message);
        }

        [Test]
        public void MultipleCommandsAreExecuted()
        {
            var testCommand1 = new TestCommand();
            var testCommand2 = new TestCommand();
            var sut = new CompositeCommand(testCommand1, testCommand2);

            sut.Execute();

            Assert.IsTrue(testCommand1.IsExecuted);
            Assert.IsTrue(testCommand2.IsExecuted);
        }

        [Test]
        public void MultipleCommandTAreExecuted()
        {
            var testCommand1 = new TestStringCommand();
            var testCommand2 = new TestStringCommand();
            var sut = new CompositeCommand<string>(testCommand1, testCommand2);

            sut.Execute("isExecuted");

            Assert.AreEqual("isExecuted", testCommand1.Message);
            Assert.AreEqual("isExecuted", testCommand2.Message);
        }
    }
}
