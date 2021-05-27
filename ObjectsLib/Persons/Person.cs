using System;

namespace ObjectsLib.Persons
{
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string NumberOfPassport { get; set; }

        public Person(string secondName, string firstName, string patronymic, DateTime dateOfBirth, 
            string placeOfBirth, string numberOfPassport)
        {
            if (String.IsNullOrEmpty(secondName) || String.IsNullOrEmpty(firstName) ||
                String.IsNullOrEmpty(patronymic) || String.IsNullOrEmpty(placeOfBirth) || 
                String.IsNullOrEmpty(numberOfPassport))
                throw new ArgumentNullException("Невозможно создать персону, так как один из " +
                                                "входных параметров пуст или равен null");
            FirstName = firstName;
            SecondName = secondName;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            PlaceOfBirth = placeOfBirth;
            NumberOfPassport = numberOfPassport;
        }

        public Person()
        {

        }

        public void PrintInfo()
        {
            Console.WriteLine("\nДанные о человеке:");

            Console.Write("Имя: " + FirstName);
            Console.Write("\nФамилия: " + SecondName);
            Console.Write("\nОтчество: " + Patronymic);
            Console.Write("\nДата рождения: " + DateOfBirth.ToShortDateString());
            Console.Write("\nМесто рождения: " + PlaceOfBirth);

            if (NumberOfPassport != null)
            {
                Console.Write("\nНомер паспорта: " + NumberOfPassport);
            }
        }

        public override string ToString()
        {
            return " Фамилия: " + SecondName + " Имя: " + FirstName + " Отчество: "
                   + Patronymic + " Дата рождения: " + DateOfBirth.ToShortDateString() +
                   " Место рождения: " + PlaceOfBirth + " Номер паспорта: " + NumberOfPassport + " ";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Person))
                return false;

            var person = (Person)obj;
            return person.FirstName == FirstName && person.SecondName == SecondName && person.Patronymic ==
                   Patronymic && person.DateOfBirth == DateOfBirth &&
                   person.PlaceOfBirth == PlaceOfBirth && person.NumberOfPassport == NumberOfPassport;
        }

        public override int GetHashCode()
        {
            return NumberOfPassport.GetHashCode();
        }

        public static bool operator ==(Person p1, Person p2) => !(p1 is null) && p1.Equals(p2);

        public static bool operator !=(Person p1, Person p2) => !(p1 is null) && !p1.Equals(p2);
    }
}
