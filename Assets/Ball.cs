using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Racket solRaket, sagRaket;
    Rigidbody2D rb2;
    public float moveSpeed = 80;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(1,0)*moveSpeed;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TagManager tagManager = collision.gameObject.GetComponent<TagManager>();

        //eklediğimiz sesi tanımladık, çalıştırdık.
        GetComponent<AudioSource>().Play();

        if(tagManager == null) return;

        Tag tag = tagManager.myTag;

        if(tag.Equals(Tag.SAG_DUVAR)) //tag.Equals() yapılabilir.
        {
            //sol raket skor yap
            solRaket.SkorYap();
             
        }
        else if(tag.Equals(Tag.SOL_DUVAR))
        {
            //sag raket skor yap
            sagRaket.SkorYap();
        }
    
        if(tag.Equals(Tag.SAG_RAKET))
        {
            //collision=raket (çarpılan yer)
            //topun y bileşenini aldık(zaten topun içindeyiz o yüzden direkt transform.position diyerek ulaşabiliriz.)
            float a = transform.position.y - collision.gameObject.transform.position.y;
            float b = collision.collider.bounds.size.y;
            float y = a/b;
            float x = -1; //sağ rakete çarpan top -1 yönünde gider.

            rb2.velocity = new Vector2(x,y) * moveSpeed;
        }
        else if (tag.Equals(Tag.SOL_RAKET))
        {

            float a = transform.position.y - collision.gameObject.transform.position.y;
            float b = collision.collider.bounds.size.y;
            float y = a/b;
            float x = 1; //sol rakete çarpan top 1 yönünde gider.

            //x ve y hesaplandı.
            rb2.velocity = new Vector2(x,y) * moveSpeed;

        }
     
    }

 
}
