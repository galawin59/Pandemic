using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject listRoomPlayerOne;
    [SerializeField] GameObject listRoomPlayerTwo;

    [SerializeField] Text needMove;



    int tempIdPlayerOne;
    int tempIdPlayerTwo;
    bool isBeginPlayerOne = true;
    bool isBeginPlayerTwo = true;
    int calculateNbCaseOne = 0;
    int calculateNbCaseTwo = 0;
    void Start()
    {

        Image[] childrenRoomPlayerOne = listRoomPlayerOne.GetComponentsInChildren<Image>();
        Image[] childrenRoomPlayerTwo = listRoomPlayerTwo.GetComponentsInChildren<Image>();

        childrenRoomPlayerOne[Players.Instance.roomStartPlayerOne].color = Color.blue;
        tempIdPlayerOne = Players.Instance.roomStartPlayerOne;
        for (int i = 0; i < childrenRoomPlayerTwo.Length; i++)
        {
            if (i != Players.Instance.roomStartPlayerOne)
                childrenRoomPlayerOne[i].enabled = false;
        }
        childrenRoomPlayerTwo[Players.Instance.roomStartPlayerTwo].color = Color.green;
        tempIdPlayerTwo = Players.Instance.roomStartPlayerTwo;
        for (int i = 0; i < childrenRoomPlayerTwo.Length; i++)
        {
            if (i != Players.Instance.roomStartPlayerTwo)
                childrenRoomPlayerTwo[i].enabled = false;
        }
        needMove.text = "Dice For move";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMoveToRoom(int id)
    {
        Image[] childrenRoomPlayerOne = listRoomPlayerOne.GetComponentsInChildren<Image>();
        Image[] childrenRoomPlayerTwo = listRoomPlayerTwo.GetComponentsInChildren<Image>();
        if (GameManager.Instance.isPlayerOne)
        {
            if (!isBeginPlayerOne)
            {



                calculateNbCaseOne = caculateNbPiece(tempIdPlayerOne, id);

            }
            else
                calculateNbCaseOne = caculateNbPiece(tempIdPlayerOne, id);

            FindObjectOfType<Dice>().ResetPosPlayerOneStack();

            GameManager.Instance.needDicetoMove = true;
            needMove.text = "Use " + calculateNbCaseOne.ToString() + "Dice to move";
            
            if (GameManager.Instance.countDice == calculateNbCaseOne)
            {
                tempIdPlayerOne = id;
                childrenRoomPlayerOne[id].enabled = true;
                childrenRoomPlayerOne[id].color = Color.blue;
               

                GameManager.Instance.idRoomPlayerOne = modifId(id);
               
                for (int i = 0; i < childrenRoomPlayerTwo.Length; i++)
                {
                    if (i != id)
                        childrenRoomPlayerOne[i].enabled = false;
                }
                isBeginPlayerOne = false;

                GameManager.Instance.needDicetoMove = false;
                needMove.text = "Dice For move";
            }


        }
        else
        {
            if (!isBeginPlayerTwo)
            {
                calculateNbCaseTwo = caculateNbPiece(tempIdPlayerTwo, id);

            }
            else
                calculateNbCaseTwo = caculateNbPiece(tempIdPlayerTwo, id);


            FindObjectOfType<Dice>().ResetPosPlayerTwoStack();

            GameManager.Instance.needDicetoMove = true;
            needMove.text = "Use " + calculateNbCaseTwo.ToString() + "Dice to move";
            if (GameManager.Instance.countDice == calculateNbCaseTwo)
            {
                tempIdPlayerTwo = id;
                childrenRoomPlayerTwo[id].enabled = true;
                childrenRoomPlayerTwo[id].color = Color.green;
                GameManager.Instance.idRoomPlayerTwo = modifId(id);
                for (int i = 0; i < childrenRoomPlayerTwo.Length; i++)
                {
                    if (i != id)
                        childrenRoomPlayerTwo[i].enabled = false;
                }
                isBeginPlayerTwo = false;
                GameManager.Instance.needDicetoMove = false;
                needMove.text = "Dice For move";
            }
        }


    }

    int caculateNbPiece(int idActualRoom, int idRoom)
    {
        int nbCases = 0;
        if (idActualRoom == 0)
        {
            if (idRoom == 1)
            {
                nbCases = 2;
            }
            else if (idRoom == 2)
            {
                nbCases = 2;
            }
            else if (idRoom == 3)
            {
                nbCases = 4;
            }
            else if (idRoom == 4)
            {
                nbCases = 1;
            }
            else if (idRoom == 5)
            {
                nbCases = 1;
            }
            else if (idRoom == 6)
            {
                nbCases = 3;
            }
        }
        else if (idActualRoom == 1)
        {
            if (idRoom == 0)
            {
                nbCases = 2;
            }
            else if (idRoom == 2)
            {
                nbCases = 1;
            }
            else if (idRoom == 3)
            {
                nbCases = 2;
            }
            else if (idRoom == 4)
            {
                nbCases = 2;
            }
            else if (idRoom == 5)
            {
                nbCases = 1;
            }
            else if (idRoom == 6)
            {
                nbCases = 1;
            }
        }
        else if (idActualRoom == 2)
        {
            if (idRoom == 0)
            {
                nbCases = 2;
            }
            else if (idRoom == 1)
            {
                nbCases = 1;
            }
            else if (idRoom == 3)
            {
                nbCases = 2;
            }
            else if (idRoom == 4)
            {
                nbCases = 2;
            }
            else if (idRoom == 5)
            {
                nbCases = 1;
            }
            else if (idRoom == 6)
            {
                nbCases = 1;
            }
        }
        else if (idActualRoom == 3)
        {
            if (idRoom == 0)
            {
                nbCases = 4;
            }
            else if (idRoom == 1)
            {
                nbCases = 2;
            }
            else if (idRoom == 2)
            {
                nbCases = 2;
            }
            else if (idRoom == 4)
            {
                nbCases = 4;
            }
            else if (idRoom == 5)
            {
                nbCases = 3;
            }
            else if (idRoom == 6)
            {
                nbCases = 1;
            }
        }
        else if (idActualRoom == 4)
        {
            if (idRoom == 0)
            {
                nbCases = 1;
            }
            else if (idRoom == 1)
            {
                nbCases = 2;
            }
            else if (idRoom == 2)
            {
                nbCases = 2;
            }
            else if (idRoom == 3)
            {
                nbCases = 4;
            }
            else if (idRoom == 5)
            {
                nbCases = 1;
            }
            else if (idRoom == 6)
            {
                nbCases = 3;
            }
        }
        else if (idActualRoom == 5)
        {
            if (idRoom == 0)
            {
                nbCases = 1;
            }
            else if (idRoom == 1)
            {
                nbCases = 1;
            }
            else if (idRoom == 2)
            {
                nbCases = 1;
            }
            else if (idRoom == 3)
            {
                nbCases = 3;
            }
            else if (idRoom == 4)
            {
                nbCases = 1;
            }
            else if (idRoom == 6)
            {
                nbCases = 2;
            }
        }
        else if (idActualRoom == 6)
        {
            if (idRoom == 0)
            {
                nbCases = 3;
            }
            else if (idRoom == 1)
            {
                nbCases = 1;
            }
            else if (idRoom == 2)
            {
                nbCases = 1;
            }
            else if (idRoom == 3)
            {
                nbCases = 1;
            }
            else if (idRoom == 4)
            {
                nbCases = 3;
            }
            else if (idRoom == 5)
            {
                nbCases = 2;
            }

        }
        return nbCases;
    }


    int modifId(int id)
    {
        if (id == 0)
        {
            id = 0;
        }
        else if (id == 1)
        {
            id = 3;
        }
        else if (id == 2)
        {
            id = 2;
        }
        else if (id == 4)
        {
            id = 1;
        }
        else if (id == 5)
        {
            id = 4;
        }
        return id;
    }
}
