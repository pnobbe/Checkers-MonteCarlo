﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SimpleAI", menuName = "Controllers/SimpleAI")]
public class Opponent : Controller {

    public override void OnEnableTurn() {
        base.OnEnableTurn();

        game.PlaceCharacter(GetAvailableTile(), this);
    }

    private Point2 GetAvailableTile() {
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                if (game.characters[x, y] == '0') {
                    return new Point2(x, y);
                }
            }
        }

        return Point2.zero;
    }
}