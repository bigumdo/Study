using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAfterInitable
{
    // 기본Init을 하고 해야하는 것들이 존재할 수 있기 때문에 만든 것
    public void AfterInit();
}
