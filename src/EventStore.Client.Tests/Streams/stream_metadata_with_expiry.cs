using System;
using System.Threading.Tasks;
using Xunit;

namespace EventStore.Client.Streams {
	[Trait("Category", "LongRunning")]
	public class stream_metadata_with_expiry : IClassFixture<stream_metadata_with_expiry.Fixture> {
		private readonly Fixture _fixture;

		public stream_metadata_with_expiry(Fixture fixture) {
			_fixture = fixture;
		}

		[Fact]
		public async Task fails_when_operation_expired() {
			var stream = _fixture.GetStreamName();

			await Assert.ThrowsAsync<TimeoutException>(() =>
				_fixture.Client.GetStreamMetadataAsync(stream,
					timeoutAfter: TimeSpan.FromHours(-1)));
		}

		public class Fixture : EventStoreGrpcFixture {
			protected override Task Given() => Task.CompletedTask;
			protected override Task When() => Task.CompletedTask;
		}
	}
}
