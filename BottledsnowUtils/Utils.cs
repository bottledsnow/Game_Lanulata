using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bottlesnow.Utils
{
    public static class UtilsClass
    {
        //�����H�����k�@�Ƥ�V�C(2D)
        public static Vector3 GetRandomDirection()
        {
            return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        }

    }
}
