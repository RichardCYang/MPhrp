
using Internal;
using System;
using System.IO;

namespace MPhrpLib {
    public class Program{
        internal static void Main( string[] args ){
            CSVParser   csvParser = new CSVParser();
            DataFrame   frame     = csvParser.ParseFromFile("test.csv");
            //File.WriteAllText( "exm.txt",frame.ToString() );
            Console.WriteLine(frame);
            Console.WriteLine(frame.Shape);
        }
    }
}