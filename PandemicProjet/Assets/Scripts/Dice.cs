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
    int maxNbDice = 6;
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
            if (!isClick[i])
            {

                if (GameManager.Instance.isPlayerOne)
                {
                    imageOne[i].GetComponent<Image>().sprite = blueDice[Random.Range(0, 6)];

                }
                else
                {
                    imageOne[i].GetComponent<Image>().sprite = greenDice[Random.Range(0, 6)];
                }
            }

        }

    }

    public void OnClick(int id)
    {
        isClick[id] = true;
        ChangePositionDice(id);
    }

    void ChangePositionDice(int id)
    {
        buttonDice[id].GetComponent<RectTransform>().position = new Vector3(buttonDice[id].GetComponent<RectTransform>().position.x, 80f, 0f);
    }
    public void ResetPosition()
    {
        for (int i = 0; i < maxNbDice; i++)
        {

            buttonDice[i].GetComponent<RectTransform>().position = new Vector3(buttonDice[i].GetComponent<RectTransform>().position.x, 30f, 0f);
            isClick[i] = false;
        }
    }
    public void ChangePlayer()
    {
        for (int i = 0; i < maxNbDice; i++)
        {
            imageOne[i].GetComponent<Image>().sprite = null;
        }
    }
}
