using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spafax.CodingTest.Tests;

public class Program {

    public static void Main(string[] args)
    {
		var p = new ProgramTest ();
		p.Task1Test ();
		p.Task2Test ();
		p.Task3Test ('a');
		p.Task3Test ('b');
		p.Task3Test ('c');
    }
}
