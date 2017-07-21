using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMergeSort
{
    class Mergesort
    {

        static public void DoMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[numbers.Length];
            int i, left_end, num_elements, tmp_pos, right_start;

            left_end = mid;
            right_start = mid + 1;
            tmp_pos = left;
            num_elements = (right - left + 1);

            //If left value is not empty and right value is not empty, check which value is lower and insert that value into a new array. THEN increment the positon of the side which is lower and the position of the storearray by 1.
            while ((left <= left_end) && (right_start <= right))
            {
                if (numbers[left] <= numbers[right_start])
                {
                    temp[tmp_pos] = numbers[left];
                    left++;
                }

                else
                {
                    temp[tmp_pos] = numbers[right_start];
                    right_start++;
                }
                tmp_pos++;
            }
         
            //while left side is bigger than one value and the right side is empty
            while (left <= left_end)
            {
                temp[tmp_pos] = numbers[left];
                tmp_pos++;
                left++;
            }
       
            //while right side is bigger than one value and the left side is empty
            while (right_start <= right)
            {
                temp[tmp_pos] = numbers[right_start];
                tmp_pos++;
                right_start++;
            }
 
            //Copy array
            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
        
        static public int[] MergeSort_Recursive(int[] numbers, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort_Recursive(numbers, left, mid);
                MergeSort_Recursive(numbers, (mid + 1), right);

                DoMerge(numbers, left, mid, right);
            }
            return numbers;
        }

        static void Main(string[] args)
        {
            int[] numbers = { 3, 8, 7, 5, 2, 12, 24, 23, 99};

            int[] intArray = MergeSort_Recursive(numbers, 0, numbers.Length - 1);

            for (int i = 0; i < intArray.Length; i++)
                Console.WriteLine(intArray[i]);

            Console.ReadKey();
            

        }
    }
}
