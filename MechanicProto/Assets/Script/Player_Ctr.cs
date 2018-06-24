using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ctr : MonoBehaviour {

	public float speed;
	public float forceJump;
	public float detecDistance;
	public ForceMode force;
	private Rigidbody rb;
	[SerializeField]
	private bool onGround;
	
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		onGround = ground();
		moveforwrd();
		if (!onGround)
			return;
	
		bool hit = Physics.Raycast(transform.position, transform.forward, detecDistance);
		if (hit)
			rb.AddForce(transform.up * forceJump, force);
	}

	private void moveforwrd()
	{
		transform.position += transform.forward * speed * Time.deltaTime;

	}
	private bool ground()
	{
		return Physics.Raycast(transform.position, -transform.up, 0.5f);
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawRay(transform.position, transform.forward* detecDistance);
		Gizmos.DrawRay(transform.position, -transform.up * 0.5f);
	}

}
