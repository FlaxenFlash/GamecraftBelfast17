using Assets.Source;
using Assets.Source.Messaging.Messages;

public class PlayedPromiseMessage : GameMessage
{
	public Promise Promise;
	public Faction Faction;
}