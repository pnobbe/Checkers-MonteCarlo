using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameMode : ScriptableObject {

    private Game game;
    private Board board;
    private TEAM team;

    public void Initialize(Game game, Board board, TEAM team) {
        this.game = game;
        this.board = board;
        this.team = team;
    }
    
    public virtual void SetActive() {

    }

}
