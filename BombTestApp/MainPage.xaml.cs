using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BombTestApp
{
	public partial class MainPage : ContentPage
	{
        //Create Bomb
        static string bomb = new Random().Next(1, 5).ToString();

        //Create scores
        static int scores = 0;

        static int highscore = 0;

        public MainPage()
		{
			InitializeComponent();
		}
        
        //When button is clicked
        async void ButtonClicked(object sender, EventArgs e)
        {

            Button button = sender as Button;

            //game over
            if (button.Text == bomb)
            {
                //Update score
                int finalScore = scores;
                scores = 0;
                string scoreText = scores.ToString();
                string highText = highscore.ToString();

                await DisplayAlert("Boom!", "Everyone is dead :( \n Final Score: "+ finalScore, "Try Again?");
              
                //Display updated score
                ScoreLabel.Text = "Score: " + scoreText;

                HighLabel.Text = "HS: " + highText;

                //Generate new bomb
                bomb = new Random().Next(1, 5).ToString();
            }
            //game continue
            else
            {
                //Update scores
                scores += 1;
                if (scores > highscore)
                {
                    highscore = scores;
                }

                string scoreText = scores.ToString();
                string highText = highscore.ToString();
               
                // await DisplayAlert("Diffused", "Score: " + scores, "Continue");
                ScoreLabel.Text = "Score: " + scoreText;

                HighLabel.Text = "HS: " + highText;

                //Generate new bomb
                bomb = new Random().Next(1, 5).ToString();
            }

        }
	}
}
