/*
 * Author: Anuj
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEventTrigger : MonoBehaviour
{
    public string worldEventName;

    public void TriggerWorldEvent()
    {
        WorldStateManager.InvokeWorldEvent(worldEventName);
    }

    public void DestoryTrigger()
    {
        Destroy(transform.parent.gameObject);
    }
}
