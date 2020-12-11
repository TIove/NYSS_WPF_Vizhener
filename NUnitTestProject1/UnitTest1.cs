using NUnit.Framework;
using System.IO;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual("����", NYSS_WPF_Vizhener.VizhenerAlgorithm.Encode("����", "�"));
            
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual("����������", NYSS_WPF_Vizhener.VizhenerAlgorithm.Decode("����������", "��������"));

        }
        [Test]
        public void Test3()
        {
            string path = @"C:\Users\Igorok\Downloads\asd.txt";
            NYSS_WPF_Vizhener.MainWindow.Upload("Test text", path);
            Assert.IsTrue(File.Exists(path));
        }
        [Test]
        public void Test4()
        {
            string path = @"C:\Users\Igorok\Downloads\asd.txt";
            var res1 = NYSS_WPF_Vizhener.MainWindow.Download(true, "��������", path);
            var res2 = NYSS_WPF_Vizhener.MainWindow.Download(false, "��������", path);
            Assert.AreEqual(res1.Item1, res2.Item2);
            Assert.AreEqual(res1.Item2, res2.Item1);
        }
    }
}