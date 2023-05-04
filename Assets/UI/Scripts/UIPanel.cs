using UnityEngine;
using Oculus.Interaction;

public class UIPanel : MonoBehaviour, IActiveState
{
    public bool IsBeingViewed { get; set; }

    public bool Active
    {
        get { return IsBeingViewed; }
    }

    public void SetBeingViewedTrue()
    {
        Debug.Log("Being viewed");
        IsBeingViewed = true;
    }

    public void SetBeingViewedFalse()
    {
        IsBeingViewed = false;
    }
}




