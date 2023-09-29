namespace GuessTheNumber
{
    internal class Program
    {

        /* 
        Namn: Maria Vestlund
        Klass: NET23
        */

        

        static void Main(string[] args)
        {
            /*********************  FIRST SOLUTION  *********************/

            Random random = new Random(); //Initializes random number generator

            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");

            int number = random.Next(1, 20);//Generates a random number

            //Guessing-loop
            int i = 0;
            while (i < 5) //counts number of trials
            {
                int guess = Int32.Parse(Console.ReadLine()); //takes users guess
                string result = CheckGuess(number, guess); //starts CheckGuess method with var "number" and "guess"
                Console.WriteLine(result); //prints result
                if (result == "Wohoo! Du klarade det!") //if win = end loop
                {
                    break;
                }
                else
                {
                    i++;
                }
            }
            if (i == 5)
            {
                Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!"); //if too many tries done = end loop with this message
            }



            //Clears before second solution with extra challenges, after pressing enter
            Console.ReadLine();
            Console.Clear();



            /*********************  SECOND SOLUTION  *********************/

            //Adds possibility to change degree of difficulty
            Console.WriteLine("Nu får du välja svårighetsgrad själv");
            Console.WriteLine("Upp till vilket tal vill du kunna gissa på?");
            int x = Int32.Parse(Console.ReadLine());
            int changeableNumber = random.Next(1, x); //Gives a random number up to x, users chosen number

            Console.WriteLine("Hur många möjliga försök vill du ha?");
            int y = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får {y} försök.");

            //Guessing-loop
            int j = 0;
            while (j < y)
            {
                int guess = Int32.Parse(Console.ReadLine());
                int randomizeAnswer = random.Next(0, 4);
                string result = CheckGuessSecondSolution(changeableNumber, guess, randomizeAnswer);
                Console.WriteLine(result);
                if (result == "Wohoo! Du klarade det!")
                {
                    break;
                }
                else
                {
                    j++;
                }
            }
            if (j == y)
            {
                Console.WriteLine($"Tyvärr, du lyckades inte gissa talet på {y} försök!");
            }
        }

        static string CheckGuess(int number, int guess) //method to return answers to first solution
        {
            if (number > guess)
            {
                return "Tyvärr, du gissade för lågt!";
            }
            else if (number < guess)
            {
                return "Tyvärr, du gissade för högt!";
            }
            else
            {
                return "Wohoo! Du klarade det!";
            }
        }

        static string CheckGuessSecondSolution(int changeableNumber, int guess, int randomizeAnswer)//method to return answers to second solution
        {
            if (changeableNumber > guess)
            {
                string[] lowGuess = {"Tyvärr, du gissade för lågt!", "Attsicken, för låg gissning!", "Ops, fel. Gissa högre!", "Pyttsingen, för låg gissning!", "Hehe, du gissade för lågt!"};
            return lowGuess[randomizeAnswer];
        }
        else if (changeableNumber < guess)
        {
            string[] highGuess = { "Haha! Det var för högt!", "Bra gissat, men det var för högt!", "Tyvärr, du gissade för högt!", "Nämen, du gissade visst för högt!", "Ojdå, blev visst lite för hög gissning!" };
            return highGuess[randomizeAnswer];

            }
            else
            {
                return "Wohoo! Du klarade det!";
            }
        }
    }
}