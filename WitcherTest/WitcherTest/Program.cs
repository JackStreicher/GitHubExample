using System;


namespace WitcherTest
{
     
    public class Program
    {
        public static void Main()
        {

           

            Random rand = new Random();

            //Unsere Eingabe
            string inputWitcher;

            //Input Umwandlung zu int
            int inputGold;

            //Für die finale Ausgabe
            int lastInput = 0;

            //Anzahl der Versuche
            int tries = 3;

            //Festlegung von Minumum und Maximum (Gold)
            int minGold = 5;
            int maxGold = 460;

            int randMax = rand.Next(minGold, maxGold);
            

            //Debug
            //Console.WriteLine(randMax);




            while (tries > 0)
            {
               
                inputWitcher = Console.ReadLine();
                inputGold = Int32.Parse(inputWitcher);

                //Eingabe von 0     5                       460
                while (inputGold < minGold || inputGold > maxGold)
                {
                    Console.WriteLine("It's either too much or too less gold, I need to rethink how much gold I want...");
                    inputWitcher = Console.ReadLine();
                    inputGold = Int32.Parse(inputWitcher);
                }


                //Damit wir nach der While dne Abstand zum Maximalwert berechnen können.
                lastInput = inputGold;

                if (inputGold <= randMax)
                {
                    //Wenn kleiner als MaxGold

                    //Wenn zu niedrig (spottbillig)
                    if (inputGold <= 0.2 * randMax)
                    {

                        //z.b: zufalls Maxwert = 400, d.h. wenn wir 80 oder drunter bieten, nimmt der Dorfbewohner an, da der Preis spottbillig ist
                        Console.WriteLine("Oh that's a goood deal Witcher, you are so generous.");
                        tries = 0;

                    }

                    else
                    {

                        Console.WriteLine(inputGold + " Gold it is then??");
                        tries--;

                        //Ab 80% des Maximalwertes
                        if (inputGold >= (randMax - randMax * 0.2))
                        {
                            //Debug
                            //Console.WriteLine(randMax);
                            Console.WriteLine("You are a stubborn haggler, eh? Well...");
                            Console.WriteLine("This is not fair.");
                        }

                        //Ab 33% des Maximalwertes UND kleiner gleich als 80% des Maximalwertes
                        if (inputGold >= (randMax / 3) && inputGold < (randMax * 0.8))
                        {
                            //Debug
                            //Console.WriteLine(randMax);
                            Console.WriteLine("That's about right");
                        }

                        //Wenn mehr als 33% des Maximalwertes UND kleiner als 50% des Maximalwertes UND größer als der Mindeswert
                        if ( inputGold < (randMax * 1/3) && inputGold < (maxGold / 2) && inputGold >= (minGold))
                        {
                            //Debug
                            //Console.WriteLine(randMax);
                            Console.WriteLine("Good price Witcher");
                        }
                    }

                }
                else
                {
                    //Wenn größer als MaxGold
                    Console.WriteLine("That's too much, stranger.");
                    tries --;


                    if (tries <= 0)
                    {
                        Console.WriteLine("Get off Witcher. Your haggling is the worst.\nGame Over");
                        lastInput = 0;
                    }

                }

            }

           
            //Abstand zum Maximalwert
            if(lastInput == 0)
            {
                Console.WriteLine("\nThe End " + "\nYou sold yourself below value");
            }

            else
            {
                Console.WriteLine("\nThe End " + "\nYou were " + (randMax - lastInput) + " away from getting the Maximum out of it");
            }
                

            Console.ReadKey();
        }
    }
}
