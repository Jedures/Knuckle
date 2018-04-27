using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private static GameManager instance = null;

	public List<GameObject> players;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
	}

    // Update is called once per frame
    void Update () {
		players.AddRange (GameObject.FindGameObjectsWithTag("Player"));
	}
}
