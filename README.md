# nettoyer_epd
Tool to keep only the last EPD string from a PGN to EPD conversion (pgn-extract)<p>

command : nettoyer_epd.exe your_epd_file.epd

# most common scenario
- From a test.pgn file containing games like this one :<br>
[Event "?"]<br>
[Site "?"]<br>
[Date "????.??.??"]<br>
[Round "?"]<br>
[White "?"]<br>
[Black "?"]<br>
[Result "*"]<p>

1. a3 a5 2. Ra2 a4 3. Ra1 Ra5 *<p>

- we run this command (PGN to EPD conversion) :<br>
pgn-extract.exe -Wepd -otest.epd test.pgn<p>

- we get a list of FEN strings :<br>
rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - c0 ?-? ? ? ????.??.??;<br>
rnbqkbnr/pppppppp/8/8/8/P7/1PPPPPPP/RNBQKBNR b KQkq - c0 ?-? ? ? ????.??.??;<br>
rnbqkbnr/1ppppppp/8/p7/8/P7/1PPPPPPP/RNBQKBNR w KQkq a6 c0 ?-? ? ? ????.??.??;<br>
rnbqkbnr/1ppppppp/8/p7/8/P7/RPPPPPPP/1NBQKBNR b Kkq - c0 ?-? ? ? ????.??.??;<br>
rnbqkbnr/1ppppppp/8/8/p7/P7/RPPPPPPP/1NBQKBNR w Kkq - c0 ?-? ? ? ????.??.??;<br>
rnbqkbnr/1ppppppp/8/8/p7/P7/1PPPPPPP/RNBQKBNR b Kkq - c0 ?-? ? ? ????.??.??;<br>
1nbqkbnr/1ppppppp/8/r7/p7/P7/1PPPPPPP/RNBQKBNR w Kk - c0 ?-? ? ? ????.??.??;<p>

- then we run this command :<br>
nettoyer_epd.exe test.epd<p>

- we get the FEN string of the last position of the game :<br>
1nbqkbnr/1ppppppp/8/r7/p7/P7/1PPPPPPP/RNBQKBNR w Kk -<p>
