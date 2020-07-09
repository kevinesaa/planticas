using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettingsManager : MonoBehaviour
{
    public static PlayerSettingsManager INSTANCE { get; private set; }
    public PlayerSettingContainer[] playersContainers;

    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
            
            for(int i=0; i < playersContainers.Length; i++) 
            {
                playersContainers[i].SetPlayerId(i);
            }
        }
        else
        {
            Destroy(this);
        }
    }
    
}
