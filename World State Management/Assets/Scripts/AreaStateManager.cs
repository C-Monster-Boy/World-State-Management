/*
 * Author: Anuj
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaStateManager : MonoBehaviour
{
    public string currAreaName;
    public AreaStates currAreaNarrativeState;
    public AreaEvent[] possibleAreaEvents;

    public void InvokeAreaEvent(string eventName)
    {
        //Get area event
        AreaEvent areaEventToPerform = GetAreaEvent(eventName);

        if(areaEventToPerform != null)
        {
            //Set area states wsm
            WorldStateManager.SetCurrentAreaState(currAreaName, areaEventToPerform.newAreaState);

            //Set area state ASM
            currAreaNarrativeState = areaEventToPerform.newAreaState;

            //Perform Events
            areaEventToPerform.eventsToTrigger.Invoke();
        }

    }

    private AreaEvent GetAreaEvent(string eventName)
    {
        for(int i=0; i<possibleAreaEvents.Length; i++)
        {
            if(possibleAreaEvents[i].eventName == eventName)
            {
                return possibleAreaEvents[i];
            }
        }

        return null;
    }
}
