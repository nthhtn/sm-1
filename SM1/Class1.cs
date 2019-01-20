using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.IO;

namespace SM1
{
    public class Class1
    {

        public string fileContent(int start, int length = 10)
        {
            if (length < 1)
            {
                return "INVALID_INPUT";
            }
            List<int> fibo = new List<int> { 1, 1 };
            List<int> result = new List<int> { };
            if (start < 1)
            {
                result = length == 1 ? new List<int> { 1 } : new List<int> { 1, 1 };
            }
            int i = fibo.Count() - 1;
            while (result.Count < length)
            {
                if (fibo[i] > start)
                {
                    result.Add(fibo[i]);
                }
                fibo.Add(fibo[i] + fibo[i - 1]);
                i = fibo.Count() - 1;
            }
            string content = string.Join(" ", result);
            string directory = Directory.GetCurrentDirectory();
            string path = directory + @"\output.txt";
            File.WriteAllText(path, content);
            return content;
        }

        // Test input

        [Fact]
        public void PassInput()
        {
            Assert.Equal("INVALID_INPUT", fileContent(0, 0));
            string directory = Directory.GetCurrentDirectory();
            string path = directory + @"\output.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void PassDefault()
        {
            Assert.Equal("5 8 13 21 34 55 89 144 233 377", fileContent(4));
            string directory = Directory.GetCurrentDirectory();
            string path = directory + @"\output.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        // Test output

        [Fact]
        public void Pass01()
        {
            Assert.Equal("1", fileContent(0, 1));
            string directory = Directory.GetCurrentDirectory();
            string path = directory + @"\output.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void Pass02()
        {
            Assert.Equal("1 1", fileContent(0, 2));
            string directory = Directory.GetCurrentDirectory();
            string path = directory + @"\output.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void Pass24()
        {
            Assert.Equal("3 5 8 13", fileContent(2, 4));
            string directory = Directory.GetCurrentDirectory();
            string path = directory + @"\output.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        // Test result written into file

        [Fact]
        public void Pass24File()
        {
            string result = fileContent(2, 4);
            string directory = Directory.GetCurrentDirectory();
            string path = directory + @"\output.txt";
            Assert.Equal("3 5 8 13", result);
            Assert.Equal(true, File.Exists(path));
            Assert.Equal(result, File.ReadAllText(path));
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

    }

}
