// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Oculus.Interaction.Input;
// using UnityEngine.Assertions;

// namespace Oculus.Interaction.PoseDetection
// {
//     public class LookedAt : MonoBehaviour, IActiveState
//     {
//         [SerializeField]
//         private string _targetTag = "UIPanel";

//         [SerializeField]
//         private float _threshold = 0.5f;

//         [SerializeField, Interface(typeof(IHand))]
//         private UnityEngine.Object _hand;

//         public bool Active { get; private set; }

//         private IHand Hand;

//         private void Awake()
//         {
//             Hand = _hand as IHand;
//         }

//         private void Update()
//         {
//             Active = IsBeingSeen();
//         }

//         private bool IsBeingSeen()
//         {
//             GameObject[] targets = GameObject.FindGameObjectsWithTag(_targetTag);
//             foreach (GameObject target in targets)
//             {
//                 Vector3 targetDir = target.transform.position - Hand.Joints[HandJointName.IndexTip].transform.position;
//                 float angle = Vector3.Angle(targetDir, Hand.PointerPose.forward);
//                 if (angle < _threshold)
//                 {
//                     return true;
//                 }
//             }
//             return false;
//         }

//         #region Inject

//         public void InjectTargetTag(string targetTag)
//         {
//             _targetTag = targetTag;
//         }

//         public void InjectHand(IHand hand)
//         {
//             _hand = hand as UnityEngine.Object;
//             Hand = hand;
//         }

//         public void InjectThreshold(float threshold)
//         {
//             _threshold = threshold;
//         }

//         #endregion
//     }
// }

