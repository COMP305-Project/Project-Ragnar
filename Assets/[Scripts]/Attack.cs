using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Attack : MonoBehaviour
{
    public GameObject parent;
    public Collider2D box;
    public SpriteRenderer sprite;

    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        box = this.GetComponent<Collider2D>();
        sprite = this.GetComponent<SpriteRenderer>();
        box.enabled = false;
        sprite.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
    }
}
