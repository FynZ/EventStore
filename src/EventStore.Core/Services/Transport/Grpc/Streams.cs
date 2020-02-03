using System;
using EventStore.Core.Authentication;
using EventStore.Core.Bus;
using EventStore.Core.Services.Storage.ReaderIndex;
using EventStore.Core.Services.TimerService;

namespace EventStore.Core.Services.Transport.Grpc {
	public partial class Streams : EventStore.Client.Streams.Streams.StreamsBase {
		private readonly IQueuedHandler _queue;
		private readonly IReadIndex _readIndex;
		private readonly IAuthenticationProvider _authenticationProvider;
		private readonly ITimeProvider _timeProvider;
		private readonly int _maxAppendSize;

		public Streams(ITimeProvider timeProvider, IQueuedHandler queue, IAuthenticationProvider authenticationProvider,
			IReadIndex readIndex, int maxAppendSize) {
			if (queue == null) throw new ArgumentNullException(nameof(queue));
			if (authenticationProvider == null) throw new ArgumentNullException(nameof(authenticationProvider));

			_queue = queue;
			_readIndex = readIndex;
			_authenticationProvider = authenticationProvider;
			_maxAppendSize = maxAppendSize;
			_timeProvider = timeProvider;
		}
	}
}
