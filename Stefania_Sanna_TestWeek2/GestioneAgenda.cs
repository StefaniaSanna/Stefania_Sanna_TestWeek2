using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefania_Sanna_TestWeek2
{
    public class GestioneAgenda
    {
        public static List<Task> tasks = new List<Task>();

        public static void AggiungiTaskDiProva()
        {
            Task taskProva = new Task()
            {
                Descrizione = "Esame di informatica",
                DataDiScadenza = new DateTime(2021, 10, 22, 16, 00, 00),
                Priorità = (Priorità)1
            };
            tasks.Add(taskProva);
        }

        public static void VisualizzaTasks()
        {
            VisualizzaTasksDiUnaLista(tasks);           
        }

        public static void VisualizzaTasksDiUnaLista(List<Task> listaTask)
        {
            Console.WriteLine("\nDescrizione, data di scadenza e ora, livello di importanza");
            foreach (Task task in listaTask)
            {
                Console.WriteLine($"{task.Descrizione}, {task.DataDiScadenza}, {task.Priorità}");
            }
            if (tasks.Count == 0)
            {
                Console.WriteLine("Non hai nessun task previsto");
            }
        }

        public static void StampaListaSuTesto()
        {
            string path = @"C:\Users\sanna\Desktop\Programmi Pink\NuovaWeek2\Stefania_Sanna_TestWeek2\Stefania_Sanna_TestWeek2\TaskPresentiInAgenda.txt";
            using (StreamWriter sw1 = new StreamWriter(path))
            {
                sw1.WriteLine("Gli impegni presenti in agenda sono:");
                foreach (Task task in tasks)
                {
                    sw1.WriteLine($"{task.Descrizione}, {task.DataDiScadenza}, {task.Priorità}");
                }
                if (tasks.Count == 0)
                {
                    sw1.WriteLine("Non hai nessun task previsto");
                }
            }
        }

        public static void AggiungiTask()
        {
            Task taskDaAggiungere = new Task();
            Console.WriteLine("Aggiungere descrizione impegno");
            taskDaAggiungere.Descrizione = Console.ReadLine();
            taskDaAggiungere.Priorità = SelezionaPriorità();
            taskDaAggiungere.DataDiScadenza = InserisciDataDiScadenza();
            tasks.Add(taskDaAggiungere);
        }

        private static DateTime InserisciDataDiScadenza()
        {
            DateTime data = new DateTime();
            bool continua = true;
            do
            {
                continua = true;
                data = SelezionaDataDiScadenza();
                foreach (Task task in tasks)
                {
                    if (data == task.DataDiScadenza)
                    {
                        Console.WriteLine("Hai già un impegno!");
                        continua = false;
                    }                    
                }
            }
            while (continua == false);
            return data;
        }
        private static DateTime SelezionaDataDiScadenza()
        {
            DateTime deadline;
            do
            {
                Console.WriteLine("\nInserire la data e l'ora dell'impegno");
            }
            while (!(DateTime.TryParse(Console.ReadLine(), out deadline) && deadline > DateTime.Today));
            return deadline;
        }

        private static Priorità SelezionaPriorità()
        {
            Console.WriteLine("Seleziona il livello di importanza del tuo impegno:");
            Console.WriteLine("Premi 1 per priorità Alta");
            Console.WriteLine("Premi 2 per priorità Media");
            Console.WriteLine("Premi 3 per priorità Bassa");
            int scelta;

            do
            {
                Console.WriteLine("Fai la tua scelta");
            }
            while(!(int.TryParse(Console.ReadLine(), out scelta) && scelta> 0 && scelta <= 3));
            return (Priorità)scelta;
        }


        public static void EliminaTask()
        {
            Console.WriteLine("Gli impegni presenti in agenda sono:");
            VisualizzaTasks();
            Console.WriteLine("\nIdentificare il task che si vuole eliminare");
            Task impegnoDaEliminare = CercaOrario();           
            if (impegnoDaEliminare == null)
            {
                Console.WriteLine("Non esistono impegni nella data inserita");
            }
            else
            {
                Console.WriteLine($"Impegno previsto per il {impegnoDaEliminare.DataDiScadenza} correttamente eliminato");
                tasks.Remove(impegnoDaEliminare);
            }           
        }

        private static Task CercaOrario()
        {
            DateTime dataDaCercare = SelezionaDataDiScadenza();            
            foreach (Task task in tasks)
            {
                if (task.DataDiScadenza == dataDaCercare)
                {
                    return task;                   
                }              
            }
            return null;
        }

        public static void FiltraTasksPerImportanza()
        {
            Priorità priorità = SelezionaPriorità();
            List<Task> tasksFiltratePerPriorità = new List<Task>();

            foreach (Task task in tasks)
            {
                if (task.Priorità == priorità)
                {
                    tasksFiltratePerPriorità.Add(task);
                }
            }
            Console.WriteLine($"I tasks con livello di importanza {priorità} sono {tasksFiltratePerPriorità.Count}");
            if(tasksFiltratePerPriorità.Count != 0)
            {
                VisualizzaTasksDiUnaLista(tasksFiltratePerPriorità);
            }            
        }
    }
}
