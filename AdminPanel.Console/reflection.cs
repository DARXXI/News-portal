namespace AdminPanel.Console
{
    class Role
    {

    }

    class MyClass
    {
        public Role Role { get; set; }
    }

    public class ElectricEngine
    { }

    public class Car
    {
        ElectricEngine engine;
        public Car()
        {
            engine = new ElectricEngine();
        }
    }

    public abstract class Engine
    { }

    public class Car2
    {
        Engine engine;
        public Car2(Engine eng)
        {
            engine = eng;
        }
    }
    //partial class Foo
    //{
    //    private string name;
    //    private int age;
    //    public virtual void PrintFoo()
    //    {
    //        System.Console.WriteLine("Foo called");
    //    }
    //    public override string ToString()
    //    {
    //        return $"name:{name}, age {age}";
    //    }
    //}
    //partial class Foo2 : Foo
    //{
    //    public new void PrintFoo()
    //    {
    //        base.PrintFoo();
    //        System.Console.WriteLine("Foo2 called");
    //    }
    //}
    //partial class Foo3 : Foo2
    //{
    //    public  void PrintFoo()
    //    {
    //        System.Console.WriteLine("Foo3 called");
    //    }
    //}

    //enum Color
    //{
    //    Green = 1,
    //    Red = 100,
    //    Brown
    //}
}
//namespace AdminPanel.Console
//{
//    Type myType = typeof(PeopleTypes.Person);

//    Console.WriteLine($"Name: {myType.Name}");              // получаем краткое имя типа
//    Console.WriteLine($"Full Name: {myType.FullName}");     // получаем полное имя типа
//    Console.WriteLine($"Namespace: {myType.Namespace}");    // получаем пространство имен типа
//    Console.WriteLine($"Is struct: {myType.IsValueType}");  // является ли тип структурой
//    Console.WriteLine($"Is class: {myType.IsClass}");       // является ли тип классом

//    namespace PeopleTypes
//    {
//        class Person
//        {
//            public string Name { get; }
//            public Person(string name) => Name = name;
//        }
//    }
//}