/*
 * Author: Anuj
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmilieAnimationPlayer : MonoBehaviour
{
    public string animationTriggerName;

    public void PlayAnimation()
    {
        GetComponent<Animator>().SetTrigger(animationTriggerName);
    }
}
