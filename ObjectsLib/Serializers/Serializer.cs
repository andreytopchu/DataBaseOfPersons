using ObjectsLib.Persons;

namespace ObjectsLib.Serializers
{
    public class Serializer
    {
        private readonly ISerializer _serializer;
        public Serializer(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public void Serialize(string path, PersonsCatalog personsCatalog)
        {
            _serializer.Serialize(path, personsCatalog);
        }

        public PersonsCatalog Deserialize(string path)
        {
            return _serializer.Deserialize(path);
        }
    }
}
