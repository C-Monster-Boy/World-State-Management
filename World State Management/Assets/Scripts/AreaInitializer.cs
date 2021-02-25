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
        Instantiate(prefabToInstantiate);
    }

    private GameObject GetPrefabBasedOnState()
    {
        for(int i=0; i<possibleAreaStates.Length; i++)
        {
            bool isAreaNameSame = possibleAreaStates[i].areaName == currAreaName;
            bool isCurrWorldStateSame = possibleAreaStates[i].id_worldState == WorldStateManager.GetCurrentWorldState();
            bool isCurrAreaStateSame = possibleAreaStates[i].id_areaState == WorldStateManager.GetCurrentAreaState(currAreaName);

            if(isAreaNameSame && isCurrWorldStateSame && isCurrAreaStateSame)
            {
                return possibleAreaStates[i].prefabToLoad;
            }
        }

        return null;
    }

    
}
