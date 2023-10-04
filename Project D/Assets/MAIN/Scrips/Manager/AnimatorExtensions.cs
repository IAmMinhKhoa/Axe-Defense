using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorExtensions 
{
    public static bool HasParameter(this Animator animator, string parameterName)
    {
        // Ki?m tra xem animator có parameterName không
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name == parameterName)
            {
                return true;
            }
        }
        return false;
    }
}
