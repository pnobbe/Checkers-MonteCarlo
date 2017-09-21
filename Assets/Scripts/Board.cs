using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {

    public Checker[,] checkers = new Checker[8, 8];

    private GameObject prefab;
    private Material checkerRed;

    public Board() {
        prefab = Resources.Load("r_Checker") as GameObject;
        checkerRed = Resources.Load("Art/r_CheckerRed") as Material;
    }
    
    public void InitializeCheckers() {
        for (int x = 0; x < 8; x++) {
            for (int y = 0; y < 3; y++) {
                if((x % 2 == 0 && y % 2 == 0) || (x % 2 != 0 && y % 2 != 0)) {
                    InstantiateChecker(new Point2(x, y), TEAM.BLUE);
                }
            }

            for (int y = 5; y < 8; y++) {
                if ((x % 2 == 0 && y % 2 == 0) || (x % 2 != 0 && y % 2 != 0)) {
                    InstantiateChecker(new Point2(x, y), TEAM.RED);
                }
            }
        }
    }

    private void InstantiateChecker(Point2 position, TEAM team) {
        GameObject checker = GameObject.Instantiate(prefab, position.toVector3, Quaternion.identity) as GameObject;
        Checker c = checker.GetComponent<Checker>();
        c.team = team;

        if (team == TEAM.RED) checker.GetComponent<MeshRenderer>().material = checkerRed;

        checkers[position.x, position.y] = c;
    }

    public bool IsValid(Point2 a, Point2 b) {
        return true;
    }
}
