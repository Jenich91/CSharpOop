using System;

namespace LamdaTask
{
    public class Person : IEquatable<Person>
    {
        public string name { get; set; }

        public int age { get; set; }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return $"{name} - возраст: {age}";
        }

        public override int GetHashCode()
        {
            int prime = 17;
            int hash = 1;

            hash = prime * hash + age.GetHashCode();
            hash = prime * hash + name.GetHashCode();

            return hash;
        }

        public bool Equals(Person obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || GetType() != obj.GetType())
            {
                return false;
            }

            Person person = (Person)obj;

            return age.Equals(person.age) && name.Equals(person.name);
        }
    }
}