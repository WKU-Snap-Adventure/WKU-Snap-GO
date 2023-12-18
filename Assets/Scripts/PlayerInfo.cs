using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public string itemName;
    public int itemAmount;

    // Given JSON input:
    // {"name":"Dr Charles","lives":3,"health":0.8}
    // this example will return a PlayerInfo object with
    // name == "Dr Charles", lives == 3, and health == 0.8f.
}