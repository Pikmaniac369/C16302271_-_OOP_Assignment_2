using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Single Line Comment

            /*
			Multi
			Line
			Comment
			*/








            //HELLO WORLD:
            //-----------------------------------------------------------------------------
            Console.WriteLine("Hello World");
            Console.Write("What is your name ");
            string name = Console.ReadLine();//Read in input from the command line
            Console.WriteLine("Hello " + name);//Say hello to the user










            //DATA TYPES
            //-----------------------------------------------------------------------------
            //Boolean: True or False
            bool canVote = true;

            //Character: A single 16-bit character
            char grade = 'A';

            //Integer with a max number of 2,147,483,647
            int maxInt = int.MaxValue;

            //Long with a max number of 9,223,372,036,854,775,807
            long maxLong = long.MaxValue;

            //Decimal has a maximum value of 79,228,162,514,264,337,593,543,950,335
            //If you need something bigger look up BigInteger
            decimal maxDec = decimal.MaxValue;

            //A float is a 32 bit number with a maxValue of 3.402823E+38 with 7 decimals of precision
            float maxFloat = float.MaxValue;

            //A double is a 32 bit number with a maxValue of 1.797693134E+308 with 15 decimals of precision
            double maxDouble = double.MaxValue;

            Console.WriteLine("Max Int: " + maxInt);

            var anotherName = "Tom";
            //Will cause an error as var has already been inferred to be a string, not an integer:
            //anotherName = 2;

            //Display anotherName's type
            Console.WriteLine("anotherName is a {0}", anotherName.GetTypeCode());//{0} is replaced with anotherName's type









            //MATHEMATICAL OPERATIONS:
            //-----------------------------------------------------------------------------
            Console.WriteLine("5 + 3 = " + (5 + 3));
            Console.WriteLine("5 - 3 = " + (5 - 3));
            Console.WriteLine("5 * 3 = " + (5 * 3));
            Console.WriteLine("5 / 3 = " + (5 / 3));
            Console.WriteLine("5.2 % 3 = " + (5.2 % 3));

            int i = 0;

            Console.WriteLine("i++ = " + (i++));//Increment i AFTER it is used
            Console.WriteLine("++i = " + (++i));//Increment i BEFORE it is used
            Console.WriteLine("i-- = " + (i--));//Decrement i AFTER it is used
            Console.WriteLine("--i = " + (--i));//Decrement i BEFORE it is used

            Console.WriteLine("i += 3: " + (i += 3));// i = i + 3
            Console.WriteLine("i -= 2: " + (i -= 2));// i = i - 2
            Console.WriteLine("i *= 2: " + (i *= 2));// i = i * 2
            Console.WriteLine("i /= 2: " + (i /= 2));// i = i / 2
            Console.WriteLine("i %= 2: " + (i %= 2));// i = i % 2









            //CASTING:
            //-------------------------------------------------------------------------------
            double pi = 3.14;
            int intPi = (int)pi;









            //IN-BUILT MATHS FUNCTIONS:
            //---------------------------------------------------------------------------------------
            //Acos
            //Asin
            //Atan
            //Atan2
            //Cos
            //Cosh
            //Exp
            //Log
            //Sin
            //Sinh
            //Tan
            //Tanh

            double number1 = 10.5;
            double number2 = 15;

            Console.WriteLine("Math.Abs(number1): " + (Math.Abs(number1)) );
            Console.WriteLine("Math.Ceiling(number1): " + (Math.Ceiling(number1)) );//Round up
            Console.WriteLine("Math.Floor(number1): " + (Math.Floor(number1)) );//Round down
            Console.WriteLine("Math.Max(number1, number2): " + (Math.Max(number1, number2)) );//The greater of the two
            Console.WriteLine("Math.Min(number1, number2): " + (Math.Min(number1, number2)) );//The lesser of the two
            Console.WriteLine("Math.Pow(number1, 2): " + (Math.Pow(number1, 2)) );//number1 to the power of 2
            Console.WriteLine("Math.Round(number1): " + (Math.Round(number1)) );//Round the number
            Console.WriteLine("Math.Sqrt(number1): " + (Math.Sqrt(number1)) );//Find the sqare root

            //Generate a random number between 1 and 10
            Random rand = new Random();
            Console.WriteLine("Random Number between 1 and 10: " + (rand.Next(1, 11)));









            //CONDITIONALS:
            //------------------------------------------------------------------------------

            //Relational Operators: > < <= >= == !=
            //Logical Operators: && || ^ !

            int age = 17;

            if( (age >= 5) && (age <= 7) )
            {
                Console.WriteLine("Go to elementary school");
            }
            else if( (age > 7) && (age < 13) )
            {
                Console.WriteLine("Go to middle school");
            }
            else
            {
                Console.WriteLine("Go to high school");
            }

            if( (age < 14) || (age > 67) )
            {
                Console.WriteLine("You're not allowed to work. You're either too young or too old!");
            }

            Console.WriteLine("!true = " + (!true));

            bool canDrive = age >= 16 ? true : false;

            switch(age)
            {
                case 0:
                    Console.WriteLine("Infant");
                    break;

                case 1:
                case 2:
                    Console.WriteLine("Toddler");
                    //goto Cute;
                    break;

                default:
                    Console.WriteLine("Child");
                    break;
            }

            /*
                Cute:
                Console.WriteLine("Toddlers are Cute");
            */









            //LOOPING:
            //----------------------------------------------------------------------------------
            int j = 0;

            while(j < 10)
            {
                if(j == 7)
                {
                    j++;
                    continue;//Skip everything after the if statement and return to beginning of loop
                }

                if(j == 9)
                {
                    break;//Leave the while loop. No more checking.
                }

                //If j is an odd number
                if( (j % 2) > 0)
                {
                    Console.WriteLine(j);
                }

                j++;
            }

            string guess;

            do
            {
                Console.WriteLine("Guess a Number: ");
                guess = Console.ReadLine();
            }
            while(!guess.Equals("15"));


            for(int k = 0; k < 10; k++)
            {
                if((k % 2) > 0)
                {
                    Console.WriteLine(k);
                }
            }

            string randStr = "Here are some random characters";
            //For each character in randStr
            foreach(char c in randStr)
            {
                Console.WriteLine(c);
            }









            //STRINGS:
            //---------------------------------------------------------------------------------
            //Within a string:
            // \' to get '
            // \" to get "
            // \\ to get \
            // \b to go back one space
            // \n to get a new line
            // \t to get a tab

            string sampString = "A bunch of random words";
            string sampString2 = "More random words";

            Console.WriteLine("Is empty: " + String.IsNullOrEmpty(sampString) );//Is it empty?
            Console.WriteLine("Is empty: " + String.IsNullOrWhiteSpace(sampString) );//Is it just whitespace?
            Console.WriteLine("String Length: " + sampString.Length);//Length of the string
            Console.WriteLine("Index of \'bunch\': " + sampString.IndexOf("bunch") );//Index of 'bunch'
            Console.WriteLine("2nd Word: " + sampString.Substring(2, 6) );

            Console.WriteLine("Strings Equal: " + sampString.Equals(sampString2) );//Are the strings equal?
            Console.WriteLine("Starts with \"A bunch\": " + sampString.StartsWith("A bunch") );
            Console.WriteLine("Ends with \"words\": " + sampString.EndsWith("words") );

            sampString = sampString.Trim();//Removes excess whitespace from beginning and end
            //sampString.TrimEnd() removes excess whitespace from the end
            //sampString.TrimStart() removes excess whitespace from the beginning

            sampString = sampString.Replace("words", "characters");//Replaces all instances of "words" with "characters"

            sampString = sampString.Remove(0, 2);//Removes two characters starting at index 0

            string[] names = new string[3] {"Matt", "Joe", "Paul" };//How to create and initialise a string array

            Console.WriteLine("Name List: " + String.Join(", ", names) );//Joins the elements of the array together in a single string with ", " between each

            string fmtStr = String.Format("{0:c} {1:00.00} {2:#.00} {3:0,0}", 1.56, 15.567, .56, 1000);

            Console.WriteLine(fmtStr);









            //STRING BUILDER:
            //------------------------------------------------------------------------------------

            //Can be edited, i.e. can be added to easily
            StringBuilder sb = new StringBuilder();

            sb.Append("This is the first sentence. ");
            sb.AppendFormat("My name is {0} and I live in {1}.", "Adam", "Navan");
            //sb.Clear();//Empty the StringBuilder

            sb.Replace("a", "e");//Replace every instance of the letter "a" with the letter "e"

            sb.Remove(5, 7);// Remove 7 characters, beginning at index 5

            Console.WriteLine(sb.ToString());//Needs to be converted to a String to be displayed









            //ARRAYS:
            //--------------------------------------------------------------------------------------
            int[] randNumArray;//Declare an array

            int[] randArray = new int[5];//Declare an array and its size

            int[] randArray2 = {1, 2, 3, 4, 5};//Declare and initialise an array. Do not put 'new'. Automatically allocates space based on number of elements.

            Console.WriteLine("Array Length: " + randArray2.Length);

            Console.WriteLine("Item 0: " + randArray2[0]);

            for(int l = 0; l < randArray2.Length; l++)
            {
                Console.WriteLine("Item {0}: {1}", l, randArray2[l]);
            }

            foreach(int num in randArray2)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("Where is 1: " + Array.IndexOf(randArray2, 1) );//Find the index of 1

            string[] names2 = {"Tom", "Paul", "Sally"};

            string nameStr = string.Join(", ", names2);

            string[] nameArray = nameStr.Split(',');

            int[,] multArray = new int[5, 3];//Declare a 2D array

            int[,] multArray2 = { {0, 1}, {2, 3}, {4, 5} };//Declare and initialise a 2D array

            foreach(int num in multArray2)
            {
                Console.WriteLine(num);
            }

            for(int x = 0; x < multArray2.GetLength(0); x++)
            {
                for(int y = 0; y < multArray2.GetLength(1); y++)
                {
                    Console.WriteLine("{0} | {1} : {2}", x, y, multArray2[x, y] );
                }
            }









            //LISTS:
            //---------------------------------------------------------------------------------

            //Like an array but can resize itself depending on the number of elements it contains
            List<int> numList = new List<int>();//Declaring a List

            //Can add values to the List without having to worry about the List's size as it'll change
            numList.Add(5);
            numList.Add(15);
            numList.Add(25);

            //Adding an array to a List
            int[] randArray3 = {1, 2, 3, 4, 5};//Must be the same data type as the List
            numList.AddRange(randArray3);//Use AddRange() for adding arrays instead of just Add()

            //Clearing a List
            //numList.Clear();

            //Copying an array into a List
            List<int> numList2 = new List<int>(randArray3);

            //Copying a new array into a List
            List<int> numList3 = new List<int>(new int[] {1, 2, 3, 4});

            numList.Insert(1, 10);//Inserts 10 into index 1 of the List

            numList.Remove(5);//Remove 5 from the List. Don't know where it is. Removal by name.

            numList.RemoveAt(2);//Remove whatever is located at index 2 of the List

            //Use Count to get the length of the List, not Length
            for(int m = 0; m < numList.Count; m++)
            {
                Console.WriteLine(numList[m]);
            }

            //Find the index of a value
            //Returns -1 if it doesn't find anything
            Console.WriteLine("4 is in index: " + numList3.IndexOf(4));

            //Check to see if the List contains a value
            Console.WriteLine("5 in List: " + numList.Contains(5) );

            //You can also search for values in a String List
            List<string> strList = new List<string>(new string[] {"Tom", "Paul"});

            Console.WriteLine("Tom in List: " + strList.Contains("Tom") );
            //Ignoring case:
            Console.WriteLine("Tom in List: " + strList.Contains("tom", StringComparer.OrdinalIgnoreCase) );

            //Sort the List alphabetically or numerically (depends on List type)
            strList.Sort();









            //EXCEPTION HANDLING:
            //--------------------------------------------------------------------------------------
            //Divide by 0 exception:
            try
            {
                Console.Write("Divide 10 by ");
                int num = int.Parse(Console.ReadLine());//Converts a String into an Integer
                Console.WriteLine("10 / {0} = {1}", num, (10 / num));
            }
            catch (DivideByZeroException ex)
            {
                //Specifically catches a Divide-By-Zero Exception

                Console.WriteLine("Can't divide by zero");
                Console.WriteLine(ex.GetType().Name);//Get the name of the exception that was triggered
                Console.WriteLine(ex.Message);//Display the exceptions error message
            }
            catch (Exception ex)
            {
                //Catches any exception

                Console.WriteLine(ex.GetType().Name);//Get the name of the exception that was triggered
                Console.WriteLine(ex.Message);//Display the exceptions error message
            }














            //Stops the command line window from closing immediately
            //Equivalent of C's getchar() function
            Console.ReadKey();
        }
    }
}
