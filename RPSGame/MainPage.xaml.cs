namespace RPSGame;

//comments are to help me look through the code :)

public partial class MainPage : ContentPage
{
    Random ranGen = new Random();
	int systemScore = 0;
	int playerScore = 0;
	int playerBonus = 0;
	int systemBonus = 0;
	public MainPage()
	{
		InitializeComponent();
	}
    void OnChoiceButtonClicked(System.Object sender, System.EventArgs e)
	{
        var button = sender as ImageButton;
        int playerChoice = int.Parse(button.CommandParameter.ToString());
        StartGame(playerChoice);
    }

	string ChoiceName(int choice)
	{
		switch(choice)
		{
			case 1: return "rock";
			case 2:return "paper";
			case 3: return "scissors";
			default: return "unknown";

		}
	}

	void DisplayChoices(int playerChoice, int systemChoice) //displays the images picked by user and system
	{
		playerPick.Source = $"{ChoiceName(playerChoice)}.png";
		systemPick.Source = $"{ChoiceName(systemChoice)}.png";

    }

	void CheckRoundWinner(int playerChoice, int systemChoice) //decides who the winner in the round is

	{
		if (playerChoice != systemChoice)
		{

			if ((playerChoice == 1 && systemChoice == 3) || (playerChoice == 2 && systemChoice == 1) || (playerChoice == 3 && systemChoice == 2))
			{
				playerScore = playerScore + 1;
			}
			else
			{
				systemScore = systemScore + 1;
			}

		}
		playerScoreLabel.Text = $"Player Score: {playerScore}";
		systemScoreLabel.Text = $"System Score: {systemScore}";
		Bonus();
	}

	void DisableChoiceButtons() //disables choice buttons
	{
        rockButton.IsEnabled = false;
        paperButton.IsEnabled = false;
        scissorsButton.IsEnabled = false;
    }
    void FinalWinner() //checks for winner at 3 points
	{
		if (playerScore == 3) 
		{
            playerBonus = playerBonus + 1;
            systemBonus = 0;
            DisplayAlert("Game Over", "You are the Winner!", "OK");
            NewGameButton.IsEnabled = true;
			DisableChoiceButtons();
        }
		else if (systemScore == 3) 
		{
            systemBonus = systemBonus + 1;
            playerBonus = 0;
            DisplayAlert("Game Over", "System Wins, Better luck nect time!", "OK");
            NewGameButton.IsEnabled = true;
			DisableChoiceButtons();
        }
		Bonus();
	}
	void OnNewGameButtonClicked(System.Object sender, System.EventArgs e) //resets the game to default
	{
		NewGame();
	}
	void NewGame() 
	{
		playerScore = 0;
		systemScore = 0;
        playerPick.Source = "question_mark.png";
        systemPick.Source = "question_mark.png";
        playerScoreLabel.Text = "Player Score: 0";
        systemScoreLabel.Text = "System Score: 0";
        NewGameButton.IsEnabled = false;
        rockButton.IsEnabled = true;
        paperButton.IsEnabled = true;
        scissorsButton.IsEnabled = true;
 
    }
	void Bonus() 
	{
        if (playerBonus == 2 || systemBonus == 2)
        {
            DisableChoiceButtons();
            NewGameButton.IsEnabled = false;
            DisplayAlert("Match Over", "", "OK");
        }
    }
    void StartGame(int playerChoice) //starts the game
    {
		{
            int systemChoice = ranGen.Next(1, 4);
			DisplayChoices(playerChoice, systemChoice);
			CheckRoundWinner(playerChoice, systemChoice);
			FinalWinner();
		}
    }
}

