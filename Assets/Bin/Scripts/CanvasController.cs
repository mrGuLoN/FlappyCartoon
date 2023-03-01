using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Text textScore, stageInt;
    [SerializeField] private GameObject _deadImage, startButton, menu;
    [SerializeField] private int stageUpScore;
    public AudioSource music, win, loos;

    public delegate void StageUp();
    public static event StageUp _stageUp;
    private int _score;
    private int _stageInt = 1;
    // Start is called before the first frame update
    void Start()
    {
        _deadImage.SetActive(false);
        menu.SetActive(false);
        _score = 0;
        ScoreUp._scoreUp += ScoreUpping;
        DeadZone._deadZ += Dead;
        textScore.text = _score.ToString();
        stageInt.text = _stageInt.ToString();
        SetVolume(PlayerPrefs.GetFloat("Music"), PlayerPrefs.GetFloat("World"));
    }

    // Update is called once per frame
    public void ScoreUpping()
    {
        _score++;
        if (_score >= stageUpScore)
        {
            stageUpScore -= _score;
            _stageUp();
            _stageInt++;
            stageInt.text = _stageInt.ToString();
        }
        textScore.text = _score.ToString();
        win.Play();
    }

    public void Dead()
    {
        _deadImage.SetActive(true);
        startButton.SetActive(true);
        music.Stop();
        loos.Play();
    }

    public void StartGame()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Rigidbody2D>().gravityScale = 0.4f;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<PlayerController>()._live = true;
        Transform playerTR = player.transform;
        playerTR.position = new Vector3(playerTR.position.x, 0, playerTR.position.z);

        GameObject.FindGameObjectWithTag("Bulder").GetComponent<BricksBilder>().enabled = true;
        GameObject.FindGameObjectWithTag("Bulder").GetComponent<BricksBilder>().NewGame();

        startButton.SetActive(false);
        _deadImage.SetActive(false);
        _score = 0;
        textScore.text = "0";
        _stageInt = 0;
        stageInt.text = _stageInt.ToString();
        music.Play();
    }

    public void SetVolume(float musicV, float stage)
    {
        music.volume = musicV;
        loos.volume = stage;
        win.volume = stage;
    }

    public void MenuOpen()
    {
        menu.SetActive(true);
    }
}
