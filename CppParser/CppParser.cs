
// CppParser.cs - generated by the SLK parser generator 

using Dsl.Common;

namespace Dsl.Parser {

class CppParser {

private static short[] Production = {0

,2,13,14 ,3,14,15,24 ,2,15,16 ,3,16,17,32 ,3,17,33,18 
,2,18,25 ,6,18,34,35,20,36,26 ,4,19,22,37,27 ,2,20,21 
,6,21,38,1,14,2,28 ,6,21,40,3,14,4,29 ,6,21,41,5,14,6,30 
,3,22,7,42 ,3,22,8,43 ,3,22,9,44 ,3,23,10,45 
,3,23,11,46 ,5,24,23,31,15,24 ,1,24 ,6,25,34,35,19,36,25 
,1,25 ,6,26,34,35,19,36,26 ,1,26 ,2,27,21 ,1,27 
,3,28,39,21 ,1,28 ,3,29,39,21 ,1,29 ,3,30,39,21 
,1,30 
,0};

private static int[] Production_row = {0

,1,4,8,11,15,19,22,29,34,37,44,51,58,62,66,70
,74,78,84,86,93,95,102,104,107,109,113,115,119,121,125
,0};

private static short[] Parse = {

0,0,2,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3
,3,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,4,4,4,5
,5,5,5,5,5,5,5,5,5,5,5,7,6,7,6,7,6,6,6,6
,6,6,6,24,25,24,25,24,25,25,25,25,25,25,25,26,27,26,27,26
,27,27,27,27,27,27,27,28,29,28,29,28,29,29,29,29,29,29,29,30
,31,30,31,30,31,31,31,31,31,31,31,1,9,1,9,1,9,1,1,1
,1,1,1,21,0,21,0,21,20,20,20,21,21,21,23,0,23,0,23,22
,22,22,23,23,23,19,0,19,0,19,8,8,8,18,18,19,10,0,11,0
,12,13,14,15,16,17,0,0
};

private static int[] Parse_row = {0

,109,1,13,25,37,49,142,110,154,153,153,142,120,131,61,73
,85,97
,0};

private static short[] Conflict = {

0
};

private static int[] Conflict_row = {0


,0};

private static short get_conditional_production ( short symbol ) { return (short) 0; }

private const short   END_OF_SLK_INPUT_ = 12;
private const short   START_SYMBOL = 13;
private const short   START_STATE = 0;
private const short   START_CONFLICT = 32;
private const short   END_CONFLICT = 32;
private const short   START_ACTION = 31;
private const short   END_ACTION = 47;
private const short   TOTAL_CONFLICTS = 0;

public const int   NOT_A_SYMBOL = 0;
public const int   NONTERMINAL_SYMBOL = 1;
public const int   TERMINAL_SYMBOL = 2;
public const int   ACTION_SYMBOL = 3;

public const int   PARSE_STACK_SIZE = 65535;

public static short[]
GetProductionArray ( short  production_number )
{
   short   index = (short)  Production_row [ production_number ],
           array_length = (short)  Production [ index ],
           new_index = 0;
   short[] productionArray = new short[16];        

   while ( array_length-- >= 0 ) {
       productionArray [ new_index++ ] = Production [ index++ ];
   }
   return  productionArray;
}

public static int GetSymbolType ( short   symbol )
{
   int   symbol_type = NOT_A_SYMBOL;

   if ( symbol >= START_ACTION  &&  symbol < END_ACTION ) {
       symbol_type = ACTION_SYMBOL;
   } else if ( symbol >= START_SYMBOL ) {
       symbol_type = NONTERMINAL_SYMBOL;
   } else if ( symbol > 0 ) {
       symbol_type = TERMINAL_SYMBOL;
   }
   return  symbol_type;
}

public static bool    IsNonterminal ( short   symbol )
{
   return ( symbol >= START_SYMBOL  &&  symbol < START_ACTION );
}

public static bool    IsTerminal ( short   symbol )
{
   return ( symbol > 0  &&  symbol < START_SYMBOL );
}

public static bool    IsAction ( short   symbol )
{
   return ( symbol >= START_ACTION  &&  symbol < END_ACTION );
}

public static short GetTerminalIndex ( short   token ){
 return ( token );
}

public static short
get_production ( short     conflict_number,
                 ref CppToken  tokens )
{
    short   entry = 0;
    int     index, level;

    if ( conflict_number <= TOTAL_CONFLICTS ) {
        entry = (short) ( conflict_number + (START_CONFLICT - 1) );
        level = 1;
        while ( entry >= START_CONFLICT ) {
            index = Conflict_row [entry - (START_CONFLICT -1)];
            index += tokens.peek ( level );
            entry = Conflict [ index ];
            ++level;
        }
    }

    return  entry;
}

private static short
get_predicted_entry ( ref CppToken   tokens,
                      short      production_number,
                      short      token,
                      int        scan_level,
                      int        depth )
{
 return  0;
}

internal static
void Accept(IVisitor visitor)
{
    visitor.Visit(Production, Production_row, Parse, Parse_row, START_SYMBOL, START_ACTION);
}

internal unsafe static void
parse (ref DslAction   action,
        ref CppToken    tokens,
        ref CppError    error,
        short       start_symbol )
{
 short     lhs;
 short     production_number, entry, symbol, token, new_token;
 int       production_length, top, index, level;
 short* stack = stackalloc short[PARSE_STACK_SIZE];

 top = PARSE_STACK_SIZE - 1;
 stack [ top ] = 0;
 if ( start_symbol == 0 ) {
     start_symbol = START_SYMBOL;
 }
 if ( top > 0 ) { stack [--top] = start_symbol;
 } else { error.message ("CppParse: stack overflow\n", ref tokens); return; }
 token = tokens.get();
 new_token = token;

 for ( symbol = (stack[top] != 0  ? stack[top++] : (short) 0);  symbol != 0; ) {

     if ( symbol >= START_ACTION ) {
         action.execute ( symbol - (START_ACTION-1) );

     } else if ( symbol >= START_SYMBOL ) {
         entry = 0;
         level = 1;
         production_number = get_conditional_production ( symbol );
         if ( production_number != 0 ) {
             entry = get_predicted_entry ( ref tokens,
                                           production_number, token,
                                           level, 1 );
         }
         if ( entry == 0 ) {
             index = Parse_row [ symbol - (START_SYMBOL-1) ];
             index += token;
             entry = Parse [ index ];
         }
         while ( entry >= START_CONFLICT ) {
             index = Conflict_row [entry - (START_CONFLICT -1)];
             index += tokens.peek (level);
             entry = Conflict [ index ];
             ++level;
         }
         if ( entry != 0 ) {
             index = Production_row [ entry ];
             production_length = Production [ index ] - 1;
             lhs = Production [ ++index ];
             if ( lhs == symbol ) {
                 action.predict ( entry, symbol, token, level - 1, tokens.getLastToken(), tokens.getLastLineNumber(), tokens.getCurToken(), tokens.getLineNumber() );
                 index += production_length;
                 for (;  production_length-- > 0;  --index ) {
                     if ( top > 0 ) { stack [--top] = Production [index];
                     } else { error.message ("CppParse: stack overflow\n", ref tokens); return; }
                 }
             } else {
                 new_token = error.no_entry ( entry, symbol, token, level - 1, ref tokens );
             }
         } else {                                       // no table entry
             new_token = error.no_entry ( entry, symbol, token, level - 1, ref tokens );
         }
     } else if ( symbol > 0 ) {
         if ( symbol == token ) {
             token = tokens.get();
             new_token = token;
         } else {
             new_token = error.mismatch ( symbol, token, ref tokens );
         }
     } else {
         error.message ( "\n parser error: symbol value 0\n", ref tokens );
     }
     if ( token != new_token ) {
         if ( new_token != 0 ) {
             token = new_token;
         }
         if ( token != END_OF_SLK_INPUT_ ) {
             continue;
         }
     }
     symbol = (stack[top] != 0  ? stack[top++] : (short) 0);
 }
 if ( token != END_OF_SLK_INPUT_ ) {
     error.input_left (ref tokens);
 }
}



};


}
