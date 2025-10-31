using UnityEngine;
using System.Collections;
public class Open : MonoBehaviour
{

    public bool op = false;
    public double test = 0;
    public SpriteRenderer tes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tes.color = new Color(1f, 1f, 1f, 0.5f);
        //gameObject.SetActive(false);
    }
    public void zustand()
    {
        test = transform.position.y;
        if (transform.position.y >-2.4 &&transform.position.y < 3.1 && op == true)
        {
            //float c = (float)(transform.position.y + 2.4);
            if (transform.position.y <-1.4)
            {
                tes.color = new Color(1f, 1f, 1f,(float) (transform.position.y+2.4));
            }else if (transform.position.y >-2.1)
            {
                tes.color = new Color(1f, 1f, 1f,(float) (-transform.position.y+3.1));
            } 
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    public void open()
    {


        if (op == true)
        {
            op = false;
        }
        else
        {
            op = true;
        }


    }
}
