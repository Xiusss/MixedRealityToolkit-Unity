using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INodeObject
{
    public bool IsReactive { get; set;}

    public void EnableTooltip(bool enable);

    public void EnableGraphicalHelpers(bool enable);
}
