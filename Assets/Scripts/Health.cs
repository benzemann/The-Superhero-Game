using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField]
    float maxHp;
    
    public float MaxHp { get { return maxHp; } private set { maxHp = value; } }
    public float Hp { get; private set; }

	// Use this for initialization
	void Start () {
        Hp = MaxHp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Reduces the health with the given damage amount
    /// </summary>
    /// <param name="dam"></param>
    public void Damage(float dam)
    {
        Hp -= dam;
        if(Hp < 0f)
        {
            Hp = 0f;
        }
    }

}
