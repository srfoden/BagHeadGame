using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene_changer : MonoBehaviour {
    
    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

}
