using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public bool isRewinding = false;
    
    List<PointInTime> pointsInTime;

    public float recordTime = 5f;

    [Header("LIVES")]
    public int rewindsRemaining;
    public TMP_Text respawnText;
    public GameObject gameOverText;

    void Start()
    {
        pointsInTime = new List<PointInTime>();
        gameOverText.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            rewindsRemaining--;
            StartRewind();
        }
        
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StopRewind();
        }

        if (rewindsRemaining <= 0)
        {
            rewindsRemaining = 0;
            
            GameOver();
        }

        respawnText.text = "REMAINING REWINDS: " + rewindsRemaining.ToString();
    }

    void FixedUpdate() 
    {
        if (isRewinding)
        {
            Rewind();
        } else 
        {
            Record(); 
        }
    }
    
    void Rewind()
    {
        if (pointsInTime.Count > 0 && rewindsRemaining >= 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        } 
        else 
        {
            StopRewind();
        }
        
    }

    void Record()
    {
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    void StartRewind()
    {
        isRewinding = true;
        PlayerController.instance.rb2D.isKinematic = true;
    }

    void StopRewind()
    {
        isRewinding = false;
        PlayerController.instance.rb2D.isKinematic = false;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        PlayerController.instance.enabled = false;
        return;
    }
}
