using Unity.Netcode;
using UnityEngine;

namespace AsteroidInvaders
{
    public class NetworkButtons : MonoBehaviour
    {
        private void OnGUI()
        {
            if (!NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
            {
                GUILayout.BeginArea(new Rect(10, 10, 100, 200));
                if (GUILayout.Button("HOST"))
                {
                    NetworkManager.Singleton.StartHost();
                }
                if (GUILayout.Button("CLIENT"))
                {
                    NetworkManager.Singleton.StartClient();
                }
                GUILayout.EndArea();
            }
        }
    }
}
