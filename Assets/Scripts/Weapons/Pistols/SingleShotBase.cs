using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotBase : WeaponBase
{

    private int fullAmmoAmount;
    private int ammoLeftInMag;

    // Start is called before the first frame update
     public virtual void Start()
    {
        StartSingleShotBase();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartSingleShotBase() {
        Debug.Log("StartSingleShotBaseSTART");
    }

   protected void AttackSingleShotBase() {
        Debug.Log("AttackSingleShotBase");
    }



















}
