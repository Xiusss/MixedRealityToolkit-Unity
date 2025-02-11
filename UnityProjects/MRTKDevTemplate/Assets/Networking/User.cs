using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public enum Role{None, Any, Instructor, Red, Green, Blue, Remote }
    public enum ControllerType{Windows,Hololes}

    public Role SessionRole { get; protected set; } = Role.Any;
}
