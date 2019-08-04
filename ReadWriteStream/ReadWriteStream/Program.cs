using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteStream
{
    class Program
    {
        static void Main(string[] args)
        {
            const int buffer = 256;
            var adress = "D:\\temp\\ReadWriteStream.txt";

            using (var stream = File.Open(adress, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                byte[] arrayBytes = new byte[buffer];
                while (true)
                {
                    var readedRealBytes = stream.Read(arrayBytes, 0, buffer);
                    var stringArrayBytes = Encoding.Default.GetString(arrayBytes, 0, readedRealBytes);
                    Console.Write(stringArrayBytes);
                    if (readedRealBytes < buffer)
                    {
                        break;
                    }
                }
                stream.Seek(0, SeekOrigin.End);
                while (true)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    char[] arrayChar;
                    if (key.Key == ConsoleKey.Enter)
                    {
                        arrayChar = new char[2];
                        arrayChar[0] = '\r';
                        arrayChar[1] = '\n';
                        Console.WriteLine();
                    }
                    else
                    {
                        arrayChar = new char[1];
                        arrayChar[0] = key.KeyChar;
                    }
                    var arrayByteKey = Encoding.Default.GetBytes(arrayChar);
                    stream.Write(arrayByteKey, 0, arrayByteKey.Length);
                }
            }


            Console.ReadKey(true);
        }

    }
}
