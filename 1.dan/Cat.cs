using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class Cat : Animal, IMessage
    {
        public string color { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public void DisplayMessage()
        {
            Console.WriteLine("You chose a cat.");
        }

        public override void DisplayText()
        {
            Console.WriteLine("You added a cat.");
        }
    }
}
