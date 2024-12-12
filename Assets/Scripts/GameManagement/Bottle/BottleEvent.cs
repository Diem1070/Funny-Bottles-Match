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

    public void DetectBottleClick(BottleManager bottleManager) // edit here *******
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
        bottle.transform.position = new Vector3(bottle.transform.position.x, bottle.transform.position.y + selectedBottleHeightOffset, bottle.transform.position.z);

    }
    
    // huy chon bottle
    public void DeselectBottle(GameObject bottle)
    {
        Debug.Log(bottle.name + " deselected");
        bottle.transform.position = new Vector3(bottle.transform.position.x, bottle.transform.position.y - selectedBottleHeightOffset, bottle.transform.position.z);

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

        // Reset the height offset for both bottles after the move.
        bottle1.GetComponent<Bottle>().StartCoroutine(ResetHeightAfterSwap(bottle1, bottle2, 0.75f)); // Adjust delay as needed
    }

    // Coroutine to reset bottle heights after the swap animation is complete
    private IEnumerator ResetHeightAfterSwap(GameObject bottle1, GameObject bottle2, float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for swap animation to finish

        // Reset heights
        DeselectBottle(bottle1);
        DeselectBottle(bottle2);
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

    private IEnumerator WaitAndResetHeight(GameObject bottle, float targetY, float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the swap animation to complete

        // Reset the Y position to the target height
        bottle.transform.position = new Vector3(bottle.transform.position.x, targetY, bottle.transform.position.z);
    }
}
