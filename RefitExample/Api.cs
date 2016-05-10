using System;
using System.Threading.Tasks;
using Refit;
namespace RefitExample
{

	// "http://api.soundcloud.com/users/67393202/tracks.json?client_id=0be8085a39603d77fbf672a62a7929ea";
	public interface ISoundcloudApi
	{
		[ Get ("/users/{user}/tracks.json?client_id={clientId}")]
		Task<Track []> GetTracks (string clientId, string user);
	}

	public interface IGithubApi
	{
		[Get ("/users/{user}")]
		Task<User> GetUser (string user);
	}

}

