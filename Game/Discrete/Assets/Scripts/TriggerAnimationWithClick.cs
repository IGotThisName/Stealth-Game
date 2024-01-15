using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TriggerAnimationWithClick : MonoBehaviour
{
    public string stateName;
    public Animator animator;
    public GameObject UIText;

    private BoxCollider interactionTrigger;
    private bool isInteractable = false;

    // Start is called before the first frame update
    void Start()
    {
        interactionTrigger = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isInteractable)
        {
            PlayOpenAnimation();
        }
    }
    
    private void PlayOpenAnimation()
    {
        Debug.Log("Running!");
        animator.Play(stateName);
    }

    private void OnTriggerEnter(Collider other)
    {
        isInteractable = true;
        UIText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        isInteractable = false;
        UIText.SetActive(false);
    }
}
