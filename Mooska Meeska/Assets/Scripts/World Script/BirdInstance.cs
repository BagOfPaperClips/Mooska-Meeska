using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdInstance : MonoBehaviour
{
    public BirdSO birdData;     
    //currentModel is the visible model, switching model when found without destroying the gameobject
    private GameObject currentModel; 
    public Transform modelHolder; 
    public GameObject defaultPrefab; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnModel() 
    //called everytime a model is updated
{
    if (currentModel != null)
        Destroy(currentModel);

    GameObject prefab = birdData.found ? birdData.birdModel : defaultPrefab;

    currentModel = Instantiate(prefab, modelHolder);
    currentModel.transform.localPosition = Vector3.zero;
    currentModel.transform.localRotation = Quaternion.identity;
}

}
