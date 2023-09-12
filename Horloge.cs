//Le script principal est le script qui gère l'entièreté de l’horloge,
//il est dédié à ajouter le modèle à la scène et de lui ajouter les composants a chaque pièce.

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System;
using System.IO;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;

public class Horloge: MonoBehaviour {
    //Objet de chaque piece
    private GameObject g1;
    //Texture de chaque piece
    private Mesh m1;
    //Rendu des textures de chaque piece
    private MeshRenderer meshRenderer;
    //Liste de String comprenant toutes les informations de chaque piece
    private List<string> readText;

    

    //methode qui se lance au demarrage
    void Start()
    {
        //On cree un objet parent Horloge
        GameObject parent = new GameObject("Horloge");

        //On declare la liste de string
        readText = new List<string>();
        //on ajoute a la liste les infos des pieces
        DonnerCoordonnées();

        //On crée un quaternion pour les angles des pieces
        Quaternion newRotation = new Quaternion();
        //On modifie l'angle
        newRotation.eulerAngles = new Vector3(-90,0,0);

        //GameObject scriptgetter = GameObject.Find("PieceScriptGetter");
        //var script = scriptgetter.GetComponent<Piece>();

        //Pour chaque piece dans la liste
        foreach (string s in readText)
        {
            //On cree un tableau en coupant la ligne au moment des virgules
	        string[] words = s.Split(',');

	        string s1="i="+words[0]+"name="+words[1];

            Console.WriteLine(s);

            //On cree l'objet avec le nom de la piece
            g1 = new GameObject(words[1]);
            //On ajoute la piece au parent horloge
            g1.transform.SetParent(parent.transform);
            //On ajoute a la piece le composant MeshFilter
            g1.AddComponent<MeshFilter>();
            //On ajoute a la piece le composant MeshRenderer
            g1.AddComponent<MeshRenderer>();
            //On ajoute a la piece le composant BoxCollider
            //g1.AddComponent<BoxCollider>();
            //On charge la texture correspondant au nom de la piece
            m1 = (Mesh)Resources.Load(words[1],typeof(Mesh));
            //On ajoute la texture de la piece au MeshFilter
            g1.GetComponent<MeshFilter>().mesh = m1;

            //On recupere le MeshRenderer de la piece
            meshRenderer = g1.GetComponent<MeshRenderer>();

            //On ajoute a la piece le composant BoxCollider
            BoxCollider bc = g1.AddComponent<BoxCollider>();

            //recuperation des limites des meshs
            Bounds b = m1.bounds;
            //redimension du box collider avec la taille du mesh
            bc.size = new Vector3(b.size.x,b.size.y,b.size.z);
            //On fait une rotation a la piece de l'angle modifie
            g1.transform.Rotate(newRotation.eulerAngles);
            //On cree lobjet CultureInfo en le clonant
            var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            //On precise le separateur des nombres qui est un point pour les decimales
            culture.NumberFormat.NumberDecimalSeparator = ".";
            //On bouge la piece a ses coordonnees en utilisant lobjet CultureInfo
            g1.gameObject.transform.Translate(float.Parse(words[2],culture),-float.Parse(words[3],culture),float.Parse(words[4],culture));
            //On fait une rotation de la piece de 180 degres sur laxe Z
            g1.transform.Rotate(new Vector3(0,0,180));
            //On modifie la couleur du rendu des textures en utilisant lobjet CultureInfo
            meshRenderer.material.SetColor("_Color",new Color(float.Parse(words[5],culture),float.Parse(words[6],culture),float.Parse(words[7],culture)));

            //ajout du composant cree qui gere les interactions
            g1.AddComponent<EveHand>();


        }

        //On change léchelle parent pour réduire l'horloge complète
        parent.transform.localScale = new Vector3(0.0008f, 0.0008f, 0.0008f);
        //On bouge lhorloge en la baissant sur l'axe y et l'avancant sur l'axe z
        parent.transform.Translate(new Vector3(0, -1f, 1f));

        Debug.Log("End");

    }

    

 

    //methode pour toutes les coordonnees de chaque pièce (359 pieces)
    void DonnerCoordonnées()
    {
        readText.Add("0,Z,0.0,350.0,-937.1,0.8,0.8,0.8");
        //etc...
    }

}

