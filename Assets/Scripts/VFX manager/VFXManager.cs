using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : Singleton<VFXManager>
{
    public enum VFXType
    {
        JUMP,
        VFX_2
    }

    public List<VFXManagertSetup> vfxSetup;

    public void PlayVFXByType(VFXType vfxType, Vector3 position)
    {
        foreach(var i in vfxSetup) //Vai pesquisar na lista o tipo de efeito, se ele tiver ele toca
        {
            if(i.vfxType == vfxType)
            {
                var item = Instantiate(i.prefab);
                item.transform.position = position;
                Destroy(item.gameObject, 3f);
                break;

            }
        }
    }
   
}

[System.Serializable]
public class VFXManagertSetup
{
    public VFXManager.VFXType vfxType;
    public GameObject prefab;

}
