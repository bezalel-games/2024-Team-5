using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightsManager : MonoBehaviour
{
    public Light2D playerLight;
    public static LightsManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }


}
