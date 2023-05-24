using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitch : MonoBehaviour
{
    public Camera tutorialCam;
    public Camera groundCam;
    public Camera spaceCam;

    public int currentCam = 0;
    private Camera[] camList;

    // Start is called before the first frame update
    void Start()
    {
        camList = new Camera[3] {tutorialCam, groundCam, spaceCam};
        SwitchCam();
    }

    public void NextMenu() {
        currentCam++;
        SwitchCam();
    }

    public void PrevMenu() {
        currentCam--;
        SwitchCam();
    }

    private void SwitchCam() {
        for(int i = 0; i < camList.Length; i++) {
            if (i == currentCam) {
                camList[i].enabled = true;
            } else {
                camList[i].enabled = false;
            }
        }
    }
}
