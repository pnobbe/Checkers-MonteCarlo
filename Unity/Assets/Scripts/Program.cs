using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MonteCarlo {
    public class Program : MonoBehaviour {

        public GameObject endDisplay;
        public Text text;

        public Color cplayer;
        public Color copponent;

        private Player current;

        private MonteCarloTreeSearch mcts;
        private Board board;

        private Button[,] buttons = new Button[3, 3];

        private const int numOfMCiterations = 17;

        private int currentStartingPlayer = 2;
        private int currentPlayer;

        private int playerWins, opponentWins, draws;

        private void Awake() {
            Button[] bs = FindObjectsOfType<Button>();
            foreach (Button b in bs) {
                ButtonValue bv = b.GetComponent<ButtonValue>();
                buttons[bv.x, bv.y] = b;
            }

            NextGame();
        }

        public void NextGame() {
            endDisplay.SetActive(false);
            mcts = new MonteCarloTreeSearch(numOfMCiterations);
            board = new Board();
            SetText();

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++) {
                    buttons[x, y].GetComponent<Image>().color = Color.white;
                }

            currentStartingPlayer = 3 - currentStartingPlayer;
            currentPlayer = currentStartingPlayer;

            if (currentPlayer == 2) PerformOpponentMove(2);
        }

        private void SetText() {
            text.text = string.Format("<color={0}>Player wins</color>: {1:00}\n", cplayer.ToString(), playerWins);
            text.text += string.Format("<color={0}>Opponent wins</color>: {1:00}\n", copponent.ToString(), opponentWins);
            text.text += string.Format("Draws: {0:00}", draws);
        }

        public void PerformMove(Button b) {
            if (currentPlayer == 2) return;

            ButtonValue bv = b.GetComponent<ButtonValue>();
            board.performMove(1, new Position(bv.x, bv.y));
            
            FillButtons();

            string s = board.printStatus();

            if (s == "Game In progress") {
                currentPlayer = 2;
                PerformOpponentMove(2);
            } else {
                GameFinished();
            }
        }

        private void PerformOpponentMove(int player) {
            board = mcts.findNextMove(board, player);
            
            FillButtons();

            string s = board.printStatus();
            Debug.Log(s);

            if (s == "Game In progress") {
                currentPlayer = 1;
            } else {
                GameFinished();
            }
        }

        private void GameFinished() {
            string status = board.printStatus();

            switch (status) {
                case "Player 1 wins":
                    playerWins++;
                    break;
                case "Player 2 wins":
                    opponentWins++;
                    break;
                case "Game Draw":
                    draws++;
                    break;
            }

            endDisplay.SetActive(true);
            endDisplay.transform.Find("EndText").GetComponent<Text>().text = status;
        }

        private void FillButtons() {
            int[,] bo = board.getBoardValues();

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++) {
                    if (bo[x, y] == 1 || bo[x, y] == 2) {
                        buttons[x, y].GetComponent<Image>().color = bo[x, y] == 1 ? cplayer : copponent;
                    }
                }
        }
    }
}