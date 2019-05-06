using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var persons = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Name = "nick",
                    Address = new Address
                    {
                        Street = "123 Main st.",
                        City = "Dallas",
                        State = "TX"
                    }
                },
                 new Person
                {
                    Id = 2,
                    Name = "paul",
                    Address = new Address
                    {
                        Street = "365 Albert st.",
                        City = "Austen",
                        State = "OR"
                    }
                 }
            };
            // $ string interoplation
            // @ are to disable escape sequences
            SerializeXMLToFile(@"C:\revature\persons.xml", persons);
            List<Person> FromFile = DeserializeXMLFromFIle(@"C:\revature\persons.xml");
            FromFile[0].Name = "Donkey";
            SerializeXMLToFile(@"C:\revature\persons.xml", FromFile);
            Task task = SerializeJSONToFile(@"C:\revature\persons.json", FromFile);
            //if you don't event, code below will  prob run
            await task;

        }

        private async static Task SerializeJSONToFile(string fileName, List<Person> persons)
        {
            string json = JsonConvert.SerializeObject(persons);
            try
            {
                await File.WriteAllTextAsync(fileName, json);
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static List<Person> DeserializeXMLFromFIle(string fileName)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Person>));
            using (FileStream filestream = new FileStream(fileName, FileMode.Open))
            {
               return (List<Person>)xmlSerializer.Deserialize(filestream);
            }
        }
        private static void SerializeXMLToFile(string fileName, List<Person> persons)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Person>));

            using (FileStream filestream = new FileStream(fileName, FileMode.Create))
            {
                xmlSerializer.Serialize(filestream, persons);
            }
        }
    }
}
