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
            Debug.Log("No object was hit by the Raycast.");
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
            
            // Reset selected bottles
            firstSelectedBottle = null;
            secondSelectedBottle = null;
        }
    }

    // chon bottle
    public void SelectBottle(GameObject bottle)
    {
        Debug.Log(bottle.name + " selected");

        // light
        Bottle bottleScript = bottle.GetComponent<Bottle>();
        if (bottleScript != null)
        {
            bottleScript.TurnOnLight();
        }
    }
    
    // huy chon bottle
    public void DeselectBottle(GameObject bottle)
    {
        Debug.Log(bottle.name + " deselected");

        // light
        Bottle bottleScript = bottle.GetComponent<Bottle>();
        if (bottleScript != null)
        {
            bottleScript.TurnOffLight();
        }
    }
    
    // doi vi tri 
    public void SwapBottlesPositions(GameObject bottle1, GameObject bottle2)
    {
        // Save the initial positions to avoid multiple changes at once.
        Vector3 bottle1OriginalPosition = bottle1.transform.position;
        Vector3 bottle2OriginalPosition = bottle2.transform.position;

        // Start the coroutine to smoothly swap positions.
        bottle1.GetComponent<Bottle>().StartCoroutine(SmoothMove(bottle1, bottle2OriginalPosition, bottle1OriginalPosition));
        bottle2.GetComponent<Bottle>().StartCoroutine(SmoothMove(bottle2, bottle1OriginalPosition, bottle2OriginalPosition));

        // Start a coroutine that will turn off the light after both bottles have moved.
        bottle1.GetComponent<Bottle>().StartCoroutine(WaitAndTurnOffLight(bottle1, 0.5f)); // Adjust time as necessary
        bottle2.GetComponent<Bottle>().StartCoroutine(WaitAndTurnOffLight(bottle2, 0.5f)); // Adjust time as necessary
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

    private IEnumerator SmoothMove(GameObject bottle, Vector3 targetPosition, Vector3 originalPosition)
    {
        float duration = 0.5f; // Time to complete the move
        float elapsedTime = 0f;
        Vector3 startPosition = bottle.transform.position;

        while (elapsedTime < duration)
        {
            bottle.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the final position is exactly the target position
        bottle.transform.position = targetPosition;
    }

    private IEnumerator WaitAndTurnOffLight(GameObject bottle, float delay)
    {
        // Wait for the given delay to ensure the bottle has finished moving
        yield return new WaitForSeconds(delay);

        // Now turn off the light for the bottle
        Bottle bottleScript = bottle.GetComponent<Bottle>();
        if (bottleScript != null)
        {
            bottleScript.TurnOffLight();
        }
    }
}
