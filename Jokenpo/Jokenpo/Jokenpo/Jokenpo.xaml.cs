using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Jokenpo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Jokenpo : ContentPage
    {
        readonly string[] images = { "paper.jpg", "rock.jpg", "scissors.jpg" };
        enum GameResult { Win, Lose, Draw };

        public Jokenpo()
        {
            InitializeComponent();
        }

        private void HandClicked(object sender, EventArgs e)
        {
            int machineChoice = GetRandomHandOption();
            SetMachineHandImage(machineChoice);

            Button btnClicked = (Button) sender;
            int playerChoice = GetImageIndex(btnClicked.ImageSource.ToString().Split(' ')[1]);

            GameResult result = GetGameResult(playerChoice, machineChoice);
            lblResult.Text = result.ToString();
        }

        private void SetMachineHandImage(int handChoice)
        {
            btnMachine.ImageSource = images[handChoice];
        }

        private int GetRandomHandOption() 
        {
            return (new Random()).Next(0, images.Length);
        }

        private GameResult GetGameResult(int playerChoice, int machineChoice)
        {
            if (playerChoice == machineChoice)
                return GameResult.Draw;

            if (playerChoice == 2 && machineChoice == 0 || playerChoice + 1 == machineChoice) 
                return GameResult.Win;

            return GameResult.Lose;
        }

        private int GetImageIndex(string imageSource)
        {
            return images.IndexOf(imageSource);
        }
    }
}