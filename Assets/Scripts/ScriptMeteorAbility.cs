using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMeteorAbility : MonoBehaviour
{
    public Collider coll; //move this into meteor ability script.
    [SerializeField] private float bouncingStats;

    /*
    // Start is called before the first frame update
    void Start()
    {
        //coll = GetComponent<Collider>();
        coll.material.bounciness = bouncingStats;
    }

    public void PlusBouncingStats()
    {
        bouncingStats += bouncingStats + 0.2f;
    }

    public void MinusBouncingStats()
    {
        bouncingStats += bouncingStats - 0.2f;
    }
    */
}


