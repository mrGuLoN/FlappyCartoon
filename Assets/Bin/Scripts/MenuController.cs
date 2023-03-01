using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Scrollbar music, world;
    [SerializeField] private CanvasController CCont;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CCont.SetVolume(music.value, world.value);
    }

    public void Exit()
    {
        Application.Quit();  
    }

    public void Close()
    {
        PlayerPrefs.SetFloat("Music", music.value);
        PlayerPrefs.SetFloat("World", world.value);
        this.gameObject.SetActive(false);
    }
}
