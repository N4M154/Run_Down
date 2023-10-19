using System;

namespace CricektClasses_2
{
    public class Batsmen
    {

        public string Batsman1, Batsman2, NewBatsman;
        public int[] RunsByBatsman1 = new int[20];
        public int[] RunsByBatsman2 = new int[20];
        public bool IsBatsman1Striker = true;



        

        public void BatsmenNameDisplay()
        {
            Console.WriteLine("Enter the name of batsman 1: ");
            Batsman1 = Console.ReadLine();
            Console.WriteLine("Enter the name of batsman 2: ");
            Batsman2 = Console.ReadLine();
            Console.WriteLine("\n");
        }

      
       

    }
}