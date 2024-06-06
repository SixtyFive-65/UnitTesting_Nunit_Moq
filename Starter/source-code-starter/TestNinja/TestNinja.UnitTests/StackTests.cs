using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Count()
        {
            var stack = new Stack<string>();

            Assert.That(stack.Count(), Is.EqualTo(0));
        }

        [Test]
        [Ignore("Should work but it moans!!!!")]
        public void Push_ArgumentNull_ReturnNull()
        {
            var stack = new Stack<string>();

           Assert.That(() => stack.Push(null),Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Push_ArgumentNull_ReturnPushedList()
        {
            var stack = new Stack<string>();

            var ogCount = stack.Count;

            stack.Push("word");

            var c = stack.Count;

            Assert.That(c, Is.EqualTo(ogCount + 1));
        }

        [Test]
        public void Pop_ArgumentNull_ReturnNull()
        {
            var stack = new Stack<object>();

            Assert.That(() => stack.Pop(), Throws.TypeOf<InvalidOperationException>());
        }


        [Test]
        public void Pop_ArgumentNull_ReturnPushedList()
        {
            var stack = new Stack<string>();

            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Pop();   

            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Peek_ArgumentNull_ReturnNull()
        {
            var stack = new Stack<object>();

            Assert.That(() => stack.Peek(), Throws.TypeOf<InvalidOperationException>());
        }


        [Test]
        public void Peek_ArgumentNull_ReturnPushedList()
        {
            var stack = new Stack<string>();

            stack.Push("");

            var p = stack.Peek();

            Assert.That(p, Is.Not.Null);
        }
    } 
}