using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlingPractice
{
    class Program
    {
        static void Main(string[] args)
        {

            FileStream file = new FileStream(@"E:\abc.txt", FileMode.OpenOrCreate);
            int i;
            for (i = 65; i <= 90; i++)
                file.WriteByte((byte)i);

            i = 0;
            while ((i = file.ReadByte()) != -1)
                Console.WriteLine((char)i);



            file = new FileStream(@"E:\stream.txt", FileMode.OpenOrCreate);

            StreamWriter streamWriter = new StreamWriter(file);
            streamWriter.WriteLine("Hello World");
            streamWriter.Close();


            StreamReader streamReader = new StreamReader(file);
            string line = streamReader.ReadLine();
            Console.WriteLine(line);

            streamReader.Close();

            //Multiple Line Write

            streamWriter = new StreamWriter(file);

            line = "";
            string writeContent = "";

            while (!line.Equals("exit"))
            {
                line = Console.ReadLine();
                writeContent += line;
            }
            streamWriter.WriteLine(line);
            streamWriter.Close();

            // Multiple line 
            streamReader = new StreamReader(file);
            line = "";

            while ((line = streamReader.ReadLine()) != null)
                Console.WriteLine(line);

            streamReader.Close();
            file.Close();


            //Text File

            using (TextWriter writer = File.CreateText(@"E:\text.txt"))
                writer.WriteLine("Hiii Everyone");


            //TextFile Multiple 

            line = "";
            string data = "";
            using (TextWriter writer = File.CreateText(@"E:\text.txt"))
            {
                while (line != "exit")
                {
                    line = Console.ReadLine();
                    data += line + '\n';
                }
                writer.WriteLine(data);
            }


            //Text Reader

            using (TextReader reader = File.OpenText(@"E:\text.txt"))
                Console.WriteLine(reader.ReadToEnd());


            //BinaryFile

            string fileName = "E:\\binary.dat";
            line = "";
            data = "";
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
            {
                while (true)
                {
                    line = Console.ReadLine();
                    if (line.Equals("Exit"))
                        break;
                    data += line + '\n';

                }
                writer.Write(data);
            }


            //Binary Reader 

            using (BinaryReader reader = new BinaryReader(File.Open("E:\\binary.dat", FileMode.Open)))
            {
                Console.WriteLine(reader.ReadString());
            }


            Console.ReadKey();
        }
    }
}

