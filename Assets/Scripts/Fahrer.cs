using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fahrer : MonoBehaviour
{
    bool rundenZaehlenErlaubt = true;
    bool inBereich = false;
    bool kamVonVorne = false;
    bool checkpoint1 = true;
    bool checkpoint2 = true;
    int runde = 0;

    public Text infoAnzeige;
    public GameObject fahrerAI;

    float[] rundenzeitStart = new float[3];
    public Text[] rundenzeitAnzeige = new Text[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rundenZaehlenErlaubt)
        {
            // Man muss imer durch beide Checkpoints fahren, bevor er einen im Ziel akzeptiert
            if (transform.position.x > 9 && transform.position.x < 15 && transform.position.z > 19.9 && transform.position.z < 20.5)
            {
                checkpoint1 = true;
            }
            
            if (transform.position.x > 19.9 && transform.position.x < 20.2 && transform.position.z > 0 && transform.position.z < 5)
            {
                checkpoint2 = true;
            }

            if(checkpoint1 && checkpoint2)
            {
                kamVonVorne = false;
            }
            else
            {
                kamVonVorne = true;
            }

            // Punkt ganz links und rechts von der Startlinie
            if (!kamVonVorne && transform.position.x > 20 && transform.position.x < 30)
            {
                /// Soll feststellen aus welcher Richtung das Fahrzeug kommt und entsprechend die Runde hoch rechnen.
                

                // Der Bereich vor dem Ziel
                if (transform.position.z > 12 && transform.position.z < 12.5f)
                {
                    inBereich = true;
                }
                // Der Bereich vom - nach dem Ziel
                else if (inBereich && transform.position.z > 12.5f && transform.position.z < 13)
                {
                    runde++;

                    // Checkpoint reset
                    checkpoint1 = false;
                    checkpoint2 = false;

                    if (runde > 0 && runde < 4)
                    {
                        rundenzeitStart[runde - 1] = Time.time;
                    }
                    inBereich = false;
                    rundenZaehlenErlaubt = false;
                    Invoke("RundenZaehlenErlauben", 10);
                }
            }
        }
        if (runde > 0 && runde < 4)
            rundenzeitAnzeige[runde - 1].text = string.Format("Runde{0,2:0}: {1,6:0.0} sec.", runde, Time.time - rundenzeitStart[runde - 1]);

        if (runde == 4)
        {
            fahrerAI.SetActive(false);
            infoAnzeige.text = "Du hast gewonnen! :)";
        }
        
    }

    void RundenZaehlenErlauben()
    {
        rundenZaehlenErlaubt = true;
    }

    public void Training()
    {
        SceneManager.LoadScene("Training");
    }
    
    public void Versus()
    {
        SceneManager.LoadScene("Versus");
    }

    public void Ende()
    {
        Application.Quit();
    }

}
