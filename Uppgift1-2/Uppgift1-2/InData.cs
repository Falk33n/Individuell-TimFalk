using System.Text.RegularExpressions;
using static System.Console;

static partial class InData
{
    internal static string[] elementArray = [];
    internal static string? bokstavsInmatning;
    internal static string? elementInmatning;               // internal static variabler för att vara lättåtkomliga i andra klasser
    internal static bool korrektBokstavsInmatning = false;
    internal static bool korrektElementInmatning = false;

    public static void Inmatningar()
    {
        BokstavsInmatning();
        ElementInmatning();
    }

    public static void BokstavsInmatning()
    {
        WriteLine("[X] Mata in endast en bokstav för det bibliotek som ska behandlas (t.ex. i format \"B\"):\n"
            + "[X]");
        Write("[X] ");
        bokstavsInmatning = ReadLine()!.ToUpper();

        while (!korrektBokstavsInmatning)
        {
            if (bokstavsInmatning.Length == 1 && char.IsLetter(bokstavsInmatning[0]))        // Fallback, fortsätt koden endast om det är EN bokstav
                korrektBokstavsInmatning = true;
            else
            {
                Clear();
                WriteLine("[X] Fel inmatning, mata in endast en bokstav samt inga specialtecken eller siffror (t.ex. i format \"B\"):\n"
                        + "[X]");
                Write("[X] ");
                bokstavsInmatning = ReadLine()!.ToUpper();
            }
        }

        Clear();
    }

    public static void ElementInmatning()
    {
        WriteLine($"[X] Mata in olika element i det valda biblioteket \"{bokstavsInmatning}\", seperera elementen med ett mellanslag mellan dem:\n"
            + "[X]");
        Write("[X] ");
        elementInmatning = ReadLine()!.ToLower();

        while (!korrektElementInmatning)
        {
            if (felaktigInmatning().IsMatch(elementInmatning))      // Fallback, om något element i inmatningen matchar med den skapade Regexen så fortsätt inte programmet
            {                                                       // Regexen hittar du längst ner
                Clear();
                WriteLine($"[X] Fel inmatning, mata in olika element i biblioteket \"{bokstavsInmatning}\","
                        + "\n[X] med endast bokstäver samt inga specialtecken eller siffror\n"
                        + "[X] seperera elementen med ett mellanslag mellan dem:\n"
                        + "[X]");
                Write("[X] ");
                elementInmatning = ReadLine()!.ToLower();
            }
            else
                korrektElementInmatning = true;
        }

        elementArray = elementInmatning.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);       // Splitta varje element till olika strings till elementArrayen
        Clear();

        UtData.Utmatningar();   // Kalla på Utmatningar funktionen i UtData klassen
    }

    [GeneratedRegex(@"^\s|[^\p{L}\s]")]     // Regexen, (För alla karaktärer som inte är en bokstav eller whitespace)
    private static partial Regex felaktigInmatning();
}