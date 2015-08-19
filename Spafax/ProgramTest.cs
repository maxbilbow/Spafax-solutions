using System;
using Spafax.CodingTest.Business;

namespace Spafax.CodingTest.Tests
{
	public class ProgramTest
	{
		
		Solution program;
	
		public ProgramTest() {
			SetupBeforeTests ();
		}
		public void SetupBeforeTests() {
			program = new Solution ();
		}
		
		public void Task1Test() {
			//Task 1 test
			Console.Out.WriteLine("TASK 1");
			Console.Out.WriteLine ("'e' and \"I have some cheese\": " + program.CountInString("I have some cheese",'e'));
		}
		
		public void Task2Test() {
			//Task 2 test
			Console.Out.WriteLine("\nTASK 2");
			Console.Out.WriteLine ("\"I have some cheese\" is palendrome? " + program.isPalendrome("I have some cheese"));
			Console.Out.WriteLine ("\"God saved Eva’s dog\" is palendrome? " + program.isPalendrome("God saved Eva’s dog"));
		}
		
		public void Task3Test(char part) {
			string input = "I have a cat named Meow and a dog name Woof. I love the dog a lot. He is larger than a small horse.";
			string[] args = new string[] {"dog", "cat", "large"};
			switch (part) {
			case 'a':
				//Task 3a test
				Console.Out.WriteLine("\nTASK 3a");
				String result = program.GetWordCount (input, args).ToString ();
				Console.Out.WriteLine ("{\"dog\", \"cat\", \"large\"} and " + input + "\nReturns: " + result);
				break;
			case 'b':
				//Task 3b test
				Console.Out.WriteLine("\nTASK 3b");
				input = "I have a cat named Meow and a dog name Woof. I love the dog a lot. He is larger than a small horse.";
				string [] words = {"Meow", "Woof"};
				Console.Out.WriteLine(program.CensorText(input, true, words));
				break;
			case 'c':
				Console.Out.WriteLine("\nTASK 3c");
				input = "Anna went to vote in the election to fulfil her civic duty";
				
				Console.Out.WriteLine(program.CensorPalindrome(input));
				break;
			default:
				if (Char.IsUpper(part))
					Task3Test(Char.ToLower(part));
				else 
					Console.Out.WriteLine("ERROR: Option not recognised");
				break;
			}
			
		}
	}
}