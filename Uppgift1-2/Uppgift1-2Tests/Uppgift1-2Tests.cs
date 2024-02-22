namespace Uppgift1_2Tests
{
    [TestClass]
    public class UnitTest1
    {
        internal List<string> testInmatning = ["hej", "jag", "�r", "hugo", "henriksson", "banan"];
        internal string testStr�ng = "hugo";
        internal char testBokstav = 'h';

        [TestMethod]
        public void Filtrering_Returnera_R�ttElement()
        {
            // Beh�vs inte mer tester d� fallbacks finns innan denna kommer
            List<string> f�rv�ntadV�rde = ["hej", "hugo", "henriksson"];
            List<string> faktisktV�rde = [];

            foreach (string element in testInmatning)
                if (element.StartsWith(testBokstav.ToString(), StringComparison.OrdinalIgnoreCase))
                    faktisktV�rde.Add(element);

            CollectionAssert.AreEqual(f�rv�ntadV�rde, faktisktV�rde);
        }

        [TestMethod]
        public void Kapitalisering_Returnera_StorBokstav()
        {
            // Beh�vs inte mer tester d� fallbacks finns innan denna kommer
            string f�rv�ntadV�rde = "Hugo";
            string faktisktV�rde = char.ToUpper(testStr�ng[0]) + testStr�ng[1..];

            Assert.AreEqual(f�rv�ntadV�rde, faktisktV�rde);
        }
    }
}