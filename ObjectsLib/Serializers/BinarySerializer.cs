using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using ObjectsLib.Persons;

namespace ObjectsLib.Serializers
{
    public class BinarySerializer:ISerializer
    {
        private readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();
        private const string Mask = @".dat$";
        public void Serialize(string path, PersonsCatalog personsCatalog)
        {
            if (!Regex.IsMatch(path, Mask))
                throw new InvalidOperationException("Невозможно сохранить файл." +
                                                    " Файл не соответствует формату .dat.");
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    _binaryFormatter.Serialize(fileStream, personsCatalog.PersonsHashSet);
                }

                Console.WriteLine("Объект сериализован");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Невозможно сохранить в файл Binary." + ex.Message);
                throw;
            }
        }

        public PersonsCatalog Deserialize(string path)
        {
            if (!Regex.IsMatch(path, Mask))
                throw new InvalidOperationException("Невозможно прочитать файл. " +
                                                    "Файл не соответствует формату .dat .");
            try
            {
                HashSet<Person> deserializesPeople =
                    (HashSet<Person>)_binaryFormatter.Deserialize(File.OpenRead(path));
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
