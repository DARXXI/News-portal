using AdminPanel.Repository;
using AdminPanel.Domain.Entities;
using System.Numerics;
using System.Data;
using AdminPanel.Console;
using System;



namespace AdminPanel.Console
{
    class Computer
    {
        public OS OS;

        public void LaunchOS(string name)
        {
            OS = OS.GetInstance(name);
        }
    }
    class OS
    {
        private static OS instance;
        public string Name { get; private set; }
        private OS(string name)
        {
            Name = name;
        }
        public static OS GetInstance(string name)
        {
            object locker = new();
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new OS(name);
                }
            }
            return instance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Computer comp = new Computer();
            comp.LaunchOS("Windows 8.1");
            System.Console.WriteLine(comp.OS.Name);

            //comp.OS = OS.GetInstance("Windows 10");
            //System.Console.WriteLine(comp.OS.Name);

            System.Console.ReadLine();
            //Foo foo = new Foo();
            //Foo2 foo2 = new Foo2();
            //Foo3 foo3 = new Foo3();

            //foo.PrintFoo();
            //foo2.PrintFoo();
            //foo3.PrintFoo();

            //try
            //{
            //    Func1();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.StackTrace);
            //    throw;
            //}
        }
    }
}

