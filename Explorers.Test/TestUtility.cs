using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Models;
using WowDotNetAPI.Utilities;

namespace WowDotNetAPI.Test
{
    [TestClass]
    public class TestUtility
    {
        //Assert.ThrowException 
        public static void ThrowsException<T>(Action action, string expectedMessage) where T : Exception
        {
            try
            {
                action.Invoke();
                Assert.Fail("Exception of type {0} should be thrown", typeof(T));
            }
            catch (T e)
            {
                Assert.AreEqual(expectedMessage, e.Message);
            }
        }
        
    }
}
