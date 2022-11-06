using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSParser
{
    class Lexer
    {
        // For multiple lines
        public static List<Token> LexLines(string[] inputLines)
        {
            List<Token> tokens = new List<Token>();

            foreach (string charStream in inputLines)
            {
                tokens.Concat(LexString(charStream));
            }

            return tokens;
        }

        // For one line/string
        public static List<Token> LexString(string charStream)
        {

            List<Token> tokens = new List<Token>();

            // Check if comment == %, returns an empty token list
            if (charStream[0] == '%') return tokens;

            // Start searching if line is not a comment
            for (int i = 0; i < charStream.Length; i++)
            {
                char c = charStream[i];

                // Find 'create'
                if (c == '%')
                {
                    // i = 
                }
                if (c == 'c')
                {
                    if (LookAheadKeywordIsMatched("create", i, charStream))
                    {
                        tokens.Add(new Token(TokenType.CREATE, "create"));
                    }
                }
            }
            return tokens;
        }

        private static bool LookAheadKeywordIsMatched(string keyword, int currentIndex, string charStream)
        {
            for (int i = 0; i < keyword.Length; i++)
            {
                if (charStream[currentIndex] + i == keyword[i])
                {
                    continue;
                }
                return false;
            }
            return true;
        }

        // private static int LookBeyondComment(int currentIndex, string charStream) {
        //     for (int i = 0; i < charStream.Length; i++) {

        //     }
        // }

        public static void PrintTokens(List<Token> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                Console.WriteLine(tokens[i]);
            }
        }
    }
}

/* Lex for Math
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
*/