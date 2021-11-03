using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ejercicio4
{

    public delegate void MyEvent();
    public class EventExample
    {
        public event MyEvent OnMyEvent;
        
        private readonly static EventExample _instance = new ();
        public static EventExample Instance
        {
            get
            {
                return _instance;
            }
        }

        readonly StringBuilder sb = new();
        EventExample()
        {
            OnMyEvent += AddOneLine;
            OnMyEvent += AddAnotherLine;
        }
       
        public void InvokeMyEvent()
        {
            OnMyEvent?.Invoke();
        }

        void AddOneLine()
        {
            sb.AppendLine("Agrego la primer linea correspondiente al metodo AddOneLine");
        }
        void AddAnotherLine()
        {
            sb.AppendLine("Agrego la segunda linea correspondiente al metodo AddAnotherLine");
        }
        public string ShowMyString()
        {
            return sb.ToString();
        }

    }
}
