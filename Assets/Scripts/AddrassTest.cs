using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddrassTest : MonoBehaviour
{
    private AsyncOperationHandle<GameObject> handle;

    private void Start()
    {
        Addressables
            .LoadAssetAsync<GameObject>("GameObject_emp") // �A�h���X�𕶎���Ŏw��
            .Completed += op => {
                // ���ʂ��擾���ăC���X�^���X��
                // �{���̓G���[�n���h�����O�ȂǕK�v
                Instantiate(op.Result);
            };
    }

}
