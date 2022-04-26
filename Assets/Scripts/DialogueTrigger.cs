using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class DialogueTrigger : MonoBehaviour
{



    [Header("interract text")]
    [SerializeField] public GameObject interractText;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;
    private void Start()
    {

        playerInRange = false;
        interractText.SetActive(false);

        Debug.Log("dans le script");

    }

    private void Update()
    {
        if(playerInRange && !DialogueManager.getInstance().dialogueIsPlaying)
        {
            interractText.SetActive(true);
            if(Input.GetKeyDown("f"))
            {
                DialogueManager.getInstance().EnterDialogueMode(inkJSON);
            }
        } else
        {
            interractText.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }
}
