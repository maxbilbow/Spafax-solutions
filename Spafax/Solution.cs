using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Spafax.CodingTest.Business {
	public class Solution {


		/// <summary>
		/// Create a function which counts the number of occurrences of a given letter in a string.
		///'e' and "I have some cheese"
		///	Output:
		///		5
		/// </summary>
		public int CountInString(string input, char c) {
			return Regex.Matches (input, c.ToString(), RegexOptions.IgnoreCase).Count;
		}

		public int CountInString(string input, string pattern) {
			return Regex.Matches (input, pattern, RegexOptions.IgnoreCase).Count;
		}

		/// <summary>
		/// Create a function which decides if a string is a palindrome.
		/// </summary>
		public bool isPalendrome(string text) {
			var formatted = Regex.Replace(text, @"\W", "").ToLower();
			var result = "";
			for (int i = formatted.Length-1; i>=0; --i)
				result += formatted [i];
			return result.ToLower() == formatted;
		}

		/// <summary>
		///	Task 3
		///	
		///		Part A)
		///			
		///			Create a function which counts the number of occurrences of words from a "censored words list" in a text.
		///			
		///			Example:
		///			
		///			Input:
		///			
		///	{"dog", "cat", "large"} and "I have a cat named Meow and a dog name Woof. I love the dog a lot. He is larger than a small horse."
		///		Output:
		///			cat: 1, dog: 2, large: 1, total: 4
		///
		/// </summary>
		/// <returns>The word count.</returns>
		/// <param name="text">Text.</param>
		/// <param name="words">Words.</param>
		/// <param name="matchSubstring">set false to avoid censoring words within words (e.g. "A school in Scunthorpe couldn't access their own website for weeks.</param>
		public WordCount GetWordCount(string text, string []words, bool matchSubstring = true) {
			WordCount wordCount = new WordCount();
			text = " " + text.ToLower ();
			foreach (string word in words) {
				string pattern = matchSubstring? word : @"\W" + word;
				wordCount.Add(word,CountInString (text, pattern));
			}
			return wordCount;
		}

		///
		/// Helper class created for counding words.
		///
		public class WordCount : Dictionary<string,int> {
			public override string ToString ()
			{
				string result = "";
				foreach (KeyValuePair<string,int> pair in this)
					result += pair.Key + ": " + pair.Value + ", ";
				return result.TrimEnd(new char[]{',',' '}) + ". Total: " + Total;
			}

			public int Total {
				get {
					int result = 0;
					foreach (int i in Values) 
						result += i;
					return result;
				}
			}
		}

		
		/// <summary>
		/// Censors the text.
		///	Part B)
		///		
		///		Create a way to censor words featured in the "censored words list" that appear in the text.
		///			
		///			Example:
		///			
		///			Input:
		///			
		///	{"moew", "woof"} and "I have a cat named Meow and a dog name Woof. I love the dog a lot. He is larger than a small horse."
		///		Output:
		///			"I have a cat named M$$w and a dog name W$$f. I love the dog a lot. He is larger than a small horse."
		///	
		/// </summary>
		/// <returns>The text.</returns>
		/// <param name="text">Text.</param>
		/// <param name="words">Words.</param>
		/// <param name="matchSubstring">If set to <c>true</c> match substring.</param>
		public string CensorText( string text, bool matchSubstring = true, params string []words) 
		{
			text = " " + text;
			foreach (string word in words) {
	//			Regex regex = new Regex(text, RegexOptions.IgnoreCase);

				string censor = Regex.Replace (word.Substring (1, word.Length - 2), @"[0-9a-z_^"+word+"]", "$$$",RegexOptions.IgnoreCase);
				string replacement = word [0] + censor + word [word.Length - 1];
				if (!matchSubstring)
					replacement = " " + replacement;
				string pattern = matchSubstring ? word : @"\W" + word + "";
	//			Console.Out.WriteLine (pattern + ":" + replacement);                                      
				text = Regex.Replace(text,pattern,replacement,RegexOptions.IgnoreCase);
			
	//			Console.Out.WriteLine(text);
			}
			return text.Substring (1);
		}


		/// <summary>
		/// Censors the palindrome.
		///	Part C)
		///			
		///			Create a way to censor a single word palindrome in a text.
		///			
		///			Example:
		///			
		///			Input:
		///			
		///			"Anna went to vote in the election to fulfil her civic duty"
		///			Output:
		///			"A$$a went to vote in the election to fulfil her c$$$c duty"
		/// </summary>
		/// <returns>The input with palendromes censored.</returns>
		/// <param name="text">Text.</param>
		/// <param name="matchSubstring">If set to <c>true</c> match substring.</param>
		public string CensorPalindrome(string text, bool matchSubstring = false) {
			string[] words = Regex.Split (text, @"\W");

			foreach (String word in words) {
				if (isPalendrome(word)) {
					text = CensorText(text, matchSubstring ,word);
				}
			}

			return text;
		}
			
	
	}
}