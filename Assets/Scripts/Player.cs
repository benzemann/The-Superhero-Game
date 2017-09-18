using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private void Start()
    {
        ObjectManager.Instance.Player = this.gameObject;
    }

    private void OnDestroy()
    {
        ObjectManager.Instance.RemovePlayer(this.gameObject);
    }

}
