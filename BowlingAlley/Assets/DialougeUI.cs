using UnityEngine;
using TMPro;
using System.Collections;

public class DialougeUI : MonoBehaviour
{
  
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private GameObject dialogueBox;
    //[SerializeField] private PlayableDirector director;

    //public bool inTimeline = false;
    public bool isOpen { get; private set; }

    private TypewriterEffect typewriterEffect;
  //  public PlayerMovement pm;
  //  [SerializeField] private bool newText = true;
  //  [SerializeField] private int textCounter = 0;



    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
    }


    public void ShowDialogue(DialogueObject dialogueObject)
    {
        isOpen = true;
        Debug.Log("Showing Text...");
       
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject)); 
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];

            yield return RunTypingEffect(dialogue);

            textLabel.text = dialogue;

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
           // FindObjectOfType<AudioManager>().PlayPitch("Click", 1, 1.5f);
            }

            for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
            {
                string dialogue = dialogueObject.Dialogue[i];

                yield return RunTypingEffect(dialogue);

                textLabel.text = dialogue;

                yield return null;
                yield return new WaitForSeconds(3f);
              //  FindObjectOfType<AudioManager>().PlayPitch("Click", 1, 1.5f);
            }
            CloseDialogueBox();
    }



    private IEnumerator RunTypingEffect(string dialogue)
    {
        typewriterEffect.Run(dialogue, textLabel);

        while (typewriterEffect.IsRunning)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.E))
            {
                typewriterEffect.Stop();
            }
        }
    }


    private void CloseDialogueBox()
    {
       
        isOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }


}
