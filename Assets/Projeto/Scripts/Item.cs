using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Item : MonoBehaviour
{
    public GameController _gc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            ++_gc.score;
        }
          
        
       
    }
}
