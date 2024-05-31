namespace RPSGame;

public partial class MainPage : ContentPage
{
	Random ranGen;
	int rock = 1;
	int paper = 2;
	int scissors =3;
	public MainPage()
	{
		InitializeComponent();
        //generate computer choice
        Random ranGen;
        Random systemChoice = new Random.Next(1, 4);
	}
}

