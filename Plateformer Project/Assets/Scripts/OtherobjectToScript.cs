using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherObjectToScript : MonoBehaviour
{
    public GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = Prefab.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
