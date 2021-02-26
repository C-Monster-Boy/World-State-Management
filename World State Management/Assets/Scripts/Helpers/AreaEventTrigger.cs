/*
 * Author: Anuj
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEventTrigger : MonoBehaviour
{
    public string areaEventToTrigger;

    public void TriggerAreaEvent()
    {
        FindObjectOfType<AreaStateManager>().InvokeAreaEvent(areaEventToTrigger);
    }

    public void DestoryTrigger()
    {
        Destroy(transform.parent.gameObject);
    }
}
