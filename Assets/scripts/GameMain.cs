using UnityEngine;
using System.Collections;
using DG.Tweening;

public class GameMain : MonoBehaviour {

    public GameObject bird;
    public GameObject readyPic;
    public GameObject tipPic;
    public GameObject scoreMgr;
    public GameObject pipeSpawner;
   

    private bool gameStarted = false;

    public bool is3D=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameStarted && Input.GetButtonDown("Fire1") && !is3D)
        {
            gameStarted = true;
            StartGame();
        }
    }

    public void OnButtonPushed()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            StartGame();
        }
    }


    private void StartGame()
    {
        Debug.Log("Function Runing");

        BirdControl control = bird.GetComponent<BirdControl>();
        // Added by jameel Qureshi to remove the error of dying before start
        control.canTriggerEnter = true;


        control.inGame = true;
        control.JumpUp();

        readyPic.GetComponent<SpriteRenderer>().material.DOFade(0f, 0.2f);
        tipPic.GetComponent<SpriteRenderer>().material.DOFade(0f, 0.2f);

        scoreMgr.GetComponent<ScoreMgr>().SetScore(0);
        pipeSpawner.GetComponent<PipeSpawner>().StartSpawning();
    }
}
