using UnityEngine;
using System.Collections;

public class CharacterBehaviourScript : MonoBehaviour {

	// [HideInInspector] means this public variable
	// will not appear and uneditable in inspector
	// component 
	[HideInInspector] public bool jump = false;
	[HideInInspector] public bool facingRight = true;

	// public variable will shown in inspector
	// so the value can be changed and different 
	// for all object that using same scripts.
	// It's good practice to give it default value
	// like this

	public GameObject bulletPrefab;

	public LayerMask groundMask;
	public LayerMask wall;

	public float jumpForce = 1000f;
	public float moveForce = 185f;
	public float maxSpeed = 4f;
	public float posBullet;
	public float maxHp;
	public float shootInterval;
	private Rigidbody2D rigidbody2d;
	private float currHp;
	public GameObject hpBar;
	private bool shootFlag;
	// for full documentation about unity behavior lifecycle
	// see http://docs.unity3d.com/Manual/ExecutionOrder.html
	void Awake () {

		// Rigidbody2D component give the object physics
		// properties like mass, drag, etc. We can interact
		// with the object using rigidbody2d by using physics
		// properties, like throwing a ball is essentially
		// add force to ball to specific direction
		rigidbody2d = GetComponent<Rigidbody2D> ();
		currHp = maxHp;
		shootFlag = true;
	}

	void Update () {
		/*------------
		 * Input
		 * -----------*/
		// Character will jump if the player told so and
		// the character is on ground (so it cannot jump mid-air)
		// TODO : Check if the character is on the ground


		// Character will fire a bullet when F button pressed.
		// masih ngaco

		if ((Input.GetMouseButtonDown(0)) && shootFlag) {
			Debug.Log ("guk");
			Vector2 bulletPos;
<<<<<<< HEAD
			Vector2 arah = new Vector2 ( Input.mousePosition.x-gameObject.transform.position.x, Input.mousePosition.y- gameObject.transform.position.y );
		
			bulletPrefab.GetComponent<ConstantForce2D>().relativeForce= (arah *10f);
				Debug.Log (bulletPrefab.GetComponent<Rigidbody2D> ().velocity);
				bulletPos = new Vector2 (GetComponent<BoxCollider2D> ().bounds.min.x, GetComponent<BoxCollider2D> ().bounds.min.y + posBullet);

=======
			Vector2 arah = new Vector2 ( Camera.main.ScreenToWorldPoint( Input.mousePosition).x-gameObject.transform.position.x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y- gameObject.transform.position.y );

			Debug.Log (arah);
			bulletPrefab.GetComponent<ConstantForce2D>().relativeForce= (arah *100f);
			Debug.Log (bulletPrefab.GetComponent<Rigidbody2D> ().velocity);
			//bulletPos = new Vector2 (GetComponent<BoxCollider2D> ().bounds.min.x, GetComponent<BoxCollider2D> ().bounds.min.y + posBullet);
			bulletPos= gameObject.transform.position;
>>>>>>> 6d7c2ed7e3fef5f13f7ef561d9c8b6d5cef3d2fb
			Instantiate(bulletPrefab,bulletPos,bulletPrefab.transform.rotation);
			shootFlag=false;
			StartCoroutine("changeShootFlag");
		}

	}

	void FixedUpdate () {
		/*------------
		 * Movement
		 * -----------*/
		// Get direction (positive = right, negative = left, zero = nothing)
		// This is defined in InputManager (Edit->Project Settings->Input)
		float direction = Input.GetAxisRaw("Horizontal");

		if (!((direction == 1 && facingRight && checkWall ()) || (direction == -1 && !facingRight && checkWall ()))) {
			// Move to direction
			// Accelerate the object to its max speed
			if (rigidbody2d.velocity.x * direction < maxSpeed)
				rigidbody2d.AddForce (Vector2.right * moveForce * direction);
			// constant speed when reached max speed
			if (Mathf.Abs (rigidbody2d.velocity.x) > maxSpeed) {
				float xSpeed = maxSpeed * Mathf.Sign (rigidbody2d.velocity.x);
				float ySpeed = rigidbody2d.velocity.y;

				rigidbody2d.velocity = new Vector2 (xSpeed, ySpeed);
			}
			Debug.Log ((direction == -1 && !facingRight && checkWall ()));
		} else {
			Debug.Log (checkWall ());
		}
		Vector3 vecHolder;
		vecHolder = new Vector3 (rigidbody2d.position.x, rigidbody2d.position.y, Camera.main.transform.position.z);
		Camera.main.transform.position = vecHolder;
		// Change Main Camera Position

		// Change character facing direction
		if (direction > 0 && !facingRight)
			Flip ();
		else if (direction < 0 && facingRight)
			Flip ();

		Vector2 rayOrigin = GetComponent<BoxCollider2D>().bounds.center;

		float rayDistance = GetComponent<BoxCollider2D>().bounds.extents.y + 0.1f;

		bool grounded = false;                                                  
		if (Physics2D.Raycast (rayOrigin, Vector2.down, rayDistance, groundMask.value)) {
			grounded = true;
		}

		if(Input.GetButtonDown("Jump") && grounded) {
			jump = true;
		}
		// if character is ordered to jump
		if (jump) {
			// TODO : get the character jumping
			rigidbody2d.AddForce(jumpForce*Vector2.up);
			// Give Force with Up Direction to Player's Rigidbody

			// successfully jumped, set jump to false so in next frame
			// it isn't jump twice
			jump = false;
		}

	}

	// Flip the character facing direction
	void Flip() {
		// flip the flag
		facingRight = !facingRight;

		// flip by scale
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void doDamage(float damage){
		if (currHp>0)
			currHp -= damage;
		float currHpBar=currHp/maxHp;
		hpBar.transform.localScale = new Vector3 (currHpBar, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
		if (currHp == 0) {
			Application.LoadLevel("LoseScreen");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("EnemyBullet"))
			doDamage (2.0f);
	}
	bool checkWall(){
		Vector2 boxOrigin = GetComponent<BoxCollider2D>().bounds.center;
		Vector2 boxSize = GetComponent<BoxCollider2D>().bounds.size;
		Vector2 direction = Vector2.left;
		if (facingRight){
			direction=Vector2.right;
		}

		if (Physics2D.BoxCast(boxOrigin, boxSize,0,direction,0.1f,wall)){
			return true;
		}
		return false;
	}
	IEnumerator changeShootFlag()
	{
		yield return new WaitForSeconds(shootInterval);
		shootFlag = true;
	}
}
