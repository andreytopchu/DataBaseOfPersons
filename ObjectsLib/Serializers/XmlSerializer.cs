using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using ObjectsLib.Persons;

namespace ObjectsLib.Serializers
{
    public class XmlSerializer: ISerializer
    {
        private readonly System.Xml.Serialization.XmlSerializer _xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(HashSet<Person>));
        private const string Mask = @".xml$";

        public void Serialize(string path, PersonsCatalog personsCatalog)
        {
            if (!Regex.IsMatch(path, Mask))
                throw new InvalidOperationException("Невозможно сохранить файл." +
                                                    " Файл не соответствует формату Xml.");
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path, false))
                {
                    _xmlSerializer.Serialize(streamWriter, personsCatalog.PersonsHashSet);
                }
                
                Console.WriteLine("Объект сериализован");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Невозможно сохранить в файл Xml." + ex.Message);
                throw;
            }
        }

        public PersonsCatalog Deserialize(string path)
        {
            if (!Regex.IsMatch(path, Mask))
                throw new InvalidOperationException("Невозможно прочитать файл. " +
                                                    "Файл не соответствует формату Xml.");
            try
            {
                HashSet<Person> deserializesPeople =
                    (HashSet<Person>)_xmlSerializer.Deserialize(File.OpenRead(path));
                PersonsCatalog newPersonsCatalog = new PersonsCatalog();
                newPersonsCatalog.Add(deserializesPeople);

                return newPersonsCatalog;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Ошибка при чтении файла. Возможно объект сериализован в другом формате.");
                throw;
            }
        }
    }
}
