namespace StatisticsTest
{
    [TestClass]
    public class StatisticsTest
    {
        internal int[] testV�rden = [4, 8, 6, 2, 8, 5, 3, 8, 9, 6, 4, 8, 6, 2, 8, 5, 3, 8, 9, 6];

        [TestMethod]
        public void Maximum_Returnerar_MaxV�rde()
        {
            Array.Sort(testV�rden);
            Array.Reverse(testV�rden);

            int f�rv�ntadV�rde = 9;
            int faktisktV�rde = testV�rden[0];

            Assert.AreEqual(f�rv�ntadV�rde, faktisktV�rde);
        }

        [TestMethod]
        public void Minimum_Returnerar_MinV�rde()
        {
            Array.Sort(testV�rden);

            int f�rv�ntadV�rde = 2;
            int faktisktV�rde = testV�rden[0];

            Assert.AreEqual(f�rv�ntadV�rde, faktisktV�rde);
        }

        [TestMethod]
        public void Mean_Returnerar_Medelv�rde()
        {
            double total = 0;

            for (int i = 0; i < testV�rden.LongLength; i++)
            {
                total += testV�rden[i];
            }

            double f�rv�ntadV�rde = 5.9;
            double faktisktV�rde = total / testV�rden.LongLength;

            Assert.AreEqual(f�rv�ntadV�rde, faktisktV�rde);
        }

        [TestMethod]
        public void Median_Returnerar_Medianen()
        {
            Array.Sort(testV�rden);
            int size = testV�rden.Length;
            int mid = size / 2;

            int f�rv�ntadV�rde = 6;
            int faktisktV�rde = testV�rden[mid];

            Assert.AreEqual(f�rv�ntadV�rde, faktisktV�rde);
        }

        [TestMethod]
        public void Mode_Returnerar_Typv�rdet()
        {
            Dictionary<int, int> antalFrekvenser = [];

            foreach (int nummer in testV�rden)  
            {
                if (antalFrekvenser.TryGetValue(nummer, out int v�rde))   
                    antalFrekvenser[nummer] = ++v�rde;
                else
                    antalFrekvenser[nummer] = 1;      
            }

            int maximalFrekvens = antalFrekvenser.Values.Max();
            List<int> typV�rde = [];      

            foreach (KeyValuePair<int, int> nyckelPar in antalFrekvenser) 
                if (nyckelPar.Value == maximalFrekvens)
                    typV�rde.Add(nyckelPar.Key);      

            int f�rv�ntadV�rde = 8;

            foreach (int faktisktV�rde in typV�rde)
            {
                Assert.AreEqual(f�rv�ntadV�rde, faktisktV�rde);
            }
        }

        [TestMethod]
        public void Range_Returnerar_Variationsbredd()
        {
            Array.Sort(testV�rden);
            int min = testV�rden[0];
            int max = testV�rden[0];

            for (int i = 0; i < testV�rden.Length; i++)
                if (testV�rden[i] > max)
                    max = testV�rden[i];

            int f�rv�ntadV�rde = 7;
            int faktisktV�rde = max - min;

            Assert.AreEqual(f�rv�ntadV�rde, faktisktV�rde);
        }

        [TestMethod]
        public void StandardDeviation_Returnerar_Standardavvikelse()
        {
            double average = testV�rden.Average();
            double sumOfSquaresOfDifferences = testV�rden.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / testV�rden.Length);
            double round = Math.Round(sd, 1);

            double f�rv�ntadV�rde = 2.3;
            double faktisktV�rde = round;

            Assert.AreEqual(f�rv�ntadV�rde, faktisktV�rde);
        }
    }
}