using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol1 : SingleShotBase
{
    // Start is called before the first frame update
    void Start()
    {   
        base.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void BaseAttack() {
        AttackSingleShotBase();
    }
}
