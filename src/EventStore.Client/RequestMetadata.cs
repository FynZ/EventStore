using System;
using System.Net.Http.Headers;
using System.Text;
using Grpc.Core;

namespace EventStore.Client {
	public static class RequestMetadata {
		public static Metadata Create(UserCredentials userCredentials) =>
			userCredentials == null
				? new Metadata()
				: new Metadata {
					new Metadata.Entry(Constants.Headers.Authorization, new AuthenticationHeaderValue(
							Constants.Headers.BasicScheme,
							Convert.ToBase64String(
								Encoding.ASCII.GetBytes($"{userCredentials.Username}:{userCredentials.Password}")))
						.ToString())
				};
	}
}
