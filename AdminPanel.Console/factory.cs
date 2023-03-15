using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Console
{
    public class factory
    {
        // абстрактный класс строительной компании
        abstract class Developer
        {
            public string Name { get; set; }

            public Developer(string n)
            {
                Name = n;
            }
            // фабричный метод
            abstract public House Create();
        }
        // строит панельные дома
        class PanelDeveloper : Developer
        {
            public PanelDeveloper(string n) : base(n)
            { }

            public override House Create()
            {
                return new PanelHouse();
            }
        }
        // строит деревянные дома
        class WoodDeveloper : Developer
        {
            public WoodDeveloper(string n) : base(n)
            { }

            public override House Create()
            {
                return new WoodHouse();
            }
        }

        abstract class House
        { }

        class PanelHouse : House
        {
            public PanelHouse()
            {
                System.Console.WriteLine("Панельный дом построен");
            }
        }
        class WoodHouse : House
        {
            public WoodHouse()
            {
                System.Console.WriteLine("Деревянный дом построен");
            }
        }
    }
}
