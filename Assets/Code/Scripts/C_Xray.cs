using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class C_Xray : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction XRayActivation;

    


    SkinnedMeshRenderer meshRenderer;
    Material[] baseMaterials;
    int baseLayer;
    bool xRayOn;
    public Material xRayMaterial;
    List<Material> xRayMaterials;
    public UnityEvent onXRay;
    public UnityEvent offXRay;

    void Awake()
    {
        XRayActivation = playerInput.actions["XRayVision"];
    }

    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        baseMaterials = meshRenderer.materials;
        baseLayer = gameObject.layer;
        xRayMaterials = new List<Material> { xRayMaterial };
        for (int i = 0; i <baseMaterials.Length - 1; i++)
        {
            xRayMaterials.Add(xRayMaterial);
        }

    }

    // Update is called once per frame
    void Update()
    {
       //if (Input.GetKeyDown(KeyCode.X))
       //{
       //    xRayOn = !xRayOn;
       //}
       //if(xRayOn != true)
       //{
       //    gameObject.layer = baseLayer;
       //    meshRenderer.materials = baseMaterials;
       //    offXRay.Invoke();
       //}
       //else
       //{
       //    gameObject.layer = 8;
       //    meshRenderer.materials = xRayMaterials.ToArray();
       //    onXRay.Invoke();
       //}

    }

    private void OnEnable()
    {
        XRayActivation.performed += _ => XRayActiveStart();
        XRayActivation.canceled += _ => XRayActiveStop();
    }

    private void OnDisable()
    {
        XRayActivation.performed -= _ => XRayActiveStart();
        XRayActivation.canceled -= _ => XRayActiveStop();
    }

    void XRayActiveStart()
    {
        gameObject.layer = 8;
        meshRenderer.materials = xRayMaterials.ToArray();
        onXRay.Invoke();
    }

    void XRayActiveStop()
    {
        gameObject.layer = baseLayer;
        meshRenderer.materials = baseMaterials;
        offXRay.Invoke();

    }



}
