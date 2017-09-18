using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager> {

    List<GameObject> enemies;
    List<GameObject> allies;
    GameObject player;

    public GameObject Player { get { return player; }
        set
        {
            if (!allies.Contains(value))
            {
                allies.Add(value);
            }
            player = value;
        }
    }
    public GameObject[] AllEnemies { get { return enemies.ToArray(); } }
    public GameObject[] AllAllies { get { return allies.ToArray(); } }

    // Use this for initialization
    void Awake () {
        enemies = new List<GameObject>();
        allies = new List<GameObject>();
	}

    public void AddEnemy(GameObject enemy)
    {
        if(!enemies.Contains(enemy))
            enemies.Add(enemy);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
        }
    }

    public void RemovePlayer(GameObject p)
    {
        if (allies.Contains(p))
        {
            allies.Remove(p);
        }
        player = null;
    }
}
