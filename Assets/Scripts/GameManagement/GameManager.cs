using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/* Manage main logic of the game: Initialize, win/lose, reset */
public class GameManager : MonoBehaviour
{
    public int numberOfBottles;
    public GameObject[] bottlePrefabs;
    public GameObject[] sampleBottles;
    public GameObject[] playedBottles;

    public float distanceBetweenBottles = 2f;
    public float sampleBottlesPosition = -2f;
    public float playedBottlesPosition = 2f;
    public float selectedBottleHeightOffset = 1f; // UI bottle selected

    private HashSet<string> createdBottleNames = new HashSet<string>(); // Track created bottles
    private GameObject firstSelectedBottle = null; 
    private GameObject secondSelectedBottle = null;

    private BottleEvent bottleEvent;

    void Start()
    {
        InitializeBottles();
        ShufflePlayedBottles();
        bottleEvent = new BottleEvent(selectedBottleHeightOffset);
    }

    // Update is called once per frame
    void Update()
    {
        // Check mouse click on bottle
        if (Input.GetMouseButtonDown(0)) // 0 is left click
        {
            DetectBottleClick();
        }

        if (Input.GetKeyDown(KeyCode.C)) // Nhan phim 'C' de kiem tra
        {
            int matchedBottles = CountMatchedBottles();
            Debug.Log("Matched bottles: " + matchedBottles);
        }
    }

    void InitializeBottles()
    {
        sampleBottles = new GameObject[numberOfBottles];
        playedBottles = new GameObject[numberOfBottles];
        
        // Starting point of bottles array
        float startingX = -((numberOfBottles - 1) * distanceBetweenBottles) / 2;

        
        for (int i = 0; i < numberOfBottles;)
        {
            GameObject bottle = bottlePrefabs[Random.Range(0, bottlePrefabs.Length)];

            if (!createdBottleNames.Contains(bottle.name))
            {
                // vi tri cua bottle
                Vector3 spawnPosition1 = new Vector3(startingX + i * distanceBetweenBottles, sampleBottlesPosition, 0f);
                Vector3 spawnPosition2 = new Vector3(startingX + i * distanceBetweenBottles, playedBottlesPosition, 0f);

               
                GameObject sampleBottle = Instantiate(bottle, spawnPosition1, Quaternion.identity);
                sampleBottle.name = bottle.name; 

                
                GameObject playedBottle = Instantiate(bottle, spawnPosition2, Quaternion.identity);
                playedBottle.name = bottle.name; 

                sampleBottles[i] = sampleBottle;
                playedBottles[i] = playedBottle;

                createdBottleNames.Add(bottle.name);

                i++;
            }
        }
    }

    // ham xao tron playedBottles
    void ShufflePlayedBottles()
    {
        for (int i = 0; i < playedBottles.Length; i++)
        {
            // chon 1 chi so ngau nhien tu 0 den 1
            int randomIndex = Random.Range(i, playedBottles.Length);

            // swap playedBottles[i] and playedBottles[randomIndex]
            GameObject temp = playedBottles[i];
            playedBottles[i] = playedBottles[randomIndex];
            playedBottles[randomIndex] = temp;

            // move bottle to new position
            Vector3 newPosition = new Vector3(-((numberOfBottles - 1) * distanceBetweenBottles) / 2 + i *  distanceBetweenBottles, playedBottlesPosition,0f);
            playedBottles[i].transform.position = newPosition;
        }
    }

    // detect mouse click on bottle from player
    void DetectBottleClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider !=  null)
        {
            GameObject clickedBottle = hit.collider.gameObject;

            // check if it is playedBottles
            if (!IsPlayedBottle(clickedBottle)) return;

            // Check if the same bottle is clicked twice to cancel the selection
            if (clickedBottle == firstSelectedBottle)
            {
                bottleEvent.DeselectBottle(firstSelectedBottle);
                firstSelectedBottle = null;
                Debug.Log("First bottle deselected: " + clickedBottle.name);
                return; // return if 1st bottle is deselected
            }

            // first bottle picked
            if (firstSelectedBottle == null)
            {
                bottleEvent.SelectBottle(clickedBottle);
                firstSelectedBottle = clickedBottle;
                Debug.Log("First bottle selected: " + clickedBottle.name);
            }
            // second bottle picked
            else if (secondSelectedBottle == null)
            {
                bottleEvent.SelectBottle(clickedBottle);    
                secondSelectedBottle = clickedBottle;
                Debug.Log("Second bottle selected: " + clickedBottle.name);
                bottleEvent.SwapBottlesPositions(firstSelectedBottle, secondSelectedBottle);
                bottleEvent.SwapBottlesInArray(playedBottles, firstSelectedBottle, secondSelectedBottle);

                // reset after swap
                bottleEvent.DeselectBottle(firstSelectedBottle);
                bottleEvent.DeselectBottle(secondSelectedBottle);
                firstSelectedBottle = null;
                secondSelectedBottle = null;
            }
        }
    }

    // Check if the clicked bottle is in playedBottles
    bool IsPlayedBottle(GameObject bottle)
    {
        foreach (GameObject playedBottle in playedBottles)
        {
            if (bottle == playedBottle) return true;
        }
        return false;
    }

    // kiem tra so Match
    public int CountMatchedBottles()
    {
        int matchedCount = 0;

        for (int i = 0; i < numberOfBottles; i++)
        {
            // So sanh ten cua 2 chai
            if (playedBottles[i].name == sampleBottles[i].name && playedBottles[i].transform.position.x == sampleBottles[i].transform.position.x)
            {
                matchedCount++;
            }
        }

        
        return matchedCount;
    }

}
