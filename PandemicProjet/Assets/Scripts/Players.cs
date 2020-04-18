using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Players : MonoBehaviour
{

    private static Players instance;
    public static Players Instance
    {
        get
        {
          if(instance==null)
            {
                instance = FindObjectOfType<Players>();
            }
            return instance;
        }

    }

  
    [SerializeField] Text playerOne;
    [SerializeField] Text playerTwo;
    [SerializeField] Text playerOnePower;
    [SerializeField] Text playerTwoPower;
    // Start is called before the first frame update

    string[] namePlayer = new string[] { "Technician", "FightPlanner", "Analyst", "Enginner" };
    string[] PowerPlayer = new string[] { "Move two piece", "Move two cases of plane ", "RollDice more two", "RoolDice plane" };

    public  int roomStartPlayerOne;

    public  int roomStartPlayerTwo;

  
   
    void Start()
    {
        int randomOne = Random.Range(0, 4);
        int randomTwo = Random.Range(0, 4);
        while (randomTwo == randomOne)
        {
            randomTwo = Random.Range(0, 4);
        }
        playerOne.text = namePlayer[randomOne];
        playerTwo.text = namePlayer[randomTwo];
        playerOnePower.text = PowerPlayer[randomOne];
        playerTwoPower.text = PowerPlayer[randomTwo];
        roomStartPlayerOne = randomOne;
        roomStartPlayerTwo = randomTwo;
        if(randomOne == 0)
        {
            GameManager.Instance.idRoomPlayerOne = 0;
          
        }
        else if(randomOne == 1)
        {
            GameManager.Instance.idRoomPlayerOne = 3;
        }
        else if (randomOne == 2)
        {
            GameManager.Instance.idRoomPlayerOne = 2;
        }
        else if (randomOne == 3)
        {
            GameManager.Instance.idRoomPlayerOne = 5;
        }

        if (randomTwo == 0)
        {
            GameManager.Instance.idRoomPlayerTwo = 0;
        }
        else if (randomTwo == 1)
        {
            GameManager.Instance.idRoomPlayerTwo = 3;
        }
        else if (randomTwo == 2)
        {
            GameManager.Instance.idRoomPlayerTwo = 2;
        }
        else if (randomTwo == 3)
        {
            GameManager.Instance.idRoomPlayerTwo = 5;
        }



    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
