using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera zoomCamera;
    [SerializeField] MouseManager mouseManager;
    [SerializeField] TextMeshProUGUI playerTurns;

    [SerializeField] public int _SendToHeavenNumber;
    [SerializeField] public int _sawNumber;
    [SerializeField] public int _flameNumber;
    [SerializeField] public int _spikeNumber;
    [SerializeField] public int _boilNumber;
    [SerializeField] public int deadGuyNumber;

    [HideInInspector]
    [SerializeField] private GameObject wonUI;
    [HideInInspector]
    [SerializeField] private GameObject LostUI;

    [HideInInspector]
    public int amountOfArrows;

    [SerializeField] public int amountOfTurns;

    public int turnsLeft;

    [HideInInspector]
    [SerializeField] Texture2D chickenLeg;

    [HideInInspector]
    public bool isGameOver;

    [HideInInspector]
    public int sendToHeavens = 0;
    [HideInInspector]
    public int sawTrapKills = 0;
    [HideInInspector]
    public int spikeTrapKills = 0;
    [HideInInspector]
    public int fireTrapKills = 0;
    [HideInInspector]
    public int boilerTrapKills = 0;

    // Start is called before the first frame update
    void Awake()
    {
        deadGuyNumber = _SendToHeavenNumber + _sawNumber + _flameNumber + _spikeNumber + _boilNumber;
    }

    private void Start()
    {
        Cursor.SetCursor(chickenLeg, Vector2.zero, cursorMode: CursorMode.ForceSoftware);
        
        turnsLeft = amountOfTurns;
        playerTurns.text = turnsLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        playerTurns.text = turnsLeft.ToString();
        
        if(deadGuyNumber == 0)
        {
            isGameOver = true;
            if (hasPlayerWon())
            {
                zoomCamera.GetComponent<CameraZoomAway>().zoomAway = true;
                wonUI.SetActive(true);
            }
            else
            {
                zoomCamera.GetComponent<CameraZoomAway>().zoomAway = true;
                LostUI.SetActive(true);
            }

        }
    }

    private bool hasPlayerWon()
    {
        if (sawTrapKills == _sawNumber && fireTrapKills == _flameNumber && spikeTrapKills == _spikeNumber && boilerTrapKills == _boilNumber && _SendToHeavenNumber == sendToHeavens)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
