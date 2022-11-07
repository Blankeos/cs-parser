namespace CSParser
{
    enum TokenType
    {
        // keywords
        CREATE, // create
        SAY, // say
        FUNCTION, // func
        PARENTHESIS, // (, )
        ASSIGN, // =
        OPERATOR, // +, -, *, /
        NUMBER, // 21
        STRING, // "Hello"
        IDENTIFIER, // variableName, functionName
    }

    struct Token
    {
        public TokenType tokenType;
        public string value;

        public Token(TokenType tokenType, string value)
        {
            this.tokenType = tokenType;
            this.value = value;
        }

        public override string ToString()
        {
            return $"<{this.tokenType}: {this.value} >";
        }
    }
}





























/* Tokens for Math
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
            return $"<{this.tokenType}: {this.value} >";
        }
    }
*/