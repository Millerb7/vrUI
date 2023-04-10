using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    // location of the panel
    private vector<int> loc;


    // material component grabbed from the files for whatever component the ui needs to be
    private Material material;
    // 
    private Mesh mesh;
    //
    private MeshRenderer meshRenderer;
    //
    private MeshFilter meshFilter;

    // default panel constructor
    public void Panel () {
        material = gameObject.get
    }

    /* args:
        mat - Material the panel will be made of
        mesh - Mesh the panel will have applied to it
    
    */
    public void Panel ( Material mat, Mesh mesh ) {
        material = mat;
        mesh = mesh
    }

}

