using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFactory : MonoBehaviour
{

    public GameObject UFOPrefab = null;

    private List<GameObject> used = new List<GameObject>();
    private List<GameObject> free = new List<GameObject>();

    private void Awake()
    {
        UFOPrefab = Instantiate(Resources.Load("UFO") as GameObject);
        UFOPrefab.SetActive(false);
    }

    public GameObject getUFO(int round)
    {
        GameObject newUFO = null;
        if (free.Count > 0)
        {
            newUFO = free[0].gameObject;
            newUFO.SetActive(true);
            free.Remove(free[0]);
        }
        else
        {
            newUFO = Instantiate(UFOPrefab);
            newUFO.SetActive(true);
        }
        used.Add(newUFO);

        if (round == 1)
        {
            newUFO.GetComponent<Transform>().localScale= new Vector3(1.5f, 1.5f * 0.5f, 1.5f);
            newUFO.GetComponent<Renderer>().material.color = Color.red;
        }
        else if(round == 2)
        {
            newUFO.GetComponent<Transform>().localScale = new Vector3(1, 1 * 0.5f, 1);
            newUFO.GetComponent<Renderer>().material.color = Color.green;
        }
        else if(round == 3)
        {
            newUFO.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f * 0.5f, 0.5f);
            newUFO.GetComponent<Renderer>().material.color = Color.blue;
        }
        return newUFO;
    }

    public void freeUFO(GameObject theUFO)
    {
        GameObject tmp = null;
        foreach (GameObject ufo in used)
        {
            if (ufo.GetInstanceID() == theUFO.GetInstanceID() )
            {
                tmp = ufo;
            }
        }
        if (tmp != null)
        {
            tmp.SetActive(false);
            free.Add(tmp);
            used.Remove(tmp);
        }
    }

}