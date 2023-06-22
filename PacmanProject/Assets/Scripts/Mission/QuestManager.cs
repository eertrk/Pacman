using System;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; set; }

    public GameObject confettiObject;

    public Quest[] quests;

    public int currentQuestIndex = 0;

    public Text scoreText;
    
    public Image scoreImage;

    private ParticleSystem confettiParticleSystem;


    private void Awake()
    {
        confettiParticleSystem = confettiObject.GetComponent<ParticleSystem>();

    }

    private void Start()
    {
        Instance = this;
        StartQuestChain();
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        if (currentQuestIndex < quests.Length)
        {
            scoreText.text = (quests[currentQuestIndex].count - PacmanController.Instance.score).ToString();
            scoreImage.sprite = quests[currentQuestIndex].targetObject.transform.GetChild(0).GetComponent<SpriteRenderer>()
                .sprite;
            scoreImage.color = quests[currentQuestIndex].targetObject.transform.GetChild(0).GetComponent<SpriteRenderer>()
                .color;
        }
        else
        {
            scoreText.text = "0";
            scoreImage.sprite = quests[currentQuestIndex-1].targetObject.transform.GetChild(0).GetComponent<SpriteRenderer>()
                .sprite;
            scoreImage.color = quests[currentQuestIndex-1].targetObject.transform.GetChild(0).GetComponent<SpriteRenderer>()
                .color;
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
    }

    private void AssignQuestToPlayer(Quest quest)
    {
        Debug.Log("Yeni görev atandı: " + quest.questName + quest.questDescription);
    }

    public void CompleteQuest(Quest quest)
    {
        quest.isCompleted = true;

        PacmanController.Instance.score = 0;

        currentQuestIndex++;

        if (currentQuestIndex == quests.Length)
        {
            Debug.Log("Tüm görevler tamamlandı.");
            Movement.Instance.isFinished = true;
            AudioManager.Instance.PlayClip(AudioManager.Instance.confettiClip);
            confettiParticleSystem.Play();
            Debug.Log(confettiParticleSystem.isPlaying.ToString());
            confettiParticleSystem.loop = true;
            Debug.Log(confettiParticleSystem.loop.ToString());
        }
        else
        {
            StartQuestChain();
        }
    }
}