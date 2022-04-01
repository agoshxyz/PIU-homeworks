using System;

namespace LibrarieModele
{
    public class Telefon
    {
        //constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        private const int ID = 0;
        private const int TITLU = 1;
        private const int DESCRIPTION = 2;
        private const int PRET = 3;
        private const int CANTITATE = 4;

        //proprietati auto-implemented
        private int idTelefon; //identificator unic telefon
        private string titlu;
        private string description;
        private string pret;
        private string cantitate;

        //contructor implicit
        public Telefon()
        {
            titlu = description = string.Empty;
        }

        //constructor cu parametri
        public Telefon(int idTelefon, string titlu, string description, string pret, string cantitate)
        {
            this.idTelefon = idTelefon;
            this.titlu = titlu;
            this.description = description;
            this.pret = pret;
            this.cantitate = cantitate;
        }

        //constructor cu un singur parametru de tip string care reprezinta o linie dintr-un fisier text
        public Telefon(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idTelefon = Convert.ToInt32(dateFisier[ID]);
            titlu = dateFisier[TITLU];
            description = dateFisier[DESCRIPTION];
            pret = dateFisier[PRET];
            cantitate = dateFisier[CANTITATE];

        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectTelefonPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idTelefon.ToString(),
                (titlu ?? " NECUNOSCUT "),
                (description ?? " NECUNOSCUT "),
                (pret ?? " NECUNOSCUT "),
                (cantitate ?? " NECUNOSCUT "));

            return obiectTelefonPentruFisier;
        }

        public int GetIdTelefon()
        {
            return idTelefon;
        }

        public string GetTitlu()
        {
            return titlu;
        }

        public string GetDescription()
        {
            return description;
        }

        public string GetPret()
        {
            return pret;
        }

        public string GetCantitate()
        {
            return cantitate;
        }

        public void SetIdTelefon(int idTelefon)
        {
            this.idTelefon = idTelefon;
        }
    }
}
