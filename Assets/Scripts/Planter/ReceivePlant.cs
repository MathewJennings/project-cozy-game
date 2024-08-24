using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ReceivePlant : MonoBehaviour, IPlantReceivable
{

    [SerializeField]
    private Sprite seededSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void IPlantReceivable.ReceivePlant()
    {
        GetComponent<SpriteRenderer>().sprite = seededSprite;
    }
}
