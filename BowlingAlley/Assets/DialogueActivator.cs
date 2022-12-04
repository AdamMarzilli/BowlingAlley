using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{

    [SerializeField] private DialogueObject dialogueObject;
   // [SerializeField] private SpriteRenderer sr;

    public bool isPaper = true;
    public void Interact(PlayerController player)
    {
        player.DialougeUI.ShowDialogue(dialogueObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
       
        if (collision.CompareTag("Player") && collision.TryGetComponent(out PlayerController player))
        {
            Debug.Log("HELLO");
            player.Interactable = this;
            
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        //sr.enabled = false;
        if (collision.CompareTag("Player") && collision.TryGetComponent(out PlayerController player))
        {
            if(player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable = null;
            }
        }
    }



}
