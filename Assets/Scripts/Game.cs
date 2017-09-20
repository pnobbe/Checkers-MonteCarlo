using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    private Board board;

    private void Awake() {
        board = new Board();
        board.Initialize();
    }
}
