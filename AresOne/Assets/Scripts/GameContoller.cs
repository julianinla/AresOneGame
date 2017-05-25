using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameContoller : MonoBehaviour {

    public static GameContoller Instance;
    public bool keyPressed;

    private GameObject levelImage;
    private Text mainText;
    private GameObject endScreen;
    private Text endText;
    private Text startText;
    private Text text;
    private bool settingUpGame;
    private bool firstLevel = true;
    private bool spaceClicked;
    private int secondsUntilLevelStart = 2;

	void Awake () {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
	}
	
	void Start () {
        InitializeGame();
	}

    private void DisableLevelImage()
    {
        levelImage.SetActive(false);
    }

    private void InitializeGame()
    {
        settingUpGame = true;
        levelImage = GameObject.Find("Level Image");
        mainText = GameObject.Find("Main Text").GetComponent<Text>();
        startText = GameObject.Find("Start Text").GetComponent<Text>();
        endScreen = GameObject.Find("End Screen");
        //endText = GameObject.Find("End Text").GetComponent<Text>();
        //endScreen.SetActive(false);
        levelImage.SetActive(true);
        if (!firstLevel)
        {
            levelImage.SetActive(false);
            firstLevel = false;
        }
        Invoke("DisableStartScreen", secondsUntilLevelStart);
    }

    private void DisableStartScreen()
    {
        if (spaceClicked)
        {
            levelImage.SetActive(false);
            firstLevel = false;
            Debug.Log("SpacePressed");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            spaceClicked = true;
        }
        if (!firstLevel && Application.loadedLevel == 0)
        {
            levelImage.SetActive(false);
            firstLevel = false;
        }
        return;
    }
}
