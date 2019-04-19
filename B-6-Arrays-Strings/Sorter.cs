using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Lesson_6
{
    public class Sorter
    {
        private ISorter _sorter = null;
        public enum SortAlgorithm
        {
            Bubble,
            Insertion,
            Heapsort,
            QuickSort
        }

        public SortAlgorithm SetAlgorithm {
            set
            {
                _sorter = SorterFactory.Create(value);
            }
        }

        public int[] SortIntArray(int[] array)
        {
            if(_sorter == null)
            {
                return new int[0];
            }
            return _sorter.SortArray(array);
        }
    }



    class SorterFactory
    {
        public static ISorter Create(Sorter.SortAlgorithm alg)
        {
            ISorter _sorter = null;

            switch (alg)
            {
                case Sorter.SortAlgorithm.Bubble:
                    _sorter = new BubbleSorter();
                    break;
                case Sorter.SortAlgorithm.Insertion:
                    _sorter = new InsertionSorter();
                    break;
                case Sorter.SortAlgorithm.Heapsort:
                    _sorter = new HeapSortSorter();
                    break;
                case Sorter.SortAlgorithm.QuickSort:
                    _sorter = new QuickSortSorter();
                    break;
                default:
                    _sorter = new NullSorter();
                    break;
            }
            return _sorter;
        }
    }

    class BubbleSorter : ISorter
    {
        public int[] SortArray(int[] array)
        {
            bool _isSorted = false;
            while (!_isSorted)
            {
                int tempVar;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1]) 
                    {
                        tempVar = array[i + 1];
                        array[i+1] = array[i];
                        array[i] = tempVar;
                    }
                }
                _isSorted = true;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1]) _isSorted = false;
                }
            }


            return array;
        }
    }
    class InsertionSorter : ISorter
    {
        public int[] SortArray(int[] array)
        {
            
            
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0 && array[j - 1] > array[j]; j--)
                {
                    int tempVar = array[j-1];
                    array[j-1] = array[j];
                    array[j] = tempVar;
                }
            }

            return array;

        }
    }
    class HeapSortSorter : ISorter
    {
        public int[] SortArray(int[] array)
        {
            throw new NotImplementedException();
        }
    }
    class QuickSortSorter : ISorter
    {
        public int[] SortArray(int[] array)
        {
            int[] tempArr = array;

            _SortQuick(tempArr, 0, tempArr.Length - 1);

            return tempArr;
        }
        private void _SortQuick(int[] arr, int left, int right)
        {

            int baseEl = arr[left];
            int l_margin = left;
            int r_margin = right;
            
            while(left < right)
            {
                while ((arr[right] >= baseEl) && (left < right)) right--;
                if(left != right)
                {
                    arr[left] = arr[right];
                    left++;
                }

                while((arr[left] <= baseEl) && (left < right)) left++;
                if (left != right)
                {
                    arr[right] = arr[left];
                    right--;
                }
            }

            arr[left] = baseEl;
            baseEl = left;
            left = l_margin;
            right = r_margin;

            if (left < baseEl) _SortQuick(arr, left, baseEl - 1);
            if (right > baseEl) _SortQuick(arr, baseEl + 1, right);


        }
    }
    class NullSorter : ISorter
    {
        public int[] SortArray(int[] array)
        {
            return new int[0];
        }
    }
}
