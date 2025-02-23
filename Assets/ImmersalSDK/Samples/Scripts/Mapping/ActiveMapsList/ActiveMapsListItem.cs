﻿/*===============================================================================
Copyright (C) 2020 Immersal Ltd. All Rights Reserved.

This file is part of the Immersal SDK.

The Immersal SDK cannot be copied, distributed, or made available to
third-parties for commercial purposes without written permission of Immersal Ltd.

Contact sdk@immersal.com for licensing requests.
===============================================================================*/

using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Immersal.REST;

namespace Immersal.Samples.Mapping.ActiveMapsList
{
    public class ActiveMapsListItem : MonoBehaviour
    {
        [SerializeField]
		private TextMeshProUGUI m_MapIdField = null;
		[SerializeField]
		private TextMeshProUGUI nameField = null;

		[SerializeField]
		private Toggle toggle = null;

        public int mapId = -1;

        private ActiveMapsListControl m_ActiveMapsListControl = null;

		private void ToggleValueChanged(Toggle t)
		{
            if(t.isOn && mapId > 0)
            {
                Debug.Log(string.Format("toggle on: {0}", mapId));
                m_ActiveMapsListControl.rootMapId = mapId;
            }
		}

        public void SetMapId(int id)
		{
			if (m_MapIdField != null)
			{
                mapId = id;
				m_MapIdField.text = string.Format("{0}", id);
			}
		}

        public void SetToggleGroup(ToggleGroup toggleGroup)
		{
            if (toggle != null)
			{
                toggle.group = toggleGroup;
            }
		}


		public void SetName(string mapName)
		{
			if (nameField != null)
			{
				nameField.text = string.Format("{0}", mapName);
			}
		}

        public void SetListController(ActiveMapsListControl activeMapsListControl)
        {
            m_ActiveMapsListControl = activeMapsListControl;
        }

		private void Start()
		{
            toggle.onValueChanged.AddListener(delegate {ToggleValueChanged(toggle);});
		}
	}
}
