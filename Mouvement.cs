//Le script gère le mouvement de certaines pièces. 

using System.Globalization;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Mouvement : MonoBehaviour
{
    private GameObject go,go1,go2,go3,go4,go5,go6,go7;
    private GameObject pop;

    void Start()
    {
        //On recupere les objets qui vont etre en mouvement
        go = GameObject.Find("EB1");
        go1 = GameObject.Find("EB2");
        go2= GameObject.Find("EE1");
        go3 = GameObject.Find("EE2");
        go4 = GameObject.Find("EF2");
        go5 = GameObject.Find("EF1");
        go6 = GameObject.Find("IC1");
        go7 = GameObject.Find("IC2");
    }

    void Update()
    {
        //Rotation de la piece sur elle meme
        go.transform.Rotate(Vector3.up *Time.deltaTime* 50,Space.Self);
        go1.transform.Rotate(Vector3.up * Time.deltaTime * 50, Space.Self);
        go2.transform.Rotate(Vector3.up * Time.deltaTime * 50, Space.Self);
        go3.transform.Rotate(Vector3.up * Time.deltaTime * 50, Space.Self);
        go4.transform.Rotate(Vector3.up * Time.deltaTime * 50, Space.Self);
        go5.transform.Rotate(Vector3.up * Time.deltaTime * 50, Space.Self);
        go6.transform.Rotate(Vector3.up * Time.deltaTime * 50, Space.Self);
        go7.transform.Rotate(Vector3.up * Time.deltaTime * 50, Space.Self);
    }

}


	




