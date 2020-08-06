using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp5;

namespace UnitTestProject1
{
    [TestClass]
    public class Code
    { 
        [TestMethod]
        public void codetester()
        {       // переменные
            string content = "моргенштерн говно";
            string key = "базаю";
            string result = "ношггошъеоо гцвлп";
            // test result
          

            string real = code1.code(content,key);

            Assert.AreEqual(real, result);
        }
        [TestMethod]
        public void decodetester() 
        {
            string content = "цпьш гд едм зшгимйъ гю гд уау";
            string key = "сюрприз";
            string result = "если ты это читаешь то ты лох";
            // test result
            string real = code1.decode(content, key);

            Assert.AreEqual(real, result);


        }
    }
}
