using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp5;

namespace UnitTestProject1
{
    [TestClass]
    public class Code
    { 
        [TestMethod]
        public void codetester()
        {       // ����������
            string content = "����������� �����";
            string key = "�����";
            string result = "����������� �����";
            // test result
          

            string real = code1.code(content,key);

            Assert.AreEqual(real, result);
        }
        [TestMethod]
        public void decodetester() 
        {
            string content = "���� �� ��� ������� �� �� ���";
            string key = "�������";
            string result = "���� �� ��� ������� �� �� ���";
            // test result
            string real = code1.decode(content, key);

            Assert.AreEqual(real, result);


        }
    }
}
