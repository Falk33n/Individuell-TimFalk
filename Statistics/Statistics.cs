using Newtonsoft.Json;
using System.Data;
using String = System.String;

namespace Statistics
{
    public static class Statistics
    {
        internal static int[] source = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"))!;

        public static dynamic DescriptiveStatistics()
        {
            Dictionary<string, dynamic> StatisticsList = new()
            {
                { "Maximum", Maximum() },
                { "Minimum", Minimum() },
                { "Medelvärde", Mean() },
                { "Median", Median() },
                { "Typvärde", String.Join(", ", Mode()) }, 
                { "Variationsbredd", Range() },
                { "Standardavvikelse", StandardDeviation() }  
            };

            string output =
                $"Maximum: {StatisticsList["Maximum"]}\n" +
                $"Minimum: {StatisticsList["Minimum"]}\n" +
                $"Medelvärde: {StatisticsList["Medelvärde"]}\n" +
                $"Median: {StatisticsList["Median"]}\n" +
                $"Typvärde: {StatisticsList["Typvärde"]}\n" +
                $"Variationsbredd: {StatisticsList["Variationsbredd"]}\n" +
                $"Standardavvikelse: {StatisticsList["Standardavvikelse"]}";

            return output;
        }

        public static int Maximum()
        {
            Array.Sort(source);
            Array.Reverse(source);
            int result = source[0];
            return result;
        }

        public static int Minimum()
        {
            Array.Sort(source);
            int result = source[0];
            return result;
        }

        public static double Mean()
        {
            double total = 0;

            for (int i = 0; i < source.LongLength; i++)
                total += source[i];
            
            return total / source.LongLength;
        }

        public static double Median()
        {
            Array.Sort(source);
            int size = source.Length;
            int mid = size / 2;
            int dbl = source[mid];
            return dbl;
        }

        public static int[] Mode()
        {
            Dictionary<int, int> antalFrekvenser = []; // Dictionary som hanterar alla frekvenser

            foreach (int nummer in source)   // Gå igenom varje nummer som finns i filen
            {
                if (antalFrekvenser.TryGetValue(nummer, out int värde))     // Om nummer har samma frekvens plussa värdet
                    antalFrekvenser[nummer] = ++värde;
                else
                    antalFrekvenser[nummer] = 1;            // Om inte, ge värde 1
            }

            int maximalFrekvens = antalFrekvenser.Values.Max();     
            List<int> typVärde = [];        // Lista som kommer hantera värdet metoden ska få fram

            foreach (KeyValuePair<int, int> nyckelPar in antalFrekvenser)       // Hittar den ett par här så är de den maximala frekvensen
                if (nyckelPar.Value == maximalFrekvens) 
                    typVärde.Add(nyckelPar.Key);            // Lägger till typvärdet med dem nycklar som är ett par

            return [.. typVärde];       // Returnerar en List på typvärdena
        }

        public static int Range()
        {
            Array.Sort(source);
            int min = source[0];
            int max = source[0];

            for (int i = 0; i < source.Length; i++)
                if (source[i] > max)
                    max = source[i];

            int range = max - min;
            return range;
        }

        public static double StandardDeviation() 
        {
            double average = source.Average();
            double sumOfSquaresOfDifferences = source.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / source.Length);

            double round = Math.Round(sd, 1);
            return round;
        }
    }
}

// DOKUMENTATION: (UPPGIFT 4 - 5 KOMMENTARER FINNS NEDANFÖR:)
//
// Först så kollade jag upp vad mode innebar och vad det faktiskt var jag skulle lösa. Efter att jag förstått mig på det så började jag
// kolla på olika forum om vilka metoder man kan använda för att komma ut samma värden i ett dictionary. Efter att jag skrev färdigt koden
// så behövde jag kontrollera manuellt att jag faktiskt skapat en korrekt funktion, då tog jag och sökte i "data.json" filen efter de 3 tal
// jag fick i konsol och kontrollerade att då alla dem talen fanns exakt lika många gånger i filen. Alltså hade jag gjort en korrekt kod.
// 
// Efter det så var det dags att ta reda på vilka olika förkodade klasser och metoder som används i detta projekt, för mer information se 
// nedanför. Sista uppgiften var att skapa unit tests där jag då skapade en array med testdata för att testa på, efter att alla metoder
// hade gåtts igenom så upptäcktes de ett fel på en metod där ett tal var fel i beräkningen. Annars så var unit testen felfria. Se nedanför
// för mer om uppgift 5.
//
// -------------------------------------------------------------------------------------------------------------------------------------------
//
// UPPGIFT 4 KOMMENTARER:
// Förkodade klasser:
//
// Math
// Array
// List och Dictionary (Härstammar från System.Collections.Generic men är olika klasser)
// String
// JsonConvert
// File 
//
//
// Förkodade metoder:
//
// Math                                 ==          Round, Sqrt
// Array                                ==          Sort, Reverse
// List                                 ==          Add
// Dictionary                           ==          TryGetValue
// String                               ==          Join
// JsonConvert                          ==          DeserializeObject
// File                                 ==          ReadAllText
// (IEnumerable är ett interface)       ==          Average, Select, Sum, Max
// (System.Collections.Generic)         ==          KeyValuePair 
//
//
// Förkodade klasser innebär att användaren kan utföra olika moment genom att kalla på en förkodad klass och dess metod, precis som att
// man själv skapar en klass och lägger till metoder i klassen som man sedan kallar på. 
// Förkodade metoder innebär ju då precis som jag sagt innan förkodade lösningar inuti en förkodad klass, allt detta för att spara tid
// för kodaren att slippa behöva koda alla funktioner själv.
//
// Ett exempel för att förstå tydligare skulle vara att kolla i Statistics.cs filen, klassen heter Statistics och innehåller flera metoder,
// man skulle kunna säga att vi har "skapat" en förkodad lösning om någon annan nu skulle bygga vidare på denna applikation. Då den nu kan
// kalla på denna klass och sen använda sig av metoder inuti.
//
//
// KeyValuePair är en väldigt bra förkodad lösning då den gör så att den letar efter en matchning av "nycklar" i frekvenserna och är just
// därför jag valde att använda mig av den lösningen.
//
//
// TryGetValue är också perfekt att använda i denna uppgift då den fungerar som en boolean, den kommer att bli sann om en frekvens redan
// finns och då plussa värdet på den frekvensen och lägga tillbaka den i Dictionary, om false så byter den värde på den till 1 och skickar
// tillbaka den till Dictionary.
//
// -------------------------------------------------------------------------------------------------------------------------------------------
//
// UPPGIFT 5 KOMMENTARER:
//
// Applikationen fungerar i sin helhet som ett bra program för att räkna ut data på olika sätt, dock så finns det olika förändringar som
// kommer att behöva implementeras, vad jag själv tycker är att i och med att WriteLines är skrivna på svenska tycker jag även att klasser
// funktioner och variabler ska vara namnsatta på svenska för att få en enhetlighet. Dessutom så fanns de på vissa ställen förenklingar
// man kunde göra som Visual Studio anmärkte. Samt att jag tycker det hade varit finare med lite laddningsanimationer som jag brukar göra och
// att man kanske väljer konsolfärger i och med att det är ett console program. Även att tillägga skulle kunna vara att göra programmet med en
// valmeny där väljaren kan välja vilken metod som ska användas osv.
//
// Rad 9 förenklad: ....JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"))!; Utropstecken för null forgiving operator
//
// Rad 13: Dictionary<string, dynamic> StatisticsList = new Dictionary<string, dynamic>()
// Rad 13 förenklad: Dictionary<string, dynamic> StatisticsList = new()
//
// Rad 19: { "Typvärde", String.Join(", ", Mode()) },
// Rad 19 förenkling: using String = System.String; Detta var ja tvungen att lägga till för att det blev error utan detta
//
// Rad 53: double total = -88;
// Rad 53 förenklad: double total = 0; för att räkna ut medelvärde ska startvärdet vara 0 och inte -88 detta ger ett mänskligt error.
//
// Överallt där det använts Statistics.source (Detta är onödigt, använd bara source direkt)
//
// Dem två for loopsen som finns i programmet är bättre att byta mot foreach eftersom att source är en array
//
// För att sammanfatta så fungerar programmet i sin helhet från början, dock så hade man behövt göra unit tests för att hitta mänskliga
// fel som t.ex. total = -88; som faktiskt inte skapar ett error men funktionen är inte rätt. Enhetlig kod behöver man för att lätt kunna
// navigera koden.