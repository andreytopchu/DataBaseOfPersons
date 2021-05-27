using System;
using System.Collections.Generic;
using ObjectsLib.Exceptions;

namespace ObjectsLib.Persons
{
    public class PersonsCatalog
    {

        public HashSet<Person> PersonsHashSet;

        public int Count()
        {
            return PersonsHashSet.Count;
        }

        public PersonsCatalog()
        {
            PersonsHashSet = new HashSet<Person>();
        }

        public void Add(Person person)
        {
            if (person == null)
                throw new ArgumentNullException("Невозможно добавить персону. Человек " +
                                                "не может быть null.");
            if (!PersonsHashSet.Contains(person))
            {
                PersonsHashSet.Add(person);
            }
            else
                throw new PersonAlreadyExistsException("Данный человек уже содержится в каталоге. " +
                                                       "Невозможно выполнить добавление.", person);
        }

        public void Add(HashSet<Person> hashSet)
        {
            if (hashSet == null)
                throw new ArgumentNullException("Невозможно добавить людей. Добавляемая база " +
                                                "не может быть null.");
            PersonsHashSet.UnionWith(hashSet);
        }

        public void DeletePerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));
            if (PersonsHashSet.Contains(person))
            {
                PersonsHashSet.Remove(person);
            }
            else
                throw new PersonDoesNotExistException("Данного человека нет в каталоге. Невозможно выполнить удаление.", person);
        }
    }
}
