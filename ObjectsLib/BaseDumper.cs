using System;
using ObjectsLib.Persons;
using ObjectsLib.Serializers;

namespace ObjectsLib
{
    public class BaseDumper
    {
        public void Save(Serializer serializer, string path, PersonsCatalog personsCatalog)
        {
            if(personsCatalog == null)
                throw new ArgumentNullException(nameof(personsCatalog),
                    "Каталог людей не может быть null");
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path),
                    "Путь не может быть null или пустой строкой");
            if (serializer == null)
                throw new ArgumentNullException(nameof(serializer),
                    "Сериализатор не может быть null");
            serializer.Serialize(path, personsCatalog);
        }

        public PersonsCatalog Load(Serializer serializer, string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path),
                    "Путь не может быть null или пустой строкой");
            if (serializer == null)
                throw new ArgumentNullException(nameof(serializer),
                    "Сериализатор не может быть null");
            return serializer.Deserialize(path);
        }
    }
}
