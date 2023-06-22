using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanController : MonoBehaviour
{
    public static PacmanController Instance { get; set; }
    
    public List<GameObject> pacman;

    public int score;
    
    private void Awake()
    {
        score = 0;
        
        Instance = this;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            
            AudioManager.Instance.PlayClip(AudioManager.Instance.eatClip);

            if (other.gameObject.name == "CF_Ctrl(Clone)")
            {
                Destroy(transform.GetChild(0).gameObject);
                var obj = Instantiate(pacman[0], transform);
                obj.transform.SetParent(this.transform);

                if (QuestManager.Instance.quests[QuestManager.Instance.currentQuestIndex].targetObject.name == "CF_Ctrl")
                {
                    score++;
                    
                    if (QuestManager.Instance.quests[QuestManager.Instance.currentQuestIndex].count == score)
                    {
                        QuestManager.Instance.CompleteQuest(QuestManager.Instance.quests[QuestManager.Instance.currentQuestIndex]);    
                    }
                    
                    QuestManager.Instance.UpdateScoreText();
                }
                
            }
            else if (other.gameObject.name == "HF_Ctrl(Clone)")
            {
                Destroy(transform.GetChild(0).gameObject);
                var obj = Instantiate(pacman[1], transform);
                obj.transform.SetParent(this.transform);
                
                if (QuestManager.Instance.quests[QuestManager.Instance.currentQuestIndex].targetObject.name == "HF_Ctrl")
                {
                    score++;
                    
                    if (QuestManager.Instance.quests[QuestManager.Instance.currentQuestIndex].count == score)
                    {
                        QuestManager.Instance.CompleteQuest(QuestManager.Instance.quests[QuestManager.Instance.currentQuestIndex]);    
                    }
                    
                    QuestManager.Instance.UpdateScoreText();

                }
            }
            else if (other.gameObject.name == "SF_Ctrl(Clone)")
            {
                Destroy(transform.GetChild(0).gameObject);
                var obj = Instantiate(pacman[2], transform);
                obj.transform.SetParent(this.transform);
                
                if (QuestManager.Instance.quests[QuestManager.Instance.currentQuestIndex].targetObject.name == "SF_Ctrl")
                {
                    score++;
                    
                    if (QuestManager.Instance.quests[QuestManager.Instance.currentQuestIndex].count == score)
                    {
                        QuestManager.Instance.CompleteQuest(QuestManager.Instance.quests[QuestManager.Instance.currentQuestIndex]);    
                    }
                    
                    QuestManager.Instance.UpdateScoreText();

                }
            }
            else
            {
                //Engele çarptığında sallancak
            }
        }
    }
}
