using UnityEngine;

public class TooltipController : MonoBehaviour
{
    private ToolTip tooltip;
    private void Awake()
    {
        tooltip = GetComponent<ToolTip>();
        if(tooltip != null)
        {
            ToolTipConnector toolTipConnector = tooltip.GetComponent<ToolTipConnector>();

            //This property MUST not be setted via editor because the TooltipConnector [AlwaysRuns] in editor mode. If no camera is found it will add
            //one in the hierarchy
            toolTipConnector.PivotDirectionOrient = ConnectorOrientType.OrientToCamera;
        }
    }

}
