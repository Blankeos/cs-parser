using System;
using System.IO;
using System.Collections.Generic;

namespace CSParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("== Parser in C# by Taleon, Elizalde, Rubinos ==");

            const string FILE_PATH = "./input.carlo";
            if (!File.Exists(FILE_PATH)) return;

            string[] lines = File.ReadAllLines(FILE_PATH);

            List<Token> tokens = Lexer.LexLines(lines);
            Console.WriteLine($"Lexed ({tokens.Count}) tokens");
            Lexer.PrintTokens(tokens);
        }
    }
}