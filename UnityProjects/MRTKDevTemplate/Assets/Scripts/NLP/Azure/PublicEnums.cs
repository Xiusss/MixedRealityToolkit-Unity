
// public enum LimbType
// {
//     RightHand,
//     LeftHand
// }

public enum HandPose
{
    Neutral = 0,
    Pointing = 1,
    GrabOnly = 2,
    Closed = 3,
    HoldTablet = 4,
    HoldCylinder = 5,
    HoldSyringe = 6,
    HoldLarge = 7,
    OpenHand = 8,
    HoldIndexThumb = 9,
    OpenMouth = 10
}

public enum MenuState
{
    General,
    VideoHelp,
    ImageHelp,
    TextHelp,
    AudioHelp
}

public enum WindowElementType
{
    None,
    Text,
    Image,
    Video,
    Options,
    ScrollPanel,
    CheckListElement
}

public enum Gender
{
    None,
    Male,
    Female,
    NonBinary
}

public enum EquipmentType
{
    None,
    Drug,
    Tool
}

public enum PatientConditionValueType
{
    Boolean,
    ThreeLevels,
    Integer
}


public enum Mode
{
    Tutorial = 0,
    Learning = 1,
    Training = 2,
    Evaluation = 3,
    Freestyle = 4
}

public enum PatientConditionDiscoveryType
{
    None,
    FullBodyVisualExam,
    HeadVisualExam,
    MouthExam
}


public enum MedicalToolType
{
    None,
    Laryngoscope,
    OrotrachealTubeBig,
    BagValve,
    Fenantyl,
    Midazolam,
    AMBUMask,
    Tape,
    Stethoscope,
    Scalpel,
    KellyForceps,
    TracheostomyTube,
    SuctionUnit,
    Oxymeter,
    MagillForceps,
    OrotrachealTubeSmall,
    XylocaineSpray,
    Capnograph,
    GuedelDevice,
    Bougie,
    IVAccess,
    Monitors,
    ObjectA,
    ObjectB,
    ObjectC
}

public enum ErrorType
{
    None,
    Minor,
    Major,
    Fatal
}

public enum Scenario
{
    Default = 0,
    Count
}

public enum DialogueState
{
    None,
    AskingState,
    AskingQuitConfirmation,
    AskingEquipmentInfo,
    AskingMedia,
    AskingAnamnesis,
    WaitingForRepeatCommand,
    WaitingForDetails,
    HoldingPatient
}

public enum MediaType
{
    None,
    Image,
    Video,
    Demonstration
}

public enum Language
{
    None,
    ENG,
    ITA,
    FRA,
    ESP
}

public enum AnamnesysQuestion
{
    None,
    PreviousIntubation,
    RespiratoryDeseases,
    CoagulationAbnormalities,
    HeadAbnormalities,
    Fasting,
    DentalArchChanges,
    Arthritis,
    Reflux,
    Diabetes,
    Count
}

public enum AgentType
{
    None,
    VirtualInstructor,
    Patient,
    Nurse
}

public enum ConditionType
{
    BloodInOralCavity,
    Color,
    Cyanosis,
    DeepIntubation,
    FailedIntubation,
    ForeignBody,
    Oedema,
    StomachIntubation,
    //conditions for anamnesys, currently not used
    Arthritis,
    CoagulationAbnormalities,
    IncisorProtusion,
    RetrognaticJaw,
    TypeIDiabetes,
    Fasting,
    CongenitalSyndromicAbnormalitiesOfTheHeadOrNeck,
    PriorIntubationDifficulties,
    GastroesophagealReflux,
    RespiratoryDisease,
    Age,
    Obesity,
    FullBeard,
    Pregnant,
    BruisesAndBurns,
    ObstructedNostrils,
    TemporomandibularJointMovements,
    GlasgowScaleEyes,
    GlasgowScaleVerbal,
    GlasgowScaleMotor
}

public enum StethoscopeAttachmentID
{
    Neck,
    Lung1,
    Lung2,
    Lung3,
    Lung4,
    Lung5,
    Lung6,
    Stomach
}

public enum ECAVoice
{
    Liam,
    Jason,
    Eric
}