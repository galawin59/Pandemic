using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnChangeTurn()
    {
        if (GameManager.Instance.isPlayerOne)
        {
            GameManager.Instance.isPlayerOne = false;
        }
        else
        {
            GameManager.Instance.isPlayerOne = true;
        }
        FindObjectOfType<Dice>().ResetPosition();
        FindObjectOfType<Dice>().ChangePlayer();
    }
}
