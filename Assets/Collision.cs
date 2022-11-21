using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasPackage;
    bool hasDeliver;
    [SerializeField] float delay = 1;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Auch, that hurts");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Box" && !hasPackage)
        {
            this.hasPackage = true;
            hasDeliver = false;
            Debug.Log("Package picked");
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, delay);
        }
        else if (other.tag == "Client" && hasPackage && !hasDeliver)
        {
            hasDeliver = true;
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            Debug.Log("Package deliver");
        }
    }
}
