static class Filtrering
{
    public static List<string> FiltreraElementen(string[] inmatning, string? bokstavsInmatning)     // En Lista som tar en string array och en string som parameter
    {
        List<string> resultat = [];

        foreach (string element in inmatning)
            if (element.StartsWith(bokstavsInmatning!.ToString(), StringComparison.OrdinalIgnoreCase))      // Om elementen börjar på den angivna bokstaven
                resultat.Add(element);                                  // Lägg till elementen i resultat listan

        return resultat;        // Skicka tillbaka den filtrerade listan i resultat
    }
}