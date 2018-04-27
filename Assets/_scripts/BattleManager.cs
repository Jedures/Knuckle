using UnityEngine;

public class BattleManager : MonoBehaviour {

    public GameObject[] Spawners;

    public int CountObjectOnScene = 10;
    private int currentCountObjectOnScene = 0;

    private void Update()
    {
        if (currentCountObjectOnScene < CountObjectOnScene)
        {
            int a = Random.Range(0, 100);
            int spawn = Random.Range(1, Spawners.Length);

            if (a <= 50)
            {
                // spawn AI
                var ai = Instantiate(Resources.Load("Ai")) as GameObject;
                ai.transform.position = Spawners[spawn].transform.position;
            }
            else if (a <= 75)
            {
                // spawn coin1
                var coin = Instantiate(Resources.Load("Score")) as GameObject;
                coin.transform.position = Spawners[spawn].transform.position;
            }
            else
            {
                // spawn coin2
                var coin = Instantiate(Resources.Load("Score2")) as GameObject;
                coin.transform.position = Spawners[spawn].transform.position;
            }

            currentCountObjectOnScene++;
        }
    }
}
