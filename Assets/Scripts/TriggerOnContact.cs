using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnContact : MonoBehaviour {

    [SerializeField]
    Triggable triggeringEvent;
    [SerializeField]
    LayerMask triggeringLayers;
    [SerializeField]
    float startUpDelay;

    float timeAtStartUp;

    private void Start()
    {
        timeAtStartUp = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        // Prevent the missile from exploding when initialized in a collider
        if (Time.time - timeAtStartUp < startUpDelay)
            return;
        if (triggeringEvent != null &&
           triggeringLayers == (triggeringLayers | (1 << c.gameObject.layer)))
        {
            triggeringEvent.Trigger(c.gameObject);
        }
    }

}

public abstract class Triggable : MonoBehaviour
{
    /// <summary>
    /// Called when the event should be triggered.
    /// </summary>
    public abstract void Trigger();
    public abstract void Trigger(GameObject go);
}
