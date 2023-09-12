//PopUpCreate sert à la création de popup sur la caméra principale.

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupCreate : MonoBehaviour
{
    //creation de popup
    private TextMesh textmesh;
    private GameObject cam;
    private GameObject pop;

    void Start()
    {
        //recuperation de la camera
        this.cam = GameObject.Find("Main Camera");
        //creation du gameobject conteneur du texte
        this.pop = new GameObject();
        //objet renomme
        this.pop.name = "PopUp";
        //objet camera parent du popup
        this.pop.transform.SetParent(this.cam.transform);
        //position du popup par rapport a la cam
        this.pop.transform.position = new Vector3(0, 1, 3);
        //modification de son echelle
        this.pop.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        //asjout d'un meshrenderer
        this.pop.AddComponent<MeshRenderer>();
        //ajout du textmesh
        this.textmesh = this.pop.AddComponent<TextMesh>();
        //on regle le texte vide
        this.textmesh.text = "";
        //changement de la taille de police
        this.textmesh.fontSize = 500;
        this.textmesh.characterSize = 0.05f;
        //on bloque le texte au centre du popup
        this.textmesh.anchor = TextAnchor.MiddleCenter;
    }

    //methode qui change le texte du popup avec le texte en parametre
    public void changerTextePopUp(string txt)
    {
        this.textmesh.text = txt;
    }

    //methode qui supprime le texte
    public void supprimerTextePopUp()
    {
        this.textmesh.text = "";
    }

}
