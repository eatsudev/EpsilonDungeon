using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    public int MAX_HEALTH = 100;
    private bool isDead = false;
    public static PlayerHealth instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        instance = this;
    }

    /*private IEnumerator VisualIndicator(Color color)
    {
        //GetComponent<Spri>
    }*/

    public void TakeDamage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }

        this.health -= amount;
        
    }
}
