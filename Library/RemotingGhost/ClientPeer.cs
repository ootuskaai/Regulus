﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Regulus.Remoting.PhotonExtension
{


	class ClientPeer : ExitGames.Client.Photon.PhotonPeer, Regulus.Remoting.IGhostRequest
	{
		///////////////////////////////////////////////////////////////////////////////////////
		///
		///////////////////////////////////////////////////////////////////////////////////////
		public ClientPeer(ExitGames.Client.Photon.IPhotonPeerListener listener, ExitGames.Client.Photon.ConnectionProtocol protocolType)
			: base(listener, protocolType)
		{

		}

		///////////////////////////////////////////////////////////////////////////////////////
		/// 斷線的廣播事件
		///////////////////////////////////////////////////////////////////////////////////////
		public event Action DisconnectEvent;
		public override void Disconnect()
		{
			if (DisconnectEvent != null)
				DisconnectEvent.Invoke();
			base.Disconnect();
		}

		void IGhostRequest.Request(byte code , Dictionary<byte , object> args )
		{
			OpCustom( code , args , true);
		}
	}
}
