using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronomyBL
{
    public class Weighted_k_NN
    {
        public double getPercentageOfRisk(double absoluteMagnitude, double diameterMin, double diameterMax, double velocity, double missDistance)
        {
            double[][] data = new double[26][];
            data[0] = new double[] { 0, 27.6, 0.0080270317, 0.0179489885, 55968.3212526889, 22465710.933294249, 0 };
            data[1] = new double[] { 1, 23.1, 0.063760979, 0.1425738833, 50952.43993298, 29924614.520712206, 0 };
            data[2] = new double[] { 2, 21.3, 0.1460679643, 0.3266178974, 40287.7695729744, 67896379.652880864, 0 };
            data[3] = new double[] { 3, 25.6, 0.0201629919, 0.0450858206, 12470.0743245454, 19096192.250596218, 0 };
            data[4] = new double[] { 4, 22.1, 0.1010543415, 0.2259643771, 20252.9887081642, 53350566.236654339, 0 };
            data[5] = new double[] { 5, 25.3, 0.0231502122, 0.0517654482, 40377.0637933387, 33329540.386316725, 0 };
            data[6] = new double[] { 6, 23.57, 0.0513517179, 0.1148259319, 21923.1206363916, 46403720.166234079, 0 };
            data[7] = new double[] { 7, 27.0, 0.0105816886, 0.023661375, 48944.7418380552, 55213427.684035178, 0 };
            data[8] = new double[] { 8, 22.4, 0.0880146521, 0.1968067451, 78622.2614074651, 60060135.125467599, 0 };
            data[9] = new double[] { 9, 20.5, 0.2111324448, 0.4721064988, 57879.1443406961, 34144548.430173126, 0 };
            data[10] = new double[] { 10, 24.0, 0.0421264611, 0.0941976306, 43750.5913144202, 15646029.97875537, 0 };
            data[11] = new double[] { 11, 23.2, 0.0608912622, 0.1361570015, 51299.2834222082, 31398964.09139144, 0 };
            data[12] = new double[] { 12, 22.6, 0.0802703167, 0.1794898848, 36994.026755178, 26428818.615410818, 0 };
            data[13] = new double[] { 13, 19.7, 0.3051792326, 0.6824015094, 30815.5048864332, 63895756.445236749, 1 };
            data[14] = new double[] { 14, 19.4, 0.3503926411, 0.7835017643, 32210.3370937632, 19393353.459564218, 1 };
            data[15] = new double[] { 15, 20.36, 0.2251930467, 0.5035469604, 65260.6371983344, 45290438.204452618, 1 };
            data[16] = new double[] { 16, 21.8, 0.1160259082, 0.2594418179, 71331.0111491022, 46339769.231018407, 1 };
            data[17] = new double[] { 17, 21.2, 0.1529519353, 0.3420109247, 44577.744392947, 23272128.16986803, 1 };
            data[18] = new double[] { 18, 16.8, 1.1602590821, 2.5944181791, 40459.3263497876, 39698959.816716016, 1 };
            data[19] = new double[] { 19, 19.4, 0.3503926411, 0.7835017643, 106017.5408782921, 44195358.892618721, 1 };
            data[20] = new double[] { 20, 21.21, 0.152249185, 0.3404395273, 49788.8554646362, 74584093.100715622, 1 };
            data[21] = new double[] { 21, 18.54, 0.3235235929, 0.7234207461, 87694.1646885868, 70189735.135854166, 1 };
            data[22] = new double[] { 22, 19.34, 0.3602093458, 0.8054525833, 38774.3004988704, 6813866.399487506, 1 };
            data[23] = new double[] { 23, 20.6, 0.2016299194, 0.4508582062, 68127.2022382618, 30599948.1047174, 1 };
            data[24] = new double[] { 24, 21.9, 0.1108038821, 0.2477650126, 43597.7173031609, 43451592.64560946, 1 };
            data[25] = new double[] { 25, 21.1, 0.160160338, 0.358129403, 25745.6113278324, 60960237.489576548, 1 };


            double[] item = new double[] { absoluteMagnitude, diameterMin, diameterMax, velocity, missDistance };

            double maxAbsoluteMagnitude = FindMaxMin(item, data)[0];
            double maxdiameterMin = FindMaxMin(item, data)[1];
            double maxdiameterMax = FindMaxMin(item, data)[2];
            double maxVelocity = FindMaxMin(item, data)[3];
            double maxmissDistance = FindMaxMin(item, data)[4];

            double minAbsoluteMagnitude = FindMaxMin(item, data)[5];
            double mindiameterMin = FindMaxMin(item, data)[6];
            double mindiameterMax = FindMaxMin(item, data)[7];
            double minVelocity = FindMaxMin(item, data)[8];
            double minmissDistance = FindMaxMin(item, data)[9];

            foreach (var myitem in data)
            {
                myitem[1] = (myitem[1] - minAbsoluteMagnitude) / (maxAbsoluteMagnitude - minAbsoluteMagnitude);
                myitem[2] = (myitem[2] - mindiameterMin) / (maxdiameterMin - mindiameterMin);
                myitem[3] = (myitem[3] - mindiameterMax) / (maxdiameterMax - mindiameterMax);
                myitem[4] = (myitem[4] - minVelocity) / (maxVelocity - minVelocity);
                myitem[5] = (myitem[5] - minmissDistance) / (maxmissDistance - minmissDistance);
            }

            item[0] = (item[0] - minAbsoluteMagnitude) / (maxAbsoluteMagnitude - minAbsoluteMagnitude);
            item[1] = (item[1] - mindiameterMin) / (maxdiameterMin - mindiameterMin);
            item[2] = (item[2] - mindiameterMax) / (maxdiameterMax - mindiameterMax);
            item[3] = (item[3] - minVelocity) / (maxVelocity - minVelocity);
            item[4] = (item[4] - minmissDistance) / (maxmissDistance - minmissDistance);

            Console.WriteLine("Nearest (k=6) to 22.2, 0.096506147, 0.2157943048, 66647.8557106394, 62701736.468136927):");
            return Analyze(item, data, 6, 2);  // 2 classes

        }

        static double[] FindMaxMin(double[] item, double[][] data)
        {
            double[] AbsoluteMagnitude = new double[data.Length + 1];
            double[] diameterMin = new double[data.Length + 1];
            double[] diameterMax = new double[data.Length + 1];
            double[] Velocity = new double[data.Length + 1];
            double[] missDistance = new double[data.Length + 1];

            for (int i = 0; i < data.Length; i++)
            {
                AbsoluteMagnitude[i] = data[i][1];
                diameterMin[i] = data[i][2];
                diameterMax[i] = data[i][3];
                Velocity[i] = data[i][4];
                missDistance[i] = data[i][5];
            }

            AbsoluteMagnitude[data.Length] = item[0];
            diameterMin[data.Length] = item[1];
            diameterMax[data.Length] = item[2];
            Velocity[data.Length] = item[3];
            missDistance[data.Length] = item[4];

            return new double[] { AbsoluteMagnitude.Max(), diameterMin.Max(), diameterMax.Max(), Velocity.Max(), missDistance.Max(), AbsoluteMagnitude.Min(), diameterMin.Min(), diameterMax.Min(), Velocity.Min(), missDistance.Min() };
        }

        static double Analyze(double[] item, double[][] data,
          int k, int c)
        {
            // 1. Compute all distances
            int N = data.Length;
            double[] distances = new double[N];
            for (int i = 0; i < N; ++i)
                distances[i] = DistFunc(item, data[i]);
            // 2. Get ordering
            int[] ordering = new int[N];
            for (int i = 0; i < N; ++i)
                ordering[i] = i;
            double[] distancesCopy = new double[N];
            Array.Copy(distances, distancesCopy, distances.Length);
            Array.Sort(distancesCopy, ordering);
            // 3. Show info for k nearest
            double[] kNearestDists = new double[k];
            for (int i = 0; i < k; ++i)
            {
                int idx = ordering[i];
                Show(data[idx]);
                Console.WriteLine("  distance = " +
                  distances[idx].ToString("F4"));
                kNearestDists[i] = distances[idx];
            }
            // 4. Vote
            double[] votes = new double[c];  // one per class
            double[] wts = MakeWeights(k, kNearestDists);
            Console.WriteLine("Weights (inverse technique): ");
            for (int i = 0; i < wts.Length; ++i)
                Console.Write(wts[i].ToString("F4") + "  ");
            Console.WriteLine("\n\nPredicted class: ");
            for (int i = 0; i < k; ++i)
            {
                int idx = ordering[i];
                int predClass = (int)data[idx][6];
                votes[predClass] += wts[i] * 1.0;
            }
            for (int i = 0; i < c; ++i)
                Console.WriteLine("[" + i + "]  " +
                votes[i].ToString("F4"));

            return votes[1];
        } // Analyze
        static double[] MakeWeights(int k, double[] distances)
        {
            // Inverse technique
            double[] result = new double[k];  // one perneighbor
            double sum = 0.0;
            for (int i = 0; i < k; ++i)
            {
                result[i] = 1.0 / distances[i];
                sum += result[i];
            }
            for (int i = 0; i < k; ++i)
                result[i] /= sum;
            return result;
        }
        static double DistFunc(double[] item, double[] dataPoint)
        {
            double sum = 0.0;
            for (int i = 0; i < 5; ++i)
            {
                double diff = item[i] - dataPoint[i + 1];
                sum += diff * diff;
            }
            return Math.Sqrt(sum);
        }
        static void Show(double[] v)
        {
            Console.Write("idx = " + v[0].ToString().PadLeft(3) +
              "  (" + v[1].ToString("F2") + " " +
              v[2].ToString("F2") + ") class = " + v[3]);
        }




    }
}
