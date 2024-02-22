namespace Uppgift1_2Tests
{
    [TestClass]
    public class UnitTest1
    {
        internal List<string> testInmatning = ["hej", "jag", "är", "hugo", "henriksson", "banan"];
        internal string testSträng = "hugo";
        internal char testBokstav = 'h';

        [TestMethod]
        public void Filtrering_Returnera_RättElement()
        {
            // Behövs inte mer tester då fallbacks finns innan denna kommer
            List<string> förväntadVärde = ["hej", "hugo", "henriksson"];
            List<string> faktisktVärde = [];

            foreach (string element in testInmatning)
                if (element.StartsWith(testBokstav.ToString(), StringComparison.OrdinalIgnoreCase))
                    faktisktVärde.Add(element);

            CollectionAssert.AreEqual(förväntadVärde, faktisktVärde);
        }

        [TestMethod]
        public void Kapitalisering_Returnera_StorBokstav()
        {
            // Behövs inte mer tester då fallbacks finns innan denna kommer
            string förväntadVärde = "Hugo";
            string faktisktVärde = char.ToUpper(testSträng[0]) + testSträng[1..];

            Assert.AreEqual(förväntadVärde, faktisktVärde);
        }
    }
}