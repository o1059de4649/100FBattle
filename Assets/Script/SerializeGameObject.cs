using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SerializeGameObject {

    public static void Register()
    {
        ExitGames.Client.Photon.PhotonPeer.RegisterType(typeof(GameObject), (byte)'G', SerializeColor, DeserializeColor);
    }

    private static byte[] SerializeColor(object i_customobject)
    {
        GameObject gameObject = (GameObject)i_customobject;

        var bytes = new byte[4 * sizeof(float)];
        int index = 0;
        ExitGames.Client.Photon.Protocol.Serialize(gameObject.GetComponent<PhotonView>().ownerId, bytes, ref index);

        return bytes;
    }

    private static object DeserializeColor(byte[] i_bytes)
    {
        var gameObject = new GameObject();
        int index = 0;
        ExitGames.Client.Photon.Protocol.Deserialize(out gameObject.GetComponent<PhotonView>().ownerId, i_bytes, ref index);
      

        return gameObject;
    }
}
