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
            .LoadAssetAsync<GameObject>("GameObject_emp") // アドレスを文字列で指定
            .Completed += op => {
                // 結果を取得してインスタンス化
                // 本来はエラーハンドリングなど必要
                Instantiate(op.Result);
            };
    }

}
