using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileWithObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Samarth";
            person.Age = 22;

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("D:\\Input.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, person);
            stream.Close();

            stream = new FileStream("D:\\Input.txt", FileMode.Open, FileAccess.Read);

            Person p = (Person)formatter.Deserialize(stream);

            Console.WriteLine(p.Name);
            Console.WriteLine(p.Age);

            Console.ReadKey();
        }
    }
}
