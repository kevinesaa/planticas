using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    private int id;
    public PlayerController PlayerController { get; private set; }

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    internal void SetPlayerId(int id)
    {
        this.id = id;
    }

    public int GetId()
    {
        return id;
    }
}
