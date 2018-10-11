namespace MagazynChemikaCNSLAPP.Abstract
{
	public interface IGlassware
	{
		string Name { get; set; }
		decimal Price { get; set; }
		float Volume { get; set; }
		int Quality { get; set; }
		string Condition { get; set; }
		bool IsClean { get; set; }
		int ItemID { get; set; }
	}
}
