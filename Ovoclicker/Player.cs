namespace Ovoclicker;

public class Player {
	public string name;
	private int _ovopoints;
	private int _tapPower = 0;
	public Player(string name) {
		this.name = name;
	}

	public int GetTapPower()
	{
		return _tapPower;
	}

	public void SetTapPower(int newTapPower) 
	{
		_tapPower = newTapPower;
	}

	public int GetOvopoints()
	{
		return _ovopoints;
	}

	public void SetOvopoints(int newOvopoints)
	{
		_ovopoints = newOvopoints;
	}
}