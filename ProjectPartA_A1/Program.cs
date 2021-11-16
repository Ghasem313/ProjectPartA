using System;

namespace ProjectPartA_A1
{
    class Program
    {
        struct Article
        {
            public string Name;
            public decimal Price;
        }
        public static bool stringParse;

        const int _maxNrArticles = 10;
        const int _maxArticleNameLength = 20;
        const decimal _vat = 0.25M;

        static Article[] articles = new Article[_maxNrArticles];
        static int nrArticles;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Welcome to projecet A Part A");
            Console.WriteLine("Lest's print a recept!");




            ReadArticles();
            PrintReciept();


        }      
        private static void ReadArticles()
        {
            //Your code to enter the articles
            bool result = true;


            while (result)
            {
                Console.WriteLine("How many articels do you want(between 1 and 10)?");
                stringParse = int.TryParse(Console.ReadLine(), out nrArticles);

                if (stringParse)
                {

                    if (nrArticles >= 1 && nrArticles <= 10)
                    {
                        result = false;
                    }
                    else
                    {
                        Console.WriteLine("The number is not between 1 and 10!");
                    }
                }
                else 
                {

                    Console.WriteLine("Wrong input, pls try again!");
                }
            }

            for (int i = 0; i < nrArticles; i++)
            {
                result = true;

                while (result)
                {
                    Console.WriteLine($"Please enter name and price for article #{i + 1} in the format name; price(example Beer; 2,25)");

                    string myArticle = Console.ReadLine();
                    
                    if (myArticle.Contains(";"))
                    {
                        var mySplit = myArticle.Split(";");
                        bool IsADecimal = decimal.TryParse(mySplit[1], out decimal validPrice);
                        if (!IsADecimal)
                        {
                            Console.WriteLine("Price error");
                            result = false;
                        }

                        if (IsADecimal)
                            
                            //if (decimal.TryParse(mySplit[1], out decimal validPrice))
                        {
                            if(mySplit[0].Length != 0 && mySplit[0].Length<= _maxNrArticles)
                            {
                                articles[i] = new Article
                                {
                                    Name = mySplit[0],
                                    Price = validPrice
                                };
                                result = false;

                            }
                            else
                            {
                                Console.WriteLine("Name error! Try again!");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Number error, please try again!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The input is not contain ';' charecter, try again!");
                    }
                }


            }

        }
        private static void PrintReciept()
        {
            Console.WriteLine();
            //Your code to print out a reciept
            Console.WriteLine("Recipt Purchased articles");
            Console.WriteLine($"Purchase date: {DateTime.Now}");

            Console.WriteLine();
            Console.WriteLine($"Number of item purchased: {nrArticles}");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("{0,-5} {1,-30} {2,-30:C2}", "#", "Name", "Price");

            decimal totalPrice = 0;
            for (int i = 0; i < nrArticles; i++)
            {


                Console.WriteLine("{0,-5} {1,-30} {2,-30:C2}",i, articles[i].Name, articles[i].Price);
                totalPrice += articles[i].Price;
            }

            Console.WriteLine();

            Console.WriteLine("{0,-36} {1,-15}", "Total purchase", $"{totalPrice:c}");
            Console.WriteLine("{0,-36} {1,-15}", "Includes VAT (25%):", $"{ _vat:c}");

        }
    }
}
