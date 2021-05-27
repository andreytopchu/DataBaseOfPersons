using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using ObjectsLib.Persons;

namespace ObjectsLib.Serializers
{
    public class JsonSerializer:ISerializer
    {
        private const string Mask = @".json$";
        public void Serialize(string path, PersonsCatalog personsCatalog)
        {
            if (!Regex.IsMatch(path, Mask))
                throw new InvalidOperationException("Невозможно сохранить файл. " +
                                                    "Файл не соответствует формату Json.");
            try
            {
                string jsonContent = JsonConvert.SerializeObject(personsCatalog.PersonsHashSet);

                File.WriteAllText(path, jsonContent);
                Console.WriteLine("Объект сериализован");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Невозможно сохранить в файл Json." + ex.Message);
                throw;
            }
        }

        public PersonsCatalog Deserialize(string path)
        {
            if (!Regex.IsMatch(path, Mask))
                throw new InvalidOperationException("Невозможно прочитать файл. " +
                                                    "Файл не соответствует формату Json.");
            try
            {
                string text = File.ReadAllText(path);

                HashSet<Person> deserializesPeople =
                    JsonConvert.DeserializeObject<HashSet<Person>>(text);
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
