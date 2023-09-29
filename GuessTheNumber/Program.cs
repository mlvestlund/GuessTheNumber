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
            int number = random.Next(1, 20);//Generates a random number

            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");

            //Guessing-loop
            int i = 0;
            while (i < 5) //counts number of trials
            {
                int guess = Int32.Parse(Console.ReadLine()); //takes users guess
                string result = CheckGuess(number, guess); //starts CheckGuess method with var "number" and "guess"
                Console.WriteLine(result); //prints result
                if (result == "Wohoo! Du klarade det!") //if win = end loop with message
                {
                    break;
                }
                else
                {
                    i++;
                }
            }
            if (i == 5) //Ends loop with message after maximum guesses
            {
                Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!"); 
            }


            //Before second solution with extra challenges this clears page after pressing enter
            Console.ReadLine();
            Console.Clear();


            /*********************  SECOND SOLUTION  *********************/

            //Adds possibility to change degree of difficulty
            Console.WriteLine("Nu får du välja svårighetsgrad själv");
            Console.WriteLine("Upp till vilket tal vill du kunna gissa på?");
            int x = Int32.Parse(Console.ReadLine());
            int targetNumber = random.Next(1, x); //Gives a random number up to x, users chosen number
            Console.WriteLine("Hur många möjliga försök vill du ha?");
            int y = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får {y} försök.");

            //Guessing-loop
            int j = 0;
            while (j < y)
            {
                int guess = Int32.Parse(Console.ReadLine());
                int answerRandomizer = random.Next(0, 4);
                string Answer = CheckGuessSecondSolution(targetNumber, guess, answerRandomizer);
                Console.WriteLine(Answer);
                if (Answer == "Wohoo! Du klarade det!")
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



        static string CheckGuessSecondSolution(int targetNumber, int guess, int answerRandomizer)
        {
            int difference = targetNumber - guess;
            if (Math.Abs(difference) < 3 && difference != 0)
            {
                string[] closeGuess = { "Såå nära!", "Det bränns!", "Nästan där", "Ojojojojoj, vad nära!", "Du tog den nästan!"};
                return closeGuess[answerRandomizer];
            }
            else if (Math.Abs(difference) >10)
            {
                string[] notCloseGuess = { "Låångt ifrån!", "Helt fel ute!", "Way off!", "Men gisses vad långt ifrån!", "Kan inte bli så mycket mer fel!" };
                return notCloseGuess[answerRandomizer];
            }
            else if (targetNumber > guess)
            {
                string[] lowGuess = { "Tyvärr, du gissade för lågt!", "Attsicken, för låg gissning!", "Ops, fel. Gissa högre!", "Pyttsingen, för lågt!", "Hehe, det vart visst för lågt!" };
                return lowGuess[answerRandomizer];
            }
            else if (targetNumber < guess)
            {
                string[] highGuess = { "Haha! Det var för högt!", "Bra gissat, men det var för högt!", "Tyvärr, du gissade för högt!", "Nämen, du gissade visst för högt!", "Ojdå, blev visst lite för högt!" };
                return highGuess[answerRandomizer];
            }
            else
            {
                return "Wohoo! Du klarade det!";
            }
        }
    }
}