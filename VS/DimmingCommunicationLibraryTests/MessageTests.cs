using Microsoft.VisualStudio.TestTools.UnitTesting;
using DimmingCommunicationLibrary;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DimmingCommunicationLibrary.Tests
{
    [TestClass()]
    public class MessageTests
    {

        [TestMethod()]
        public void getMessageTest()
        {
            char[] actual = new char[] { '@', '0', '1', 'F', '1', '2', '5', '7', 'F' };

            Message m = new Message();
            m.SetChannel(1);
            m.SetBody(new char[] { 'F', '1', '2', '5' });
            char[] result = m.GetMessage().Select( c => Convert.ToChar(c)).ToArray();

            Assert.IsTrue(actual.SequenceEqual(result));
        }
    }
}