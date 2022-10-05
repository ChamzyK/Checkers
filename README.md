# Checkers
Implementation of a famous board game in the ```C#``` programming language.

App code incude 4 projects (for more details, click on the link):
- [__CheckersLib__](CheckersLib "Checkers library") - implementation the game logic
- [__CheckersLib.Tests__](CheckersLib.Tests "MSTest project for checkers library") - ```MSTest``` project for testing a checkers logic library
- [__CheckersConsole__](CheckersConsole "Console view") - implementation for gaming in the console
- [__CheckersUI__](CheckersUI "Window view") - implementation for gaming in the desktop window

## [Screenshots](Images)

### [Console checkers](CheckersConsole)

The game control is carried out using arrow keys: 
- __up__ ↑
- __down__ ↓
- __left__ ←
- __right__ →

Conventions:
- "круг" for a disk
- "ромб" for a king

![Alt text](Images/Console_Start.png "Start")

__Yellow__ highlight is used for designation of the __current__ cell.

__Green__ highlight show __selected__ disk or king.

![Alt text](Images/Console_Selected.png "Selected highlight")

![Alt text](Images/Console_Capture.png "Capture")

_The king_ named "ромб" in this implementation. Can see on the following screenshot:

![Alt text](Images/Console_Queen.png "Queen on the field")

### [Window checkers](CheckersUI)

On the start displayed the following view:

![Alt text](Images/WPF_Start.png "Start")

On click "Новая игра" button create new game.

![Alt text](Images/WPF_NewGame.png "New game")

![Alt text](Images/WPF_Selected.png "Selected highlight")

_Circles_ are used for displaying __disks__, __kings__ get _rhombus_.

![Alt text](Images/WPF_Queen.png "Queen on the field")

When game ended, showed alert on the screenshot:

![Alt text](Images/WPF_GameEnd.png "Alert on the game end")
