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
            Assert.AreEqual("аааа", NYSS_WPF_Vizhener.VizhenerAlgorithm.Encode("аааа", "а"));
            
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual("поздравл€ю", NYSS_WPF_Vizhener.VizhenerAlgorithm.Decode("бщцфаирщри", "скорпион"));

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
            var res1 = NYSS_WPF_Vizhener.MainWindow.Download(true, "скорпион", path);
            var res2 = NYSS_WPF_Vizhener.MainWindow.Download(false, "скорпион", path);
            Assert.AreEqual(res1.Item1, res2.Item2);
            Assert.AreEqual(res1.Item2, res2.Item1);
        }
    }
}