using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableRocket: InteractableBase {

    

    // constructor
    public InteractableRocket (GameObject Subject): base(Subject){
        
    }
    public override void PerformAction(int signal){
            Subject.GetComponent<Rocket>().FireUp();
    }
}
