using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSParser
{
    class Lexer
    {
        # region Static Functions
        public static List<Token> LexLines(string[] inputLines)
        {
            List<Token> tokens = new List<Token>();

            foreach (string charStream in inputLines)
            {
                tokens = tokens.Concat(LexString(charStream)).ToList();
            }

            return tokens;
        }

        // For one line/string
        public static List<Token> LexString(string charStream)
        {
            List<Token> tokens = new List<Token>();

            // Check if comment == %, returns an empty token list
            if (charStream == "" || charStream[0] == '%') return tokens;

            for (int i = 0; i < charStream.Length; i++)
            {
                char c = charStream[i];

                string create = LookAheadKeyword("create", ref i, charStream);
                if (create != null) tokens.Add(new Token(TokenType.CREATE, "create"));
                string say = LookAheadKeyword("say", ref i, charStream);
                if (say != null) tokens.Add(new Token(TokenType.SAY, "say"));

                if (c == '=')
                {
                    // Add lookahead for equality '==' here
                    tokens.Add(new Token(TokenType.ASSIGN, "="));
                }
                if (Regex.Match(c.ToString(), @"\+|-|\*|\/").Success)
                {
                    tokens.Add(new Token(TokenType.OPERATOR, c.ToString()));
                }

                string identifier = LookAhead(ref i, charStream, @"[a-z]|[A-Z]|_", @"[a-z]|[A-Z]|_|[0-9]");
                if (identifier != null)
                {
                    tokens.Add(new Token(TokenType.IDENTIFIER, identifier));
                    continue;
                }
                string number = LookAhead(ref i, charStream, @"[0-9]", @"[0-9]");
                if (number != null)
                {
                    tokens.Add(new Token(TokenType.NUMBER, number));
                }
            }
            return tokens;
        }
        #endregion

        # region Utility Functions
        private static bool LookAheadKeywordIsMatched(string keyword, int currentIndex, string charStream)
        {
            for (int i = 0; i < keyword.Length; i++)
            {
                if (i >= charStream.Length) break;
                if (charStream[currentIndex + i] != keyword[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static string LookAheadKeyword(string keyword, ref int currentIndex, string charStream)
        {
            int startIndex = currentIndex;

            // Trigger for LookAhead
            if (charStream[startIndex] == keyword[0])
            {
                for (int i = 0; i < keyword.Length; i++)
                {
                    if (charStream[currentIndex] != keyword[i])
                    {
                        currentIndex = startIndex;
                        return null;
                    }
                    currentIndex++;
                    if (currentIndex >= charStream.Length) break;
                }
                // Every index matched, so successful, let's return keyword.
                return keyword;
            }

            currentIndex = startIndex;
            return null;
        }

        private static string LookAhead(ref int currentIndex, string charStream, string startPattern, string loopPattern)
        {
            string result = "";

            // Look Ahead Entry
            if (!Regex.Match(charStream[currentIndex].ToString(), startPattern).Success) return null;

            // Look Ahead Loop
            for (int j = currentIndex; j < charStream.Length; j++)
            {
                if (Regex.Match(charStream[j].ToString(), loopPattern).Success)
                {
                    result += charStream[j];
                }
                else
                {
                    break;
                }
            }

            // Success
            if (result.Length > 0)
            {
                currentIndex += result.Length - 1;
                return result;
            }
            return null;
        }

        public static void PrintTokens(List<Token> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                Console.WriteLine(tokens[i]);
            }
        }
        # endregion
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