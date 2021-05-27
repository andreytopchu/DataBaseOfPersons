using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectsLib;
using ObjectsLib.Persons;
using ObjectsLib.Serializers;
using System.IO;

namespace Test
{
    [TestClass]
    public class DataBaseTest
    {
        private const string PathForSave = "D:/АНДРЕИНО/универ/4 семестр/Практика C#/Projects/DatabaseOfPersons/Test/PersonsSerialized";
        [TestMethod]
        public void XmlSerializationTest()
        {
            GeneratorOfPersons generator = new GeneratorOfPersons();
            var collectionOfPersons = generator.GeneratePersons(25);
            PersonsCatalog personsCatalog = new PersonsCatalog();
            personsCatalog.Add(collectionOfPersons);

            Serializer serializer = new Serializer(new XmlSerializer());
            BaseDumper baseDumper = new BaseDumper();

            baseDumper.Save(serializer,Path.Combine(PathForSave,"peoples.xml"),personsCatalog);
            PersonsCatalog newPersonsCatalog = baseDumper.Load(serializer, 
                Path.Combine(PathForSave, "peoples.xml"));

            foreach (var person in newPersonsCatalog.PersonsHashSet)
            {
                person.PrintInfo();
            }

            Assert.AreEqual(personsCatalog.Count(),newPersonsCatalog.Count());
        }

        [TestMethod]
        public void JsonSerializationTest()
        {
            GeneratorOfPersons generator = new GeneratorOfPersons();
            var collectionOfPersons = generator.GeneratePersons(25);
            PersonsCatalog personsCatalog = new PersonsCatalog();
            personsCatalog.Add(collectionOfPersons);

            Serializer serializer = new Serializer(new JsonSerializer());
            BaseDumper baseDumper = new BaseDumper();

            baseDumper.Save(serializer, Path.Combine(PathForSave, "peoples.json"), personsCatalog);
            PersonsCatalog newPersonsCatalog = baseDumper.Load(serializer,
                Path.Combine(PathForSave, "peoples.json"));

            foreach (var person in newPersonsCatalog.PersonsHashSet)
            {
                person.PrintInfo();
            }
            Assert.AreEqual(personsCatalog.Count(), newPersonsCatalog.Count());
        }

        [TestMethod]
        public void BinarySerializationTest()
        {
            GeneratorOfPersons generator = new GeneratorOfPersons();
            var collectionOfPersons = generator.GeneratePersons(25);
            PersonsCatalog personsCatalog = new PersonsCatalog();
            personsCatalog.Add(collectionOfPersons);

            Serializer serializer = new Serializer(new BinarySerializer());
            BaseDumper baseDumper = new BaseDumper();

            baseDumper.Save(serializer, Path.Combine(PathForSave, "peoples.dat"), personsCatalog);
            PersonsCatalog newPersonsCatalog = baseDumper.Load(serializer,
                Path.Combine(PathForSave, "peoples.dat"));

            foreach (var person in newPersonsCatalog.PersonsHashSet)
            {
                person.PrintInfo();
            }
            Assert.AreEqual(personsCatalog.Count(), newPersonsCatalog.Count());
        }
    }
}
