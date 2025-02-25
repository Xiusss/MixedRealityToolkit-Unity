// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using UnityEngine;


    public interface IToolTipBackground
    {
        bool IsVisible { set; }

        void OnContentChange(Vector3 localContentSize, Vector3 localContentOffset, Transform contentParentTransform);
    }
