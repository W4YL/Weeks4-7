using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BarrelTrap : MonoBehaviour
{
    public List<GameObject> barrels;
    public GameObject barrelPrefab;
    private GameObject spawnedBarrels;
    public BarrelBehaviour barrelScript;
    public EventDrivenLara playerScript;
    public SpriteRenderer playerSR;
    public SpriteRenderer buttonSR;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = barrels.Count - 1; i >= 0; i--)
        {
            BarrelBehaviour barrel = barrels[i].GetComponent<BarrelBehaviour>();

            if (barrel.barrelImpact)
            {
                Destroy(barrels[i]);
                barrels.RemoveAt(i);

                if (playerSR.bounds.Intersects(buttonSR.bounds))
                {
                    playerScript.health -= 2;
                }
            }
        }
    }

    public void TriggerTrap()
    {
        Debug.Log("Trigger button");
        spawnedBarrels = Instantiate(barrelPrefab, transform.position, transform.rotation);
        barrels.Add(spawnedBarrels);
    }
}
