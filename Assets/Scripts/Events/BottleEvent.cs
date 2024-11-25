using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleEvent 
{
    private float selectedBottleHeightOffset;

    public BottleEvent(float heightOffset)
    {
        selectedBottleHeightOffset = heightOffset;
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

}
