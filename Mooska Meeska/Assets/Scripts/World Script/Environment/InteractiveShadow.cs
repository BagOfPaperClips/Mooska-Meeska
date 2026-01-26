using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveShadow : MonoBehaviour
{

    [SerializeField] private Transform shadowTransform;
    [SerializeField] private Transform lightTransform;
    private LightType lightType;
    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private Vector3 extrusionDirecetion = Vector3.zero;
    private Vector3[] objectVertices;
    private Mesh shadowColliderMesh;
    private MeshCollider shadowCollider;

    // Start is called before the first frame update
    void Awake()
    {
        InitializeShadowCollider();
        lightType = lightTransform.GetComponent<Light>().type;
        objectVertices = transform.GetComponent<MeshFilter>().mesh.vertices;
        shadowColliderMesh = new Mesh();
    }

    // Update is called once per frame
    void Update()
    {
        shadowTransform.position = transform.position;
    }
    private void FixedUpdate()
    {
        shadowColliderMesh.vertices = ComputeShadowColliderMeshVertices();
        shadowCollider.sharedMesh = shadowColliderMesh;
    }
    private void InitializeShadowCollider()
    {
        GameObject shadowGameObject = shadowTransform.gameObject;
        //shadowGameObject.hideFlags = HideFlags.HideInHierarchy; //Hidden in the hierarchy
        shadowCollider = shadowGameObject.AddComponent<MeshCollider>();
        shadowCollider.convex = true;
        shadowCollider.isTrigger = true;
    }

    private Vector3[] ComputeShadowColliderMeshVertices()
    {
        Vector3[] points = new Vector3[2 * objectVertices.Length];

        Vector3 raycastDirection = lightTransform.forward;

        int n = objectVertices.Length;

        for(int i = 0; i< n; i++)
        {
            Vector3 point = transform.TransformPoint (objectVertices[i]);
        
            if(lightType != LightType.Directional)
            {
                raycastDirection = point - lightTransform.position;
            }
            points[i] = ComputeIntersectionPoint(point, raycastDirection);
            points[n + 1] = ComputeExtrusionPoint(point, points[i]);
        }

        return points;
    }

    private Vector3 ComputeIntersectionPoint(Vector3 fromPosition, Vector3 direction)
    {
        RaycastHit hit;

        if(Physics.Raycast(fromPosition, direction, out hit, Mathf.Infinity, targetLayerMask))
        {
            return hit.point - transform.position;
        }
        return fromPosition + 100 * direction - transform.position;
    }

    private Vector3 ComputeExtrusionPoint(Vector3 objectVertexPosition, Vector3 shadowPointPosition)
    {
        if(extrusionDirecetion.sqrMagnitude == 0)
        {
            return objectVertexPosition - transform.position;
        }
        return shadowPointPosition + extrusionDirecetion;
    }
}
