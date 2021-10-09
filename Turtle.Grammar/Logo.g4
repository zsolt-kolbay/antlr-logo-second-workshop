grammar Logo;

// Parser rules
// Every identifier must start with a small letter.
// Recursive rules are allowed.
program: commandList;
commandList: command*;
command: forward | turn | repeat;

// The actual LOGO commands.
forward: FORWARD NUMBER;
turn: TURN NUMBER;
repeat: REPEAT NUMBER BLOCKSTART commandList BLOCKEND;

// Lexer rules
// Every identifier must start with a capital letter.
// Rules cannot directly reference each other.
BLOCKSTART: '{';
BLOCKEND: '}';
NUMBER: [+-]?[0-9]+; // we can use text matching patterns similar to regex
FORWARD: 'forward';
TURN: 'turn';
REPEAT: 'repeat';
WS: [ \t] -> skip; // we're skipping whitespace characters, they will not be part of our syntax tree
NL: '\r'? '\n' -> skip; // same for newline characters