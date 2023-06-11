using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uicontroller : MonoBehaviour
{
    // Start is called before the first frame update
    Player player;
    Text distanceText;
    
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        distanceText = GameObject.Find("DistanceText").GetComponent<Text>();
    }   
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // int distance = Mathf.FloorToInt(player.distance);
        // Debug.Log(distance);
        // distanceText.text = distance + " m";
    }
}
