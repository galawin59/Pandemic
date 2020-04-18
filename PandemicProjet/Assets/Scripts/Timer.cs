using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;

    [SerializeField] Image[] TimmerAddOne;

    int timer = 120;
    bool isStart = false;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "120";
    }

    IEnumerator Wait()
    {
        while (!GameManager.Instance.isOver)
        {

            yield return new WaitForSeconds(1.0f);
            timer--;
            timerText.text = timer.ToString();
            if (timer == 0)
            {
                if (count >= 3)
                {
                    GameManager.Instance.isOver = true;
                }
                if (!GameManager.Instance.isOver)
                {
                   
                    TimmerAddOne[count].enabled = false;
                    count++;
                }
                timer = 121;


            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isStart && !isStart)
        {
            isStart = true;
            StartCoroutine(Wait());

        }
    }
}
