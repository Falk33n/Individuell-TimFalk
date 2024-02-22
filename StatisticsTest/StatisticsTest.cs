namespace StatisticsTest
{
    [TestClass]
    public class StatisticsTest
    {
        internal int[] testVärden = [4, 8, 6, 2, 8, 5, 3, 8, 9, 6, 4, 8, 6, 2, 8, 5, 3, 8, 9, 6];

        [TestMethod]
        public void Maximum_Returnerar_MaxVärde()
        {
            Array.Sort(testVärden);
            Array.Reverse(testVärden);

            int förväntadVärde = 9;
            int faktisktVärde = testVärden[0];

            Assert.AreEqual(förväntadVärde, faktisktVärde);
        }

        [TestMethod]
        public void Minimum_Returnerar_MinVärde()
        {
            Array.Sort(testVärden);

            int förväntadVärde = 2;
            int faktisktVärde = testVärden[0];

            Assert.AreEqual(förväntadVärde, faktisktVärde);
        }

        [TestMethod]
        public void Mean_Returnerar_Medelvärde()
        {
            double total = 0;

            for (int i = 0; i < testVärden.LongLength; i++)
            {
                total += testVärden[i];
            }

            double förväntadVärde = 5.9;
            double faktisktVärde = total / testVärden.LongLength;

            Assert.AreEqual(förväntadVärde, faktisktVärde);
        }

        [TestMethod]
        public void Median_Returnerar_Medianen()
        {
            Array.Sort(testVärden);
            int size = testVärden.Length;
            int mid = size / 2;

            int förväntadVärde = 6;
            int faktisktVärde = testVärden[mid];

            Assert.AreEqual(förväntadVärde, faktisktVärde);
        }

        [TestMethod]
        public void Mode_Returnerar_Typvärdet()
        {
            Dictionary<int, int> antalFrekvenser = [];

            foreach (int nummer in testVärden)  
            {
                if (antalFrekvenser.TryGetValue(nummer, out int värde))   
                    antalFrekvenser[nummer] = ++värde;
                else
                    antalFrekvenser[nummer] = 1;      
            }

            int maximalFrekvens = antalFrekvenser.Values.Max();
            List<int> typVärde = [];      

            foreach (KeyValuePair<int, int> nyckelPar in antalFrekvenser) 
                if (nyckelPar.Value == maximalFrekvens)
                    typVärde.Add(nyckelPar.Key);      

            int förväntadVärde = 8;

            foreach (int faktisktVärde in typVärde)
            {
                Assert.AreEqual(förväntadVärde, faktisktVärde);
            }
        }

        [TestMethod]
        public void Range_Returnerar_Variationsbredd()
        {
            Array.Sort(testVärden);
            int min = testVärden[0];
            int max = testVärden[0];

            for (int i = 0; i < testVärden.Length; i++)
                if (testVärden[i] > max)
                    max = testVärden[i];

            int förväntadVärde = 7;
            int faktisktVärde = max - min;

            Assert.AreEqual(förväntadVärde, faktisktVärde);
        }

        [TestMethod]
        public void StandardDeviation_Returnerar_Standardavvikelse()
        {
            double average = testVärden.Average();
            double sumOfSquaresOfDifferences = testVärden.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / testVärden.Length);
            double round = Math.Round(sd, 1);

            double förväntadVärde = 2.3;
            double faktisktVärde = round;

            Assert.AreEqual(förväntadVärde, faktisktVärde);
        }
    }
}