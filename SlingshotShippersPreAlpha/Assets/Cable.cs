using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    public GameObject cable;
    private LineRenderer line;
    private SpringJoint springJoint;
    public GameObject object1;
    public GameObject object2;

    // Start is called before the first frame update
    void Start()
    {
        line = cable.GetComponent<LineRenderer>();
        springJoint = object1.GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPositions(new Vector3[] {transform.TransformPoint(springJoint.anchor), springJoint.connectedBody.transform.TransformPoint(springJoint.connectedAnchor)});
    }
}
