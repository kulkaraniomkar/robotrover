A robotic rover is to be landed by NASA on a rectangular plateau of Mars. The rover can navigate the plateau using a set of simple commands.

Your task is to write a simple program to simulate the rover and its control software. Implement the following functions.

SetPosition(int x, int y, string direction) 
Deploys the rover to an initial grid location [x y], where direction is the initial compass direction.
For example, [0 0 N] means the rover is situated at the bottom left corner, facing North. Assume that the square directly North from (x, y) is (x, y+1).
You may assume that the plateau size has no upper bound.

Move(string commands) 
Moves the rover by accepting a command string in the form "L1R2...". 
•	L rotates the rover 90 degrees left
•	R rotates the rover 90 degrees right 
•	The number represents the grid positions to move in the direction it is facing
The command string may be of any length. This function may be called many times per mission.

Requirements
------------
1.	The application must be executable via the command line 
2.	Initial position can be set to [10 10 N] 
3.	Interpret the command sequence "R1R3L2L1", then output the resulting grid location in the format [x, y, direction]
