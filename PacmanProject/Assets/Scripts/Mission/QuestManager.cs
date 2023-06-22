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


    private void Start()
    {
        Instance = this;
        StartQuestChain();
        UpdateScoreText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CompleteQuest(quests[currentQuestIndex]);
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = (quests[currentQuestIndex].count - PacmanController.Instance.score).ToString();
        scoreImage.sprite = quests[currentQuestIndex].targetObject.transform.GetChild(0).GetComponent<SpriteRenderer>()
            .sprite;
        scoreImage.color = quests[currentQuestIndex].targetObject.transform.GetChild(0).GetComponent<SpriteRenderer>()
            .color;
    }

    private void StartQuestChain()
    {
        if (currentQuestIndex < quests.Length)
        {
            Quest currentQuest = quests[currentQuestIndex];
            currentQuest.isCompleted = false;
            AssignQuestToPlayer(currentQuest);
        }
        /*else
        {
            Debug.Log("Tüm görevler tamamlandı.");
            confettiObject.GetComponent<ParticleSystem>().Play();
            confettiObject.GetComponent<ParticleSystem>().loop = true;
            Movement.Instance.rb.velocity = Vector2.zero;
        }*/
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

        if (currentQuestIndex > quests.Length)
        {
            Debug.Log("Tüm görevler tamamlandı.");
            confettiObject.GetComponent<ParticleSystem>().Play();
            confettiObject.GetComponent<ParticleSystem>().loop = true;
            Movement.Instance.rb.velocity = Vector2.zero;
        }
        else
        {
            StartQuestChain();
        }
    }
}