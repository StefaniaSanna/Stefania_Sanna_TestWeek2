using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefania_Sanna_TestWeek2
{
    public class Menù
    {
        public static void PresentaOpzioni()
        {
            Console.WriteLine("Benvenuto nell'applicazione Agenda");
            GestioneAgenda.AggiungiTaskDiProva();
            bool continua = true;
            do
            {
                Console.WriteLine("\n**********Menù**********");
                Console.WriteLine("Premi 1 per visualizzare i tasks");
                Console.WriteLine("Premi 2 per aggiungere un nuovo task");
                Console.WriteLine("Premi 3 per eliminare un task già esistente");
                Console.WriteLine("Premi 4 per filtrare i tasks per importanza");
                Console.WriteLine("Premi 0 per uscire dall'applicazione");

                int scelta;
                do
                {
                    Console.WriteLine("Seleziona una delle opzioni");

                }
                while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4));

                switch (scelta)
                {
                    case 1:
                        GestioneAgenda.VisualizzaTasks();
                        break;
                    case 2:
                        GestioneAgenda.AggiungiTask();
                        break;
                    case 3:
                        GestioneAgenda.EliminaTask();
                        break;
                    case 4:
                        GestioneAgenda.FiltraTasksPerImportanza();
                        break;
                    case 0:
                        Console.WriteLine("Arrivederci");
                        continua = false;
                        GestioneAgenda.StampaListaSuTesto();                        
                        break;
                }
            }
            while (continua == true);            
        }
    }
}
