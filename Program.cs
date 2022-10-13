using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSParser
{
    enum TokenEnum
    {
        NUMBER,
        PUNCTUATION,
        OPERATOR,
    }
    struct Token
    {
        public TokenEnum tokenType;
        public string value;

        public Token(TokenEnum tokenType, string value)
        {
            this.tokenType = tokenType;
            this.value = value;
        }

        public override string ToString()
        {
            return $"<{this.tokenType}: {this.value}>";
        }
    }
    class Parser
    {
        public static List<Token> Lex(string charStream)
        {
            List<Token> tokens = new List<Token>();
            for (int i = 0; i < charStream.Length; i++)
            {
                char c = charStream[i];

                if (c == ' ' || c == '\n') continue;
                else if (Regex.Match(c.ToString(), @"\+|-|\*|\/").Success)
                {
                    tokens.Add(new Token(TokenEnum.OPERATOR, c.ToString()));
                }
                else if (Regex.Match(c.ToString(), @"[0-9]").Success)
                {
                    string number = "";
                    while (Regex.Match(c.ToString(), @"[0-9]").Success && i < charStream.Length)
                    {
                        number += c;
                        i++;
                        if (i >= charStream.Length) break;
                        c = charStream[i];
                    }
                    tokens.Add(new Token(TokenEnum.NUMBER, number));
                    i--; // Subtract the indexer because that means the last lookAhead failed, so put the indexer back
                }
                else if (Regex.Match(c.ToString(), @"\(|\)").Success)
                {
                    tokens.Add(new Token(TokenEnum.PUNCTUATION, c.ToString()));
                }
            }
            return tokens;
        }

        public static void PrintTokens(List<Token> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                Console.WriteLine(tokens[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("== Parser in C# by Taleon, Elizalde, Rubinos ==");
            List<Token> tokens = Parser.Lex("(3 + 4) - 500");
            Parser.PrintTokens(tokens);
        }
    }
}