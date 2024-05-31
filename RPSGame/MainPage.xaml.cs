namespace RPSGame;

public partial class MainPage : ContentPage
{
	Random ranGen;
	int systemChoice;
	int playerChoice;
	int systemScore = 0;
	int playerScore = 0;
	public MainPage()
	{
		InitializeComponent();
        //generate computer choice
        Random ranGen = new Random();
        systemChoice = ranGen.Next(1, 4);

	}

	void ImageButton_Click(System.Object sender, System.EventArgs e)
	{

		NewGameButton.IsEnabled = true;

	if (systemChoice == 1)  //rock is 1
		{
			systemPick.Source = ImageSource.FromFile("rock.png");
		}
    else if(systemChoice == 2) //paper is 2
		{
            systemPick.Source = ImageSource.FromFile("paper.png");
        }
    else if(systemChoice == 3) //scissors is 3
		{
            systemPick.Source = ImageSource.FromFile("scissors.png");
        }
    }
}

