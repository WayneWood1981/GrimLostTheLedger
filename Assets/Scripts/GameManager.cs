
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("CountDown Timer")]
    public bool isThereACountDown;
    private float timer = 3;
    private float currentTimer;
    private bool playOnce = false;
   
    public ChickenCoup startCoup;

    [SerializeField] GameObject timerTextGO;
    [SerializeField] TextMeshProUGUI timerText; // Main canvas text fo countdown
    

    [Space]
    [SerializeField] Camera zoomCamera;
    [SerializeField] MouseManager mouseManager;
    [SerializeField] TextMeshProUGUI playerTurns;
    [SerializeField] TextMeshProUGUI deadGuysToHeaven;
    [SerializeField] TextMeshProUGUI sawText;
    [SerializeField] TextMeshProUGUI spikeText;
    [SerializeField] TextMeshProUGUI FlameText;
    [SerializeField] TextMeshProUGUI BoilerText;

    [SerializeField] public int _SendToHeavenNumber;
    [SerializeField] public int _sawNumber;
    [SerializeField] public int _flameNumber;
    [SerializeField] public int _spikeNumber;
    [SerializeField] public int _boilNumber;
    [SerializeField] public int deadGuyNumber;
    [SerializeField] public int lostSoul = 0;

    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip loseSound;
    private bool hasPlayedSound = false;

    [HideInInspector]
    [SerializeField] private GameObject wonUI;
    [HideInInspector]
    [SerializeField] private GameObject LostUI;

    [HideInInspector]
    public int amountOfArrows;

    [SerializeField] public int amountOfTurns;

    public int turnsLeft;

    
    [SerializeField] Texture2D chickenLeg;

    [HideInInspector]
    public bool isGameOver;

    private AudioSource audioSource;

    public int sendToHeavens = 0;
    
    public int sawTrapKills = 0;
    
    public int spikeTrapKills = 0;
    
    public int fireTrapKills = 0;
    
    public int boilerTrapKills = 0;

    // Start is called before the first frame update
    void Awake()
    {
        deadGuyNumber = _SendToHeavenNumber + _sawNumber + _flameNumber + _spikeNumber + _boilNumber;
    }

    private void Start()
    {
        currentTimer = timer;
        //Cursor.SetCursor(chickenLeg, Vector2.zero, cursorMode: CursorMode.ForceSoftware);
       // startBlock = GameObject.FindGameObjectWithTag("Start");
        timerTextGO = GameObject.FindGameObjectWithTag("Timer");
        timerText = timerTextGO.GetComponent<TextMeshProUGUI>();
       // startCoup = startBlock.GetComponent<ChickenCoup>();
        audioSource = GetComponent<AudioSource>();
        turnsLeft = amountOfTurns;
        playerTurns.text = turnsLeft.ToString();
        deadGuysToHeaven.text = _SendToHeavenNumber.ToString();
        sawText.text = _sawNumber.ToString();
        spikeText.text = _spikeNumber.ToString();
        FlameText.text = _flameNumber.ToString();
        BoilerText.text = _boilNumber.ToString();
        if (isThereACountDown)
        {
            timerText.text = "3";
        }
        else
        {
            //timerText.text = "";
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isThereACountDown)
        {
            currentTimer -= 1 * Time.deltaTime;
            int roundedFloat = Mathf.RoundToInt(currentTimer);
            timerText.text = roundedFloat.ToString();

            if (roundedFloat <= -1.0f)
            {
                if (!playOnce)
                {
                    startCoup.StartSpawning();
                    
                    playOnce = true;
                }



                timerText.text = "";
            }
        }

        playerTurns.text = turnsLeft.ToString();

        if(lostSoul > 0)
        {
            Invoke("PlayerLost", 1.0f);
        }

        if(_SendToHeavenNumber < 0 || _sawNumber < 0 || _flameNumber < 0 || _spikeNumber < 0 || _boilNumber < 0)
        {
            Invoke("PlayerLost", 1.0f);
        }

        if(deadGuyNumber == 0)
        {
            isGameOver = true;

            if (hasPlayerWon())
            {
                PlayerWon();
            }
            else
            {
                PlayerLost();
            }

        }


    }

    

    private void PlayerWon()
    {
        zoomCamera.GetComponent<CameraZoomAway>().zoomAway = true;
        wonUI.SetActive(true);
        if (!hasPlayedSound)
        {
            audioSource.PlayOneShot(winSound);
            hasPlayedSound = true;
        }
    }

    private void PlayerLost()
    {
        zoomCamera.GetComponent<CameraZoomAway>().zoomAway = true;
        LostUI.SetActive(true);
        if (!hasPlayedSound)
        {
            audioSource.PlayOneShot(loseSound);
            hasPlayedSound = true;
        }
    }

    public void UpdateTextMeshPros()
    {
        deadGuysToHeaven.text = _SendToHeavenNumber.ToString();
        sawText.text = _sawNumber.ToString();
        spikeText.text = _spikeNumber.ToString();
        FlameText.text = _flameNumber.ToString();
        BoilerText.text = _boilNumber.ToString();
    }

    private bool hasPlayerWon()
    {
        if (_SendToHeavenNumber == 0 && _sawNumber == 0 && _spikeNumber == 0 && _flameNumber == 0 && _boilNumber == 0)
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
