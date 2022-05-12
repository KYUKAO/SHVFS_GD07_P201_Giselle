using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorComponent : MonoBehaviour
{
    public static int CurrentNumOfCollection;
    public static int NumOfCollectable;
    private void Start()
    {
        CollectorComponent.NumOfCollectable = FindObjectsOfType<CollactableComponent>().Length;
        CurrentNumOfCollection = 0;
    }
    private void Update()
    {
        Debug.Log($"{ NumOfCollectable},{ CurrentNumOfCollection}");
    }
    //have this on the player ,had better make every values in this Class;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CollactableComponent>()!=null)
        {
            //add this collectable instance into...?
            Evently.Instance.Publish(new CollectionEvent(other.GetComponent<CollactableComponent>(),1));
            if(CurrentNumOfCollection>=NumOfCollectable)
            {
                Evently.Instance.Publish(new GameOverEvent(true));
            }
        }
    }

}
