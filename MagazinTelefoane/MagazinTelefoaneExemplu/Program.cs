using System;
using System.Configuration;
using LibrarieModele;
using NivelStocareDate;

namespace EvidentaStudenti
{
    class Program
    {
        static void Main()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];

            AdministrareTelefoane_FisierText adminTelefoane = new AdministrareTelefoane_FisierText(numeFisier);
            Telefon telefonNou = new Telefon();

            int nrTelefoane = 0;

            adminTelefoane.GetTelefoane(out nrTelefoane);


            string optiune;
            do
            {
                Console.WriteLine("C. Citire informatii telefoane de la tastatura");
                Console.WriteLine("A. Afisarea ultimului telefonul introdus");
                Console.WriteLine("F. Afisare telefonul din fisier");
                Console.WriteLine("S. Salvare telefonul in fisier");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");

                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        telefonNou = CitireTelefonTastatura();
                        break;

                    case "A":
                        AfisareTelefon(telefonNou);
                        break;

                    case "F":
                        Telefon[] studenti = adminTelefoane.GetTelefoane(out nrTelefoane);
                        AfisareStudenti(studenti, nrTelefoane);
                        break;

                    case "S":
                        int idTelefon = nrTelefoane + 1;
                        telefonNou.SetIdTelefon(idTelefon);
                        //adaugare telefon nou in fisier
                        adminTelefoane.AddTelefon(telefonNou);
                        nrTelefoane = nrTelefoane + 1;
                        break;

                    case "X":
                        return;

                    default:
                        Console.WriteLine("Optiune nu exista");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }

        public static void AfisareTelefon(Telefon telefon)
        {
            string infoTelefon = string.Format("Telefonul cu ID-ul #{0}\n are Titlul: {1} \n Descriptie: {2}\n Pretul: {3} \n Cantitate:{4} \n",
                   telefon.GetIdTelefon(),
                   telefon.GetTitlu() ?? " NECUNOSCUT ",
                   telefon.GetDescription() ?? " NECUNOSCUT ",
                   telefon.GetPret() ?? " NECUNOSCUT ",
                   telefon.GetCantitate() ?? " NECUNOSCUT ");

            Console.WriteLine(infoTelefon);
        }

        public static void AfisareStudenti(Telefon[] telefoane, int nrTelefoane)
        {
            Console.WriteLine("Telefoane sunt:");
            for (int contor = 0; contor < nrTelefoane; contor++)
            {
                AfisareTelefon(telefoane[contor]);
            }
        }

        public static Telefon CitireTelefonTastatura()
        {
            Console.WriteLine("Introduceti titlul: ");
            string titlu = Console.ReadLine();

            Console.WriteLine("Introduceti descriptie: ");
            string description = Console.ReadLine();

            Console.WriteLine("Introduceti pretul in lei: ");
            string pret = Console.ReadLine();

            Console.WriteLine("Introduceti cantitate: ");
            string cantitate = Console.ReadLine();


            Telefon telefon = new Telefon(0, titlu, description, pret, cantitate);

            return telefon;
        }
    }
}
