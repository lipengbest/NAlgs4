using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAlgs4
{
    /// <summary>
    /// The <c>StdRandom</c> class provides static methods for generating
    /// random number from various discrete and continuous distributions, 
    /// including uniform, Bernoulli, geometric, Gaussian, exponential, Pareto,
    /// Poisson, and Cauchy. It also provides method for shuffling an
    /// array or subarray and generating random permutations.
    /// </summary>
    public static class StdRandom
    {
        private static Random random = new Random();
        private static int seed = DateTime.Now.Millisecond;

        /// <summary>
        /// Sets the seed of the pseudo-random number generator.
        /// This Property enables you to produce the same sequence of "random"
        /// number for each execution of the program.
        /// Ordinarily, you set this property at most once per program.
        /// </summary>
        /// <value>the seed</value>
        public static int Seed
        {
            get { return seed; }
            set
            {
                seed = value;
                random = new Random(seed);
            }
        }

        /// <summary>
        /// Returns a random real number uniformly in [0, 1).
        /// </summary>
        /// <returns>a random real number uniformly in [0, 1)</returns>
        public static double Uniform()
        {
            return random.NextDouble();
        }

        /// <summary>
        /// Returns a random integer uniformly in [0, n).
        /// </summary>
        /// <param name="n">number of possible integers</param>
        /// <returns>a random integer uniformly between 0 (inclusive) and {@code n} (exclusive)</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int Uniform(int n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException($"argument must be positive: {n}");
            return random.Next(n);
        }

        /// <summary>
        /// Returns a random long integer uniformly in [0, n).
        /// </summary>
        /// <param name="n">number of possible {@code long} integers</param>
        /// <returns>a random long integer uniformly between 0 (inclusive) and <c>n</c> (exclusive)</returns>
        /// <exception cref="ArgumentException"></exception>
        public static long Uniform(long n)
        {
            if (n <= 0L)
                throw new ArgumentException($"argument must be positive: {n}");

            // https://docs.oracle.com/javase/8/docs/api/java/util/Random.html#longs-long-long-long-
            long r = random.NextLong();
            long m = n - 1;

            // power of two
            if ((n & m) == 0L)
                return n & m;

            long u = r >> 1;
            while (u + m - (r = u % n) < 0L)
            {
                u = random.NextLong() >> 1;
            }
            return r;
        }

        private static long NextLong(this Random random)
        {
            return (long)(random.NextDouble() * long.MaxValue);
        }

        /// <summary>
        /// Returns a random real number uniformly in [0, 1).
        /// </summary>
        /// <returns>a random real number uniformly in [0, 1)</returns>
        /// <remarks>Replaced by <see cref="Uniform()"/></remarks>
        [Obsolete]
        public static double Random()
        {
            return Uniform();
        }

        /// <summary>
        /// Returns a random integer uniformly in [a, b).
        /// </summary>
        /// <param name="a">the left endpoint</param>
        /// <param name="b">the right endpoint</param>
        /// <returns>a random integer uniformly in [a, b)</returns>
        /// <exception cref="ArgumentException"></exception>
        public static int Uniform(int a, int b)
        {
            if (b <= a || (long)b - a > int.MaxValue)
                throw new ArgumentException($"invalid range: [{a},{b})");
            return Uniform(b - a) + a;
        }

        /// <summary>
        /// Returns a random real number uniformly in [a, b).
        /// </summary>
        /// <param name="a">the left endpoint</param>
        /// <param name="b">the right endpoint</param>
        /// <returns>a random real number uniformly in [a, b)</returns>
        /// <exception cref="ArgumentException"></exception>
        public static double Uniform(double a, double b)
        {
            if (!(a < b))
                throw new ArgumentException($"invalid range: [{a},{b})");
            return Uniform() * (b - a) + a;
        }

        /// <summary>
        /// Returns a random boolean from a Bernoulli distribution with success
        /// probability <c>p</c>.
        /// </summary>
        /// <param name="p">the probability of returning <c>true</c></param>
        /// <returns><c>true</c> with probability <c>p</c> and <c>false</c> with probability <c>p</c></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool Bernoulli(double p)
        {
            if (!(p >= 0.0 && p <= 1.0))
                throw new ArgumentOutOfRangeException($"probability p must be between 0.0 and 1.0: {p}");
            return Uniform() < p;
        }

        /// <summary>
        /// Returns a random boolean from a Bernoulli distribution with success
        /// probability 1/2.
        /// </summary>
        /// <returns><c>true</c> with probability 1/2 and <c>false</c> with probability 1/2</returns>
        public static bool Bernoulli()
        {
            return Bernoulli(0.5);
        }

        /// <summary>
        /// Returns a random real number from a standard Gaussian distribution.
        /// </summary>
        /// <returns>
        /// a random real number from a standard Gaussian distribution
        /// (mean 0 and standard deviation 1).
        /// </returns>
        public static double Gaussian()
        {
            // use the polar form of the Box-Muller transform
            double x, y, r;
            do
            {
                x = Uniform(-1.0, 1.0);
                y = Uniform(-1.0, 1.0);
                r = x * x + y * y;
            } while (r >= 1 || r == 0);
            return x * Math.Sqrt(-2 * Math.Log(r) / r);

            // Remark:  y * Math.sqrt(-2 * Math.log(r) / r)
            // is an independent random gaussian
        }

        /// <summary>
        /// Returns a random real number from a Gaussian distribution with mean <c>mu</c>
        /// and standard deviation <c>sigma</c>.
        /// </summary>
        /// <param name="mu">the mean</param>
        /// <param name="sigma">the standard deviation</param>
        /// <returns>a real number distributed according to the Gaussian distribution with mean <c>mu</c> and standard deviation <c>sigma</c></returns>
        public static double Gaussian(double mu, double sigma)
        {
            return mu + sigma * Gaussian();
        }

        /// <summary>
        /// Returns a random integer from a geometric distribution with success
        /// probability <c>p</c>
        /// </summary>
        /// <param name="p">the parameter of the geometric distribution</param>
        /// <returns>
        /// a random integer from a geometric distribution with success
        /// probability <c>p</c>; or <c>int.MaxValue</c> if
        /// <c>p</c> is (nearly) equal to <c>1.0</c>.
        /// </returns>
        public static int Geometric(double p)
        {
            if (!(p >= 0.0 && p <= 1.0))
                throw new ArgumentOutOfRangeException($"probability p must be between 0.0 and 1.0: {p}");
            return (int)Math.Ceiling(Math.Log(Uniform()) / Math.Log(1.0 - p));
        }

        /// <summary>
        /// Returns a random integer from a Poisson distribution with mean <c>lambda</c>.
        /// </summary>
        /// <param name="lambda">the mean of the Poisson distribution</param>
        /// <returns>a random integer from a Poisson distribution with mean <c>lambda</c></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int Poisson(double lambda)
        {
            if (!(lambda > 0.0))
                throw new ArgumentException($"lambda must be positive: {lambda}");
            if (double.IsInfinity(lambda))
                throw new ArgumentException($"lambda must not be infinite: {lambda}");
            // using algorithm given by Knuth
            // see http://en.wikipedia.org/wiki/Poisson_distribution
            int k = 0;
            double p = 1.0;
            double expLamda = Math.Exp(lambda);
            do
            {
                k++;
                p *= Uniform();
            } while (p >= expLamda);
            return k - 1;
        }

        /// <summary>
        /// Returns a random real number from the standard Pareto distribution.
        /// </summary>
        /// <returns>a random real number from the standard Pareto distribution</returns>
        public static double Pareto()
        {
            return Pareto(1.0);
        }

        /// <summary>
        /// Returns a random real number from a Pareto distribution with
        /// shape parameter <c>alpha</c>.
        /// </summary>
        /// <param name="alpha">shape parameter</param>
        /// <returns>a random real number from a Pareto distribution with shape parameter <c>alpha</c></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double Pareto(double alpha)
        {
            if (!(alpha > 0.0))
                throw new ArgumentException($"alpha must be positive: {alpha}");
            return Math.Pow(1 - Uniform(), -1.0 / alpha) - 1;
        }

        /// <summary>
        /// Returns a random real number from the Cauchy distribution.
        /// </summary>
        /// <returns>a random real number from the Cauchy distribution.</returns>
        public static double Cauchy()
        {
            return Math.Tan(Math.PI * (Uniform() - 0.5));
        }

        /// <summary>
        /// Returns a random integer from the specified discrete distribution.
        /// </summary>
        /// <param name="probabilities">the probability of occurrence of each integer</param>
        /// <returns>a random integer from a discrete distribution: <c>i</c> with probability <c>probabilities[i]</c></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static int Discrete(double[] probabilities)
        {
            if (probabilities == null)
                throw new ArgumentNullException("argument array is null");
            double EPSILON = 1E-14;
            double sum = 0.0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                if (!(probabilities[i] > 0.0))
                    throw new ArgumentException($"array entry {i} must be nonnegative: {probabilities[i]}");
                sum += probabilities[i];
            }
            if (sum > 1.0 + EPSILON || sum < 1.0 - EPSILON)
                throw new ArgumentException($"sum of array entries does not approximately equal 1.0: {sum}");

            // the for loop may not return a value when both r is (nearly) 1.0 and when the
            // cumulative sum is less than 1.0 (as a result of floating-point roundoff error)
            while (true)
            {
                double r = Uniform();
                sum = 0.0;
                for (int i = 0; i < probabilities.Length; i++)
                {
                    sum += probabilities[i];
                    if (sum > r)
                        return i;
                }
            }
        }

        /// <summary>
        /// Returns a random integer from the specified discrete distribution.
        /// </summary>
        /// <param name="frequencies">the frequency of occurrence of each integer</param>
        /// <returns>a random integer from a discrete distribution: <c>i</c> with probability proportional to <c>frequencies[i]</c></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static int Discrete(int[] frequencies)
        {
            if (frequencies == null)
                throw new ArgumentNullException("argument array is null");
            long sum = 0;
            for (int i = 0; i < frequencies.Length; i++)
            {
                if (frequencies[i] < 0)
                    throw new ArgumentException($"array entry {i} must be nonnegative: {frequencies[i]}");
                sum += frequencies[i];
            }
            if (sum == 0)
                throw new ArgumentException("at least one array entry must be positive");
            if (sum >= int.MaxValue)
                throw new ArgumentException("sum of frequencies overflows an int");

            // pick index i with probabilitity proportional to frequency
            double r = Uniform((int)sum);
            sum = 0;
            for (int i = 0; i < frequencies.Length; i++)
            {
                sum += frequencies[i];
                if (sum > r)
                    return i;
            }

            // can't reach here
            return -1;
        }
    }
}
