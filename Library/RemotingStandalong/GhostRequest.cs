﻿
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Regulus.Remoting.Standalone

{
	public class GhostRequest : IGhostRequest
	{
		public event Action<Guid, string, Guid, byte[][]> CallMethodEvent;

		public event Action PingEvent;

		public event Action<Guid> ReleaseEvent;

		

		private readonly Queue<RequestPackage> _Requests;

		public GhostRequest()
		{
			_Requests = new Queue<RequestPackage>();
		}

		void IGhostRequest.Request(ClientToServerOpCode code, byte[] args)
		{
			lock(_Requests)
			{
				_Requests.Enqueue(
					new RequestPackage
					{
						Code = code, 
						Data = args
					});
			}
		}

		public void Update()
		{
			var requests = new Queue<RequestPackage>();
			lock(_Requests)
			{
				while(_Requests.Count > 0)
				{
					requests.Enqueue(_Requests.Dequeue());
				}
			}

			while(requests.Count > 0)
			{
				var request = requests.Dequeue();
				_Apportion(request.Code, request.Data);
			}
		}

		private void _Apportion(ClientToServerOpCode code, byte[] args)
		{
			if(ClientToServerOpCode.Ping == code)
			{
				if(PingEvent != null)
				{
					PingEvent();
				}
			}
			else if(ClientToServerOpCode.CallMethod == code)
			{
				

				/*var EntityId = new Guid(args[0]);

				var MethodName = Encoding.Default.GetString(args[1]);

				byte[] par = null;
				var ReturnId = Guid.Empty;
				if(args.TryGetValue(2, out par))
				{
					ReturnId = new Guid(par);
				}

				var MethodParams = (from p in args
				                    where p.Key >= 3
				                    orderby p.Key
				                    select p.Value).ToArray();*/


			    var data = args.ToPackageData<PackageCallMethod>();
                if (CallMethodEvent != null)
				{
                    
                    CallMethodEvent(data.EntityId, data.MethodName, data.ReturnId, data.MethodParams);
				}
			}
			else if(ClientToServerOpCode.Release == code)
			{
                var data = args.ToPackageData<PackageRelease>();
                //var EntityId = new Guid(args[0]);
				ReleaseEvent(data.EntityId);
			}
		}
	}
}
