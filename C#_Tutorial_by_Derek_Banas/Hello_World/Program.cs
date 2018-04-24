using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
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

			Console.WriteLine("Hello World");
			Console.Write("What is your name ");
			string name = Console.ReadLine();//Read in input from the command line
			Console.WriteLine("Hello " + name);//Say hello to the user
		}
	}
}