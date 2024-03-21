using BroomDLL;
using BroomDLL.Browsers;
namespace BroomTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestWriteToLogFile()
        {
            string line;
            string line1 = "";
            BroomLogFile.WriteLogFile("Test message");
            using(var reader = File.OpenText(@"broom.log"))
            {
                while((line = reader.ReadLine()) != null)
                {
                    line1 = line;
                }
            }
            Assert.AreEqual("Test message", line1);
        }

         [Test]
        public void TestCrearTestFolder()
        {
            CreateTestDirAndFiles();
            Test.Clear(@"C:\Users\");
            bool expect = !Directory.EnumerateFileSystemEntries(@"C:\Users\Temp").Any();
            Assert.AreEqual(true, expect);
        }  

        private void CreateTestDirAndFiles()
        {
            const string dir = @"C:\Users\Temp\";
            DirectoryInfo path = new DirectoryInfo($@"{dir}");
            path.Create();
            const string subDir = @"SubDirectory\";
            path.CreateSubdirectory(subDir);
            for (int i = 0; i < 3; i++)
            {
                string file = dir + "file" + i + ".txt";
                using (FileStream fs = File.Create(file));
                string subFile = dir + subDir + "file" + i + ".txt";
                using (FileStream fs = File.Create(subFile));
            }
            BroomLogFile.WriteLogException += BroomConsole.BroomConsole.ExceptionMessage;
        }     
    }
}