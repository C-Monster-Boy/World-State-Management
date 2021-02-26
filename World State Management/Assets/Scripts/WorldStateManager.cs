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
    public SO_WorldEvent[] worldEventList;


    public static WorldStates CurrentWorldState;
    public static AreaStateMapper[] AreaStateList;
    public static SO_WorldEvent[] WorldEventList;
    


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

            CopyDataIntoStatics();
        }

       
    }
   
    public static WorldStates GetCurrentWorldState()
    {
       
        return CurrentWorldState;
    }

    public static void SetCurrentWorldState(WorldStates newWorldState)
    {
        CurrentWorldState = newWorldState;
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

    public static void SetCurrentAreaState(string areaName, AreaStates newAreaState)
    {
        for (int i = 0; i < AreaStateList.Length; i++)
        {
            if (areaName == AreaStateList[i].areaName)
            {
                AreaStateList[i].currAreaState = newAreaState;
                return;
            }
        }
    }

    
    public static void InvokeWorldEvent(string worldEventName)
    {
        SO_WorldEvent worldEventToInvoke = GetWorldEvent(worldEventName);

        //Set new world state
        SetCurrentWorldState(worldEventToInvoke.newWorldState);

        //Invoke Area Events
        InvokeAreaEventsRelatedToWorldEvent(worldEventToInvoke);

    }

    private static void InvokeAreaEventsRelatedToWorldEvent(SO_WorldEvent worldEventToInvoke)
    {
        AreaStateManager currLoadedArea = FindObjectOfType<AreaStateManager>();

        foreach (AreaEventWithAreaName areaEvent in worldEventToInvoke.areaEventsToTrigger)
        {
            if (areaEvent.areaName == currLoadedArea.currAreaName)
            {
                currLoadedArea.InvokeAreaEvent(areaEvent.areaEvent);
            }
            else
            {
                SetCurrentAreaState(areaEvent.areaName, areaEvent.newAreaState);
            }
        }

        print("Curr world state: " + CurrentWorldState + "\t");
    }

    private static SO_WorldEvent GetWorldEvent(string worldEventName)
    {
        for (int i = 0; i < WorldEventList.Length; i++)
        {
            if (WorldEventList[i].worldEventName == worldEventName)
            {
                return WorldEventList[i];
            }
        }
        return null;
    }

    private void CopyDataIntoStatics()
    {
        CurrentWorldState = currentWorldState;
        AreaStateList = areaStateList;
        WorldEventList = worldEventList;
    }

    private void DestroyNewerInstances()
    {
       if(this != worldStateManagerInstance)
        {
            Destroy(this.gameObject);
        }

        print("Checked for destruction");
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
