using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedPickupThing : MonoBehaviour
{
    public bool isCollectableToInv;
    public bool isCarryable;

    private GameObject player;

    [Header("other")]
    public GameEvent onThingAcquired;
    public BasicInteract basicInteract;

    private bool cancel;
    private bool yoinking;
    private KeyCode useKey;
    private int itemID;
    private float yoinkRange;
    private Vector3 playerLoc;
    private Vector3 itemLoc;
    private float distanceFromItem;

    private float pickupProgress = 0;
    [SerializeField] private float yoinkTime;

    [SerializeField] private Slider progressBar;

    // NOTE - You MUST have an event assigned here if you want to delete up the object, even if you don't need one, because the code will exit on a null event.

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        useKey = basicInteract.interactOrPickUpKey;

        progressBar.gameObject.SetActive(false);
        yoinkRange = basicInteract.rayLength;
    }

    private void Update()
    {
        if (yoinking)
        {
            playerLoc = player.transform.position;
            itemLoc = transform.position;

            if (Vector3.Distance(playerLoc, itemLoc) > yoinkRange)
            {
                yoinking = false;
                ResetProgress();
                return;
            }

            progressBar.gameObject.SetActive(true);

            pickupProgress += (1 / yoinkTime) * Time.deltaTime;
            progressBar.value = pickupProgress;

            if (pickupProgress >= 1)
            {
                YoinkSuccess();
            }
        } 
        
        else
        {
            ResetProgress();
        }
        

    }

    public void RemoveObject()
    {
        Destroy(gameObject);
    }

    public void TimedCollectionEvent(int ID)
    {
        yoinking = true;
        itemID = ID;
    }

    private void YoinkSuccess()
    {

        ResetProgress();

        // add item to inv
        basicInteract.addItemtoInv(itemID);
        // raise event
        if (onThingAcquired != null)
        {
            onThingAcquired.Raise(this, null);
        }

        Destroy(this.gameObject); // REMOVE OBJECT FROM THE WORLD
    }

    private void ResetProgress()
    {
        pickupProgress = 0;
        progressBar.value = 0;

        progressBar.gameObject.SetActive(false);
    }
}
