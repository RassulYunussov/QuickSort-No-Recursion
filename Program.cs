using System;
using System.Collections.Generic;
using System.Linq;

namespace exp
{
    class Program
    {
        class Borders
        {
            public int Left { get; set; }
            public int Right { get; set; }
            public Borders(int left,int right)
            {
                Left = left;
                Right = right;
            }
        }
       static void QuickSort(int [] src)
    	{
			Stack<Borders> brds = new Stack<Borders>();
            brds.Push(new Borders(0,src.Length-1));
			while(brds.Count>0)
			{
				Borders b= brds.Pop();
				int index = partition(b.Left,b.Right);
				if(index<b.Right)
					brds.Push(new Borders(index,b.Right));
				if(b.Left<index-1)
					brds.Push(new Borders(b.Left,index-1));
			}
			void swap(ref int lv,ref int rv)
			{
				int temp = lv;
				lv = rv;
				rv = temp;
			}
			int partition(int ll, int rr)
			{
				int i = ll, j = rr;
				int pivot = src[(ll + rr) / 2];
				while (i <= j) 
				{
						while (src[i] < pivot)
							i++;
						while (src[j] > pivot)
							j--;
						if (i <= j) {
							swap(ref src[i++],ref src[j--]);
						}
				}
				return i;
			}	
    	}

      

        static void Main(string[] args)
        {
            Random r = new Random();
            int [] a =Enumerable.Range(1,10000).Select(x=>r.Next(1,10000)).ToArray();
            QuickSort(a);
        }
    }
}
