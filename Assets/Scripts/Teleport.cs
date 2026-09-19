using System.Collections.Specialized;

using System.Security.Cryptography;
using System.Security.Permissions;
using System.Threading;
using UnityEngine;
//integers are whole numbers
// float is decimal numbers
//Public makes variables accessible to devs in editor
//single = sign is an assignment of whatever is on the other side of the =
public class Teleport : MonoBehaviour
{
    public KeyCode teleportKey;

    public KeyCode quitKey;

    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    public Transform tf;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetKey updates the entire time the key is down, GetKeyDown updates only when key is first pressed each time its pressed.
        if (Input.GetKeyDown(teleportKey))
        {
            tf.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }

        if (Input.GetKeyDown(quitKey))
        {
            Application.Quit();
        }
    }
}
