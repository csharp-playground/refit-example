using NUnit.Framework;
using System;
using Refit;
using System.Linq;

namespace RefitExample
{
	public class SlToken
	{
		public string ClientId => "0be8085a39603d77fbf672a62a7929ea";
		public string UserId => "67393202";
		public string Api => "http://api.soundcloud.com";
	}

	[TestFixture]
	public class RefitSpec
	{

		[Test]
		public void ShouldGetGithubUsers ()
		{
			var api = RestService.For<IGithubApi> ("https://api.github.com");
			var octocat = api.GetUser ("octocat").Result;
			Assert.NotNull (octocat);
		}

		[Test]
		public void ShouldGetTracks ()
		{
			var token = new SlToken ();
			var api = RestService.For<ISoundcloudApi> (token.Api);
			var tracks = api.GetTracks (token.ClientId, token.UserId).Result;

			var genesis = tracks.Where (x => x.Genre == "GENESIS");

			Assert.True (tracks.Length > 0);
			Assert.True (genesis.Count () == 1);
		}
	}
}

