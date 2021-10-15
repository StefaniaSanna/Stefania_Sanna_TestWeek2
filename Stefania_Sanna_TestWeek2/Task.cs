using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefania_Sanna_TestWeek2
{
    public class Task
    {
        public string Descrizione { get; set; }
        public DateTime DataDiScadenza { get; set; }
        public Priorità Priorità { get; set; }
    }

    public enum Priorità
    {
        Alto = 1,
        Medio = 2,
        Basso = 3
    }
}
