
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                 =  0, // (EOF)
        SYMBOL_ERROR               =  1, // (Error)
        SYMBOL_WHITESPACE          =  2, // Whitespace
        SYMBOL_MINUSMINUS          =  3, // '--'
        SYMBOL_LPAREN              =  4, // '('
        SYMBOL_RPAREN              =  5, // ')'
        SYMBOL_COMMA               =  6, // ','
        SYMBOL_COLON               =  7, // ':'
        SYMBOL_PLUSPLUS            =  8, // '++'
        SYMBOL_EQ                  =  9, // '='
        SYMBOL_ARITH_OP            = 10, // 'ARITH_OP'
        SYMBOL_BASMA               = 11, // Basma
        SYMBOL_COMP_OP             = 12, // 'COMP_OP'
        SYMBOL_DEDENT              = 13, // DEDENT
        SYMBOL_DEF                 = 14, // def
        SYMBOL_DIGIT               = 15, // Digit
        SYMBOL_ELSECOLON           = 16, // 'else:'
        SYMBOL_END                 = 17, // End
        SYMBOL_FALSE               = 18, // False
        SYMBOL_FLOAT_NUM           = 19, // 'FLOAT_NUM'
        SYMBOL_FOR                 = 20, // for
        SYMBOL_ID                  = 21, // ID
        SYMBOL_IF                  = 22, // if
        SYMBOL_IN                  = 23, // in
        SYMBOL_INDENT              = 24, // INDENT
        SYMBOL_INT_NUM             = 25, // 'INT_NUM'
        SYMBOL_LOGIC_OP            = 26, // 'LOGIC_OP'
        SYMBOL_PRINT               = 27, // print
        SYMBOL_RETURN              = 28, // return
        SYMBOL_STR                 = 29, // STR
        SYMBOL_TRUE                = 30, // True
        SYMBOL_WHILE               = 31, // while
        SYMBOL_ARGLIST             = 32, // <arglist>
        SYMBOL_ASSIGNMENT          = 33, // <assignment>
        SYMBOL_EXPR                = 34, // <expr>
        SYMBOL_FACTOR              = 35, // <factor>
        SYMBOL_FUNCTIONCALL        = 36, // <functionCall>
        SYMBOL_FUNCTIONDECLARATION = 37, // <functionDeclaration>
        SYMBOL_IFSTATEMENT         = 38, // <ifStatement>
        SYMBOL_INDENTEDBLOCK       = 39, // <indentedBlock>
        SYMBOL_LOOP                = 40, // <loop>
        SYMBOL_PARAMLIST           = 41, // <paramlist>
        SYMBOL_PRINTSTM            = 42, // <printStm>
        SYMBOL_PROGRAM             = 43, // <program>
        SYMBOL_RETURNSTM           = 44, // <returnStm>
        SYMBOL_STEP                = 45, // <step>
        SYMBOL_STM                 = 46, // <stm>
        SYMBOL_STMLIST             = 47, // <stmlist>
        SYMBOL_TERM                = 48  // <term>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_BASMA_END                              =  0, // <program> ::= Basma <stmlist> End
        RULE_STMLIST                                        =  1, // <stmlist> ::= <stm> <stmlist>
        RULE_STMLIST2                                       =  2, // <stmlist> ::= <stm>
        RULE_STM                                            =  3, // <stm> ::= <assignment>
        RULE_STM2                                           =  4, // <stm> ::= <ifStatement>
        RULE_STM3                                           =  5, // <stm> ::= <loop>
        RULE_STM4                                           =  6, // <stm> ::= <functionDeclaration>
        RULE_STM5                                           =  7, // <stm> ::= <functionCall>
        RULE_STM6                                           =  8, // <stm> ::= <returnStm>
        RULE_STM7                                           =  9, // <stm> ::= <printStm>
        RULE_STM8                                           = 10, // <stm> ::= <step>
        RULE_ASSIGNMENT_ID_EQ                               = 11, // <assignment> ::= ID '=' <expr>
        RULE_EXPR_COMP_OP                                   = 12, // <expr> ::= <expr> 'COMP_OP' <term>
        RULE_EXPR                                           = 13, // <expr> ::= <term>
        RULE_TERM_ARITH_OP                                  = 14, // <term> ::= <term> 'ARITH_OP' <factor>
        RULE_TERM                                           = 15, // <term> ::= <factor>
        RULE_FACTOR_LPAREN_RPAREN                           = 16, // <factor> ::= '(' <expr> ')'
        RULE_FACTOR_ID                                      = 17, // <factor> ::= ID
        RULE_FACTOR_INT_NUM                                 = 18, // <factor> ::= 'INT_NUM'
        RULE_FACTOR_FLOAT_NUM                               = 19, // <factor> ::= 'FLOAT_NUM'
        RULE_FACTOR_STR                                     = 20, // <factor> ::= STR
        RULE_FACTOR_TRUE                                    = 21, // <factor> ::= True
        RULE_FACTOR_FALSE                                   = 22, // <factor> ::= False
        RULE_IFSTATEMENT_IF_COLON                           = 23, // <ifStatement> ::= if <expr> ':' <indentedBlock>
        RULE_IFSTATEMENT_IF_COLON_ELSECOLON                 = 24, // <ifStatement> ::= if <expr> ':' <indentedBlock> 'else:' <indentedBlock>
        RULE_INDENTEDBLOCK_INDENT_DEDENT                    = 25, // <indentedBlock> ::= INDENT <stmlist> DEDENT
        RULE_LOOP_FOR_ID_IN_COLON                           = 26, // <loop> ::= for ID in <expr> ':' <indentedBlock>
        RULE_LOOP_WHILE_COLON                               = 27, // <loop> ::= while <expr> ':' <indentedBlock>
        RULE_FUNCTIONDECLARATION_DEF_ID_LPAREN_RPAREN_COLON = 28, // <functionDeclaration> ::= def ID '(' <paramlist> ')' ':' <indentedBlock>
        RULE_PARAMLIST_ID_COMMA                             = 29, // <paramlist> ::= ID ',' <paramlist>
        RULE_PARAMLIST_ID                                   = 30, // <paramlist> ::= ID
        RULE_PARAMLIST                                      = 31, // <paramlist> ::= 
        RULE_FUNCTIONCALL_ID_LPAREN_RPAREN                  = 32, // <functionCall> ::= ID '(' <arglist> ')'
        RULE_ARGLIST_COMMA                                  = 33, // <arglist> ::= <expr> ',' <arglist>
        RULE_ARGLIST                                        = 34, // <arglist> ::= <expr>
        RULE_RETURNSTM_RETURN                               = 35, // <returnStm> ::= return <expr>
        RULE_PRINTSTM_PRINT_LPAREN_RPAREN                   = 36, // <printStm> ::= print '(' <arglist> ')'
        RULE_STEP_ID_MINUSMINUS                             = 37, // <step> ::= ID '--'
        RULE_STEP_ID_PLUSPLUS                               = 38, // <step> ::= ID '++'
        RULE_STEP_PLUSPLUS_ID                               = 39, // <step> ::= '++' ID
        RULE_STEP_MINUSMINUS_ID                             = 40  // <step> ::= '--' ID
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;

        public MyParser(string filename, ListBox lst)
        {

            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);
            Init(stream);
            stream.Close();
            this.lst = lst;
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARITH_OP :
                //'ARITH_OP'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BASMA :
                //Basma
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMP_OP :
                //'COMP_OP'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEDENT :
                //DEDENT
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEF :
                //def
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSECOLON :
                //'else:'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //End
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FALSE :
                //False
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT_NUM :
                //'FLOAT_NUM'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //ID
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INDENT :
                //INDENT
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT_NUM :
                //'INT_NUM'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGIC_OP :
                //'LOGIC_OP'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT :
                //print
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STR :
                //STR
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //True
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGLIST :
                //<arglist>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT :
                //<assignment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONCALL :
                //<functionCall>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONDECLARATION :
                //<functionDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFSTATEMENT :
                //<ifStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INDENTEDBLOCK :
                //<indentedBlock>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOP :
                //<loop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMLIST :
                //<paramlist>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINTSTM :
                //<printStm>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURNSTM :
                //<returnStm>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STM :
                //<stm>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMLIST :
                //<stmlist>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_BASMA_END :
                //<program> ::= Basma <stmlist> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMLIST :
                //<stmlist> ::= <stm> <stmlist>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMLIST2 :
                //<stmlist> ::= <stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM :
                //<stm> ::= <assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM2 :
                //<stm> ::= <ifStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM3 :
                //<stm> ::= <loop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM4 :
                //<stm> ::= <functionDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM5 :
                //<stm> ::= <functionCall>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM6 :
                //<stm> ::= <returnStm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM7 :
                //<stm> ::= <printStm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM8 :
                //<stm> ::= <step>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_ID_EQ :
                //<assignment> ::= ID '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_COMP_OP :
                //<expr> ::= <expr> 'COMP_OP' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_ARITH_OP :
                //<term> ::= <term> 'ARITH_OP' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_LPAREN_RPAREN :
                //<factor> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_ID :
                //<factor> ::= ID
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_INT_NUM :
                //<factor> ::= 'INT_NUM'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_FLOAT_NUM :
                //<factor> ::= 'FLOAT_NUM'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_STR :
                //<factor> ::= STR
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TRUE :
                //<factor> ::= True
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_FALSE :
                //<factor> ::= False
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_COLON :
                //<ifStatement> ::= if <expr> ':' <indentedBlock>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_COLON_ELSECOLON :
                //<ifStatement> ::= if <expr> ':' <indentedBlock> 'else:' <indentedBlock>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INDENTEDBLOCK_INDENT_DEDENT :
                //<indentedBlock> ::= INDENT <stmlist> DEDENT
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOOP_FOR_ID_IN_COLON :
                //<loop> ::= for ID in <expr> ':' <indentedBlock>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOOP_WHILE_COLON :
                //<loop> ::= while <expr> ':' <indentedBlock>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONDECLARATION_DEF_ID_LPAREN_RPAREN_COLON :
                //<functionDeclaration> ::= def ID '(' <paramlist> ')' ':' <indentedBlock>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMLIST_ID_COMMA :
                //<paramlist> ::= ID ',' <paramlist>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMLIST_ID :
                //<paramlist> ::= ID
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMLIST :
                //<paramlist> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONCALL_ID_LPAREN_RPAREN :
                //<functionCall> ::= ID '(' <arglist> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGLIST_COMMA :
                //<arglist> ::= <expr> ',' <arglist>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGLIST :
                //<arglist> ::= <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNSTM_RETURN :
                //<returnStm> ::= return <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINTSTM_PRINT_LPAREN_RPAREN :
                //<printStm> ::= print '(' <arglist> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_ID_MINUSMINUS :
                //<step> ::= ID '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_ID_PLUSPLUS :
                //<step> ::= ID '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS_ID :
                //<step> ::= '++' ID
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS_ID :
                //<step> ::= '--' ID
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            lst.Items.Add(message);
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            lst.Items.Add(message);
            string expectedToken = "Expected Token is " + args.ExpectedTokens.ToString();
            lst.Items.Add(expectedToken);
            //todo: Report message to UI?
        }

    }
}
