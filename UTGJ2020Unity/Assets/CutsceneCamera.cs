using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneCamera : MonoBehaviour
{

    [SerializeField] Camera cam_1;
    [SerializeField] Camera cam_2;
    [SerializeField] Camera cam_3;

    private int cameraIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam_1.transform.position = new Vector3(-2.6f, 2f, -10f);
        cam_1.GetComponent<Animator>().Play("Camera");
        cam_2.enabled = false;
        cam_3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckClick();
    }

    void CheckClick(){
        //move camera to next position
        if(Input.GetMouseButtonDown(0)){
            switch(cameraIndex){
                //show second panel (disable cam 1&3, enable cam 2)
                case 0:{
                    cam_1.enabled = false;
                    cam_2.enabled = true;
                    cam_3.enabled = false;
                    break;
                }
                //show third and final panel (disable cam 1&2, enable cam 3)
                case 1:{
                    cam_1.enabled = false;
                    cam_2.enabled = false;
                    cam_3.enabled = true;
                    break;
                }
                //switch to the main game scene
                case 2:{
                    //2 is scene index of game
                    SceneManager.LoadScene(2);
                    break;
                }
            }
            cameraIndex++;
        }
    }
}
