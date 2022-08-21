using System;
using System.Collections.Generic;

namespace CSDK {
    namespace Common {
	    public class Arrays {
		    public static string[] Add(string[] array, string value) {
			    int index = array.Length;
			    string[] temp = new string[index + 1];
			    for (int i = 0; i < index; ++i) 
                    temp[i] = array[i];
			    temp[index] = value;
			    return temp;
		    }

		    public static string[] Remove(string[] array, int c) {
			    if (c >= 0) {
				    int index = array.Length;
				    string[] temp = new string[index - 1];
				    int t = 0;
				    for (int i = 0; i < index; ++i) {
					    if (i != c) {
						    temp[t] = array[i];
						    ++t;
					    }
				    }
				    return temp;
			    }
			    return array;
		    }

			private static string[] Merge(string[] array, string[] tmp, int left, int right, int rightend) {
				int leftend = right - 1;
				int k = left;
				int num = rightend - (left + 1);

				while (left <= leftend && right <= rightend) {
					if (array[left].CompareTo(array[right]) <= 0)
						tmp[k++] = array[left++];
					else
						tmp[k++] = array[right++];
				}
				while (left <= leftend)
					tmp[k++] = array[left++];
				while (right <= rightend)
					tmp[k++] = array[right++];
				for (int i = 0; i < num; i++, rightend--)
					array[rightend] = tmp[rightend];
				return array;
			}

			private static string[] MergeSort(string[] array, string[] tmp, int left, int right) {
				string[] _tmp;
				if (right != 0 && left < right) {
					int center = (left + right) / 2;
					tmp = MergeSort(array, tmp, left, center);
					tmp = MergeSort(array, tmp, center + 1, right);
					_tmp = Merge(array, tmp, left, center + 1, right);
				}
				else
					return array;
				return _tmp;
			}

			public static string[] MergeSort(string[] array) {
				if (array.Length == 0)
					return array;
				string[] tmp = new string[array.Length];
				return MergeSort(array, tmp, 0, array.Length - 1);
			}

			public static string[] BubbleSort(string[] array) {
				if (array.Length == 0)
					return array;
                for (int i = 0; i < array.Length; ++i) {
					string tmp;
					for (int k = 0; k < array.Length - 1; ++k)
					{
						tmp = array[k];
						array[k] = array[k + 1];
						array[k + 1] = tmp;
					}
                }
				return array;
			}

			public static string[] NullSort(string[] array) {
				Array.Sort(array);
				return array;			
			}
	    }
    }
}
