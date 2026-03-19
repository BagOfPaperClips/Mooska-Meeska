using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GentleBob : MonoBehaviour
{
    [SerializeField] GameObject key1;
    [SerializeField] GameObject key2;
    [SerializeField] GameObject key3;
    [SerializeField] GameObject key4;
    [SerializeField] GameObject key5;
    [SerializeField] GameObject key6;
    [SerializeField] GameObject key7;
    [SerializeField] GameObject key8;
    [SerializeField] GameObject key9;
    [SerializeField] GameObject key10;
    [SerializeField] GameObject key11;
    [SerializeField] GameObject key12;
    [SerializeField] GameObject key13;
    private float rotationSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateKey(key1);
        rotateKey(key2);
        rotateKey(key3);
        rotateKey(key4);
        rotateKey(key5);
        rotateKey(key6);
        rotateKey(key7);
        rotateKey(key8);
        rotateKey(key9);
        rotateKey(key10);
        rotateKey(key11);
        rotateKey(key12);
        rotateKey(key13);
    }
    private void rotateKey(GameObject k)
    {
        k.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
