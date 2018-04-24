using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//DELEGATES:
//-----------------------------------------------
delegate double GetSum(double num1, double num2);




namespace ConsoleApp2
{
    //STRUCTS:
    //---------------------------------------------
    struct Customers
    {
        private string name;
        private double balance;
        private int id;

        public void createCust(string n, double b, int i)
        {
            name = n;
            balance = b;
            id = i;
        }

        public void showCust()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Balance: " + balance);//("Balance: {0:c}", balance); formats it as a currency
            Console.WriteLine("ID: " + id);
        }
    }
    
    
    

    //ENUMERATED TYPES(ENUMs):
    //---------------------------------------------
    public enum Temperature
    {
        Freeze,
        Low,
        Warm,
        Boil
    }


    class Animal
    {
        //public: access not limited
        //protected: access limited to specific class methods, i.e. methods inside of class, and sub-class methods
        //private: access limited to this class's methods

        //Using C#'s built-in getters and setters
        public double height { get; set; }
        public double weight { get; set; }
        public string sound { get; set; }

        //Making your own getters and setters
        //value MUST be used as it's the default for setting the items in C#
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        //Make a constructor. Default one will be made if you don't make one yourself
        //Default constructor that doesn't receive values
        public Animal()
        {
            //Initialise the properties/fields
            this.height = 0;
            this.weight = 0;
            this.name = "No Name";
            this.sound = "No Sound";
            numOfAnimals++;
        }

        //Constructor that sets the variables
        public Animal(double height, double weight, string name, string sound)
        {
            //Initialise the properties/fields
            this.height = height;
            this.weight = weight;
            this.name = name;
            this.sound = sound;
            numOfAnimals++;
        }

        static int numOfAnimals = 0;//Used to keep track of the total number of Animal objects

        //Static classes cannot access non-static class members
        //getNumOfAnimals cannot access height,weight,name and sound as they aren't static
        //It CAN access numOfAnimals as it IS static

        public static int getNumOfAnimals()
        {

            return numOfAnimals;
        }

        public string toString()
        {
            return String.Format("{0} is {1} inches tall, weighs {2} lbs and likes to say {3}", name, height, weight, sound);
        }

        //METHOD OVERLOADING:
        //----------------------------
        public int getSum(int num1 = 1, int num2 = 1)
        {
            return num1 + num2;
        }

        //double num1 and int num2 would also work
        public double getSum(double num1 = 1, double num2 = 1)
        {
            return num1 + num2;
        }






        static void Main(string[] args)
        {
            //Create a new Animal object
            Animal spot = new Animal(15, 10, "Spot", "Woof");

            //Print info about the Animal object
            Console.WriteLine("{0} says {1}", spot.name, spot.sound);

            //Get the number of Animal objects. You need the class name for static methods
            //as they belong to the class itself, not the objects
            Console.WriteLine("Number of Animals = " + Animal.getNumOfAnimals());

            //Print the Animal object's information
            Console.WriteLine(spot.toString());






            //METHOD OVERLOADING:
            //-------------------------
            Console.WriteLine(spot.getSum(1, 2));//The integer version
            Console.WriteLine(spot.getSum(1.4, 2.7));//The double version
            Console.WriteLine(spot.getSum(num2: 2.7, num1: 1.4));//The different-order version

            //Create a new Animal object using the Object Initialiser:
            Animal grover = new Animal
            {
                name = "Grover",
                height = 16,
                weight = 18,
                sound = "Grrrr"
            };

            //The total number of Animals has increased
            Console.WriteLine("Number of Animals = " + Animal.getNumOfAnimals());

            Dog spike = new Dog();

            Console.WriteLine(spike.toString());//Display the default initialised Dog Object spike

            //Overwrite spike's information
            spike = new Dog(20, 15, "Spike", "Grr", "Chicken");

            Console.WriteLine(spike.toString());//Display the overwritten Dog Object spike








            //POLYMORPHISM USING ABSTRACT CLASSES:
            //----------------------------------------------------------------------------------------------------------
            //Both Shapes but one is a Rectangle and the other a Triangle
            //Since both are Shapes, they can go into Shape arrays despite technically being different classes
            Shape rect = new Rectangle(5, 5);
            Shape tri = new Triangle(5, 5);

            //Polymorphism makes it so that the correct area() method is called for each
            Console.WriteLine("Area of rect = " + (rect.area()) );
            Console.WriteLine("Area of tri = " + (tri.area()) );

            //The following will work thanks to the Operator Overloading done in the Rectangle class
            Rectangle combRect = new Rectangle(5, 5) + new Rectangle(5, 5);

            //Display combRect's area
            Console.WriteLine("Area of combRect = " + (combRect.area()) );







            //GENERICS CONTINUED:
            //-----------------------------------------------------
            KeyValue<string, string> superman = new KeyValue<string, string>("", "");

            superman.key = "Superman";
            superman.value = "Clark Kent";

            KeyValue<int, string> samsungTV = new KeyValue<int, string>(0, "");

            samsungTV.key = 12345;
            samsungTV.value = "a 50-inch Samsung TV";

            superman.showData();
            samsungTV.showData();





            //ENUMERATED TYPES(ENUMs) CONTINUED:
            //---------------------------------------------------
            Temperature micTemp = Temperature.Warm;

            switch(micTemp)
            {
                case Temperature.Freeze:
                    Console.WriteLine("Temp on Freezing");
                    break;

                case Temperature.Low:
                    Console.WriteLine("Temp on Low");
                    break;

                case Temperature.Warm:
                    Console.WriteLine("Temp on Warm");
                    break;

                case Temperature.Boil:
                    Console.WriteLine("Temperature on Boil");
                    break;
            }









            //STRUCTS CONTINUED:
            //------------------------------------------------------------------------
            Customers bob = new Customers();

            bob.createCust("Bob", 15.50, 12345);

            bob.showCust();









            //DELEGATES CONTINUED:
            //------------------------------------------------------------------------
            //An anonymus method has no name and it's return type is defined by the return used in the method
            GetSum sum = delegate (double num1, double num2)
            {
                return num1 + num2;
            };

            Console.WriteLine("5 + 10 = " + sum(5, 10) );

            //Lamda expressions: Used to act as an anonymus function or an expression trait
            //Can assign the Lamda expression to a function instance
            Func<int, int, int> getSum = (x, y) => x + y;

            Console.WriteLine("5 + 3 = " + getSum.Invoke(5, 3) );

            //They're often used with lists:
            List<int> numList = new List<int> { 5, 10, 15, 20, 25};

            List<int> oddNums = numList.Where(n => n % 2 == 1).ToList();//Place all odd numbers in the oddNums List

            foreach(int num in oddNums)
            {
                Console.WriteLine(num + ", ");
            }









            //FILE I/O:
            //-----------------------------------------------------------------------------------------------
            string[] custs = new string[] { "Tom", "Paul", "Greg"};

            //Create custs.txt if it doesn't exist and write to it:
            //HAD TO MAKE CustomerStorage FOLDER MYSELF!!!!!!!
            using (StreamWriter sw = new StreamWriter("CustomerStorage/custs.txt"))
            {
                foreach(string cust in custs)
                {
                    Console.WriteLine("Adding {0} to the file", cust);
                    sw.WriteLine(cust);
                }
            }

            //Read the contents of custs.txt until you reach the end:
            string custName = "";
            //HAD TO MAKE CustomerStorage FOLDER MYSELF!!!!!!!
            using (StreamReader sr = new StreamReader("CustomerStorage/custs.txt"))
            {
                while( (custName = sr.ReadLine()) != null)
                {
                    Console.WriteLine(custName);//Display the contents of custs.txt
                }
            }






            //Used to keep the window open. C#'s version of C's getchar()
            Console.ReadKey();
        }
    }







    //Create a sub-class of Animal
    class Dog : Animal
    {
        //Attributes only Dog objects will have
        public string favFood { get; set; }

        //Custom constructor for Dog. base() causes the superclass's constructor to execute as well
        public Dog() : base()
        {
            this.favFood = "No Favourite Food";
        }

        public Dog(double height, double weight, string name, string sound, string favFood) : base(height, weight, name, sound)
        {
            this.favFood = favFood;
        }

        //Override toString()
        new public string toString()
        {
            return String.Format("{0} is {1} inches tall, weighs {2} lbs, likes to say {3} and eats {4}", name, height, weight, sound, favFood);
        }
    }







    //ABSTRACT CLASSES AND INTERFACES:
    //------------------------------------------------

    //You can only inherit one abstract class per class, but you can inherit multiple interfaces per class
    //You CANNOT instantiate or create an object from an abstract class

    abstract class Shape
    {
        //Abstract method(must be implemented in the class that inherits the abstract class)
        public abstract double area();

        //Method that does something
        //Can't be used with interfaces. Interfaces can only have abstract methods
        public void sayHi()
        {
            Console.WriteLine("Hello");
        }
    }

    public interface ShapeItem
    {
        //Every method in an interface is already abstract, so no need for 'abstract' keyword
        //Must be implemented in the class that inherits the interface
        double area();
    }

    class Rectangle : Shape
    {
        private double length;
        private double width;

        //Constructor
        public Rectangle(double num1, double num2)
        {
            length = num1;
            width = num2;
        }

        //Must implement area() as it's inherited from Shape
        public override double area()
        {
            return length * width;
        }


        //OPERATOR OVERLOADING:
        //--------------------------------------------
        //Static class that returns a Rectangle and overloads the + symbol
        //Makes it so that the following happens when you '+' two Rectangle Objects
        public static Rectangle operator+(Rectangle rect1, Rectangle rect2)
        {
            double rectLength = rect1.length + rect2.length;
            double rectWidth = rect1.width + rect2.width;

            return new Rectangle(rectLength, rectWidth);
        }

    }







    class Triangle : Shape
    {
        private double theBase;//Would call it base but it's a keyword in C# so can't be done
        private double height;

        public Triangle(double num1, double num2)
        {
            theBase = num1;
            height = num2;
        }

        public override double area()
        {
            return (theBase * height) / 2;
        }
    }






    //GENERICS:
    //---------------------------------------------
    class KeyValue<TKey, TValue>
    {
        public TKey key { get; set; }
        public TValue value { get; set; }

        public KeyValue(TKey k, TValue v)
        {
            key = k;
            value = v;
        }

        public void showData()
        {
            Console.WriteLine("{0} is {1}", this.key, this.value);
        }
    }







}
