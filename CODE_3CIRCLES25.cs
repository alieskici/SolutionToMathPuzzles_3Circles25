/*
  Solved by Ali Eskici in 261020
  https://www.facebook.com/4l135k1c1
  github.com/alieskici
*/


using System;
using System.Collections.Generic;

namespace ConsoleApp1_3_Circles_25
{
  class Program
  {
      static void Main()
    {
      List<int> remain = new List<int>();
      int[] c1 = new int[5];
      int[] c2 = new int[5];
      int[] c3 = new int[5];

      Random r = new Random();
      int sumc1, sumc2, sumc3;
      int choosenindex;
      bool flag;

      List<string> solCir = new List<string>();
      string sc1 = "";
      string sc2 = "";
      string sc3 = "";
      string sumCn = "";
      int tryCount = 0;

      do
      {
        tryCount++;
        if (tryCount>1000000)
        {
          break;
        }

        remain.Clear();
        for (int i = 0; i < 9; i++)
        {
          remain.Add(i+1);
        }

        Array.Clear(c1, 0, c1.Length);
        Array.Clear(c2, 0, c2.Length);
        Array.Clear(c3, 0, c3.Length);

        flag = false;

        //c1
        for (int i = 0; i < 5; i++)
        { 
          choosenindex = r.Next(0, remain.Count);
          c1[i] = remain[choosenindex];
          remain.RemoveAt(choosenindex);
        }

        //c2
        c2[0] = c1[4];
        c2[2] = c1[2];

        choosenindex = r.Next(0, remain.Count);
        c2[1] = remain[choosenindex];
        remain.RemoveAt(choosenindex);

        choosenindex = r.Next(0, remain.Count);
        c2[3] = remain[choosenindex];
        remain.RemoveAt(choosenindex);

        choosenindex = r.Next(0, remain.Count);
        c2[4] = remain[choosenindex];
        remain.RemoveAt(choosenindex);

        //c3 (below circle)
        c3[0] = c2[1];
        c3[1] = c1[1];
        c3[3] = c2[3];
        c3[4] = c1[3];

        choosenindex = r.Next(0, remain.Count);
        c3[2] = remain[choosenindex];
        remain.RemoveAt(choosenindex);


        sumc1 = c1[0] + c1[1] + c1[2] + c1[3] + c1[4];
        if (sumc1 == 25)
        {
          sumc2 = c2[0] + c2[1] + c2[2] + c2[3] + c2[4];
          if (sumc2 == 25)
          {
            sumc3 = c3[0] + c3[1] + c3[2] + c3[3] + c3[4];
            if (sumc3 == 25)
            {
              flag = true;
            }
          }
        }

        sc1 = ""; sc2 = ""; sc3 = "";
        if (flag)
        {
          for (int i = 0; i < 5; i++)
          {
            sc1 += c1[i].ToString();
            sc2 += c2[i].ToString();
            sc3 += c3[i].ToString();
          }

          sumCn = sc1 + " " + sc2 + " " + sc3;

          if (solCir.IndexOf(sumCn) == -1)
          {
            solCir.Add(sumCn);
            Console.WriteLine(sumCn);
            tryCount = 0;
          }

          flag = false;
        }

        Console.Title = tryCount.ToString();

      } while (!flag);
      
      Console.WriteLine("There are " + solCir.Count.ToString() +  " solutions");
      Console.ReadKey();
    }
  }
}