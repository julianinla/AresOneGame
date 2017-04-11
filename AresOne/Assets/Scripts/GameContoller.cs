using UnityEngine;
using System.Collections;

public class GameContoller : MonoBehaviour {

    public static GameContoller Instance;

	void Awake () {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
	}
	
	void Update () {
	
	}
}
