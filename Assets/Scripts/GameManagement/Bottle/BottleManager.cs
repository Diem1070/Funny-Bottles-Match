using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager
{
    public GameObject[] sampleBottles { get; private set; }
    public GameObject[] playedBottles { get; private set; }

    public Transform parentTransform;

    private int numberOfBottles;
    private GameObject[] bottlePrefabs;
    private float distanceBetweenBottles;
    private float sampleBottlesPosition;    // vi tri cua hang chai mau
    private float playedBottlesPosition;    // vi tri cua hang chai duoc choi
    private HashSet<string> createdBottleNames;     // theo doi cac chai da duoc tao
    float parentZ;

    public int NumberOfBottles { get; private set; }

    // constructor
    public BottleManager(int numberOfBottles, GameObject[] bottlePrefabs, float distance, float samplePos, float playedPos, Transform parentTransform)
    {
        this.numberOfBottles = numberOfBottles;
        this.bottlePrefabs = bottlePrefabs;
        this.distanceBetweenBottles = distance;
        this.sampleBottlesPosition = samplePos;
        this.playedBottlesPosition = playedPos;
        createdBottleNames = new HashSet<string>();
        this.parentTransform = parentTransform;
        this.parentZ = parentTransform.position.z;
    }

    public void InitializeBottles()
    {
        // khoi tao mang
        sampleBottles = new GameObject[numberOfBottles];
        playedBottles = new GameObject[numberOfBottles];

        // tinh toan vi tri cua chai dau tien
        float startingX = -((numberOfBottles - 1) * distanceBetweenBottles) / 2;
        float parentZ = parentTransform.position.z;

        // loop tao bottles
        for (int i = 0; i < numberOfBottles; )
        {
            // chon ngau nhien
            GameObject bottle = bottlePrefabs[Random.Range(0, bottlePrefabs.Length)];

            // kiem tra xem ten chai co trong HashSet hay chua (co duoc tao chua)
            if (!createdBottleNames.Contains(bottle.name))
            {
                // tinh toan vi tri cho chai do
                Vector3 samplePos = new Vector3(startingX + i * distanceBetweenBottles, sampleBottlesPosition, parentTransform.position.z);
                Vector3 playedPos = new Vector3(startingX + i * distanceBetweenBottles, playedBottlesPosition, parentTransform.position.z);

                playedBottles[i] = CreateBottle(bottle, playedPos, 0);
                sampleBottles[i] = CreateBottle(bottle, samplePos, 1);
                

                createdBottleNames.Add(bottle.name);
                i++;
            }
        }

        ShufflePlayedBottles();
    }

    private GameObject CreateBottle(GameObject prefab, Vector3 position, int _bottles)
    {
        GameObject bottle = GameObject.Instantiate(prefab, position, Quaternion.identity, parentTransform);

        if (_bottles == 1) SetBottleColor(bottle, Color.black);
        if (_bottles == 0) SetBottleColor(bottle, Color.white);

        bottle.name = prefab.name;
        bottle.transform.localScale = new Vector3(108, 108, 1);
        return bottle;
    }

    // xao tron vi tri cac chai
    private void ShufflePlayedBottles()
    {
        // loop tung chai 
        for (int i = 0; i < numberOfBottles; i++)
        {
            // chon 1 chi so ngau nhien tu 0 den 1
            int randomIndex = Random.Range(i, playedBottles.Length);

            // swap playedBottles[i] and playedBottles[randomIndex]
            GameObject temp = playedBottles[i];
            playedBottles[i] = playedBottles[randomIndex];
            playedBottles[randomIndex] = temp;

            // move bottle to new position
            Vector3 newPosition = new Vector3(-((numberOfBottles - 1) * distanceBetweenBottles) / 2 + i * distanceBetweenBottles, playedBottlesPosition, parentZ);
            playedBottles[i].transform.position = newPosition;
        }
    }

    public int CountMatchedBottles()
    {
        int matchedCount = 0;

        for (int i = 0; i < numberOfBottles;i++)
        {
            if (sampleBottles[i].name == playedBottles[i].name)
                matchedCount++;
        }
        return matchedCount;
    }

    public void SetBottleColor(GameObject bottle, Color color)
    {
        Renderer bottleRenderer = bottle.GetComponent<Renderer>();
        bottleRenderer.material.color = color;
    }
}
