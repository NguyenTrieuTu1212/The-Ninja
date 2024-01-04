using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnCoin : MonoBehaviour
{
    public GameObject coinPrefab;
    public int minCoins = 5;
    public int maxCoins = 10;
    public float burstForce = 5f;
    public float upwardForce = 10f;
    public float coinLifetime = 2.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnCoinBurst();
        }
    }

    void SpawnCoinBurst()
    {
        int numberOfCoins = Random.Range(minCoins, maxCoins + 1);

        for (int i = 0; i < numberOfCoins; i++)
        {
            GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            Rigidbody2D coinRb = coin.GetComponent<Rigidbody2D>();

            // �?t l?c t�c �?ng l�n �?ng xu �? n� r�i xu?ng
            coinRb.AddForce(new Vector2(Random.Range(-burstForce, burstForce), upwardForce), ForceMode2D.Impulse);

            StartCoroutine(DestroyCoinAfterDelay(coin,coinLifetime));
        }
    }

    IEnumerator DestroyCoinAfterDelay(GameObject coin, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(coin);
    }


}
