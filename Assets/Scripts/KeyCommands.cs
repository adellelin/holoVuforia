using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyCommands : MonoBehaviour {

    public Text ToniDoveBio;

    // called by gazegesturemanager
    public void OnSelect()
    {
        SceneManager.LoadScene("ToniDove");
        ToniDoveBio.text = "Toni Dove Bio ";
    }
}
