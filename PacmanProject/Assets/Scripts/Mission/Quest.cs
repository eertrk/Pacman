using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest")]
public class Quest : ScriptableObject
{
    public string questName;
    public string questDescription;
    public int count;
    public GameObject targetObject;
    public GameObject pacmanObject;
    public bool isCompleted;
}