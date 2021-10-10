parser grammar LogoParser;

options {
	tokenVocab = LogoLexer;
}

// Parser rules
// Every identifier must start with a small letter.
// Recursive rules are allowed.
program: commandList;
commandList: command*;
command: forward | turn | repeat | setColor | penUpOrDown | saveImage;

// The actual LOGO commands.
forward: FORWARD NUMBER;
turn: TURN NUMBER;
repeat: REPEAT NUMBER BLOCKSTART commandList BLOCKEND;
strokeColor: COLOR_BLACK | COLOR_RED | COLOR_GREEN | COLOR_BLUE;
setColor: COLOR strokeColor;
penUpOrDown: PEN (UP | DOWN);
saveImage: SAVE STRING_LITERAL;