// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR;


// public class FingerClosingTracker : MonoBehaviour
// {
//     [SerializeField] private HandTracking _handTracking;
//     [SerializeField] private ShapeRecognizer[] _shapeRecognizers;

//     [Header("Finger Closing")]
//     [SerializeField] private FingerClosingTracker _fingerClosingTracker;
//     [SerializeField] private float _distanceFromHand;

//     private Hand _hand;
//     private ShapeRecognizerActiveState _shapeRecognizerActiveState;

//     private void Awake()
//     {
//         _shapeRecognizerActiveState = new ShapeRecognizerActiveState();
//     }

//     private void OnEnable()
//     {
//         _handTracking.HandsManager.OnHandTracked += OnHandTracked;
//         _fingerClosingTracker.FingerClosed += OnFingerClosed;
//     }

//     private void OnDisable()
//     {
//         _handTracking.HandsManager.OnHandTracked -= OnHandTracked;
//         _fingerClosingTracker.FingerClosed -= OnFingerClosed;
//     }

//     private void OnHandTracked(Hand hand)
//     {
//         if (hand.Handedness == Handedness.Right)
//         {
//             _hand = hand;
//         }
//     }

//     private void Update()
//     {
//         if (_hand != null)
//         {
//             // Check if all fingers are facing the user and are up
//             if (CheckFingersFacingUserAndUp(_hand))
//             {
//                 // Activate shape recognizer active state and check if all required shapes are present
//                 _shapeRecognizerActiveState.InjectAllShapeRecognizerActiveState(_hand, _hand.HandStateProvider,
//                     _shapeRecognizers);
//                 if (_shapeRecognizerActiveState.Active)
//                 {
//                     // All required shapes are present, check if all fingers are closed
//                     if (_fingerClosingTracker.CheckIfAllFingersClosed(_hand))
//                     {
//                         // Move an object in front of the hand
//                         Vector3 handPos = _hand.PointerPose.position;
//                         Vector3 middleFingerTipPos = _hand.Joints[HandJointId.MiddleTip].Position;
//                         Vector3 objectPos = handPos + (_distanceFromHand / 3f) * (middleFingerTipPos - handPos).normalized;

//                         // Move object to new position
//                         transform.position = objectPos;
//                     }
//                 }
//             }
//         }
//     }

//     private bool CheckFingersFacingUserAndUp(Hand hand)
//     {
//         foreach (var finger in hand.Fingers)
//         {
//             Vector3 fingerDir = finger.Joints[3].Position - finger.Joints[1].Position;
//             Vector3 fingerUp = finger.Joints[2].Position - finger.Joints[1].Position;
//             if (Vector3.Dot(fingerDir.normalized, -Camera.main.transform.forward) < 0.5f ||
//                 Vector3.Dot(fingerUp.normalized, Camera.main.transform.up) < 0.5f)
//             {
//                 return false;
//             }
//         }

//         return true;
//     }

//     private void OnFingerClosed(Hand hand, HandFinger finger)
//     {
//         Debug.Log($"Finger {finger} on hand {hand.Handedness} has been closed.");
//     }
// }





