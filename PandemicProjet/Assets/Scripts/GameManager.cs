using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

            }
            return instance;
        }
    }
    [HideInInspector]
    [SerializeField] GameObject gameOver;
    [HideInInspector]
    public bool isPlayerOne = true;
    [HideInInspector]
    public bool needDicetoMove = false;
    [HideInInspector]
    public int countDice = 0;
    [HideInInspector]
    public Sprite[] StackDicePlayerOne = new Sprite[6];
    [HideInInspector]
    public Sprite[] StackDicePlayeTwo = new Sprite[6];
    [HideInInspector]
    public int idRoomPlayerOne = 0;
    [HideInInspector]
    public int idRoomPlayerTwo = 0;
    [HideInInspector]
    public bool[] isUseToStackPlayerOne = new bool[6];
    [HideInInspector]
    public bool[] isUseToStackPlayerTwo = new bool[6];
    [HideInInspector]
    public bool isOver = false;
    [HideInInspector]
    public bool isStart = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isOver)
        {
            gameOver.SetActive(true);
        }
    }
}
