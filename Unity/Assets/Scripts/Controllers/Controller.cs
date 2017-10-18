using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : ScriptableObject {

    public Color color;
    public string winText;
    public char character;
    public bool isTurn { get; set; }

    protected Game game;

    public virtual void Initialize(Game game) {
        this.game = game;
    }

    public virtual void OnEnableTurn() {
        isTurn = true;
    }

    public virtual void OnDisableTurn() {
        isTurn = false;
    }
}