
 I have implemented this task in console application using c#, Once you run this task, you have a set of commands to choose from.
- If you select PLACE command, the app will ask you to choose the x and y coordinates
- If you select MOVE command, the app will prompt you will different direction to choose, based on the direction that you choose it will update the coordinates.
- If you select DETECT command, the app will reply you whether the well is EMPTY or FULL
- If you select DROP command, the app  will set the well to FULL status.
- If you select REPORT command, the app will respond with the output
- If you select any other command, which is invalid, the app will ask you to choose the right command.

>  ### Notes
- When the application starts the wells will reset to status of EMPTY.
- If the user tries to place a coordinate outside the range of the plate, the app will validate 
- If the user tries to move a direction outside the range of the plate, the app will ignore
