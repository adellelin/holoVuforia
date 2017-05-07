using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitZoneManagerToni : MonoBehaviour
{

    public Text exitText;
    public GameObject MovieBottom;
    public GameObject ToniDoveStudio;
    public GameObject KeyScene;
    public GazeGestureManager keySceneGaze;
    public GameObject exitActivationZonePosition;
    float exitActivationZoneOffset;

    void Start()
    {
        Debug.Log("Logging Collision script");
    }

    void checkIfInExitZone()
    {
        exitActivationZoneOffset = Vector3.Distance(transform.position, exitActivationZonePosition.transform.position);
        //Debug.Log("sculptureoffset: "+sculptureActivationZoneOffset);
        if (Mathf.Abs(exitActivationZoneOffset) < 3.3f)
        {
            exitScene();
        }
    }
   
        
        
    void OnTriggerEnter(Collider CollisionCube)
    {
        exitScene();
    }
    public void OnSelect()
    {
        exitScene();
    }

    void exitScene()
    {
        Debug.Log("Went through the exit");
        Renderer render = GetComponent<Renderer>();

        //render.material.color = Color.cyan;
        //SceneManager.LoadScene("VuforiaTest");
        //exitText.text = "exited";
        MovieBottom.SetActive(false);
        ToniDoveStudio.SetActive(false);
        KeyScene.SetActive(true);
        keySceneGaze.enabled = true;
    }
}
