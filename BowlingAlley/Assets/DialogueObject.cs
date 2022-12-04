
using UnityEngine;


[CreateAssetMenu(menuName ="Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [NonReorderable]
    [SerializeField][TextArea(10, 10)] private string[] dialogue;


    public string[] Dialogue => dialogue;

}
