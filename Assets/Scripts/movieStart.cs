using UnityEngine;
using System.Collections;

public class movieStart : MonoBehaviour
{

    public bool loop;
    Renderer r;
    MovieTexture moviePlayer;

    // Use this for initialization
    void Start()
    {
        r = GetComponent<Renderer>();
        moviePlayer = (MovieTexture)r.material.mainTexture;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnSelect()
    {
        
        moviePlayer.Play();

    }

    public void PlayMovie()
    { 
        moviePlayer.Play();
        moviePlayer.loop = true;
    }

    public void PauseMovie()
    {
        Start();
        moviePlayer.Pause();
      
    }
}
