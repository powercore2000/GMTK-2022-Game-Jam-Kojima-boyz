using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystems
{
    public interface ICharacterClass
    {
        public string ClassName { get; }

        public void Ability();

        public void CriticleFailure();
    }
}