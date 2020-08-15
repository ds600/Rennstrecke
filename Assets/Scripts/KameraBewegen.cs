using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraBewegen : MonoBehaviour
{
    public GameObject fahrzeug;
    float abstandXZ = 6;
    float hoeheY = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Richtung in die das Auto schaut
        Quaternion fahrzeugRoationY = new Quaternion();
        fahrzeugRoationY.eulerAngles = new Vector3(0, fahrzeug.transform.eulerAngles.y, 0);

        // Entfernung hinter das Auto
        Vector3 abstandHinterFahrzeug = fahrzeugRoationY * new Vector3(0, 0, abstandXZ);
        
        // Bewegt die Kamera hinter das Auto in höhe der Entfernung
        transform.position = fahrzeug.transform.position - abstandHinterFahrzeug;

        // Die Kamera auf die Richtige höhe stellen
        transform.position = new Vector3(transform.position.x, transform.position.y + hoeheY, transform.position.z);

        // Rotation immer so richten, dass sie auf das Auto guckt
        transform.LookAt(fahrzeug.transform);


    }
}
