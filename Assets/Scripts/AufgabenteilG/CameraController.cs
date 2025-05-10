using System;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Camera egoCam;
    public Camera thirdPersonCam;
    public Camera topDownCam;

    private Boolean isEgo = true;
    private Boolean isThirdPerson = false;
    private Boolean isTopDown = false;



    void Start() {
        egoCam.gameObject.SetActive(isEgo);
        thirdPersonCam.gameObject.SetActive(isThirdPerson);
        topDownCam.gameObject.SetActive(isTopDown);
    }

    void Update() {

        //switch camera when space is pressed
        if (Input.GetKeyDown(KeyCode.Space)) {
            
            //switch from ego to 3rd
            if (isEgo) {
                isEgo = false;
                isThirdPerson = true;
            }
            //switch from 3rd to topdown
            else if (isThirdPerson) {
                isThirdPerson = false;
                isTopDown = true;
            }
            //switch from topdown to ego
            else {
                isTopDown = false;
                isEgo = true;
            }
            
            egoCam.gameObject.SetActive(isEgo);
            thirdPersonCam.gameObject.SetActive(isThirdPerson);
            topDownCam.gameObject.SetActive(isTopDown);

        }

    }

}
