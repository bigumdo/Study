using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAgentComponent
{ 
    //Agent가 컴포넌트를 모두 가지고 있기 위해 만든 interface이자 한번에 Init하기 위해 만든 것
    public void Initialize(Agent agent);
}
