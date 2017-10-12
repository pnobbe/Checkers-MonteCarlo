using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : ScriptableObject {

    public Color color;
    public string controllerName;
    public char character;

    public virtual void Initialize() {

    }

    public virtual void OnEnableTurn() {

    }

    public virtual void OnDisableTurn() {

    }
}