﻿/* ---------------------------------------
 * Author: Martin Pane (martintayx@gmail.com) (@tayx94)
 * Project: Graphy - Ultimate Stats Monitor
 * Date: 03-Jan-18
 * Studio: Tayx
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * -------------------------------------*/

using UnityEngine;
using System.Collections;

namespace Tayx.Graphy.UI
{
    public interface IModifiableState
    {
        /// <summary>
        /// Set the module state.
        /// </summary>
        /// <param name="newState"></param>
        void SetState(GraphyManager.ModuleState newState);
    }

}
