lexer grammar LogoLexer;

// Lexer rules
// Every identifier must start with a capital letter.
// Rules cannot directly reference each other.
BLOCKSTART: '{';
BLOCKEND: '}';
NUMBER: [+-]?[0-9]+; // we can use text matching patterns similar to regex
FORWARD: 'forward';
TURN: 'turn';
REPEAT: 'repeat';
COLOR: 'color';
SAVE: 'save';

// colors
COLOR_BLACK: 'black';
COLOR_RED: 'red';
COLOR_GREEN: 'green';
COLOR_BLUE: 'blue';

// pen
PEN: 'pen';
UP: 'up';
DOWN: 'down';

STRING_LITERAL: '"' .*? '"';
COMMENT: '//' ~[\r\n]* -> channel(2);

// filler characters
WS: [ \t] -> skip; // we're skipping whitespace characters, they will not be part of our syntax tree
NL: '\r'? '\n' -> skip; // same for newline characters