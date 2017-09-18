using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private void Start()
    {
        ObjectManager.Instance.AddEnemy(this.gameObject);
    }

    private void OnDestroy()
    {
        ObjectManager.Instance.RemoveEnemy(this.gameObject);
    }
}
