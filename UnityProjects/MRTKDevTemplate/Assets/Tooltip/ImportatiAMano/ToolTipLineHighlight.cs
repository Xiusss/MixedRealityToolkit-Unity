// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using UnityEngine;

    /// <summary>
    /// Renders an outline around tooltip background
    /// </summary>
    [AddComponentMenu("Scripts/MRTK/SDK/ToolTipLineHighlight")]
    public class ToolTipLineHighlight : MonoBehaviour, IToolTipHighlight
    {
        public bool ShowHighlight
        {
            set
            {
                lineRenderer.enabled = value;
            }
        }

        [SerializeField]
        private BaseMixedRealityLineRenderer lineRenderer = null;
    }
