using static System.Console;

namespace Uppgift1_2
{
    public class Program
    {
        static void Main()
        {
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.Green;

            Write("[X] Laddar programmet");     // Animation för när användaren öppnar programmet
            for (int index = 0; index < 3; index++)
            {
                Thread.Sleep(600);
                Write(". ");
            }

            Thread.Sleep(300);
            Clear();
            WriteLine("[X] Välkommen till elementhanterare programmet!");

            Hanterare hanterare = new();    // Skapa en instans av Hanterare klassen och kalla på ProgramHanterare funktionen
            hanterare.ProgramHanterare();
        }
    }
}

// DOKUMENTATION UPPGIFT 1 & 2:
//
//
// Anledningen till varför jag inte valt att göra ytterligare unit tests är för att iochmed mina goda förmågor i problemlösning så har jag sett
// till att göra fallbacks för varje ställe i programmet där man kan få ett oväntat resultat eller kan lyckas krascha programmet, genom t.ex.
// while loops som tvingar användaren att mata in rätt värden oavsett vad, detta är anledningen till att flera unit tests inte kändes
// nödvändigt för mig att göra i detta fallet eftersom att jag täckt alla tänkbara luckor som det kan bli fel i. Så på sätt och vis har jag
// gjort unit tests men för hand genom väldigt många "IRL" tester i konsolen för att försöka bryta programmet.
//
// Genom tydliga namn på funktioner, klasser och variabler uppnår jag en tydlighet i koden som gör att färre kommentarer behövs då namnen
// förklarar vad syftet för det är då Stefan från JavaScript 1 kursen lärde mig "försök koda så pass tydligt att du inte ens behöver
// kommentarer".
//
// Tydliga instruktioner ges alltid till användaren för att den ska förstå tydligt hur den ska göra för att avancera i programmet.
// Helhets bedömning av mig själv är att jag lyckats bra med uppgiften och löst den så som det efterfrågades. Förändringar man själv
// skulle kunna göra i framtiden är väl kanske att göra om programmet så det är en applikation med GUI för finare estestiskt
// användarupplevelse. Annars tycker jag faktiskt att jag täckt allt och är väldigt stolt över slutresultatet.