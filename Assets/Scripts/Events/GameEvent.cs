﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable object that holds a list of GameEventListeners. Responsible for raising events across all listeners
[CreateAssetMenu]
public class GameEvent : ScriptableObject
{

    //The collection of listeners.
    List<GameEventListener> gameEventListeners = new List<GameEventListener>();
    public void Raise()
    {
        //Debug.Log("Raised " + name);
        for (int i = 0; i < gameEventListeners.Count; i++)
        {
            gameEventListeners[i].Invoke();
        }
    }

    public void Raise(float f)
    {
        for (int i = 0; i < gameEventListeners.Count; i++)
        {
            Debug.Log("Raised " + name + " on " + gameEventListeners[i].gameObject.name);
            gameEventListeners[i].Invoke();
            gameEventListeners[i].Invoke(f);
        }
    }

    public void Raise(Sprite s)
    {
        for (int i = 0; i < gameEventListeners.Count; i++)
        {
            gameEventListeners[i].Invoke();
            gameEventListeners[i].Invoke(s);
        }
    }

    public void Raise(float f, Sprite s)
    {
        for (int i = 0; i < gameEventListeners.Count; i++)
        {
            gameEventListeners[i].Invoke();
            gameEventListeners[i].Invoke(f);
            gameEventListeners[i].Invoke(s);
        }
    }

    //When an object with the GameEventListener component is created, it adds itself to gameEventListeners
    public void RegisterListener(GameEventListener listener)
    {
        if (!gameEventListeners.Contains(listener))
            gameEventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (gameEventListeners.Contains(listener))
            gameEventListeners.Remove(listener);
    }
}