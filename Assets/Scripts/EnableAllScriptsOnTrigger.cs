using UnityEngine;
using System.Collections;

public class EnableAllScriptsOnTrigger : MonoBehaviour
{
    void OnTriggerEnter()
    {
        foreach (MonoBehaviour mono in gameObject.GetComponentsInParent<MonoBehaviour>())
        {
            mono.enabled = true;
        }
    }
}
