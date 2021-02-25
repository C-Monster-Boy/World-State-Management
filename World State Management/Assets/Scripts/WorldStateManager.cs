/*
 * Author: Anuj
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateManager : MonoBehaviour
{
    public static WorldStateManager worldStateManagerInstance;
    public float TimeOfCreation { get; private set; }

    public WorldStates currentWorldState;
    public AreaStateMapper[] areaStateList;

    private void Awake()
    {
        if(worldStateManagerInstance)
        {
            DestroyNewerInstances();
        }
        else
        {
            TimeOfCreation = Time.time;
            DontDestroyOnLoad(gameObject);
        }
    }
   
    private void DestroyNewerInstances()
    {
        WorldStateManager[] worldStateManagerList = GameObject.FindObjectsOfType<WorldStateManager>();

        WorldStateManager oldest = worldStateManagerList[0];
        for (int i = 1; i < worldStateManagerList.Length; i++)
        {
            if (worldStateManagerList[i].TimeOfCreation < oldest.TimeOfCreation)
            {
                oldest = worldStateManagerList[i];
            }
        }

        for (int i = 0; i < worldStateManagerList.Length; i++)
        {
            if (worldStateManagerList[i] != oldest)
            {
                Destroy(worldStateManagerList[i].gameObject);
            }
        }
    }
}

public enum WorldStates
{
    Start,
    Earthquake
}

public enum AreaStates
{
    Pocco_Start,
    Pocco_Earthquake,

    PoccoHill_Start,
    PoccoHill_Earthquake
}

[System.Serializable]
public struct AreaStateMapper
{
    public string areaName;
    public AreaStates currAreaState;
}
