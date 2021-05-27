using ObjectsLib.Persons;

namespace ObjectsLib.Serializers
{
    public interface ISerializer
   {
       void Serialize(string path, PersonsCatalog personsCatalog);
       PersonsCatalog Deserialize(string path);
   }
}
