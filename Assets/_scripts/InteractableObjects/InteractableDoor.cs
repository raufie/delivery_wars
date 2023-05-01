using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor: InteractableBase {

    

    // constructor
    public InteractableDoor (GameObject Subject): base(Subject){
        
    }
    public override void PerformAction(int signal){
            Subject.GetComponent<Door>().Open();
    }
}
