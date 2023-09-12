//Composant qui gère les interactions avec chaque pièce.

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System;
using System.IO;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;

public class EveHand : MonoBehaviour
{

    private GameObject popUp;

    //pointeur obligatoire mais inutile (sert a faire comprendre au casque que c'est un event listener)
    private IMixedRealityPointer _pointer;
    // Start is called before the first frame update
    void Start()
    {
        //on recupere le popup
        this.popUp = GameObject.Find("PopUpCreator");
        //on ajoute un manager de contrainte pour la gestion des interactions
        this.gameObject.AddComponent<ConstraintManager>();
        //on ajoute un manipulateur d'objet
        ObjectManipulator om = this.gameObject.AddComponent<ObjectManipulator>();
        //om.ManipulationType = 0;
        //on ajoute la methode de manipulation au depart de l'interaction
        om.OnManipulationStarted.AddListener(HandleOnManipulationStarted);
        //on ajoute la methode de manipulation a la fin de l'interaction
        om.OnManipulationEnded.AddListener(HandleOnManipulationEnded);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //methode de manipulation au depart de l'interaction
    private void HandleOnManipulationStarted(ManipulationEventData eventData)
    {
        //on modifie le popup en ajoutant le nom de la piece
        this.popUp.GetComponent<PopupCreate>().changerTextePopUp(this.name);


    }
    //methode de manipulation a la fin de l'interaction
    private void HandleOnManipulationEnded(ManipulationEventData eventData)
    {
        //on modifie le popup en retirant le texte
        this.popUp.GetComponent<PopupCreate>().supprimerTextePopUp();
    }
}
