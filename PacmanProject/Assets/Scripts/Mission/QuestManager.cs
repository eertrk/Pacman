using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; set; }
    
    public GameObject confettiObject;

    public Quest[] quests;
    
    public int currentQuestIndex = 0;


    private void Start()
    {
        Instance = this;
        StartQuestChain();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CompleteQuest(quests[currentQuestIndex]);
        }
    }

    private void StartQuestChain()
    {
        if (currentQuestIndex < quests.Length)
        {
            Quest currentQuest = quests[currentQuestIndex];
            currentQuest.isCompleted = false;
            AssignQuestToPlayer(currentQuest);
        }
        else
        {
            Debug.Log("Tüm görevler tamamlandı.");
            confettiObject.GetComponent<ParticleSystem>().Play();
            confettiObject.GetComponent<ParticleSystem>().loop = true;
            Movement.Instance.rb.velocity = Vector2.zero;
        }
    }

    private void AssignQuestToPlayer(Quest quest)
    {
        // Oyuncuya görevi atama işlemleri burada yer alır
        Debug.Log("Yeni görev atandı: " + quest.questName + quest.questDescription);
    }

    public void CompleteQuest(Quest quest)
    {
        quest.isCompleted = true;
        PacmanController.Instance.score = 0;
        currentQuestIndex++;
        StartQuestChain();
    }
}
