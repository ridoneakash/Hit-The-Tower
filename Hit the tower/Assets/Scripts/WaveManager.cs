using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public Transform enemyPrefabs;

    public float waveDelay = 5.0f;
    public float countDown = 0;
    private float waveNumber = 0;
    public Transform spwanPoint;

    public TextMeshProUGUI waveCountDwonText;

    private void Update()
    {
        if(countDown <= 0)
        {
            StartCoroutine (SpwanWave());
            countDown = waveDelay;
        }

       
        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountDwonText.text = string.Format("{0:00.00 }", countDown);
    }

     IEnumerator SpwanWave()
    {
        waveNumber++;
        for (int i =0; i < waveNumber; i++)
        {
            SpwanEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        
    }

    void SpwanEnemy()
    {
        Instantiate(enemyPrefabs, spwanPoint.position, spwanPoint.rotation);
    }

}
