using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour {

    GameObject target;

    enum TargetType { Enemies, Allied, PlayerOnly };

    [SerializeField]
    TargetType targetType;
    [SerializeField]
    float delay;

    float timeAtLastSearch;

    public GameObject Target
    {
        get
        {
            return target;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(target == null && Time.time - timeAtLastSearch > delay)
        {
            FindTarget();
        }
	}

    void FindTarget()
    {
        timeAtLastSearch = Time.time;

        GameObject[] possibleTargets = new GameObject[0];
        switch (targetType)
        {
            case TargetType.Enemies:
                possibleTargets = ObjectManager.Instance.AllEnemies;
                break;
            case TargetType.Allied:
                possibleTargets = ObjectManager.Instance.AllAllies;
                break;
            case TargetType.PlayerOnly:
                possibleTargets = new GameObject[] { ObjectManager.Instance.Player };
                break;
            default:
                break;
        }
        if(possibleTargets.Length == 0 || possibleTargets[0] == null)
        {
            return;
        }
        // Find the closes target
        GameObject newTarget = possibleTargets[0];
        var targetDistance = Vector2.Distance(newTarget.transform.position, this.transform.position);
        for(int i = 0; i < possibleTargets.Length; i++)
        {
            var dis = Vector2.Distance(possibleTargets[i].transform.position, this.transform.position);
            if(dis < targetDistance)
            {
                newTarget = possibleTargets[i];
                targetDistance = dis;
            }
        }
        target = newTarget;
    }
}
