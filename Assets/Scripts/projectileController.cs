using UnityEngine;
using System.Collections;

public class projectileController : MonoBehaviour
{
    public float swordSpeed;

    Rigidbody2D myRB;

    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z>0)
            myRB.AddForce(new Vector2(-1, 0) * swordSpeed, ForceMode2D.Impulse);
        else myRB.AddForce(new Vector2(1, 0) * swordSpeed, ForceMode2D.Impulse);
    }

    void Update()
    {

    }

    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }

}