using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class Dog : Animal, IMessage
    {
       
        public string breed { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public void DisplayMessage()
        {
            Console.WriteLine("You chose a dog.");
        }

        public override void DisplayText()
        {
            Console.WriteLine("You added a dog.");
        }

    }
}
