using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MonteCarlo {
    public class Program : MonoBehaviour {

        public Text text;

        private Color cplayer = Color.green;
        private Color copponent = Color.red;

        private Player current;

        private MonteCarloTreeSearch mcts;
        private Board board;

        private Button[,] buttons = new Button[3,3];

        private const int numOfMCiterations = 17;
        
        private void Awake() {
            mcts = new MonteCarloTreeSearch(numOfMCiterations);
            board = new Board();

            Button[] bs = FindObjectsOfType<Button>();
            foreach(Button b in bs) {
                ButtonValue bv = b.GetComponent<ButtonValue>();
                buttons[bv.x, bv.y] = b;
            }
        }

        public void PerformMove(Button b) {
            ButtonValue bv = b.GetComponent<ButtonValue>();
            board.performMove(1, new Position(bv.x, bv.y));

            FillText();
            FillButtons();

            string s = board.printStatus();
            Debug.Log(s);

            if (s == "Game In progress") {
                PerformOpponentMove(2);
            }
        }

        private void PerformOpponentMove(int player) {
            board = mcts.findNextMove(board, player);

            FillText();
            FillButtons();

            string s = board.printStatus();
            Debug.Log(s);
        }

        private void FillText() {
            int[,] b = board.getBoardValues();
            string[] data = new string[] { "", "", "" };

            for(int x = 0; x < 3; x++)
                for(int y = 0; y < 3; y++) {
                    data[y] += b[x, y] + " ";
                }

            string textt = data[2] + "\n" + data[1] + "\n" + data[0];
            text.text = textt;
        }

        private void FillButtons() {
            int[,] bo = board.getBoardValues();

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++) {
                    if(bo[x, y] == 1 || bo[x, y] == 2) {
                        buttons[x, y].GetComponent<Image>().color = bo[x, y] == 1 ? cplayer : copponent;
                    }
                }
        }
    }
}