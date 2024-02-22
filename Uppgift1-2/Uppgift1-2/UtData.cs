using static System.Console;

static class UtData
{
    static string? filensSökväg;

    public static void Utmatningar()
    {
        for (int index = 0; index < InData.elementArray.Length; index++)
            InData.elementArray[index] = Kapitalisering.KapitaliseraVarjeElement(InData.elementArray[index]);       // Kalla på KapitaliseraVarjeElement funktionen som gör att varje element startar med stor bokstav

        List<string> resultat = Filtrering.FiltreraElementen(InData.elementArray, InData.bokstavsInmatning);    // Kalla på FiltreraElementen som gör att elementen som börjar på
                                                                                                                // samma bokstav som det valda biblioteket ska läggas till i resultat
        if (resultat.Count > 0)     // Kör detta blocket av kod endast om resultat innehåller något korrekt element
        {
            Write("[X] Laddar filtreraren");    // Laddningsanimation
            for (int index = 0; index < 3; index++)
            {
                Thread.Sleep(600);
                Write(". ");
            }

            Thread.Sleep(300);
            Clear();

            Array.Sort(InData.elementArray);    // Här sorterar vi alla element som har skrivits in i bokstavsordning
            WriteLine("[X] Elementlistan före filtrering:" + "\n[X]");

            foreach (string element in InData.elementArray)     // Visar upp vilka element användaren har skrivit in före filtrering
                WriteLine($"[X] {element}");

            Directory.CreateDirectory(InData.bokstavsInmatning!.ToString());       // Här skapar vi mappen för det valda biblioteket
            filensSökväg = Path.Combine($"{InData.bokstavsInmatning}", $"{InData.bokstavsInmatning}.txt");      // Här skapar vi filen som hamnar i det valda biblioteket
                                                                                                                // Vi gör detta såhär sent för att ENDAST skapa filer om det VERKLIGEN behövs
            WriteLine("[X]\n"
                    + $"[X] Elementlistan efter filtrering för dem element som börjar på \"{InData.bokstavsInmatning}\":"
                    + "\n[X]");

            foreach (string element in resultat)
            {
                WriteLine($"[X] {element}");
                File.AppendAllText(filensSökväg!, $"{element}\n");      // Skriv ut listan efter filtreringen samt lägg till varje element i det nyskapade textdokumentet
            }

            Write("[X] ");
            Thread.Sleep(1300);
            Write("\n[X] För över element till det angivna biblioteket");   // Animation för överföringen
            for (int index = 0; index < 3; index++)
            {
                Thread.Sleep(1700);
                Write(". ");
            }

            Thread.Sleep(450);
            Clear();
            WriteLine("[X] Överföringen lyckades!\n[X]"
                    + "\n[X] Du hittar ditt bibliotek i följande sökväg:\n"
                    + "[X] \\Program-Mappens-Plats\\Individuell-inlämning-uppgift-1-2-Tim-Falk\\bin\\Debug\\net8.0");    // Meddelande till användare vart biblioteket kan hittas
        }
        else
            WriteLine($"[X] Inmatningen innehåller inte något element som börjar på \"{InData.bokstavsInmatning}\", vänligen försök igen.");    // Fallback
    }
}