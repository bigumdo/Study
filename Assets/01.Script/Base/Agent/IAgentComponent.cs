using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAgentComponent
{ 
    //Agent�� ������Ʈ�� ��� ������ �ֱ� ���� ���� interface���� �ѹ��� Init�ϱ� ���� ���� ��
    public void Initialize(Agent agent);
}
