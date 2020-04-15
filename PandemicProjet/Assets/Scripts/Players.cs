using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Players : MonoBehaviour
{
    [SerializeField] GameObject listRoom;
    [SerializeField] Text playerOne;
    [SerializeField] Text playerTwo;
    [SerializeField] Text playerOnePower;
    [SerializeField] Text playerTwoPower;
    // Start is called before the first frame update

    string[] namePlayer = new string[] { "Technician", "FightPlanner", "Analyst", "Enginner" };
    string[] PowerPlayer = new string[] { "Move two piece", "Move two cases of plane ", "RollDice more two", "RoolDice plane" };

    void Start()
    {
        int randomOne = Random.Range(0, 4);
        int temp = Random.Range(0, 4);
        while (temp == randomOne)
        {
            temp = Random.Range(0, 4);
        }
        playerOne.text = namePlayer[randomOne];
        playerTwo.text = namePlayer[temp];
        playerOnePower.text = PowerPlayer[randomOne];
        playerTwoPower.text = PowerPlayer[temp];
        Image[] childrenRoom = listRoom.GetComponentsInChildren<Image>();
        childrenRoom[randomOne].color = Color.blue;
        childrenRoom[temp].color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
