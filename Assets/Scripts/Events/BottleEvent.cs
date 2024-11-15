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

    public void SelectBottle(GameObject bottle)
    {
        bottle.transform.position = new Vector3(bottle.transform.position.x, bottle.transform.position.y + selectedBottleHeightOffset, bottle.transform.position.z);
        Debug.Log(bottle.name + " selected");
    }

    public void DeselectBottle(GameObject bottle)
    {
        bottle.transform.position = new Vector3(bottle.transform.position.x, bottle.transform.position.y - selectedBottleHeightOffset, bottle.transform.position.z);
        Debug.Log(bottle.name + " deselected");
    }

    public void SwapBottlesPositions(GameObject bottle1, GameObject bottle2)
    {
        Vector3 tempPosition = bottle1.transform.position;
        bottle1.transform.position = bottle2.transform.position;
        bottle2.transform.position = tempPosition;
        Debug.Log("Swapped positions of " + bottle1.name + " and " + bottle2.name);
    }
}
