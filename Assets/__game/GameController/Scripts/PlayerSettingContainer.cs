using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerSettingContainer 
{
    private int id;
    public PlayerController playerController;
    public HeadquarterController headquarter;
    public UIHealthManager uiHealthHeadquarterController;
    public UIHealthManager uiHealthPlayerController;

    internal void SetPlayerId(int id)
    {
        this.id = id;
        playerController.SetPlayerId(id);
        headquarter.SetPlayerId(id);

        uiHealthPlayerController.SetHealthManager(playerController);
        uiHealthHeadquarterController.SetHealthManager(headquarter);
    }

    public int GetId()
    {
        return id;
    }

}
