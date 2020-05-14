
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update


    //Game State
    int level; // Variable for level

    string password; // Variable for password

    string[] levelOnePasswords = { "student", "teacher", "book", "pencil", "notebook" }; // Possible passwords for level 1
    string[] levelTwoPasswords = { "laptop", "monopoly", "keyboard", "innovation", "software" }; // Possible passwords for level 2
    string[] levelThreePasswords = { "national", "aeronautics", "space", "administration" }; // Possible passwords for level 3
    const string menu = "You can type menu at any time"; // Variable for menu reminder message to user

    enum Screen { MainMenu, Password, Win } // Different game states
    Screen currentScreen = Screen.MainMenu; // Variable to keep track of gamestates


    void Start() // Start function
    {
        ShowMainMenu();
    }

    void OnUserInput(string input) // Is run every milisecond, checks for user input
    {

        if (input == "menu") // Returns user to menu
        {
            Terminal.ClearScreen();
            ShowMainMenu();
            currentScreen = Screen.MainMenu; // Changes gamestate
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input); // Checks for user input on main menu screen
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassowrd(input); // Checks for user input on level screen
        }

        

    }

    void ShowMainMenu() // Main menu information
    {
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the School Grading System");
        Terminal.WriteLine("Press 2 for the Apple Inc");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("");
        Terminal.WriteLine(menu);
        Terminal.WriteLine("Enter your selection: ");
    }

    private void RunMainMenu(string input)  // Logic for main menu
    {


        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3"); // Checks if input variable is 1, 2, or 3 which are the only 3 levels
        if (isValidLevelNumber) // if true
        {
            level = int.Parse(input); // Turns the string into an integer
            StartGame(); // begins the game
        }
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("Please pick a valid option Mr.Bond");
        }
        else // User did not enter valid option
        {
            Terminal.WriteLine("Please pick a valid option"); 
            Terminal.WriteLine(menu); // Menu Reminder
        }
    }


    void StartGame() // Sets everything up for level
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Password; // Changes Gamestate 

        SetRandomPassword(); // Sets password

        Terminal.WriteLine(menu);
        Terminal.WriteLine("Please enter password");
        Terminal.WriteLine("Hint: " + password.Anagram()); // Gives user password as an Anagram

    }

    void SetRandomPassword() // Sets password for each level
    {
        switch (level)
        {
            case 1: // if level == 1
                password = levelOnePasswords[Random.Range(0, levelOnePasswords.Length)]; // Sets password to random string in levelOnePasswords array
                break; // needed break statement for switch 

            case 2: // level == 2
                password = levelTwoPasswords[Random.Range(0, levelTwoPasswords.Length)]; // Sets password to random string in levelTwoPasswords array
                break;

            case 3: // level == 3
                password = levelThreePasswords[Random.Range(0, levelThreePasswords.Length)]; // Sets password to random string in levelThreePasswords array
                break;
            default: // else
                Debug.LogError("how did you even get here?");
                break;
        }
    }

    void CheckPassowrd(string input) // Checks if user password is correct, called by OnUserInput method
    {
        if (input == password)
        {
            currentScreen = Screen.Win; // Changes gamestate
            Terminal.ClearScreen();
            DisplayWinScreen(); // Runs win screen method

        } else
        {
            Terminal.WriteLine("Wrong, try again"); // Wrong password message for user
            Terminal.WriteLine(menu);
            StartGame(); // Restarts the level
        }
    }

    void DisplayWinScreen() // Different win screens for each level
    {
        switch (level)
        {
            case 1:

                Terminal.WriteLine("Nice one!");
                Terminal.WriteLine(@"
____________
|A+        |
|A+        |
|A+        |
|A+        |
|__________|
");
                Terminal.WriteLine(menu);
                break;



            case 2:
                Terminal.WriteLine("Nice one!");
                Terminal.WriteLine(@"
          .:'
      __ :'__
   .'`__`-'__``.
  :__________.-'
  :_________:
   :_________`-;
    `.__.-.__.'

");
                Terminal.WriteLine(menu);

                break;

            case 3:

                Terminal.WriteLine("Nice one!");
                Terminal.WriteLine(@"

 _ __   __ _ ___  __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|
                      
");
                Terminal.WriteLine(menu);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
