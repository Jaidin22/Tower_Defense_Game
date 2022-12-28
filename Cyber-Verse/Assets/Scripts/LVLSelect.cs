using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LVLSelect : MonoBehaviour
{
    public SceneTransition transition;


    public void Select(string levelName)
    {
        transition.FadeTo(levelName);
    }
}
