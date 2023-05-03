using Oculus.Interaction.Input;
using UnityEngine;
using UnityEngine.Assertions;


namespace Oculus.Interaction.PoseDetection
{
    public class Hand_Close : MonoBehaviour, IActiveState
    {
        [SerializeField, Interface(typeof(IHand))]
        private UnityEngine.Object _leftHand;

        [SerializeField, Interface(typeof(IHand))]
        private UnityEngine.Object _rightHand;

        private IHand LeftHand;
        private IHand RightHand;

        [SerializeField]
        private Collider[] _panelCols;

        [SerializeField]
        private Collider[] _gestureCols;

        [SerializeField]
        private HandJointId _jointToTest = HandJointId.HandWristRoot;

        public bool Active { get; private set; }

        private bool _active = false;

        protected virtual void Awake()
        {
            LeftHand = _leftHand as IHand;
            RightHand = _rightHand as IHand;
            Active = false;
        }

        protected virtual void Start()
        {
            this.AssertField(LeftHand, nameof(LeftHand));
            this.AssertField(RightHand, nameof(RightHand));
            this.AssertCollectionField(_panelCols, nameof(_panelCols));
            this.AssertCollectionField(_gestureCols, nameof(_gestureCols));
        }

        protected virtual void Update()
        {
            UpdateHandClose(LeftHand);
            UpdateHandClose(RightHand);

            Active = _active;
        }

        private void UpdateHandClose(IHand hand)
        {
            if (hand.GetJointPose(_jointToTest, out Pose jointPose))
            {
                _active = JointPassesTests(jointPose);
            }
            else
            {
                _active = false;
            }
        }

        private bool JointPassesTests(Pose jointPose)
        {
            bool passesCollisionTest;

            if (_active)
            {
                passesCollisionTest = IsPointWithinColliders(jointPose.position, _gestureCols);
                if(passesCollisionTest) {
                    //Debug.Log("Gesture Distance");
                }
            }
            else
            {
                passesCollisionTest = IsPointWithinColliders(jointPose.position, _panelCols);
                if(passesCollisionTest) {
                    //Debug.Log("Close to panel");
                }
            }

            _active = passesCollisionTest;
            return passesCollisionTest;
        }

        private bool IsPointWithinColliders(Vector3 point, Collider[] colliders)
        {
            foreach (var collider in colliders)
            {
                if (!Collisions.IsPointWithinCollider(point, collider))
                {
                    return false;
                }
            }
            return true;
        }

        #region Inject

        public void InjectAllColliderContainsHandJointActiveState(IHand leftHand, IHand rightHand, Collider[] panelCols, Collider[] gestureCols, HandJointId jointToTest)
        {
            InjectLeftHand(leftHand);
            InjectRightHand(rightHand);
            Panel_Colliders(panelCols);
            Gesture_Colliders(gestureCols);
            InjectJointToTest(jointToTest);
        }

        public void InjectLeftHand(IHand leftHand)
        {
            _leftHand = leftHand as UnityEngine.Object;
            LeftHand = leftHand;
        }

        public void InjectRightHand(IHand rightHand)
        {
            _rightHand = rightHand as UnityEngine.Object;
            RightHand = rightHand;
        }

        public void Panel_Colliders(Collider[] panelCols)
        {
            _panelCols = panelCols;
        }

        public void Gesture_Colliders(Collider[] gestureCols)
        {
            _gestureCols = gestureCols;
        }

        public void InjectJointToTest(HandJointId jointToTest)
        {
            _jointToTest = jointToTest;
        }

        #endregion
    }
}