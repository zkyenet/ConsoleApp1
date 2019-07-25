To whom it may concern:

Attached is my code submission for the Rover challenge. It was developed using Visual Studio 2017.

I assumed that once a rover has moved from its initial point to its end point, the next rover starts moving
as if the first rover was not there; ie. rovers cannot collide and can coexist in the same space. The alternate
solution would require a grid class that interacts with the Rover class.

The Rover class contains coordinates, headings and limits on where the rover can move, as well as a procedure
that consumes the instructions string and moves the rover appropriately. Finally, it also has a toString function
for printing the final output.

The main procedure parses the input strings, attempting to catch any obvious errors, and creates an array of rovers
based on the number of lines received. The user can stop entering lines after inputting the EOF character with CTRL+Z in
a new line.

