using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] private Transform ExplosionPoint;
    [SerializeField] private GameObject Explosion;
    bool isShooted = false;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isShooted)
        {
            GameObject tmp = Instantiate(Explosion, ExplosionPoint.position, Quaternion.Euler(0, 0, 0));
            tmp.transform.localScale = new Vector3(2, 2, 2);
            Destroy(tmp, 0.5f);



        }
    }
}
