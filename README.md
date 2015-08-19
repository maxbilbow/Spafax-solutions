# Spafax-solutions
Spafax.codingtest

To present the censored word count, you could:
 * keep a private WordCount object (see Solution.WordCount); field in the class and increment the count as each word is censored.
   this could be accessed through a standard getter method: GetCountForWord(string word) or readonly variable: 
   ```C#
   public int Total 
   { 
      get { 
         return WordCount.Total;
      }
   } 
   ```
 * If the application needs to know when the count is updated using a Key-Value Observer pattern would be efficient, allowing future applications to register for changes to the count of any or all words
 * A visitor patten, where the program broadcasts a message to a "NotificationCenter" class who then sends the message to any objects who which to be notified about it.
