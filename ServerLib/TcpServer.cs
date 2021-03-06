﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TecWare.DE.Server
{
	///////////////////////////////////////////////////////////////////////////////
	/// <summary></summary>
	public interface IListenerTcp : IDisposable
	{
		IPEndPoint LocalEndPoint { get; }
	} // interface IListenerTcp
	
	///////////////////////////////////////////////////////////////////////////////
	/// <summary>Interface for the tcp-Server interface.</summary>
	public interface IServerTcp
	{
		/// <summary>Registers a listener for a ip endpoint.</summary>
		/// <param name="endPoint">Endpoint to listen on.</param>
		/// <param name="createHandler">Handle that creates the protocol for the in bound data,</param>
		/// <returns>Registered tcp-Listener</returns>
		IListenerTcp RegisterListener(IPEndPoint endPoint, Action<Stream> createHandler);

		/// <summary></summary>
		/// <param name="endPoint">End point for the connection</param>
		/// <param name="timeout"></param>
		/// <returns></returns>
		Task<Stream> CreateConnectionAsync(IPEndPoint endPoint, CancellationToken cancellationToken);

		/// <summary>Resolve the address to the endpoint.</summary>
		/// <param name="dnsOrAddress"></param>
		/// <param name="port"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<IPEndPoint> ResolveEndpointAsync(string dnsOrAddress, int port, CancellationToken cancellationToken);

		/// <summary>Returns a informational string about the given stream. The stream should be
		/// created from the tcp-server.</summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		string GetStreamInfo(Stream stream);
  } // interface IServerTcp
}
