/*
 * Author: Anuj
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaInitializer : MonoBehaviour
{
    public string currAreaName;
    public SO_AreaState[] possibleAreaStates;

    // Start is called before the first frame update
    void Start()
    {
        GameObject prefabToInstantiate = GetPrefabBasedOnState();
        if(prefabToInstantiate)
        {
            Instantiate(prefabToInstantiate);
        }
        else
        {
            print("No value recieved");
        }
        
    }

    private GameObject GetPrefabBasedOnState()
    {
        for(int i=0; i<possibleAreaStates.Length; i++)
        {
            bool isAreaNameSame = possibleAreaStates[i].areaName == currAreaName;
            bool isCurrAreaStateSame = possibleAreaStates[i].id_areaState == WorldStateManager.GetCurrentAreaState(currAreaName);
            bool isCurrWorldStateSame = IsCurrentWorldStateSame(possibleAreaStates[i]);

            if (isAreaNameSame && isCurrWorldStateSame && isCurrAreaStateSame)
            {
                return possibleAreaStates[i].prefabToLoad;
            }
        }

        return null;
    }

    private bool IsCurrentWorldStateSame(SO_AreaState areaState)
    {
        bool ans = false;
        WorldStates currWorldState = WorldStateManager.GetCurrentWorldState();

        foreach(WorldStates worldState in areaState.id_acceptableWorldStateList)
        {
            if(worldState == currWorldState)
            {
                ans = true;
                break;
            }
        }

        return ans;
    }

    
}
