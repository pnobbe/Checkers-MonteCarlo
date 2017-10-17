using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Player", menuName = "Controllers/Player")]
public class Player : Controller {

    public override void Initialize(Game game) {
        base.Initialize(game);
        
        for(int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                Point2 p = new Point2(x, y);
                game.buttons[x, y].onClick.AddListener(delegate { ClickButton(p); });
            }
        }
    }

    public void ClickButton(Point2 p) {
        if (!isTurn) return;

        game.PlaceCharacter(p, this);
    }
}