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

    public bool isPlayerOne = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
