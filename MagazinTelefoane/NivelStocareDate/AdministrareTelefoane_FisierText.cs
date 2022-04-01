using LibrarieModele;
using System.IO;

namespace NivelStocareDate
{
public class AdministrareTelefoane_FisierText
{
    private const int NR_MAX_TELEFOANE = 100;
    private string numeFisier;

    public AdministrareTelefoane_FisierText(string numeFisier)
    {
        this.numeFisier = numeFisier;
        // se incearca deschiderea fisierului in modul OpenOrCreate
        // astfel incat sa fie creat daca nu exista
        Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
        streamFisierText.Close();
    }

    public void AddTelefon(Telefon telefon)
    {
        // instructiunea 'using' va apela la final streamWriterFisierText.Close();
        // al 2lea parametru setat la 'true' al constructorului StreamWriter indica
        // modul 'append' de deschidere al fisierului
        using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
        {
            streamWriterFisierText.WriteLine(telefon.ConversieLaSir_PentruFisier());
        }
    }

    public Telefon[] GetTelefoane(out int nrTelefoane)
    {
        Telefon[] telefoane = new Telefon[NR_MAX_TELEFOANE];

        // instructiunea 'using' va apela streamReader.Close()
        using (StreamReader streamReader = new StreamReader(numeFisier))
        {
            string linieFisier;
            nrTelefoane = 0;

            // citeste cate o linie si creaza un obiect de tip Student
            // pe baza datelor din linia citita
            while ((linieFisier = streamReader.ReadLine()) != null)
            {
                telefoane[nrTelefoane++] = new Telefon(linieFisier);
            }
        }

        return telefoane;
    }
}
}