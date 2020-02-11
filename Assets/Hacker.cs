using UnityEngine;


public class Hacker : MonoBehaviour
{
    //Show Menu
    const string menuHint = "You may type \"menu\" any time";
    //passwords
    string[] level1passwords = { "simple", "queen", "king", "majestic","locker"};
    string[] level2passwords = { "laugh", "socialize", "homosapiens", "wedding", "crazy" };
    string[] level3passwords = { "apocalyptic", "andromeda", "astronauts", "catastrophic", "aliens" };

    //Checking whether person has lost once
    bool lose = false;
    //Game State
    int level;
    string Password;
    string name;
    enum Screen { Name, MainMenu, Password, Win };
    Screen currentscreen;

    // Start is called before the first frame update
    void Start()
    {
        Terminal.WriteLine("Hello, What's your name?");
        currentscreen = Screen.Name;
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu(name);
        }
        else if(input == "close" || input=="quit" || input == "exit")
        {
            Terminal.WriteLine("If on the web, close the tab!");
            Application.Quit();
        }
        else if (currentscreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentscreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (currentscreen == Screen.Name)
        {
            name = input;
            ShowMainMenu(name);
        }
    }

    void CheckPassword(string input)
    {
        if (input == Password)
        {
            DisplayWinSceen();
        }
        else
        {
            lose = true;
            AskForPassword();
        }
    }
    void DisplayWinSceen()
    {
        Terminal.ClearScreen();
        currentscreen = Screen.Win;
        ShowLevelRewards();
        lose = false;
    }

    void ShowLevelRewards()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Well Done!The kingdom is yours");
                Terminal.WriteLine(@"
 _   |~  _
[_]--'--[_]
|'|**`**|'|
| |     | |
| | /^\ | |
|_|_|I|_|_|");
                break;
            case 2:
                Terminal.WriteLine("Yayy,People Looveeee youuu!!");
                Terminal.WriteLine("Play Again for a harder challenge");
                Terminal.WriteLine(@"
,d88b.d88b,
88888888888
`Y8888888Y'
  `Y888Y'  
    `Y'
");
                break;
            case 3:
                Terminal.WriteLine("Yayy,NASA gifted you a rocket!");
                Terminal.WriteLine(@"
        |
       / \
      / _ \
     |.o '.|
     |'._.'|     
   ,'|  |  |`.
  /  |  |  |  \
  |,-'--|--'-.|");
                break;
            default:
                Debug.LogError("Invalid level reached!");
                break;
        }
        Terminal.WriteLine("Type \"menu\" to go to play again");

    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007") Terminal.WriteLine("Welcome Mr.Bond to MI6,Ready to blast and romance, Please Select your level");
        else Terminal.WriteLine("Please Enter a Valid Input");
    }

    void AskForPassword()
    {
        currentscreen = Screen.Password;
        Terminal.ClearScreen();
        if (lose)
        {
            Terminal.WriteLine("The Harder you try, the dumber you get");
        }
        SelectRandomPassword();
        Terminal.WriteLine("Enter the Password,Hint:"+ Password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SelectRandomPassword()
    {
        int index;
        switch (level)
        {
            case 1:
                index = Random.Range(0, level1passwords.Length);
                Password = level1passwords[index];
                break;
            case 2:
                index = Random.Range(0, level2passwords.Length);
                Password = level2passwords[index];
                break;
            case 3:
                index = Random.Range(0, level3passwords.Length);
                Password = level3passwords[index];
                break;
            default:
                Debug.LogError("Invalid Level");
                break;
        }
    }

    void ShowMainMenu(string greeting)
    {
        currentscreen = Screen.MainMenu;
        lose = false;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello "+ greeting);
        Terminal.WriteLine("What would you like to Hack into?");
        Terminal.WriteLine("Press 1:- Hack into the Good Kingdom!");
        Terminal.WriteLine("Press 2:- Hack into people's lives!");
        Terminal.WriteLine("Press 3:- Hack into the Deadly Space");
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Enter your selection:- ");
    }
}
