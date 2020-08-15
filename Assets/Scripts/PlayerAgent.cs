using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerAgent : MonoBehaviour
{
    [SerializeField]

    public Transform goal1, goal2, goal3;
    public GameObject spieler;
    public Text infoAnzeige;
    bool rundenStart = true;
    int runde = 0;

    // Start is called before the first frame update
    void Start()
    {
        var playerAgent = GetComponent<NavMeshAgent>();
        playerAgent.destination = goal1.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        var playerAgent = GetComponent<NavMeshAgent>();

        if ((transform.position - goal1.position).magnitude < 0.5)
        {
            playerAgent.destination = goal2.position;
            rundenStart = true;
        }

        if ((transform.position - goal2.position).magnitude < 0.5)
        {
            playerAgent.destination = goal3.position;
        }

        if (rundenStart && (transform.position - goal3.position).magnitude < 0.5)
        {
            playerAgent.destination = goal1.position;
            runde++;
            rundenStart = false;
        }

        if (runde == 3)
        {
            Invoke("Verloren", 1);
        }
    }

    void Verloren()
    {
        spieler.SetActive(false);
        infoAnzeige.text = "Du hast verloren :(";
    }
}
