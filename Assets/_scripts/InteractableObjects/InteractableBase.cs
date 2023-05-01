using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase {

    public GameObject Subject;

    // constructor
    public InteractableBase (GameObject Subject){
        this.Subject = Subject;
    }
    public virtual void PerformAction(int signal){
            Debug.Log("signal Received"+signal);
    }
}
