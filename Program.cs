using System;
using Networking.Serialization;

namespace SerializationTest
{
    // Sample class to serialize and deserialize
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ISerializer serializer = new Serializer();

            // Create a new Person object
            Person person = new Person
            {
                Name = "Alice",
                Age = 30
            };

            // Serialize the Person object
            string serializedPerson = serializer.Serialize(person);
            Console.WriteLine("Serialized Person:");
            Console.WriteLine(serializedPerson);

            // Deserialize the string back to a Person object
            Person deserializedPerson = serializer.Deserialize<Person>(serializedPerson);
            Console.WriteLine("\nDeserialized Person:");
            Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");

            // Test with a null object
            string nullSerialized = serializer.Serialize<Person>(null);
            Console.WriteLine($"\nSerialized null object: {nullSerialized}");

            // Test deserialization of an invalid string
            Person invalidDeserialized = serializer.Deserialize<Person>("invalid xml");
            Console.WriteLine($"\nDeserialized from invalid string: {invalidDeserialized}");
        }
    }
}

