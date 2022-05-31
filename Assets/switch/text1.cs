using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text1 : MonoBehaviour
{
    float localX;
    float localY;
    float localZ;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        localX = transform.localPosition.x;
        localZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        localY = transform.localPosition.y + speed * Time.deltaTime;
        transform.localPosition = new Vector3(localX, localY, localZ);
    }
}
