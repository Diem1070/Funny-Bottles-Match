using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleEvent 
{
    private float selectedBottleHeightOffset;
    private GameObject firstSelectedBottle;
    private GameObject secondSelectedBottle;


    public BottleEvent(float heightOffset)
    {
        this.selectedBottleHeightOffset = heightOffset;
    }

    public void DetectBottleClick(BottleManager bottleManager)
    {
        // Raycast to detect the clicked object
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider == null)
        {
            Debug.Log("No bottle clicked.");
            return;
        }

        GameObject clickedBottle = hit.collider.gameObject;
        Debug.Log("Clicked bottle: " + clickedBottle.name);

        // Check if the clicked bottle is part of the played bottles
        if (!IsPlayedBottle(clickedBottle, bottleManager.playedBottles))
        {
            Debug.Log("Clicked bottle is not in the played bottles.");
            return;
        }

        // Deselect the first selected bottle if clicked again
        if (clickedBottle == firstSelectedBottle)
        {
            Debug.Log("Deselecting the first selected bottle: " + firstSelectedBottle.name);
            DeselectBottle(firstSelectedBottle);
            firstSelectedBottle = null;
            return;
        }

        // Handle first selection
        if (firstSelectedBottle == null)
        {
            Debug.Log("First bottle selected: " + clickedBottle.name);
            SelectBottle(clickedBottle);
            firstSelectedBottle = clickedBottle;
        }
        // Handle second selection
        else if (secondSelectedBottle == null)
        {
            Debug.Log("Second bottle selected: " + clickedBottle.name);
            SelectBottle(clickedBottle);
            secondSelectedBottle = clickedBottle;

            Debug.Log("Swapping bottles: " + firstSelectedBottle.name + " and " + secondSelectedBottle.name);
            // Swap their positions and update the played bottles array
            SwapBottlesPositions(firstSelectedBottle, secondSelectedBottle);
            SwapBottlesInArray(bottleManager.playedBottles, firstSelectedBottle, secondSelectedBottle);

            // Deselect both bottles after swapping
            Debug.Log("Deselecting bottles after swapping.");
            DeselectBottle(firstSelectedBottle);
            DeselectBottle(secondSelectedBottle);

            // Reset selected bottles
            firstSelectedBottle = null;
            secondSelectedBottle = null;
        }
    }

    // chon bottle
    public void SelectBottle(GameObject bottle)
    {
        bottle.transform.position = new Vector3(bottle.transform.position.x, bottle.transform.position.y + selectedBottleHeightOffset, bottle.transform.position.z);
        Debug.Log(bottle.name + " selected");
    }

    // huy chon bottle
    public void DeselectBottle(GameObject bottle)
    {
        bottle.transform.position = new Vector3(bottle.transform.position.x, bottle.transform.position.y - selectedBottleHeightOffset, bottle.transform.position.z);
        Debug.Log(bottle.name + " deselected");
    }

    // doi vi tri 
    public void SwapBottlesPositions(GameObject bottle1, GameObject bottle2)
    {
        Vector3 tempPosition = bottle1.transform.position;
        bottle1.transform.position = bottle2.transform.position;
        bottle2.transform.position = tempPosition;
        Debug.Log("Swapped positions of " + bottle1.name + " and " + bottle2.name);
    }

    // Swap bottles in the playedBottles array
    public void SwapBottlesInArray(GameObject[] bottlesArray, GameObject bottle1, GameObject bottle2)
    {
        int index1 = System.Array.IndexOf(bottlesArray, bottle1);
        int index2 = System.Array.IndexOf(bottlesArray, bottle2);

        if (index1 >= 0 && index2 >= 0)
        {
            GameObject temp = bottlesArray[index1];
            bottlesArray[index1] = bottlesArray[index2];
            bottlesArray[index2] = temp;
            Debug.Log($"Swapped in array: {bottle1.name} and {bottle2.name}");
        }
    }

    private bool IsPlayedBottle(GameObject bottle, GameObject[] playedBottles)
    {
        foreach (var b in playedBottles)
        {
            if (bottle == b) return true;
        }
        return false;
    }
}
