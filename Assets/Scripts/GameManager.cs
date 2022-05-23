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

    [SerializeField] public int _sawNumber;
    [SerializeField] public int _flameNumber;
    [SerializeField] public int _spikeNumber;
    [SerializeField] public int _boilNumber;
    [SerializeField] public int chickenNumber;

    [SerializeField] private GameObject wonUI;
    [SerializeField] private GameObject LostUI;

    public int amountOfArrows;

    [SerializeField] public int amountOfTurns;

    public int turnsLeft;

    [SerializeField] Texture2D chickenLeg;

    public bool isGameOver;

    public int sawTrapKills = 0;
    public int spikeTrapKills = 0;
    public int fireTrapKills = 0;
    public int boilerTrapKills = 0;

    // Start is called before the first frame update
    void Awake()
    {
        
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
        Debug.Log(sawTrapKills);
        if(chickenNumber == 0)
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
        if (sawTrapKills == _sawNumber && fireTrapKills == _flameNumber && spikeTrapKills == _spikeNumber && boilerTrapKills == _boilNumber)
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
