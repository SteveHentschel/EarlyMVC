using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IF_Abstract_Class_Tut
{
    class SomeClass
    {
        public void SomeAction()
        {
            // lets use the bad logger here
            LoggerBad logger = new LoggerBad();
            IEnumerable<string> logs = logger.GetLast10Messages();

            foreach (string s in logs)
            {
                Console.Write(s);
            }
            Console.WriteLine();
        }
    }

    class SomeClassTwo
    {
        public void SomeAction(ILogger _logger)
        {
            // lets use the bad logger here
            ILogger logger = _logger;
            IEnumerable<string> logs = logger.GetLast10Messages();

            foreach (string s in logs)
            {
                Console.Write(s);
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SomeClass userClass1 = new SomeClass();
            // call the logger method
            userClass1.SomeAction();

            SomeClassTwo userclass2 = new SomeClassTwo();
            // use our good old class
            userclass2.SomeAction(new LoggerGood());

            // Use the new coud logger
            userclass2.SomeAction(new LogToCloud());

            Console.ReadLine();
        }
    }
}
