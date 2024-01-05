using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreboard
{
    public class matchtype
    {
        public static string GetValidType()
        {
            string Type;

            bool isValidInput = false;

            do
            {

                Type = Console.ReadLine().ToLower();


                // Convert to lowercase for case-insensitive comparison
                //whatever casing, code will reform to avoid any error


                try
                {
                    // check input type
                    if (!(Type == "odi" || Type == "t20" || Type == "shortmatch"))
                    {
                        throw new ArgumentException("Invalid input. Please enter 'ODI' or 'T20' or 'shortmatch' .");
                    }

                    isValidInput = true;
                }



                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }


            while (!isValidInput);

            return Type;
        }
    }
}
