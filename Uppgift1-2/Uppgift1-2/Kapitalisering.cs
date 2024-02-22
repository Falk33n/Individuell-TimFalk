static class Kapitalisering
{
    public static string KapitaliseraVarjeElement(string inmatning)     // Ta emot en string som parameter (elementen)
    {
        return char.ToUpper(inmatning[0]) + inmatning[1..];     // Skicka tillbaka elements första bokstav med storbokstav
    }
}