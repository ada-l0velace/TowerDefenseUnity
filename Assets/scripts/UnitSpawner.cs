﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 15f;
    private float countdown = 1f;
    int counter = 0;
    public GameManager gameManager;
    public Text waveNumber;
    public Text waveCountdownText;

    //public GameManager gameManager;

    private int waveIndex = 0;

    void Update() {

        if (EnemiesAlive > 0) {
            return;
        }
        //Debug.Log(waveIndex);
        if (waveIndex == waves.Length) {
            gameManager.WinLevel();
            waveCountdownText.text = "0:00.00";
            this.enabled = false;
        }

        if (countdown <= 0f) {
            counter++;
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveNumber.text = "Wave " + (counter);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave() {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++) {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy) {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
