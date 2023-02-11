using System;
using System.Linq;
using Xamarin.Forms;

namespace XOGame
{
    public partial class MainPage : ContentPage
    {
        private Game game;
        private readonly Button[] btnBoard;
        
        public MainPage()
        {
            InitializeComponent();

            game = new Game();
            btnBoard = new Button[] { Field0, Field1, Field2, Field3, Field4, Field5, Field6, Field7, Field8 };
        }

        public void FieldClicked(System.Object sender, System.EventArgs e)
        {
            // Player's turn
            GameStatus status = game.Play(((Button)sender).TabIndex);
            UpdateBoard();
            HandleGameStatus(status);

            if (status != GameStatus.Unfinished) return;

            // Machine's turn
            status = game.Play();
            UpdateBoard();
            HandleGameStatus(status);
        }

        public void btnRestart_Clicked(System.Object sender, System.EventArgs e)
        {
            ClearBoard();
            game.StartOver();
        }

        private void ClearBoard()
        {
            for (int i = 0; i < btnBoard.Length; i++)
            {
                btnBoard[i].Text = "";
            }
            EnableBoard(true);
            lblGameStatus.Text = "";
        }

        private void HandleGameStatus(GameStatus status)
        {
            switch (status)
            {
                case GameStatus.X:
                    lblGameStatus.Text = "X Won!";
                    break;
                case GameStatus.O:
                    lblGameStatus.Text = "O Won!";
                    break;
                case GameStatus.Draw:
                    lblGameStatus.Text = "Draw!";
                    break;
                case GameStatus.Unfinished:
                    lblGameStatus.Text = "In progress...";
                    return;
            }

            EnableBoard(false);
        }

        private void EnableBoard(bool enable)
        {
            for (int i = 0; i < btnBoard.Length; i++)
            {
                btnBoard[i].IsEnabled = enable;
            }
        }

        private void UpdateBoard()
        {
            for (int i = 0; i < game.Board.Length; i++)
            {
                btnBoard[i].Text = game.Board[i].ToString();
                btnBoard[i].IsEnabled = game.Board[i].IsEmpty();
            }
        }
    }
}

