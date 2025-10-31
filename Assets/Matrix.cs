using UnityEngine;

public class Matrix : MonoBehaviour
{
    public GameObject Square;
    public GameObject[] items;
    public bool z = false;
    public int test ;
    public float location = 0;
    public Vector2 x = new Vector2(0, 0);





    void Start()
    {
        items = new GameObject[100];
        int n = 0;
        int i = 0;
        for (int k = 0; k < items.Length; k++)
        {



            items[k] = Instantiate(Square);
            items[k].transform.position = new Vector2(-5.5f + 1.1f * i, 2.5f + n * -1.1f);
            //items[k].SetActive(false);

            i++;
            if (i >= 10)
            {
                n++;
                i = 0;
            }

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i].GetComponent<Open>().open();
            }

        }
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponent<Open>().zustand();
        }
        
        
        scroll();
        bewegen();
        test = reien();
    }
    void scroll()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            location = location - 5 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            location = location + 5 * Time.deltaTime;
        }
        if (location < 0) { location = 0; }
        if (location > reien()*1.1f-5.5f) { location = reien()*1.1f-5.5f; }
        
    }
    int reien()
    {
        if (items.Length % 10 > 0)
        {
            return items.Length/10 + 1;
        }
        else
        {
            return items.Length/10;
        }

    }
    void bewegen(){
        int n = 0;
        for (int k = 0; k < items.Length; n++)
        {
            for (int i = 0; i < 10; i++)
            {   
                items[k].transform.position = new Vector2(-5.5f + 1.1f * i, 2.5f + n * -1.1f+location);
                k++;
                
                if (k > items.Length)
                {
                    i = 10;
                }
            }

        }

    }
    
}
