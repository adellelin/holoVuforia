using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BioScript : MonoBehaviour {

    public GameObject BioText;
	// Use this for initialization
	void Start () {
        BioText.SetActive(false);
    }

    public void OnSelect()
    {

        BioText.SetActive(true);
    }
}
