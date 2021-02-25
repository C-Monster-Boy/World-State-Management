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

    public static WorldStates CurrentWorldState;
    public static AreaStateMapper[] AreaStateList;



    private void Awake()
    {
        if(worldStateManagerInstance != null)
        {
            DestroyNewerInstances();
        }
        else
        {
            TimeOfCreation = Time.time;
            worldStateManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        }

        CurrentWorldState = currentWorldState;
        AreaStateList = areaStateList;
    }
   
    public static WorldStates GetCurrentWorldState()
    {
       
        return CurrentWorldState;
    }

    public static AreaStates GetCurrentAreaState(string areaName)
    {
        for(int i=0; i<AreaStateList.Length; i++)
        {
            if(areaName == AreaStateList[i].areaName)
            {
                return AreaStateList[i].currAreaState;
            }
        }

        return 0;
    }

    private void DestroyNewerInstances()
    {
        WorldStateManager[] worldStateManagerList = FindObjectsOfType<WorldStateManager>();

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

        print("Checked for destruction: " + TimeOfCreation);
    }
}

public enum WorldStates
{
    Start,
    WorldEvent1,
    WorldEvent2
}

public enum AreaStates
{
    Area1_Start,
    Area1_AfterWorldEvent1,
    Area1_AfterWorldEvent2,

    Area2_Start,
    Area2_AfterWorldEvent2,

    Area3_Start
}

[System.Serializable]
public struct AreaStateMapper
{
    public string areaName;
    public AreaStates currAreaState;
}
