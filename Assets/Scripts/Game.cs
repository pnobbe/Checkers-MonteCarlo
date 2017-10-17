using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public Controller[] controllers = new Controller[2];
    [HideInInspector]
    public Button[,] buttons = new Button[3, 3];
    [HideInInspector]
    public char[,] characters = new char[,] { { '0', '0', '0' }, { '0', '0', '0' }, { '0', '0', '0' } };                                            

    private Controller current;
    private int turn = 0; 

    private void Awake() {
        // Get all available buttons, so we can change the text later on
        for (int y = 0; y < 3; y++) {
            Transform row = GameObject.Find(string.Format("Row:{0:00}", y)).transform;
            for (int x = 0; x < 3; x++) {
                buttons[x, y] = row.Find(string.Format("Tile:{0:00}", x)).GetComponent<Button>();
            }
        }
        
        foreach(Controller c in controllers) {
            c.Initialize(this);
        }

        current = controllers[0];
        current.OnEnableTurn();
    }

    public void PlaceCharacter(Point2 p, Controller controller) {
        // Plaats character c in de double array
        // Doe enkele for loops (diagonaal x 2, verticaal, horizontaal)
        ClickButton(p, controller.character, controller.color);

        characters[p.x, p.y] = controller.character;

        turn++;
        if(turn > 8) {
            Debug.Log("Draw");
            return;
        }

        SetNextTurn();
    }

    private void SetNextTurn() {
        current.OnDisableTurn();
        current = controllers[turn % 2];
        current.OnEnableTurn();
    }

    private void ClickButton(Point2 p, char c, Color color) {
        buttons[p.x, p.y].interactable = false;
        Text text = buttons[p.x, p.y].GetComponentInChildren<Text>();
        text.text = c.ToString();
        text.color = color;
    }

    private void EndGame(string text, Color color) {

    }
}