using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XOGame
{
    public partial class MainPage : ContentPage
    {
        private const char PlayerSign = 'X';
        private const char MachineSign = 'O';

        private char[] board = new char[9]; // player is X
        private readonly Button[] btnBoard;
        private enum GameStatus { X, O, Draw, Unfinished }
        
        public MainPage()
        {
            InitializeComponent();
            btnBoard = new Button[] { Field0, Field1, Field2, Field3, Field4, Field5, Field6, Field7, Field8 };
        }

        public void FieldClicked(System.Object sender, System.EventArgs e)
        {
            // Player's turn
            UpdateBoard(((Button)sender), PlayerSign);
            if (HandleGameStatus()) return;

            // Machine's turn
            var freeIndexes = GetAvailableIndexes(board);
            int machineIndex = (new Random()).Next(0, freeIndexes.Count);

            UpdateBoard(freeIndexes.ElementAt(machineIndex), MachineSign);
            HandleGameStatus();
        }

        public void btnRestart_Clicked(System.Object sender, System.EventArgs e)
        {
            ClearBoard();
        }

        private void ClearBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = '\0';
                btnBoard[i].Text = "";
            }
            EnableBoard(true);
        }

        /// <summary>
        /// Handles the game status
        /// </summary>
        /// <returns>
        /// A boolean indicating that game has finished.
        /// True: The game is over.
        /// False: The game is in progress.
        /// </returns>
        private bool HandleGameStatus()
        {
            GameStatus gameStatus = GetBoardStatus(board);

            switch (gameStatus)
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
                    return false;
                    break;
            }

            EnableBoard(false);

            return true;
        }

        private void EnableBoard(bool enable)
        {
            for (int i = 0; i < btnBoard.Length; i++)
            {
                btnBoard[i].IsEnabled = enable;
            }
        }

        private List<int> GetAvailableIndexes(char[] board)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == '\0')
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

        private void UpdateBoard(int fieldIndex, char sign)
        {
            Button btn = btnBoard[fieldIndex];
            board[btn.TabIndex] = sign;
            btn.Text = sign.ToString();
            btn.IsEnabled = false;
        }

        private void UpdateBoard(Button btn, char sign)
        {
            UpdateBoard(btn.TabIndex, sign);
        }

        private GameStatus GetBoardStatus(char[] board)
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i * 3] == board[i * 3 + 1] && board[i * 3 + 1] == board[i * 3 + 2] && (board[i * 3] == PlayerSign || board[i * 3] == MachineSign))
                {
                    return board[i * 3].ToString() == "X" ? GameStatus.X : GameStatus.O;
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == board[i + 3] && board[i + 3] == board[i + 6] && (board[i] == PlayerSign || board[i] == MachineSign))
                {
                    return board[i].ToString() == "X" ? GameStatus.X : GameStatus.O;
                }
            }

            // Check diagonals
            if (board[0] == board[4] && board[4] == board[8] && (board[0] == PlayerSign || board[0] == MachineSign))
            {
                return board[0].ToString() == "X" ? GameStatus.X : GameStatus.O;
            }
            if (board[2] == board[4] && board[4] == board[6] && (board[2] == PlayerSign || board[2] == MachineSign))
            {
                return board[2].ToString() == "X" ? GameStatus.X : GameStatus.O;
            }

            // Return draw if no winner found
            if (Array.IndexOf(board, '\0') == -1)
            {
                return GameStatus.Draw;
            }

            // Return "unfinished" if game is not finished
            return GameStatus.Unfinished;
        }
    }
}

