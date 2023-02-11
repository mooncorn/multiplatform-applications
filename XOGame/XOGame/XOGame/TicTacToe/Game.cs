using System;
using System.Collections.Generic;

namespace XOGame
{
	public class Game
	{

        private Field[] _board = new Field[9];
        public Field[] Board
        {
            get { return _board; }
        }
        private bool turn = true;

        public Game()
        {
            InitializeBoard();
        }

        public GameStatus Play(int index)
		{
            if (turn)
            {
                _board[index].Sign = Sign.X;
            } else
            {
                _board[index].Sign = Sign.O;
            }


            turn = !turn;
            return GetBoardStatus();
		}

        public GameStatus Play()
        {
            var freeIndexes = GetAvailableSpots();
            var machineIndex = (new Random()).Next(0, freeIndexes.Count);
            return Play(freeIndexes[machineIndex]);
        }

        public void StartOver()
        {
            InitializeBoard();
        }

        private List<int> GetAvailableSpots()
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < _board.Length; i++)
            {
                if (_board[i].IsEmpty())
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

        private GameStatus GetBoardStatus()
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (_board[i * 3].Sign == _board[i * 3 + 1].Sign && _board[i * 3 + 1].Sign == _board[i * 3 + 2].Sign && (_board[i * 3].Sign == Sign.X || _board[i * 3].Sign == Sign.O))
                {
                    return _board[i * 3].ToString() == "X" ? GameStatus.X : GameStatus.O;
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (_board[i].Sign == _board[i + 3].Sign && _board[i + 3].Sign == _board[i + 6].Sign && (_board[i].Sign == Sign.X || _board[i].Sign == Sign.O))
                {
                    return _board[i].ToString() == "X" ? GameStatus.X : GameStatus.O;
                }
            }

            // Check diagonals
            if (_board[0].Sign == _board[4].Sign && _board[4].Sign == _board[8].Sign && (_board[0].Sign == Sign.X || _board[0].Sign == Sign.O))
            {
                return _board[0].ToString() == "X" ? GameStatus.X : GameStatus.O;
            }
            if (_board[2].Sign == _board[4].Sign && _board[4].Sign == _board[6].Sign && (_board[2].Sign == Sign.X || _board[2].Sign == Sign.O))
            {
                return _board[2].ToString() == "X" ? GameStatus.X : GameStatus.O;
            }

            // Return draw if no winner found
            if (GetAvailableSpots().Count == 0)
            {
                return GameStatus.Draw;
            }

            // Return "unfinished" if game is not finished
            return GameStatus.Unfinished;
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < _board.Length; i++)
            {
                _board[i] = new Field();
            }
        }
    }
}

