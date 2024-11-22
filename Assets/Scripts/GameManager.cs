using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//oyunu yöneten kodlar 
public class GameManager : MonoBehaviour
{
    public Camera _camera;
    public GameObject firstObject;
    public GameObject secondObject;
    public int ObjectCount = 0;
    public int Score = 0;
    public TextMeshProUGUI ScoreText;

    public MainMenu menu;

    public List<GameObject> Prefabs;
    public List<Transform> SpawnPositions;
    // Start is called before the first frame update
    public void InitalizeScene()
    {
        foreach (GameObject obj in Prefabs)
        {
            for (int i = 0; i < 2; i++) 
            {
                var RandomPos = SpawnPositions[Random.RandomRange(0, SpawnPositions.Count)];
                var SpawnedObject = Instantiate(obj, RandomPos.position, Quaternion.identity);
                SpawnedObject.GetComponent<ModelProperties>().manager = this;
                ObjectCount++;
            }
        }
        Score = 0;
        ScoreText.text = "Score : 0";
        ScoreText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ModelProperties>() != null) 
        {
            if (firstObject == null)
            {
                firstObject = other.gameObject;
            }
            else if (secondObject == null && firstObject != null)
            {
                secondObject = other.gameObject;
                var firstConf = firstObject.GetComponent<ModelProperties>();
                var secondConf = secondObject.GetComponent<ModelProperties>();
                if(firstConf.id == secondConf.id)
                {
                    Destroy(firstObject);
                    Destroy(secondObject);
                    firstObject = null;
                    secondObject = null;
                    Score += 100;
                    ScoreText.text = "Score : " + Score.ToString();
                    ObjectCount -= 2;
                    if(ObjectCount == 0)
                    {
                        menu.GameOver.SetActive(true);
                    }
                }
                else
                {
                    Debug.Log("Eþleþme Baþarýsýz");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<ModelProperties>() != null)
        {
            if (firstObject != null && other.gameObject.GetInstanceID() == firstObject.GetInstanceID())
            {
                firstObject = null;
            } 
            if(secondObject != null && other.gameObject.GetInstanceID() == secondObject.GetInstanceID())
            {
                secondObject = null;
            }
        }
    }

}
