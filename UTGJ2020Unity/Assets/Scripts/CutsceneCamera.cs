using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Authored by Mason Eastman
public class CutsceneCamera : MonoBehaviour
{

    [SerializeField] Camera cam_1;


    // Start is called before the first frame update
    void Start()
    {
        cam_1.transform.position = new Vector3(-2.6f, 2f, -10f);
        cam_1.GetComponent<Animator>().Play("Camera");
        Invoke("LoadGame", 12);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadGame(){
        Debug.Log("Loading game scene");
        SceneManager.LoadScene(2);
    }
}
