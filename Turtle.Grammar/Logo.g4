grammar Logo;

// Parser rules
// Every identifier must start with a small letter.
// Recursive rules are allowed.
program: commandList;
commandList: (NL* command (NL+ | EOF))*;
command: forward | turn | repeat | setColor | penUpOrDown | saveImage;

// The actual LOGO commands.
forward: FORWARD NUMBER;
turn: TURN NUMBER;
repeat: REPEAT NUMBER NL* BLOCKSTART commandList BLOCKEND;
strokeColor: COLOR_BLACK | COLOR_RED | COLOR_GREEN | COLOR_BLUE;
setColor: COLOR strokeColor;
penUpOrDown: PEN (UP | DOWN);
saveImage: SAVE STRING_LITERAL;

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
LINE_COMMENT: '//' ~[\r\n]* -> skip;
NL: [\r\n]+;

// filler characters
WS: [ \t] -> skip; // we're skipping whitespace characters, they will not be part of our syntax tree