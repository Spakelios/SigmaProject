using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layerchanger : MonoBehaviour
{
    public SpriteRenderer spriteRef;
    public string layername;

    private void Start()
    {
        layername = spriteRef.sortingLayerName;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<SpriteRenderer>().sortingLayerName = layername;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<SpriteRenderer>().sortingLayerName = "PlayerLayer";
        }
    }
}
