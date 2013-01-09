using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

  public static float level = 0.0f;
  private float risingSpeed = 6.0f;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
    if (level < 12) {
      ChangeLevel(risingSpeed * Time.deltaTime);
    }
	}

  void ChangeLevel(float delta) {
    level = level + delta;
    transform.position += Vector3.up * delta / 2;
    transform.localScale += Vector3.up * delta;
    renderer.material.mainTextureScale = new Vector2(renderer.material.mainTextureScale.x, level / 5);
  }
}

