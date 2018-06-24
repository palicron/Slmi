using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

    Vector3 dist;
    float posX;
    float posY;
	Vector3 curPos;
	Rigidbody rb;
  void OnMouseDown(){
      dist = Camera.main.WorldToScreenPoint(transform.position);
      posX = Input.mousePosition.x - dist.x;
      posY = Input.mousePosition.y - dist.y;
		rb = this.GetComponent<Rigidbody>();

    }

  void OnMouseDrag(){
       curPos = 
                new Vector3(Input.mousePosition.x - posX, 
                Input.mousePosition.y - posY, dist.z);
	
		curPos.z = 0;
	  Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
		worldPos.z = 0;
		
		

		if (Vector3.Distance(worldPos, transform.position) < 1f)
		{
			rb.AddForce((worldPos - transform.position).normalized*0.7f , ForceMode.Impulse);
		}
		else
		{
			rb.AddForce((worldPos - transform.position).normalized * 5f, ForceMode.Impulse);
		}
	
			
      //transform.position = worldPos;
  }

	private void OnMouseUp()
	{
		rb.isKinematic = false;
		rb.useGravity = true;
	}
}
