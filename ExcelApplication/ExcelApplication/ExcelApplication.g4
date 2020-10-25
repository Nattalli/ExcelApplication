grammar ExcelApplication;

/*
* Parser Rules
*/

compileUnit : expression EOF;

expression :
  LPAREN expression RPAREN #ParenthesizedExpr
  |expression EXPONENT expression #ExponentialExpr
  | expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
  | expression UNARYPLUS expression #UnaryPExpr
  | expression UNARYMINUS expression #UnaryMExpr
  | expression operatorToken=(ADD | SUBTRACT) expression #AdditiveExpr
  | operatorToken=(MMAX | MMIN) LPAREN expression (DESP expression)* RPAREN #MmaxMminExpr
  | NUMBER #NumberExpr
  | IDENTIFIER #IdentifierExpr
  ;

/*
* Lexer Rules
*/

NUMBER : INT ('.' INT)?;
IDENTIFIER : [a-zA-Z]+[1-9][0-9]+;
INT : ('0'..'9')+;
EXPONENT : '^';
MULTIPLY : '*';
DIVIDE : '/';
SUBTRACT : '-';
ADD : '+';
LPAREN : '(';
RPAREN : ')';
MMAX : 'MMAX';
MMIN : 'MMIN';
UNARYPLUS : '++';
UNARYMINUS : '--';
DESP : ',';

WS : [\t\r\n] -> channel(HIDDEN);