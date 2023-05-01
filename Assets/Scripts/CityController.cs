using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pincushion.LD53
{
    public class CityController : MonoBehaviour
    {
        public Dictionary<string, IPlatformController> Platforms = new Dictionary<string, IPlatformController>();
        public Dictionary<string, IPlatformController> SourcePlatforms { get { return Platforms; } }//; = new Dictionary<string, IPlatformController>();
        public Dictionary<string, IPlatformController> DestinationPlatforms { get { return Platforms; } }//; = new Dictionary<string, IPlatformController>();
        public IPlatformController Headquarters = null;

        private void Awake()
        {
            IPlatformController[] platforms = GetComponentsInChildren<IPlatformController>();

            SourcePlatforms.Clear();
            DestinationPlatforms.Clear();
            foreach (IPlatformController platform in platforms)
            {
                if (platform.Id == null || platform.Id == "")
                {
                    Debug.LogError("Platform " + platform.gameObject.name + " is missing Id");
                    continue;
                }

                /*if (platform.PlatformType == PlatformType.Source)
                {
                    SourcePlatforms.Add(platform.Id, platform);
                }
                if (platform.PlatformType == PlatformType.Destination)
                {
                    DestinationPlatforms.Add(platform.Id, platform);
                }*/
                if (platform.PlatformType == PlatformType.Headquarters)
                {
                    Headquarters = platform;
                }
                Platforms.Add(platform.Id, platform);
            }

            string platformString= "";
            foreach (KeyValuePair<string, IPlatformController> kv in Platforms)
            {
                platformString += kv.Key + ",";
            }
            Debug.Log("Platforms" + platformString);
        }

        public void Init()
        {
        }


    }
}