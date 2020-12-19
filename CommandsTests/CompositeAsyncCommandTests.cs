using NUnit.Framework;
using ReneWiersma.Commands;
using System.Threading.Tasks;

namespace ReneWiersma.CommandsTests
{
    public class CompositeAsyncCommandTests
    {
        [Test]
        public void ConstructWithNull()
        {
            Assert.That(() => new CompositeAsyncCommand(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ConstructWithMultipleNulls()
        {
            Assert.That(() => new CompositeAsyncCommand(new TestAsyncCommand(), null), Throws.ArgumentNullException);
        }

        [Test]
        public void ConstructTWithNull()
        {
            Assert.That(() => new CompositeAsyncCommand<string>(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ConstructTWithMultipleNulls()
        {
            Assert.That(() => new CompositeAsyncCommand<string>(new TestStringAsyncCommand(), null), Throws.ArgumentNullException);
        }

        [Test]
        public async Task CommandIsExecuted()
        {
            var testCommand = new TestAsyncCommand();
            var sut = new CompositeAsyncCommand(testCommand);

            await sut.Execute();

            Assert.IsTrue(testCommand.IsExecuted);
        }

        [Test]
        public async Task CommandTIsExecuted()
        {
            var testCommand = new TestStringAsyncCommand();
            var sut = new CompositeAsyncCommand<string>(testCommand);

            await sut.Execute("isExecuted");

            Assert.AreEqual("isExecuted", testCommand.Message);
        }

        [Test]
        public async Task MultipleCommandsAreExecuted()
        {
            var testCommand1 = new TestAsyncCommand();
            var testCommand2 = new TestAsyncCommand();
            var sut = new CompositeAsyncCommand(testCommand1, testCommand2);

            await sut.Execute();

            Assert.IsTrue(testCommand1.IsExecuted);
            Assert.IsTrue(testCommand2.IsExecuted);
        }

        [Test]
        public async Task MultipleCommandTAreExecuted()
        {
            var testCommand1 = new TestStringAsyncCommand();
            var testCommand2 = new TestStringAsyncCommand();
            var sut = new CompositeAsyncCommand<string>(testCommand1, testCommand2);

            await sut.Execute("isExecuted");

            Assert.AreEqual("isExecuted", testCommand1.Message);
            Assert.AreEqual("isExecuted", testCommand2.Message);
        }
    }
}
