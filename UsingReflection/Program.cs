using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UsingReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleMVA();

        }

        static void HowDoIGetTypeData()
        {
            var person = new Person();

            //first way for get type
            Type t1 = typeof(Person);

            Console.WriteLine(t1.Name);

            //second way for get type
            Type t2 = person.GetType();

            Console.WriteLine(t2.Assembly);

            Console.ReadKey();
        }

        static void HowCanICreateInstanceOfaType()
        {
            var newPerson = (Person)Activator.CreateInstance(typeof(Person));

            var genericPerson = Activator.CreateInstance<Person>();

            var personConstructor = typeof(Person).GetConstructors()[0];

            var advancePerson = (Person)personConstructor.Invoke(null);
        }

        static void AccessingaProperty()
        {

            // create a new instance
            var person = new Person() { Name = "Lucas" };
            //get a type
            var t1 = person.GetType();
            //get a property
            var property = t1.GetProperty("Name");
            //get a value of property 
            var value = property.GetValue(person, null);
            Console.WriteLine(value);
        }

        static void InvokingaMehtod()
        {
            //get a new instance 
            var person = new Person();
            //get a new type
            var t1 = person.GetType();
            // get a new method
            var method = t1.GetMethod("Walk");
            //invoke a method 
            var value = (string)method.Invoke(person, null);

            Console.WriteLine(value);
        }

        static void ExampleMVA()
        {
            object person = Activator.CreateInstance(typeof(Person));
            // system using reflection - with reflection
            PropertyInfo[] properties = typeof(Person).GetProperties();
            PropertyInfo NameOfPerson = properties[1];
            PropertyInfo SurnameOfPerson = properties[2];

            //or
            PropertyInfo NameOfPerson2 = null;
            foreach (PropertyInfo propInfo in properties)
            {
                if (propInfo.Name.Equals("Name", StringComparison.InvariantCulture))
                {
                    NameOfPerson2 = propInfo;
                }
            }

            NameOfPerson.SetValue(person, "Matheus", null);
            SurnameOfPerson.SetValue(person, "Brito", null);
            Console.WriteLine(NameOfPerson2.GetValue(person, null));

            // use reflection to invoke different constructors

            var defaultConstructor = typeof(Person).GetConstructor(new  Type[0]);
            var legConstructor = typeof(Person).GetConstructor(new[] { typeof(string) });

            var defaultperson = (Person)defaultConstructor.Invoke(null);
            Console.WriteLine(defaultperson.Name);

            var legPerson = (Person)legConstructor.Invoke(new object[] { "Jose e Maria"});
            Console.WriteLine(legPerson.Name);

            Console.Read();
        }
    }
}
