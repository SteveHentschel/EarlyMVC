using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IF_Abstract_Class_Tut
{
    interface ILogger
    {
        void LogMessage(string msg);
        IEnumerable<string> GetLast10Messages();
    }

    class LoggerGood : ILogger
    {
        public void LogMessage(string msg)
        {
            // Log this message here
        }

        public IEnumerable<string> GetLast10Messages()
        {
            return new string[]
            {
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" 
            };
        }
    }

    class LogToCloud : ILogger
    {
        public void LogMessage(string msg)
        {
            // Log this message to the cloud using some web service
        }

        public IEnumerable<string> GetLast10Messages()
        {
            // call some web service and fetch the data
            return new string[]
            {
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" 
            };
        }
    }


    class LoggerBad
    {
        public void LogMessage(string msg)
        {
            // Log this message here
        }

        public string[] GetLast10Messages()
        {
            return new string[]
            {
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" 
            };
        }
    }
}
