using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;

    public TextMeshProUGUI waveCountdownText;

    private float _countDown = 2f;
    private int _waveIndex = 1;

    private void Update()
    {
        if (_countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countDown = timeBetweenWaves;
        }

        _countDown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(_countDown).ToString();
    }

    private IEnumerator SpawnWave()
    {
        _waveIndex++;
        
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
