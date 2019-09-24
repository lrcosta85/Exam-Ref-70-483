using System;
using System.IO;
using System.Text;
using System.IO.Compression;
using System.Linq;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //CreateFileUseFileStream();
            //FileCreateTextStreamWriter();
            //OpenReadFileStream();
            //OpenTextFileStreamReader();
            CompressFileGZipStream();
        }

        public static void CreateFileUseFileStream()
        {
            string path = @"C:\Users\luizr\Documents\Certificação\teste.txt";

            if (File.Exists(path))
            {
                using (FileStream fileStream = File.OpenWrite(path))
                {
                    string myValue = "MyValue123";
                    byte[] data = Encoding.UTF8.GetBytes(myValue);
                    fileStream.Write(data, 0, data.Length);

                }
            }
            else
            {
                using (FileStream fileStream = File.Create(path))
                {
                    string myValue = "MyValue";
                    byte[] data = Encoding.UTF8.GetBytes(myValue);
                    fileStream.Write(data, 0, data.Length);

                }
            }

        }
        public static void FileCreateTextStreamWriter()
        {
            string path = @"C:\Users\luizr\Documents\Certificação\FileCreateTextStreamWriter.txt";

            using (StreamWriter streamWriter = File.CreateText(path))
            {
                string myValue = "MyValue FileCreateTextStreamWriter";
                streamWriter.Write(myValue);
            }
        }
        public static void OpenReadFileStream()
        {
            string path = @"C:\Users\luizr\Documents\Certificação\FileCreateTextStreamWriter.txt";
            using (FileStream fileStream = File.OpenRead(path))
            {
                byte[] data = new byte[fileStream.Length];

                for (int i = 0; i < fileStream.Length; i++)
                {
                    data[i] = (byte)fileStream.ReadByte();
                }

                Console.WriteLine(Encoding.UTF8.GetString(data));
            }
        }
        public static void OpenTextFileStreamReader()
        {
            string path = @"C:\Users\luizr\Documents\Certificação\FileCreateTextStreamWriter.txt";

            using (StreamReader streamReader = File.OpenText(path))
            {
                Console.WriteLine(streamReader.ReadLine());
            }
        }
        public static void CompressFileGZipStream()
        {
            string path = @"C:\Users\luizr\Documents\Certificação";
            string arquivoDescompactadoPath = Path.Combine(path, "NovoArquivo.txt");
            string arquivoCompactadoPath = Path.Combine(path, "ArquivoCompactado.gz");

            byte[] data = Enumerable.Repeat((byte)'a', 1024 * 1024).ToArray();

            using(FileStream descompactadoFileStream = File.Create(arquivoDescompactadoPath))
            {
                descompactadoFileStream.Write(data, 0, data.Length);
            }
            using (FileStream compactadoFileStream = File.Create(arquivoCompactadoPath))
            {
                using(GZipStream compactacaoStream = new GZipStream(compactadoFileStream, CompressionMode.Compress))
                {
                    compactacaoStream.Write(data, 0, data.Length);
                }
            }

        }



    }
}
