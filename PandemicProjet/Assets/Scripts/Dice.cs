using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite[] blueDice;
    [SerializeField] Sprite[] greenDice;

    [SerializeField] GameObject[] imageOne;
    [SerializeField] GameObject[] buttonDice;



    bool[] isClick = new bool[6];
    bool[] isClickToMove = new bool[6];

    bool iskeep = false;
    int maxNbDice = 6;

    int maxRoolDice = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnRollDice()
    {
        for (int i = 0; i < maxNbDice; i++)
        {
            if (!isClick[i] && maxRoolDice < 3)
            {

                if (GameManager.Instance.isPlayerOne)
                {
                    imageOne[i].GetComponent<Image>().sprite = blueDice[Random.Range(0, 6)];
                    GameManager.Instance.isStart = true;

                }
                else
                {
                    imageOne[i].GetComponent<Image>().sprite = greenDice[Random.Range(0, 6)];
                }
            }

        }
        maxRoolDice++;
        if (maxRoolDice >= 3)
        {
            ResetPosition();
            iskeep = true;
        }
    }

    public void OnClick(int id)
    {
        if (!GameManager.Instance.needDicetoMove)
        {
            if (!iskeep)
            {
                isClick[id] = true;

                ChangePositionDice(id);

            }
            else
            {
                if (GameManager.Instance.isPlayerOne)
                {

                    GameManager.Instance.StackDicePlayerOne[id] = imageOne[id].GetComponent<Image>().sprite;
                    GameManager.Instance.isUseToStackPlayerOne[id] = true;
                    ChangePositionDice(id);

                }
                else
                {
                    GameManager.Instance.StackDicePlayeTwo[id] = imageOne[id].GetComponent<Image>().sprite;
                    GameManager.Instance.isUseToStackPlayerTwo[id] = true;
                    ChangePositionDice(id);
                }


            }
        }
        else
        {
            if (!isClickToMove[id])
            {
                isClickToMove[id] = true;
                ChangePositionDiceForMove(id);
                GameManager.Instance.countDice++;
            }

        }

    }

    void ChangePositionDice(int id)
    {

        if (!isClickToMove[id])
            buttonDice[id].GetComponent<RectTransform>().position = new Vector3(buttonDice[id].GetComponent<RectTransform>().position.x, buttonDice[id].GetComponent<RectTransform>().position.y, -47.267f);
    }
    void ChangePositionDiceForMove(int id)
    {
        
        buttonDice[id].GetComponent<RectTransform>().position = new Vector3(buttonDice[id].GetComponent<RectTransform>().position.x, buttonDice[id].GetComponent<RectTransform>().position.y, -40.267f);
    }
    public void ResetPosition()
    {
        for (int i = 0; i < maxNbDice; i++)
        {
            if (!isClickToMove[i])
            {
                buttonDice[i].GetComponent<RectTransform>().position = new Vector3(buttonDice[i].GetComponent<RectTransform>().position.x, buttonDice[i].GetComponent<RectTransform>().position.y, -54.267f);
                isClick[i] = false;
            }
        }
        if (!GameManager.Instance.needDicetoMove)
        {
            GameManager.Instance.countDice = 0;
        }
    }
    public void ChangePlayer()
    {
        for (int i = 0; i < maxNbDice; i++)
        {
            imageOne[i].GetComponent<Image>().sprite = null;
            isClickToMove[i] = false;
            maxRoolDice = 0;
            iskeep = false;
        }
    }

    public void ResetPosPlayerOneStack()
    {
        for (int i = 0; i < maxNbDice; i++)
        {
            if (!isClickToMove[i] && !GameManager.Instance.isUseToStackPlayerOne[i])
            {
                buttonDice[i].GetComponent<RectTransform>().position = new Vector3(buttonDice[i].GetComponent<RectTransform>().position.x, buttonDice[i].GetComponent<RectTransform>().position.y, -54.267f);
                isClick[i] = false;
            }
        }
        if (!GameManager.Instance.needDicetoMove)
        {
            GameManager.Instance.countDice = 0;
        }
    }
    public void ResetPosPlayerTwoStack()
    {
        for (int i = 0; i < maxNbDice; i++)
        {
            if (!isClickToMove[i] && !GameManager.Instance.isUseToStackPlayerTwo[i])
            {
                buttonDice[i].GetComponent<RectTransform>().position = new Vector3(buttonDice[i].GetComponent<RectTransform>().position.x, buttonDice[i].GetComponent<RectTransform>().position.y, -54.267f);
                isClick[i] = false;
            }
        }
        if (!GameManager.Instance.needDicetoMove)
        {
            GameManager.Instance.countDice = 0;
        }
    }



}
