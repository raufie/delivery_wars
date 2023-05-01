using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    public float initialZoom;
    // Start is called before the first frame update
    void Start()
    {
        initialZoom = vCam.m_Lens.OrthographicSize;

        // initialY
    }

    public void ZoomOut(){
        vCam.m_Lens.OrthographicSize = 75f;
    }
    public void ResetZoom(){
        vCam.m_Lens.OrthographicSize = initialZoom;
    }
    public void UpdateCam(Transform _transform){
    
        vCam.Follow = _transform;
        vCam.LookAt = _transform;
     }
}
