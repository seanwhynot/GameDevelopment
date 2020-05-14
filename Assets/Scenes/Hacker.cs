using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update


    //Game State
    string level;
    string password;
    enum Screen {MainMenu, Passowrd, Win }
    Screen currentScreen = Screen.MainMenu;


    void Start()
    {
        ShowMainMenu();
    }

    void OnUserInput(string input)
    {

        if (input == "menu")
        {
            ShowMainMenu();
            currentScreen = Screen.MainMenu;
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Passowrd)
        {
            CheckPassowrd(input);
        }

        

    }

    void ShowMainMenu()
    {
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the School Grading System");
        Terminal.WriteLine("Press 2 for the Town Hall");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection: ");
    }



    private void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = input;
            StartGame();
            password = "coca";
        }
        else if (input == "2")
        {
            level = input;
            StartGame();
            password = "cola";
        }
        else if (input == "3")
        {
            level = input;
            StartGame();
            password = "zero";
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please pick a valid option Mr.Bond");
        }
        else
        {
            Terminal.WriteLine("Please pick a valid option");
        }
    }


    void StartGame()
    {
        Terminal.WriteLine("You picked level " + level);
        currentScreen = Screen.Passowrd; 
    }



    void CheckPassowrd(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Good job, you got the password");
        } else
        {
            Terminal.WriteLine("Wrong, try again");
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
