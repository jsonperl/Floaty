using UnityEngine;
using System.Collections;

public class Guy : MonoBehaviour {

  public Vector3 bouyancyCenterOffset;
  public float bounceDamp;

  private float speed = 2000.0f;
  private Vector3 moveDirection = Vector3.zero;
  private float lastx = 0;

  // Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate () {
    if (transform.position.y + 2.5 <= Water.level / 2) {
      Debug.Log(string.Format("transform.position.y: {0}", transform.position.y));

      Float();
    }
    else {
      Debug.Log("done");
      rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
    }

    Movement();
	}

  void Movement (){
    float x = Input.GetAxis("Horizontal");
    float y = Input.GetAxis("Vertical");

    // Change directions
    if (SignChanged(x, lastx)) rigidbody.velocity = rigidbody.velocity * 0.1f;
    lastx = x;

    if (x != 0 || y != 0) {
      moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), moveDirection.y, Input.GetAxisRaw("Vertical"));
      rigidbody.AddForce(moveDirection * speed * Time.deltaTime);
    }
  }

  void Float() {
    Vector3 actionPoint = transform.position + transform.TransformDirection(bouyancyCenterOffset);

    float forceFactor = 1f - ((actionPoint.y - Water.level) / transform.localScale.y);

    if (forceFactor > 0f) {
      Vector3 uplift = -Physics.gravity * (forceFactor - rigidbody.velocity.y * bounceDamp);
      rigidbody.AddForceAtPosition(uplift, actionPoint);
    }
  }

  bool SignChanged(float one, float two) {
    if ((one > 0 && two < 0) || (one < 0 && two > 0)) {
      return true;
    }

    return false;
  }
}
