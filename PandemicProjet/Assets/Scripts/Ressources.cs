using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ressources : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject plane;

    [SerializeField] GameObject[] ressources;


    [SerializeField] Sprite[] greenDice;
    [SerializeField] Sprite[] blueDice;

    [SerializeField] Sprite[] supplyCrate;

    string[] nameDicePlayerOne = new string[] { "BlueAid", "BlueWater", "BlueFood", "BluePower", "BlueVaccine" };
    string[] nameDicePlayerTwo = new string[] { "GreenAid", "GreenWater", "GreenFood", "GreenPower", "GreenVaccine" };
    bool[,] isStack;
    void Start()
    {
        isStack = new bool[6, 6];
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStackRessources(int id)
    {
        Image[] childrenRessources = ressources[id].GetComponentsInChildren<Image>();

        InitStackRessourcesForExeption();

        for (int i = 0; i < 6; i++)
        {


            if (!GameManager.Instance.isPlayerOne)
            {

               

                if (GameManager.Instance.StackDicePlayeTwo[i].name == nameDicePlayerTwo[id] && GameManager.Instance.idRoomPlayerTwo == id)
                {
                   
                    for (int j = 0; j < 6; j++)
                    {
                       
                        if (childrenRessources[j].sprite == null )
                        {
                            childrenRessources[j].sprite = greenDice[id];
                          
                            break;
                        }
                    }

                    GameManager.Instance.StackDicePlayeTwo[i] = null;

                    break;
                }


            }
            else
            {
              

                if (GameManager.Instance.StackDicePlayerOne[i].name == nameDicePlayerOne[id] && GameManager.Instance.idRoomPlayerOne == id)
                {
                  
                    for (int j = 0; j < 6; j++)
                    {
                      
                        if (childrenRessources[j].sprite == null )
                        {
                            childrenRessources[j].sprite = blueDice[id];
                        
                            break;
                        }
                    }

                    GameManager.Instance.StackDicePlayerOne[i] = null;

                    break;
                }


            }


        }

    }
    public void OnSendRessources(int id)
    {
        int count = 0;
        int result = 0;
        int nbRessources = 0;
        int countPlane = 0;
        Image[] childrenRessources = ressources[id].GetComponentsInChildren<Image>();
        Image[] childrenPlane = plane.GetComponentsInChildren<Image>();
        for (int i = 0; i < childrenRessources.Length; i++)
        {
            if (childrenRessources[i].GetComponent<Image>().sprite == null)
            {
                count++;
            }
        }
        result = childrenRessources.Length - count;

        if (id == 0)
        {
            if (result == 3)
            {
                nbRessources = 1;
            }
            if (result == 4)
            {
                nbRessources = 2;
            }
            if (result == 5)
            {
                nbRessources = 3;
            }
        }
        else if (id == 1)
        {
            if (result == 3)
            {
                nbRessources = 2;
            }
            if (result == 5)
            {
                nbRessources = 3;
            }

        }
        else if (id == 2)
        {
            if (result == 3)
            {
                nbRessources = 1;
            }

            if (result == 5)
            {
                nbRessources = 3;
            }
        }
        else if (id == 3)
        {
            if (result == 3)
            {
                nbRessources = 1;
            }
            if (result == 4)
            {
                nbRessources = 2;
            }
            if (result == 5)
            {
                nbRessources = 3;
            }
        }
        else if (id == 4)
        {

            if (result == 4)
            {
                nbRessources = 2;
            }
            if (result == 5)
            {
                nbRessources = 3;
            }
        }


        for (int i = 0; i < childrenPlane.Length; i++)
        {
            if (childrenPlane[i].GetComponent<Image>().sprite != null)
            {
                countPlane++;
            }
        }

        for (int i = countPlane; i < countPlane + nbRessources; i++)
        {
            if (countPlane + nbRessources <= childrenPlane.Length)
            {
                childrenPlane[i].sprite = supplyCrate[id];
            }
        }
        ResetRessourcesStack(childrenRessources);
        ResetStack(id);
    }

    void InitStackRessourcesForExeption()
    {
        if (!GameManager.Instance.isPlayerOne)
        {
            for (int j = 0; j < GameManager.Instance.StackDicePlayeTwo.Length; j++)
            {
                if (GameManager.Instance.StackDicePlayeTwo[j] == null)
                {
                    GameManager.Instance.StackDicePlayeTwo[j] = supplyCrate[0];
                }
            }
        }
        else
        {
            for (int j = 0; j < GameManager.Instance.StackDicePlayerOne.Length; j++)
            {

                if (GameManager.Instance.StackDicePlayerOne[j] == null)
                {
                    GameManager.Instance.StackDicePlayerOne[j] = supplyCrate[0];
                }
            }
        }
    }

    void ResetRessourcesStack(Image[] childrenRessources)
    {
        for (int i = 0; i < childrenRessources.Length; i++)
        {
            childrenRessources[i].GetComponent<Image>().sprite = null;

        }
    }

    void ResetStack(int id)
    {
        for (int i = 0; i <6; i++)
        {

            isStack[id, i] = false;

        }
    }
}
