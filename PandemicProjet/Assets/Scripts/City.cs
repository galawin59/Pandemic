using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class City : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject prefabsCardCity;
    [SerializeField] GameObject canvas;
    [SerializeField] Sprite[] citySprite;
    [SerializeField] GameObject listCity;
    [SerializeField] Sprite planeSprite;
    enum NameCity
    {
        Tokyo,
        Seoul,
        HongKong,
        Bangkok,
        Delhi,
        Karachi,
        Riyadh,
        Cairo,
        Istanbul,
        Moscow,
        Essen,
        Paris,
        London,
        Madrid,
        Montreal,
        Atlanta,
        LosAngeles,
        Mexico,
        Bogota,
        Saopaulo,
        Lagos,
        Johannesburg,
        Sydney,
        Manila
    }
    string[] nameCity = new string[] { "Tokyo","Seoul","HongKong", "Bangkok","Delhi","Karachi","Riyadh","Cairo","Istanbul","Moscow","Essen","Paris","London","Madrid",
        "Montreal","Atlanta","LosAngeles", "Mexico","Bogota","Saopaulo", "Lagos","Johannesburg","Sydney", "Manila" };

    void Start()
    {

        CreateCityCard();
       
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateCityCard()
    {
        Image[] childrenListCity = listCity.GetComponentsInChildren<Image>();
        GameObject newButton = Instantiate(prefabsCardCity) as GameObject;
        newButton.transform.SetParent(canvas.transform, false);
        int random = Random.Range(0, 24);
        newButton.GetComponentInChildren<Text>().text = nameCity[random];
        childrenListCity[random].GetComponent<Image>().sprite = planeSprite;
        for (int i = 0; i < 24; i++)
        {
            if(i!=random)
            childrenListCity[i].enabled = false;
        }
        Image[] childrenPref = newButton.GetComponentsInChildren<Image>();
        for (int i = 1; i <4; i++)
        {
            childrenPref[i].GetComponent<Image>().sprite = citySprite[Random.Range(0,5)];
        }
        childrenPref[5].GetComponent<Image>().sprite = citySprite[Random.Range(0, 5)];
        childrenPref[4].enabled = false;
    }
}
