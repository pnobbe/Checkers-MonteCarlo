using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public GameMode playerBlue, playerRed;

    private Board board;

    private void Awake() {
        board = new Board();
        board.InitializeCheckers();

        playerBlue.Initialize(this, board, TEAM.BLUE);
        playerRed.Initialize(this, board, TEAM.RED);
    }
}
