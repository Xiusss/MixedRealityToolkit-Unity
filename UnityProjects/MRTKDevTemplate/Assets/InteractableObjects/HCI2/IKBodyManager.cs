using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Assertions;

public enum LimbType
{
    None,
    LeftHand,
    RightHand,
    LeftFoot,
    RightFoot,
}

//public class GrabbableLimb : INodeObject
//{
//    public LimbIKController Controller;
//    public Transform Bone;
//    public LimbDestination Destination;
//    public bool CorrectPosition;

//    protected float BONE_PRECISION_THRESHOLD = 0.2f;

//    public GrabbableLimb(LimbIKController controller, Transform bone, LimbDestination destination)
//    {
//        Controller = controller;
//        Bone = bone;
//        Destination = destination;
//        CorrectPosition = false;
//    }

//    public bool LimbInPosition()
//    {
//        CorrectPosition = Vector3.Distance(Bone.position, Destination.transform.position) <
//                          BONE_PRECISION_THRESHOLD;

//        return CorrectPosition;
//    }

//    public void SnapToBone(bool snapRotation = false)
//    {
//        Controller.transform.position = Bone.position;
//        if (snapRotation)
//            Controller.transform.rotation = Bone.rotation;
//    }

//    private AvatarIKGoal LimbToAvatarIKGoal(LimbType limbType)
//    {
//        switch (limbType)
//        {
//            case LimbType.None:
//                Utility.LogError($"LimbType: {limbType}, does not have a matching AvatarIKGoal element");
//                return 0;
//            case LimbType.LeftHand:
//                return AvatarIKGoal.LeftHand;
//            case LimbType.RightHand:
//                return AvatarIKGoal.RightHand;
//            case LimbType.LeftFoot:
//                return AvatarIKGoal.LeftFoot;
//            case LimbType.RightFoot:
//                return AvatarIKGoal.RightFoot;
//            default:
//                throw new ArgumentOutOfRangeException(nameof(limbType), limbType, null);
//        }
//    }

//    private Quaternion LimbToControllerRotation(LimbType limbType)
//    {

//        switch (limbType)
//        {
//            case LimbType.None:
//                Utility.LogError($"LimbType: {limbType}, does not have a corresponding desired rotation");
//                return Quaternion.identity;
//            case LimbType.LeftHand:
//                return Quaternion.Euler(24.0139618f, 162.061111f, 83.9410553f);
//            case LimbType.RightHand:
//                return Quaternion.Euler(359.825592f, 189.279205f, 276.368103f);
//            case LimbType.LeftFoot:
//                return Quaternion.Euler(-95.942f, -268.767f, 436.062f);
//            case LimbType.RightFoot:
//                return Quaternion.Euler(273.180328f, 50.3292847f, 128.117813f);

//            default:
//                throw new ArgumentOutOfRangeException(nameof(limbType), limbType, null);
//        }
//    }

//    public void SetLimbIK(Animator animator)
//    {
//        //Setting Position
//        animator.SetIKPositionWeight(LimbToAvatarIKGoal(Controller.LimbType), 1);
//        animator.SetIKPosition(LimbToAvatarIKGoal(Controller.LimbType), Controller.transform.position);

//        //Setting Orientation
//        //None of the below options have positive results. Find a way to handle rotation. For the moment without handling it results are acceptable

//        //Approach #1
//        //Controller.transform.localRotation = LimbToControllerRotation(Controller.LimbType);
//        //animator.SetIKRotation(LimbToAvatarIKGoal(Controller.LimbType), Controller.transform.localRotation);

//        //Approach #2
//        //Changing the controller to be oriented in the say way as the previous bone and then apply that rotation
//        Quaternion desiredHandRotation = Bone.transform.parent.rotation;
//        //animator.SetIKRotation(LimbToAvatarIKGoal(Controller.LimbType), desiredHandRotation);
//        Bone.transform.localRotation = Quaternion.identity;

//    }
//    public bool IsReactive
//    {
//        get => Controller.IsReactive;
//        set => Controller.IsReactive = value;
//    }
//    public void EnableTooltip(bool enable)
//    {
//        throw new NotImplementedException();
//    }
//    public void EnableGraphicalHelpers(bool enable)
//    {
//        Controller.ShowHandle(enable);
//        Destination.Show(enable);
//    }
//}

//public class LimbMovedEventArgs : EventArgs
//{
//    public GrabbableLimb Limb;


//    public LimbMovedEventArgs(GrabbableLimb limb)
//    {
//        Limb = limb;
//    }

//}

//public class IKBodyManager : MonoBehaviour, INodeObject
//{
//    [SerializeField] protected Animator animator;
//    [SerializeField] protected Transform bodyTransform;

//    Dictionary<LimbType, GrabbableLimb> limbs = new Dictionary<LimbType, GrabbableLimb>();

//    public event EventHandler<LimbMovedEventArgs> LimbCorrectlyPositioned;
//    public event EventHandler BodyCorrectlyPositioned;
//    public event EventHandler<LimbMovedEventArgs> LimbGrabStared;
//    public event EventHandler<LimbMovedEventArgs> LimbGrabFinished;

//    protected bool controllersInitialized = false;


//    public int CorrectPositionedLimbsCount
//    {
//        get
//        {
//            int count = 0;
//            foreach (var limb in limbs.Values)
//            {
//                if (limb.CorrectPosition)
//                    count++;
//            }

//            return count;
//        }
//    }

//    public bool CorrectlyPositioned => CorrectPositionedLimbsCount == limbs.Count;
//    public int BodyBoneNumber => limbs.Count;
//    public Animator BodyAnimator => animator;
//    void Awake()
//    {
//        Dictionary<LimbType, LimbIKController> limbsIKControllers = new Dictionary<LimbType, LimbIKController>();
//        Dictionary<LimbType, Transform> bones = new Dictionary<LimbType, Transform>();
//        Dictionary<LimbType, LimbDestination> limbsDestinations = new Dictionary<LimbType, LimbDestination>();

//        if (animator == null)
//            animator = GetComponent<Animator>();

//        HumanDescription hd = animator.avatar.humanDescription;
//        string leftFootTransformName = hd.human.FirstOrDefault(x => x.humanName == "LeftFoot").boneName;
//        Transform leftFoot = bodyTransform.RecursiveFindChild(leftFootTransformName);
//        bones.Add(LimbType.LeftFoot, leftFoot);

//        string rightFootTransformName = hd.human.FirstOrDefault(x => x.humanName == "RightFoot").boneName;
//        Transform rightFoot = bodyTransform.RecursiveFindChild(rightFootTransformName);
//        bones.Add(LimbType.RightFoot, rightFoot);

//        string leftHandTransformName = hd.human.FirstOrDefault(x => x.humanName == "LeftHand").boneName;
//        Transform leftHand = bodyTransform.RecursiveFindChild(leftHandTransformName);
//        bones.Add(LimbType.LeftHand, leftHand);

//        string rightHandTransformName = hd.human.FirstOrDefault(x => x.humanName == "RightHand").boneName;
//        Transform rightHand = bodyTransform.RecursiveFindChild(rightHandTransformName);
//        bones.Add(LimbType.RightHand, rightHand);

//        string rightArmTransformName = hd.human.FirstOrDefault(x => x.humanName == "RightLowerArm").boneName;
//        Transform rightArm = bodyTransform.RecursiveFindChild(rightArmTransformName);


//        limbsIKControllers = GetComponentsInChildren<LimbIKController>()
//            .ToDictionary(limbIKController => limbIKController.LimbType, limbIKController => limbIKController);
//        Assert.IsTrue(limbsIKControllers.Count > 0);

//        limbsDestinations = GetComponentsInChildren<LimbDestination>()
//            .ToDictionary(destination => destination.LimbType, destination => destination);
//        Assert.IsTrue(limbsDestinations.Count > 0);


//        for (int i = 1; i < Enum.GetNames(typeof(LimbType)).Length; i++)
//        {
//            LimbType key = (LimbType)i;
//            GrabbableLimb grabbaleLimb = new GrabbableLimb(limbsIKControllers[key], bones[key], limbsDestinations[key]);
//            limbs.Add(key, grabbaleLimb);

//            grabbaleLimb.Controller.OnGrabbed += ((sender, args) =>
//            {
//                if (LimbGrabStared != null)
//                    LimbGrabStared(this, new LimbMovedEventArgs(grabbaleLimb));
//            });

//            grabbaleLimb.Controller.OnDropped += ((sender, args) =>
//            {
//                if (LimbGrabFinished != null)
//                    LimbGrabFinished(this, new LimbMovedEventArgs(grabbaleLimb));
//            });

//            grabbaleLimb.Controller.OnDropped += CheckLimbPosition;

//        }

//        InitializeControllers();
//    }


//    public void InitializeControllers()
//    {
//        controllersInitialized = true;
//        foreach (var limb in limbs.Values)
//        {
//            limb.SnapToBone();
//        }
//    }


//    private void OnAnimatorIK()
//    {
//        if (!controllersInitialized)
//            return;

//        foreach (var limb in limbs.Values)
//        {
//            limb.SetLimbIK(animator);
//        }
//    }

//    private void CheckLimbPosition(object sender, EventArgs e)
//    {
//        LimbIKController controller = (LimbIKController)sender;
//        GrabbableLimb limb = limbs[controller.LimbType];

//        // returns the controller position to the bone position after possible over-extension
//        limb.SnapToBone();

//        if (limb.LimbInPosition())
//        {
//            Utility.Log($"{controller.LimbType} has been correctly positioned");

//            limb.Controller.SetHandleColor(true);
//            limb.Destination.gameObject.SetActive(false);

//            if (LimbCorrectlyPositioned != null)
//                LimbCorrectlyPositioned(this, new LimbMovedEventArgs(limbs[controller.LimbType]));

//        }
//        else
//        {
//            limb.Controller.SetHandleColor(false);
//            limb.Destination.gameObject.SetActive(true);
//        }

//        CheckBodyPosition();
//    }

//    private void CheckBodyPosition()
//    {

//        if (CorrectPositionedLimbsCount == limbs.Count)
//        {
//            if (BodyCorrectlyPositioned != null)
//                BodyCorrectlyPositioned(this, EventArgs.Empty);
//        }
//    }
//    public List<LimbType> LimbsToBePlaced()
//    {
//        List<LimbType> list = new List<LimbType>();
//        foreach (var limb in limbs)
//        {
//            if (!limb.Value.CorrectPosition)
//                list.Add(limb.Value.Controller.LimbType);
//        }

//        return list;
//    }
//    public bool IsReactive
//    {
//        get => limbs.FirstOrDefault().Value.IsReactive;
//        set
//        {
//            foreach (var limb in limbs)
//            {
//                limb.Value.IsReactive = value;
//            };
//        }
//    }
//    public void EnableTooltip(bool enable)
//    {
//        foreach (GrabbableLimb limb in limbs.Values)
//        {
//            limb.Controller.EnableTooltip(enable);
//        }
//    }
//    public void EnableGraphicalHelpers(bool enable)
//    {
//        foreach (GrabbableLimb limb in limbs.Values)
//        {
//            limb.EnableGraphicalHelpers(enable);
//        }
//    }
//}
