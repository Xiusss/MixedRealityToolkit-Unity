
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using UnityEngine;
using UnityEngine.Assertions;
using Unity;
public enum ClipId {

	None,
	Intro,
	Details,
	
//INTERACTION TRAINING
	GazeTrainingFirstObjectGazed,
	GazeTrainingSecondObjectGazed,
	TapTrainingFirstObjectGazed,
	TapTrainingSecondObjectGazed,
	
	TutorialObjectManipulationFirstObjectReleased,
	TutorialObjectManipulationSecondObjectReleased,
	TutorialObjectManipulationFirstObjectGrabbed,
	TutorialObjectManipulationSecondObjectGrabbed,
	
	TutorialButtonPressFirstButtonPressed,
	TutorialButtonPressSecondButtonPressed,
	
	TutorialVoiceFirstObjectActivated,
	TutorialVoiceSecondObjectActivated,
	
	TutorialAvatarFirstInteraction,
	TutorialAvatarFirstInteractionCompleted,
	TutorialAvatarSecondInteraction,
	TutorialAvatarSecondInteractionCompleted,
	
	SelectedVoiceTrainingFirstObjectActivated,
	SelectedVoiceTrainingSecondObjectActivated,
	SelectedVoiceTrainingElementClicked,
	ClickerTrainingFirstObjectGazed,
	ClickerTrainingSecondObjectGazed,

//LEARNING
	SceneSafetyUserInfo,
	ConsciousnessEvaluationConsciousnessEvaluationLearningStatement,
	ConsciousnessEvaluationConsciousnessEvaluationRehearsalStatement,
	ConsciousnessEvaluationBreathingEvaluationLearningStatement,
	ConsciousnessEvaluationBreathingEvaluationRehearsalStatement,
	ConsciousnessEvaluationBreathingEvaluationWrong,
	ConsciousnessEvaluationConsciousnessEvaluationCorrect,
	ConsciousnessEvaluationConsciousnessEvaluationWrong,
	ConsciousnessEvaluationBreathAndConsciousnessEvaluation,
	ConsciousnessEvaluationUserInfoSpeakNoShake,
	ConsciousnessEvaluationUserInfoNoSpeakShake,
	ConsciousnessEvaluationUserInfoNoSpeakNoShake,
	
	CheckAirwayUserInfo,
	CheckAirwayUserInfoOneHand,
	CheckAirwayHandPlaced,
	CheckAirwayRequestEvaluation,
	CheckAirwayCorrectEvaluation,
	CheckAirwayWrongEvaluation,
	CheckAirwayEvaluationNotUnderstood,
	
	CheckBreathUserInfoNotPositioned,
	CheckBreathUserInfoNotLooked,
	CheckBreathAssessBreath,
	CheckBreathAssessBreathCorrect,
	CheckBreathAssessBreathWrong,
	
	CheckPulseUserInfo,
	CheckPulseCarotidHandPlaced,
	CheckPulseAssessPulse,
	CheckPulseAssessPulseCorrect,
	CheckPulseAssessPulseWrong,
	
	CallEmergencyUserInfo,
	
	AskDefibrillatorUserInfo1,
	AskDefibrillatorUserInfo2,
	AskDefibrillatorUserInfo3,

	LearnerPositioningUserInfo,
	LearnerPositioningLearnerInPlace,
	
	VictimAlignmentUserInfoSingular,
	VictimAlignmentUserInfoPlural,
	VictimAlignmentCorrectLimbPositioned,
	VictimAlignmentRemoveClothes,
	
	CPRHandsPlacement,
	CPRHandsPosition,
	CPRFingersPosition,
	CPRShouldersPosition,
	CPRArmsPosition,
	CPRDepth,
	CPRRate,
	CPRRelease,
	CPRBip,
	
	ApplyBreathMaskUserInfoNoMaskGrabbed,
	ApplyBreathMaskUserInfoMaskNotPositioned,
	DeliverBreathUserInfoHeadNotPositioned,
	DeliverBreathUserInfoPositionNotHeld,
	DeliverBreathBreathDelivered,
	
	DefibrillatorTurnOnUserInfo,
	DefibrillatorTurnOnTurnedOn,

	DefibrillatorInitPlugConnected,
	DefibrillatorInitPaddlePlaced,
	DefibrillatorInitPaddlesPlaced,
	DefibrillatorInitUserInfoStart,
	DefibrillatorInitUserInfoPlug,
	DefibrillatorInitUserInfoPaddles,
	
	DefibrillatorChargedCanDischarge,
	DefibrillatorChargedNoDischarge,
	
	DefibrillationSecurityProtocolSecondIntro,
	DefibrillatorSecurityProtocolSuggestionsNoScreamLook,
	DefibrillatorSecurityProtocolSuggestionsScreamNoLook,
	DefibrillatorSecurityProtocolSuggestionsNoScreamNoLook,
	
	CPRAndDischargeRemindCPR,
	CPRAndDischargeRemindDefibrillatorCharge,
	CPRAndDischargeRemindDefibrillation,
	
//Defibrillator
	DefibrillatorDischargeReadyLoop,
	DefibrillatorReady,
	DefibrillatorApplyPads,
	DefibrillatorPluginConnector,
	DefibrillatorReadyNoDischarge,
	DefibrillatorDischarge,
	
	BackwardEvaluationCheckPulse,
	BackwardEvaluationCheckBreath,
	BackwardEvaluationCheckAirway,
	
	PulseNoBreathingSequenceDeliverBreath,
	PulseNoBreathingSequenceCheckPulse,
	PulseNoBreathingSequenceEmergencyArrives,
	
	EmergencyArrivesOverdoseEvaluationCorrect,
	EmergencyArrivesOverdoseEvaluationWrong,
	
//Electric Therapy Nodes

	PatientArrivesDefibrillationScenario1,
	PatientArrivesDefibrillationScenario2,
	PatientArrivesTachycardiaScenario1,
	PatientArrivesTachycardiaScenario2,
	PatientArrivesBradycardiaScenario1,
	PatientArrivesBradycardiaScenario2,
	
	DefibrillatorPaddlesPlacementUserInfo,

	EvaluateShockableRhythmAssessRhythm,
	EvaluateShockableRhythmAssessRhythmCorrect,
	EvaluateShockableRhythmAssessRhythmWrong,
	
	DefibrillatorPaddlesRepositionUserInfo,
	
	DefibrillatorEnergySettingUserInfoPushButton,
	DefibrillatorEnergySettingUserInfoCorrectEnergy,
	DefibrillatorEnergySettingCorrectEnergy,
	
	DefibrillatorEnergySettingTachyarrhythmiaUserInfoPushButton,
	DefibrillatorEnergySettingTachyarrhythmiaUserInfoCorrectEnergy,
	DefibrillatorEnergySettingTachyarrhythmiaCorrectEnergy,
	
	GrabDefibrillatorPaddlesUserInfo,
	
	DefibrillatorChargePaddlesIntentNotRecognized,
	DefibrillatorChargePaddlesUserInfo,
	DefibrillatorChargePaddlesCharged,
	DefibrillatorDischargePaddlesIntentNotRecognized,
	DefibrillatorDischargePaddlesUserInfo,
	DefibrillatorDischargePaddlesDischarged,
	
	DefibrillatorChargePlatesUserInfo,
	DefibrillatorChargePlatesCharged,
	DefibrillatorDischargePlatesUserInfo,
	DefibrillatorDischargePlatesDischarged,
	
	DefibrillatorElectrodesModeSwitchUserInfo,
	
	ElectrodesPlacementUserInfo,
	
	EvaluateRhythmCheckMonitor,
	EvaluateRhythmAssessRhythm,
	EvaluateRhythmAssessRhythmCorrect,
	EvaluateRhythmAssessRhythmWrong,
	
	DefibrillatorPlatesSetupPlatesPlaced,
	DefibrillatorPlatesSetupUserInfo,
	DefibrillatorPlatesSetupCardioversion,
	DefibrillatorPlatesSetupPacing,
	
	DefibrillatorSyncFunctionUserInfo,
	DefibrillatorPacingFunctionUserInfo,
	
	SedatePatientUserInfo,
	
	DefibrillatorMonitorCheckCheckMonitor,
	DefibrillatorMonitorCheckAssessRhythm,
	DefibrillatorMonitorCheckAssessRhythmCorrect,
	DefibrillatorMonitorCheckAssessRhythmWrong,
	
//Airway Management Nodes

	CheckAvailableMedicalDevicesUserInfo,
	CheckAvailableMedicalDevicesCorrectlyPositioned,
	OpenMouthUserInfo,
	OropharyngealAirwayPlacementUserInfoPlacement,
	OropharyngealAirwayPlacementUserInfoTwist,
	ApplyBagValveMaskUserInfo,
	DeliverBreathBagValveCPRUserInfo,
	DeliverBreathBagValveCPRNode,
	DeliverBreathBagValveNode,
	DeliverBreathBagValveCPRLoop,
	DeliverBreathBagValveNoCPRUserInfo,
	RepeatCompression,
	TimerExpired,
	CompressNow,
	
	
// Rule manager warning and error messages

	TrainingConsciousnessEvaluationWrong,
	TrainingBreathingEvaluationWrong,
	TrainingConsciousnessEvaluationNotReceived,
	TrainingBreathEvaluationNotReceived,
	
	EvaluationManagerSessionTimerExpired,
	
	WrongUserNodeCompleted,

}

public enum ObjectTextId
{
	None,
	Tooltip,
	
	EyeGazeableAvatarAttentionRequested,
	EyeGazeableAvatarUnclearAnswer,
	
	PhoneBoxOperatorPickingUp,
	PhoneBoxOperatorStoppedPickingUp,
	PhoneBoxOperatorHowOld,
	PhoneBoxOperatorConsciousness,
	PhoneBoxOperatorBreath,
	PhoneBoxOperatorEndCall,
	
	WalkingObserverAttentionRequested,
	WalkingObserverDefibrillatorRequested,
	WalkingObserverReturned,
	
	EmergencyAvatarTakeControl,
	EmergencyAvatarAskOverdose,
	EmergencyAvatarAskOverdoseRepeat,
	EmergencyAvatarAskOverdoseNotUnderstand,
	EmergencyAvatarSalute,
	
	DefibrillatorTurnOnTooltip,
	DefibrillatorChargeTooltip,
	DefibrillatorDischargeTooltip,
	DefibrillatorEnergyTooltip,
	DefibrillatorElectrodesModeTooltip,
	DefibrillatorSyncFunctionTooltip,
	DefibrillatorPaceFunctionTooltip,
	
	DefibrillatorPaddleRepositionTooltip,
	
	NursePositiveAnswer,
	NurseIntentNotRecognized,
	
	VirtualInstructorConfirmQuit,
	VirtualInstructorReturningHome,
	VirtualInstructorCancelReturningHome,
	VirtualInstructorIntentNotClear,
	VirtualInstructorNoDetailsAvailable,
	
	MainManagerNoLicense
}

public enum WordID
{
	And, Enabled, Disabled
}

public struct RichTextParameters
{
	public string RichTextKey;
	public string ParamKey;
	public string ParamValue;


	public RichTextParameters(string richTextKey, string paramKey, string paramValue)
	{
		RichTextKey = richTextKey;
		ParamKey = string.IsNullOrEmpty(paramKey) ? richTextKey : paramKey;
		ParamValue = paramValue;
	}
	
	public RichTextParameters(string richTextKey, string paramKey)
	{
		ParamKey = paramKey;
		ParamValue = "";
		RichTextKey = richTextKey;
	}
}
public struct RichText
{
	public string originalText;
	public string cleanedText;
	public Dictionary<string, List<RichTextParameters>> Parameters;

	//Rich text appears as {CONSCIOUSNESS:"CONSCIOUS"="conscious";"VITAL"="showing vital signs"}
	public RichText(string text)
	{
		originalText = text;
		cleanedText = originalText;
		Parameters = new Dictionary<string, List<RichTextParameters>>();
		int parametersGroupIndex = 1;
		while (true)
		{
			Regex regex = new Regex(@"\{[^}]*\}", RegexOptions.Multiline);
			Match match = regex.Match(cleanedText);
			if (!match.Success)
				break;
			
			//Debug.LogWarning($"Parsing Rich Text:{match.Value}");
			int parametersIndex = match.Index;
			int parametersLength = match.Length;
			
			string cleanedParameters = match.Value.TrimStart('{').TrimEnd('}');

			string richTextKey = "";
			string[] parameters;
			string[] richTextData = cleanedParameters.Split('=');

			//multiple item case
			//{CONSCIOUSNESS="CONSCIOUS":"conscious";"VITAL":"showing vital signs"}
			if (richTextData.Length > 1)
			{
				richTextKey = richTextData[0];
				parameters = richTextData[1].Split(';');
			}
			//single item case
			//{"NUMBER":""}
			else
			{
				parameters = new[] { cleanedParameters };
				richTextKey = cleanedParameters.Split(':')[0].TrimStart('"').TrimEnd('"');;
			}
			
			
			if (parameters.Length == 0)
			{
				parameters = new[] { cleanedParameters };
			}

			for (int j = 0; j < parameters.Length; j++)
			{
				string parameter = parameters[j];
				string[] keyValue = parameter.Split(':');
				string key = keyValue[0].TrimStart('"').TrimEnd('"');
				string value = keyValue[1].TrimStart('"').TrimEnd('"');
				if (!Parameters.ContainsKey(richTextKey))
					Parameters[richTextKey] = new List<RichTextParameters>();
				
				Parameters[richTextKey].Add(new RichTextParameters(richTextKey,key,value));
			}
			
			cleanedText = cleanedText.Remove(parametersIndex, parametersLength);
			cleanedText = cleanedText.Insert(parametersIndex, richTextKey);

		}
	}

	public string GetText(params RichTextParameters[] parameters)
	{
		string resultingText = cleanedText;

		if (Parameters.Count != parameters.Length)
		{
			Debug.LogWarning($"Rich text requested with {parameters.Length} parametters, but rich text contains {Parameters.Count} internal parameters. Returning unchanged text {cleanedText}");
			return resultingText;
		}
		
		if (parameters.Length == 0)
			return resultingText;
		
		foreach (RichTextParameters givenParameter in parameters)
		{
			if (!Parameters.ContainsKey(givenParameter.RichTextKey))
			{
                Debug.LogWarning($"Rich Text does not contain a RichTextKey:{givenParameter.RichTextKey}. Current Rich Text is:{cleanedText}");
				continue;
			}

			foreach (RichTextParameters parameter in Parameters[givenParameter.RichTextKey])		
			{
				if(!givenParameter.ParamKey.Equals(parameter.ParamKey))
					continue;

				string value = string.IsNullOrEmpty(givenParameter.ParamValue)
					? parameter.ParamValue
					: givenParameter.ParamValue;
				
				resultingText = resultingText.Replace(givenParameter.RichTextKey, value);
				break;
			}

			
		}

		return resultingText;
	}
}

public class LocaleManager : Singleton<LocaleManager>
{
	public event EventHandler<EventArgs> LanguageChanged; 

    private Dictionary<Language,Dictionary<string, Dictionary<ClipId, RichText>>> languageActivitiesTexts =  
        new Dictionary<Language, Dictionary<string, Dictionary<ClipId, RichText>>>();

    private Dictionary<string, Dictionary<Language, Dictionary<ObjectTextId, string>>> objectsTexts =
        new Dictionary<string, Dictionary<Language, Dictionary<ObjectTextId, string>>>();

    private Dictionary<Language, Dictionary<WordID, string>> words =
	    new Dictionary<Language, Dictionary<WordID, string>>();

    protected string[] yesKeywords = null;
    protected string[] noKeywords = null;

    public static Language CurrentLanguage { get; private set; } = Language.ITA;
    public static Language[] SupportedLanguages { get; private set; } = new[] { Language.ITA };

    protected override void Awake()
    {
        base.Awake();
        LoadLanguageRepository();
       // CurrentLanguage = Configuration.GetEnum("language", CurrentLanguage);
        SupportedLanguages = new[] { Language.ENG, Language.ITA };
        //SupportedLanguages = new[] { Language.ENG };
        InitializeLanguageData(CurrentLanguage);
    }
    
    private void InitializeLanguageData(Language currentLanguage)
    {
	    //somethings here should be moved to an XML
	    
	    switch (currentLanguage)
	    {
		    case Language.ENG:
			    yesKeywords = new string[]{"yes"};
			    noKeywords = new string[]{"no"};
			    break;
		    case Language.ITA:
			    yesKeywords = new string[]{"see", "sea", "set", "sip", "say", "sing", "sick", "yes"};
			    noKeywords = new string[]{"no", "know"};
			    break;
		    case Language.FRA:
			    break;
		    case Language.ESP:
			    break;
		    default:
			    throw new ArgumentOutOfRangeException(nameof(currentLanguage), currentLanguage, null);
	    }
    }

    protected void LoadLanguageRepository()
    {
	    //TODO load from XML all texts...
	    LoadObjectsTexts();

	    words[Language.ENG] = new Dictionary<WordID, string>()
	    {
		    { WordID.And, "and" },
		    { WordID.Enabled, "enabled"},
		    { WordID.Disabled, "disabled"}
	    };
	    words[Language.ITA] = new Dictionary<WordID, string>()
	    {
		    { WordID.And, "e" },
		    { WordID.Enabled, "abilitato"},
		    { WordID.Disabled, "disabilitato"}
	    };
    }
    
    public void SetLanguage(Language language)
    {
        if(CurrentLanguage == language)
            return;

        CurrentLanguage = language;
        InitializeLanguageData(CurrentLanguage);
        
        LanguageChanged?.Invoke(this, EventArgs.Empty);
    }
    
    private void LoadObjectsTexts()
    {
	    TextAsset[] objectsTextAssets = Resources.LoadAll<TextAsset>("Objects");
	    if (objectsTextAssets.Length == 0)
	    {
            Debug.LogWarning($"No objects text in Resources folder Objects.");
		    return;
	    }

	    foreach (TextAsset objectText in objectsTextAssets)
	    {
		    XmlDocument doc = new XmlDocument();

		    try
		    {
			    doc.LoadXml(objectText.text);
		    }
		    catch (Exception e)
		    {
                Debug.LogError("error in loading file " + objectText.name + " :: " + e);
			    return;
		    }

		    XmlNodeList languagesNodeList = doc.SelectNodes("/object/language");
		    if (languagesNodeList == null)
			    return;

		    Dictionary<Language, Dictionary<ObjectTextId, string>> objectTexts =
			    new Dictionary<Language, Dictionary<ObjectTextId, string>>();
		    
		    foreach (XmlNode languageNode in languagesNodeList)
		    {
			    if (languageNode.Attributes["value"] == null)
			    {
                    Debug.LogWarning(
					    $"Object:{objectText.name} parsing data. Missing language value in node language");
				    continue;
			    }

			    Language language = Language.None;
			    Enum.TryParse(languageNode.Attributes["value"].InnerText, out language);
			    if (language == Language.None)
			    {
                    Debug.LogWarning(
					    $"Object:{objectText.name} parsing data. Cannot parse language:{languageNode.Attributes["language"].InnerText}.");
				    continue;
			    }

			    if (objectTexts.ContainsKey(language))
			    {
                    Debug.LogWarning($"Object:{objectText.name}  multiple instances of language:{language}");
				    continue;
			    }

			    objectTexts[language] = new Dictionary<ObjectTextId, string>();

			    foreach (XmlNode textNode in languageNode.ChildNodes)
			    {
				    string text = textNode.InnerText;
				    if (string.IsNullOrEmpty(text)) continue;

				    if (textNode.Attributes["id"] == null)
				    {
                        Debug.LogWarning(
						    $"Object:{objectText.name} parsing data. Phrase node does not contain clipId attribute. Phrase is: {text}");
					    continue;
				    }

				    ObjectTextId objectTextId = ObjectTextId.None;
				    Enum.TryParse(textNode.Attributes["id"].InnerText, out objectTextId);
				    if (objectTextId == ObjectTextId.None)
				    {
					    Debug.LogWarning(
						    $"Object:{objectText.name} parsing data. Cannot parse id:{textNode.Attributes["id"].InnerText}. Phrase is:{text}");
					    continue;
				    }

				    if (objectTexts[language].ContainsKey(objectTextId))
				    {
                        Debug.LogWarning(
						    $"Object:{objectText.name} phrases already contains an id:{objectTextId} for language:{language}");
					    continue;
				    }

				    objectTexts[language][objectTextId] = text;
			    }
		    }

		    if (objectsTexts.ContainsKey(objectText.name))
		    {
			    Debug.LogWarning(
				    $"Object:{objectText.name} is already contained in LocaleManager objectsTexts collection");
			    continue;
		    }

		    objectsTexts[objectText.name] = objectTexts;
	    }
    }

    public void AddActivityTexts(Language language, string activityName, Dictionary<ClipId, string> content)
    {
        if (!languageActivitiesTexts.ContainsKey(language))
            languageActivitiesTexts.Add(language, new Dictionary<string, Dictionary<ClipId, RichText>>());

        Dictionary<string, Dictionary<ClipId, RichText>> activitiesTexts = languageActivitiesTexts[language];

        Dictionary<ClipId, RichText> richTextContents = new Dictionary<ClipId, RichText>();
        foreach (KeyValuePair<ClipId,string> keyValuePair in content)
        {
	        richTextContents[keyValuePair.Key] = new RichText(keyValuePair.Value);
        }
        
        activitiesTexts[activityName] = richTextContents;
    }

    public void ClearActivityTexts()
    {
	    languageActivitiesTexts.Clear();
    }

    public string GetActivityText(string activityName, ClipId clipId, params RichTextParameters[] parameters)
    { 
        if (!languageActivitiesTexts.ContainsKey(CurrentLanguage))
        {
            Debug.LogWarning($"Activities Texts does not contain language:{CurrentLanguage}");
            return null;
        }

        Dictionary<ClipId, RichText> activityTexts = null;
        if (!languageActivitiesTexts[CurrentLanguage].TryGetValue(activityName, out activityTexts))
        {
            Debug.LogWarning($"Language:{CurrentLanguage}, Activities Texts does not contain activity Data:{activityName}");
            return null;
        }

        RichText result;
        if (!activityTexts.TryGetValue(clipId, out result))
        {
            Debug.LogWarning($"Language:{CurrentLanguage}, Activity:{activityName} does not contain text for ClipId:{clipId}");
            return null;
        }
        
        return result.GetText(parameters);
    }

    public string GetObjectText(string objectName, ObjectTextId id)
    {
	    if (!objectsTexts.ContainsKey(objectName))
	    {
            Debug.LogWarning($"LocaleManager does not contain object:{objectName} among its objects texts");
		    return "";
	    }

	    if (!objectsTexts[objectName].ContainsKey(CurrentLanguage))
	    {
            Debug.LogWarning($"LocaleManager does not contain Language Data:{CurrentLanguage} for object:{objectName}");
		    return "";
	    }
	    
	    if (!objectsTexts[objectName][CurrentLanguage].ContainsKey(id))
	    {
            Debug.LogWarning($"LocaleManager does not contain objectId:{id} for Language Data:{CurrentLanguage} for object:{objectName}");
		    return "";
	    }

	    return objectsTexts[objectName][CurrentLanguage][id];

    }
    
    public string GetWord(WordID wordId)
    {
	    if (!words.ContainsKey(CurrentLanguage))
	    {
            Debug.LogWarning($"Words collection does not contain language:{CurrentLanguage}");
		    return "";
	    }

	    if (!words[CurrentLanguage].ContainsKey(wordId))
	    {
            Debug.LogWarning($"Language:{CurrentLanguage} Words collection does not contain WordId:{wordId}");
		    return "";
	    }

	    return words[CurrentLanguage][wordId];
    }
    
    public string[] GetYesNoKeywords()
    {
	    List<string> list = new List<string>();
	    list.AddRange(yesKeywords);
	    list.AddRange(noKeywords);
	    return list.ToArray();
    }

    public bool IsYesKeyword(string key)
    {
	    return Array.IndexOf(yesKeywords, key) >= 0;
    }
    
    public bool IsNoKeyword(string key)
    {
	    return Array.IndexOf(noKeywords, key) >= 0;
    }
    
    public string GetLimbWord(LimbType limbType)
    {
	    switch (CurrentLanguage)
	    {
		    case Language.ENG:
			    switch (limbType)
			    {
				    case LimbType.None:
					    break;
				    case LimbType.LeftHand:
					    return "left hand";
				    case LimbType.RightHand:
					    return "right hand";
				    case LimbType.LeftFoot:
					    return "left foot";
				    case LimbType.RightFoot:
					    return "right foot";
				    default:
					    throw new ArgumentOutOfRangeException(nameof(limbType), limbType, null);
			    }
			    break;
		    case Language.ITA:
			    switch (limbType)
			    {
				    case LimbType.None:
					    break;
				    case LimbType.LeftHand:
					    return "la mano sinistra";
				    case LimbType.RightHand:
					    return "la mano destra";
				    case LimbType.LeftFoot:
					    return "il piede sinistro";
				    case LimbType.RightFoot:
					    return "il piede destro";
				    default:
					    throw new ArgumentOutOfRangeException(nameof(limbType), limbType, null);
			    }
			    break;
		    case Language.FRA:
			    break;
		    case Language.ESP:
			    break;
		    default:
			    throw new ArgumentOutOfRangeException();
	    }

	    return "";
    }

    public string GetReadableRolesName(List<User.Role> roles)
    {
	    string result = "";
	    foreach (User.Role role in roles)
	    {
		    result += GetLanguageRoleName(role) + " ";
	    }

	    return result;
    }
    
    public string GetLanguageRoleName(User.Role role, Language language = Language.None)
    {
	    if (language == Language.None)
		    language = CurrentLanguage;
	    
	    switch (language)
	    {
		    case Language.None:
			    break;
		    case Language.ENG:
			    return role.ToString();
		    case Language.ITA:
			    switch (role)
			    {
				    case User.Role.Any:
					    return "chiunque";
				    case User.Role.Instructor:
					    return "istruttore";
				    case User.Role.Red:
					    return "rosso";
				    case User.Role.Green:
					    return "verde";
				    case User.Role.Blue:
					    return "blu";
				    default:
					    throw new ArgumentOutOfRangeException(nameof(role), role, null);
			    }
		    case Language.FRA:
			    throw new ArgumentOutOfRangeException(nameof(language), language, null);
			    break;
		    case Language.ESP:
			    throw new ArgumentOutOfRangeException(nameof(language), language, null);
			    break;
		    default:
			    throw new ArgumentOutOfRangeException(nameof(language), language, null);
	    }

	    return "";
    }

}
