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
            char[] actual = new char[] { '@', '0', '1', 'F', '1', '2', '5', '7', 'F', '\r', '\n' };

            Message m = new Message();
            m.SetChannel(1);
            m.SetBody(new char[] { 'F', '1', '2', '5' });
            char[] result = m.GetMessage().Select(c => Convert.ToChar(c)).ToArray();

            Assert.IsTrue(actual.SequenceEqual(result));
        }

        [TestMethod()]
        public void test調光データ設定電文()
        {
            Message m = SendMessage.調光データ設定電文(1, 2);
            String expected = "@01F00279\r\n";

            string actual = m.ToASCII();
            Assert.IsTrue(actual == expected);
        }
        [TestMethod()]
        public void test発光モード設定電文()
        {
            Message m = SendMessage.発光モード設定電文(1, 発光モード.ONOFFモード, ストロボ.v_10m);
            String expected = "@01S0054\r\n";

            string actual = m.ToASCII();
            Assert.IsTrue(actual == expected);
        }
        [TestMethod()]
        public void testONOFF設定電文()
        {
            Message m = SendMessage.ONOFF設定電文(1, true);
            string expected = "@01L11E\r\n";

            string actual = m.ToASCII();
            Assert.IsTrue(actual == expected);
        }
        [TestMethod()]
        public void test設定状態確認電文()
        {
            Message m = SendMessage.設定状態確認電文(1);
            String expected = "@01MEE\r\n";

            string actual = m.ToASCII();
            Assert.IsTrue(actual == expected);
        }
        [TestMethod()]
        public void test状態確認電文()
        {
            Message m = SendMessage.状態確認電文();
            String expected = "@00CE3\r\n";

            string actual = m.ToASCII();
            Assert.IsTrue(actual == expected);
        }
    }
}
