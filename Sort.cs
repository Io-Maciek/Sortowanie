namespace Sortowanie
{
    public abstract class Sort
    {

        static T[] Swap<T>(T[] tab, int indexA, int indexB) where T : IComparable<T>
        {
            T key = tab[indexA];
            tab[indexA] = tab[indexB];
            tab[indexB] = key;
            return tab;
        }



        static void MERGE_SORT<T>(T[] tab, int p, int r) where T : IComparable<T>
        {
            if (p < r)
            {
                int q = Convert.ToInt32(Math.Floor((p + r) / 2.0));
                MERGE_SORT(tab, p, q);
                MERGE_SORT(tab, q + 1, r);
                MERGE(tab, p, q, r);
            }
        }
        static void MERGE<T>(T[] tab, int p, int q, int r) where T : IComparable<T>
        {

            int n1 = q - p + 1;
            int n2 = r - q;
            T[] L = new T[n1];
            T[] R = new T[n2];

            Array.Copy(tab, p, L, 0, q - p + 1);
            Array.Copy(tab, q + 1, R, 0, r - q);


            int i = 0, j = 0;

            for (int k = p; k < r + 1; k++)
            {
                if (i == L.Length)
                {
                    tab[k] = R[j];
                    j++;
                }
                else if (j == R.Length)
                {
                    tab[k] = L[i];
                    i++;
                }
                else if (L[i].CompareTo(R[j]) < 0)
                {
                    tab[k] = L[i];
                    i++;
                }
                else
                {
                    tab[k] = R[j];
                    j++;
                }
            }

        }

        /// <summary>
        /// Sortuj tabele przez sortowanie przez scalanie, którego średnia złożoność obliczeniowa jest rzędu <c>O(n*log(n))</c>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tab"></param>
        public static void MERGE_SORT<T>(T[] tab) where T : IComparable<T>
        {
            MERGE_SORT(tab, 0, tab.Length - 1);
        }


        /// <summary>
        /// Sortuj tabele poprzez sortowanie szybkie, którego średnia złożoność obliczeniowa jest rzędu <c>O(n*log(n))</c>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tab"></param>
        public static void QUICKSORT<T>(T[] tab) where T : IComparable<T>
        {
            int i = 0;
            int j = tab.Length - 1;
            QUICK_SORT(tab, i, j);
        }

        static void QUICK_SORT<T>(T[] tab, int p, int r) where T : IComparable<T>
        {
            if (p < r)
            {
                int q = PARTITION(tab, p, r);
                QUICK_SORT(tab, p, q - 1);
                QUICK_SORT(tab, q + 1, r);
            }
        }
        static int PARTITION<T>(T[] tab, int p, int r) where T : IComparable<T>
        {
            T x = tab[r];
            int i = p - 1;

            for (int j = p; j < r; j++)
            {
                //if (tab[j] <= x)
                if (tab[j].CompareTo(x) < 0)
                {
                    Swap(tab, ++i, j);
                }
            }
            Swap(tab, i + 1, r);
            return i + 1;
        }


        /// <summary>
        /// Sortuj tabele przez sortowanie przez kopcowanie, którego średnia złożoność obliczeniowa jest rzędu <c>O(n*log(n))</c>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tab"></param>
        public static void HEAP_SORT<T>(T[] tab) where T : IComparable<T>
        {
            int nSize = tab.Length;
            for (int j = nSize / 2; j >= 0; j--)
                Update(tab, j, nSize - 1);
            for (int j = nSize - 1; j > 0; j--)
            {

                T x = tab[0];
                tab[0] = tab[j];
                tab[j] = x;

                Update(tab, 0, j - 1);
            }
        }

        static void Update<T>(T[] tab, int left, int right) where T : IComparable<T>
        {
            if (left >= right) return;
            int i = left;
            int j = 2 * i + 1;
            T x = tab[i];

            while (j <= right)
            {
                if (j < right)
                    if (tab[j].CompareTo(tab[j + 1]) < 0)
                        j++;
                if (tab[j].CompareTo(x) < 0) break;
                tab[i] = tab[j];
                i = j;
                j = 2 * i + 1;
            }
            tab[i] = x;

        }

    }
}
