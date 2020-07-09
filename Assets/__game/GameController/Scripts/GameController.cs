using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController INSTANCE { get; private set; }
    

    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        foreach(PlayerSettingContainer container in PlayerSettingsManager.INSTANCE.playersContainers)
        {
            container.headquarter.OnHealtZero += OnPlayerLoose;
        }
    }

    private void OnPlayerLoose(int playerId) 
    {

    }

}
