using UnityEngine;
using System.Collections;

public class fireWeapon : MonoBehaviour {
    public GameObject projectile;
    public float pVelocity=-1000;
    public Transform arrowSpawnPoint;
    GameObject nockedArrow;
    int turnedValue;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            nockedArrow = GameObject.Instantiate(projectile, arrowSpawnPoint.position,Quaternion.identity) as GameObject;
            nockedArrow.transform.parent = arrowSpawnPoint;
            turnedValue = gameObject.transform.localScale.x < 0 ? -1 : 1;
            rb = nockedArrow.GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
            nockedArrow.GetComponent<Collider2D>().isTrigger = true;
        
       
            float xScale = nockedArrow.transform.localScale.x;
            nockedArrow.transform.localScale = new Vector3(turnedValue * xScale, nockedArrow.transform.localScale.y, nockedArrow.transform.localScale.z);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            rb.isKinematic = false;
            turnedValue = gameObject.transform.localScale.x < 0 ? -1 : 1;
            nockedArrow.transform.parent = null;
            rb.AddForce(pVelocity * Vector3.right * turnedValue, ForceMode2D.Impulse);
        }
            //float xScale = nockedArrow.transform.localScale.x;
            //nockedArrow.transform.localScale = new Vector3(turnedValue*xScale, nockedArrow.transform.localScale.y, nockedArrow.transform.localScale.z);
            
            //Rigidbody2D rb = nockedArrow.GetComponent<Rigidbody2D>();
            //rb.AddForce(pVelocity * Vector3.right*turnedValue, ForceMode2D.Impulse);


            //if (gameObject.transform.localScale.x > 0)
            //{
            //    GameObject.Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            //}
            //else
            //{
            //    GameObject.Instantiate(projectile, gameObject.transform);
            //}

        
	
	}
}
