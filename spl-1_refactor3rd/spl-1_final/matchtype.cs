using System;


namespace scoreboard
{
    public class matchtype
    {
        public static string GetValidType()
        {
            bool isValidInput = false;
            string type = "";

            do
            {

                type = Console.ReadLine().ToLower();


                // Convert to lowercase for case-insensitive comparison
                //whatever casing, code will reform to avoid any error


                try
                {
                    ValidateInputType(type);
                    isValidInput = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (!isValidInput);

            return type;
        }

        private static void ValidateInputType(string type)
        {
            if (!(type == "odi" || type == "t20" || type == "shortmatch"))
            {
                throw new ArgumentException("Invalid input. Please enter 'ODI', 'T20', or 'shortmatch'.");
            }
        }
    }
}