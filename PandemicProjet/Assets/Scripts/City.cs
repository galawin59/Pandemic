using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class City : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject prefabsCardCity;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject listCity;
    [SerializeField] Sprite[] citySprite;
    [SerializeField] Sprite planeSprite;

    GameObject firstCard;
    GameObject newCard;
    GameObject[] newCardHidden = new GameObject[3];

    int[] id = new int[24];
    int[] tempId = new int[24];

    List<int> intId = new List<int>();
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        CreateCardForBeginGame(2);
        CreateCardHidden(3);
    }
    string[] nameCity = new string[] { "Tokyo","Seoul","HongKong", "Bangkok","Delhi","Karachi","Riyadh","Cairo","Istanbul","Moscow","Essen","Paris","London","Madrid",
        "Montreal","Atlanta","LosAngeles", "Mexico","Bogota","Saopaulo", "Lagos","Johannesburg","Sydney", "Manila" };

    void Start()
    {
        for (int i = 0; i < 24; i++)
        {
            intId.Add(i);
        }
        Randomize();

        CreateFirstCityCard();


    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateFirstCityCard()
    {
        Image[] childrenListCity = listCity.GetComponentsInChildren<Image>();
        firstCard = Instantiate(prefabsCardCity) as GameObject;
     
        firstCard.transform.SetParent(canvas.transform, false);
        firstCard.GetComponentInChildren<Text>().text = nameCity[id[0]];
        childrenListCity[id[0]].GetComponent<Image>().sprite = planeSprite;
        for (int i = 0; i < 24; i++)
        {
            if (i != id[0])
                childrenListCity[i].enabled = false;
        }
        Image[] childrenPref = firstCard.GetComponentsInChildren<Image>();
        for (int i = 1; i < 5; i++)
        {
            childrenPref[i].GetComponent<Image>().sprite = citySprite[Random.Range(0, 5)];
        }

        childrenPref[5].enabled = false;
        StartCoroutine(Wait());
    }

    void CreateCardForBeginGame(int nbCard)
    {
        Destroy(firstCard);
        for (int i = 0; i < nbCard; i++)
        {
            newCard = Instantiate(prefabsCardCity) as GameObject;
            newCard.transform.SetParent(canvas.transform, false);
            newCard.transform.position = new Vector3(canvas.transform.position.x + (i * 20), canvas.transform.position.y, canvas.transform.position.z - 50f);
            newCard.GetComponentInChildren<Text>().text = nameCity[id[i + 1]];
            Image[] childrenPref = newCard.GetComponentsInChildren<Image>();
            for (int j = 1; j < 5; j++)
            {
                childrenPref[j].GetComponent<Image>().sprite = citySprite[Random.Range(0, 5)];
            }

            childrenPref[5].enabled = false;
        }

    }

    void CreateCardHidden(int nbCard)
    {
        for (int i = 0; i < nbCard; i++)
        {
            int tempid = i;
            newCardHidden[i] = Instantiate(prefabsCardCity) as GameObject;
            newCardHidden[i].GetComponent<Button>().onClick.AddListener(() => OnReturnCardCity(tempid, ref newCardHidden));
            newCardHidden[i].transform.SetParent(canvas.transform, false);
            newCardHidden[i].transform.position = new Vector3(canvas.transform.position.x + ((i + 3) * 15), canvas.transform.position.y, canvas.transform.position.z - 50f);

            newCardHidden[i].GetComponentInChildren<Text>().enabled = false;
            Image[] childrenPref = newCardHidden[i].GetComponentsInChildren<Image>();
            for (int j = 1; j < 5; j++)
            {

                childrenPref[j].enabled = false;
            }

            childrenPref[5].enabled = false;

        }
    }

    void Randomize()
    {
        for (int i = 0; i < 24; i++)
        {
            int random = Random.Range(0, intId.Count);

            id[i] = intId[random];
            intId.RemoveAt(random);
        }

    }

    public void OnReturnCardCity(int idCard, ref GameObject[] go)
    {

        newCardHidden[idCard].GetComponent<Button>().onClick.RemoveAllListeners();
        newCardHidden[idCard].GetComponentInChildren<Text>().enabled = true;
        go[idCard].GetComponentInChildren<Text>().text = nameCity[id[idCard + 3]];

        Image[] childrenPref = go[idCard].GetComponentsInChildren<Image>();
        for (int j = 1; j < 5; j++)
        {
            childrenPref[j].enabled = true;
            childrenPref[j].GetComponent<Image>().sprite = citySprite[Random.Range(0, 5)];

        }

    }
}
