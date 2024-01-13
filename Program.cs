using System;

class Program
{
    static void Main()
    {
        // Sample data representing wicket falls in each over
        int[] wicketsPerOver = { 0, 1, 0, 2, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0 };
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Wicket Falling Graph (Bottom to Top):");

        for (int over = wicketsPerOver.Length - 1; over >= 0; over--)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"Over {over + 1}: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(new string('.', (over+1) * 2)); // Add leading spaces based on the over number

            // Print '*' for each wicket fallen in the current over
            for (int wicket = 0; wicket < wicketsPerOver[over]; wicket++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("*");
            }
            if (wicketsPerOver[over] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(new string('.', ((wicketsPerOver.Length) - over) * 2));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(new string('.', (((wicketsPerOver.Length) - over) * 2)- wicketsPerOver[over]));
            }
                Console.WriteLine(); // Move to the next line for the next over
        }

        Console.ReadLine();
    }
    //static int GetDigitCount(int number)
    //{
    //  return (int)Math.Floor(Math.Log10(number) + 1);
    //}//
}
