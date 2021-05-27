using System;
using System.Collections.Generic;

namespace ObjectsLib.Persons
{
    public class GeneratorOfPersons
    {
        private readonly Random _rand = new Random();


        private readonly string[] _names = new string[]
        {
            " Андрей ",
            " Владимир ",
            " Анатолий ",
            " Георгий ",
            " Валентин ",
            " Валерий ",
            " Александр ",
            " Аркадий ",
            " Дмитрий ",
            " Кирилл "
        };

        private readonly string[] _secondNames = new string[]
        {
            " Иванов ",
            " Петров ",
            " Давыдов ",
            " Сидоров ",
            " Беляков ",
            " Шумило ",
            " Симоненко ",
            " Шубин ",
            " Кузнецов ",
            " Игнатов  ",
        };

        private readonly string[] _patronymics = new string[]
        {
            " Владимирович ",
            " Петрович ",
            " Алексеевич ",
            " Леонидович ",
            " Эдуардович ",
            " Васильевич ",
            " Сергеевич ",
            " Андреевич ",
            " Владимирович ",
            " Викторович  ",
        };

        private readonly string[] _placesOfBirth = new string[]
        {
            " Тирасполь ",
            " Бендеры ",
            " Слободзея ",
            " Суклея ",
            " Григориополь ",
            " Дубоссары ",
            " Каменка ",
            " Рыбница ",
            " Красное ",
            " Копанка  ",
        };

        private string GenerateFirstName()
        {
            return _names[_rand.Next(0, _names.Length)];
        }

        private string GenerateSecondName()
        {
            return _secondNames[_rand.Next(0, _secondNames.Length)];
        }

        private string GeneratePatronymic()
        {
            return _patronymics[_rand.Next(0, _patronymics.Length)];
        }

        private DateTime GenerateDate()
        {
            var start = new DateTime(1950, 1, 1);
            var range = (new DateTime(2005, 1, 1) - start).Days;
            return start.AddDays(_rand.Next(range));
        }

        private string GeneratePlaceOfBirth()
        {
            return _placesOfBirth[_rand.Next(0, _placesOfBirth.Length)];
        }

        readonly HashSet<int> _hashSet = new HashSet<int>();

        private string GenerateNumberOfPassport()
        {
            var flag = false;
            var serialNumber = -1;

            while (!flag)
            {
                serialNumber = _rand.Next(100000, 1000000);
                if (_hashSet.Add(serialNumber)) flag = true;
            }

            return "I-ПР №" + serialNumber;
        }

        public HashSet<Person> GeneratePersons(int count)
        {
            var personsHashSet = new HashSet<Person>();
            for (var i = 0; i < count; i++)
            {
                try
                {
                    personsHashSet.Add(new Person(GenerateSecondName(), GenerateFirstName(), GeneratePatronymic(),
                        GenerateDate(), GeneratePlaceOfBirth(), GenerateNumberOfPassport()));
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
            return personsHashSet;
        }

    }
}
