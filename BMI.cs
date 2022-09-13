using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BMI
{
    internal class Program
    {
        //Dem olika nivåerna för män respektive kvinnor.
        public static float[] levelsMale = { 20.0f, 25.0f, 30.0f };
        public static float[] levelsFemale = { 18.5f, 24.0f, 29.0f};

        //Denna funtion kalkulerar din BMI på höjd och vikt Math.Pow är inte riktigt nödvändigt men ser bra och professionellt ut
        public static float calcBmi(float height, float weight)
        {
            return (weight / (float)Math.Pow(height / 100, 2));
        }

        

        //Denna funktion användes för att ta reda på vilken din nästa nivå är och hur långt du har dit. 
        public static void nextLevel(float height, float weight, int level, bool isMale)
        {
            float requiredWeight;
            float weightDifference;

            if (isMale)
            {
                requiredWeight = (float)Math.Sqrt(levelsMale[level++] * height);
                weightDifference = requiredWeight - weight;

                Console.WriteLine("Your need to gain " + Math.Round(weightDifference, 1) + " kg to reach the next BMI level.");
            }
            else
            {
                requiredWeight = (float)Math.Sqrt(levelsFemale[level++] * height);
                weightDifference = requiredWeight - weight;

                Console.WriteLine("Your need to gain " + Math.Round(weightDifference, 1) + " kg to reach the next BMI level.");
            }
            
        }

        //Denna funktion används för att slippa repetera koden innut i på flera ställen = mindre kod.
        public static void printColoredText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            //Viktiga variabler som används i koden
            bool stopProgram = false;
            bool requiredGender = false;
            bool isMale = false;
            string gender;
            int level;

            float height = 0;
            float weight = 0;
            float BMI;
            bool validHeight = false;
            bool validWeight = false;


            //Själva huvud loopen. Allting händer innuti denna.
            while (!stopProgram)
            {

                //Ser till så att du skriver in ditt kön. Den tillåter iget annat än man och kvinna. 
                while (!requiredGender)
                {
                    Console.Write("Are you a Male or Female: ");
                    gender = Console.ReadLine(); ;
                    if (gender.ToLower() == "male")
                    {
                        isMale = true;
                        requiredGender = true;
                    }
                    else if (gender.ToLower() == "female")
                    {
                        requiredGender = true;
                    }
                    else
                    {
                        printColoredText("Please enter a valid gender(Male/Female)!", ConsoleColor.Red);
                        Thread.Sleep(1000);
                    }
                }

                //Lika dant som förra men för längd. 
                while (!validHeight)
                {
                    Console.Write("Please enter your height(cm): ");
                    try
                    {
                        height = (float)Math.Round(Convert.ToDouble(Console.ReadLine()), 1);
                        validHeight = true;
                    }
                    catch
                    {
                        printColoredText("Please enter a valid number!", ConsoleColor.Red);
                        Thread.Sleep(1000);
                    }
                }
                //Ya da ya da. Samma men för vikt.
                while (!validWeight)
                {
                    Console.Write("Please enter your weight(kg): ");
                    try
                    {
                        weight = (float)Math.Round(Convert.ToDouble(Console.ReadLine()), 1);
                        validWeight = true;
                    }
                    catch
                    {
                        printColoredText("Please enter a valid number!", ConsoleColor.Red);
                        Thread.Sleep(1000);
                    }
                }

                //Här så räknar den ut din BMI och avrundar den till 1 decimal
                BMI = (float)Math.Round(calcBmi(height, weight), 1);
                Console.WriteLine();


                //Här nedan kollar den ifall du är man eller kvinna så den korrekt kan ge dig din viktklass. 
                if (isMale)
                {
                    if(BMI < levelsMale[0])
                    {
                        printColoredText("You are in level one with a BMI of " + BMI.ToString(), ConsoleColor.Green);
                        level = 1;
                    }else if(BMI >= levelsMale[0] && BMI < levelsMale[1])
                    {
                        printColoredText("You are in level two with a BMI of " + BMI.ToString(), ConsoleColor.Green);
                        level = 2;
                    }else if(BMI >= levelsMale[1] && BMI < levelsMale[2])
                    {
                        printColoredText("You are in level three with a BMI of " + BMI.ToString(), ConsoleColor.Green);
                        level = 3;
                    }
                    else
                    {
                        printColoredText("You are in level four with a BMI of " + BMI.ToString(), ConsoleColor.Green);
                        level = 4;
                    }
                    nextLevel(height, weight, level, isMale);
                }
                else
                {
                    if (BMI < levelsFemale[0])
                    {
                        Console.WriteLine("You are in level one with a BMI of " + BMI);
                        level = 1;
                    }
                    else if (BMI >= levelsFemale[0] && BMI < levelsFemale[1])
                    {
                        Console.WriteLine("You are in level two with a BMI of " + BMI);
                        level = 2;
                    }
                    else if (BMI >= levelsFemale[1] && BMI < levelsFemale[2])
                    {
                        Console.WriteLine("You are in level three with a BMI of " + BMI);
                        level = 3;
                    }
                    else
                    {
                        Console.WriteLine("You are in level four with a BMI of" + BMI);
                        level = 4;
                    }
                    nextLevel(height, weight, level, isMale);
                }

                //Denna del av programmet kollar ifall du vill fortsätta elller avsluta programmet. 
                Thread.Sleep(1200);
                Console.WriteLine("\n\n");
                Console.WriteLine("Do you want to continue?(Yes/No)");

                if (Console.ReadLine().ToLower() == "yes"){
                    validHeight = false;
                    validWeight = false;
                    requiredGender = false;
                    Thread.Sleep(1200);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Thank you for using my BMI calculator!");
                    Thread.Sleep(2000);
                    stopProgram = true;
                }
            }
        }
    }
}
