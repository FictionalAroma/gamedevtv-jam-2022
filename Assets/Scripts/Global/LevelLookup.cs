using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Global
{
    public class LevelLookup : MonoBehaviour
    {
        public static LevelLookup Instance;

        private void Awake()
        {
            Instance = this;
        }
    }
}
