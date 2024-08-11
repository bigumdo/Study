using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1)   * (to2 - from2) + from2;
    // value: 변환하고자 하는 값입니다.
    // from1: 원래 범위의 시작 값입니다.
    // to1: 원래 범위의 끝 값입니다.
    // from2: 새로운 범위의 시작 값입니다.
    // to2: 새로운 범위의 끝 값입니다.
    }

}
