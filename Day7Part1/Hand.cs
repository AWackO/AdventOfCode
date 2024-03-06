internal class Hand
{
    public string Cards { get; }
    public int Bid { get; }

    public Hand(string cards, int bid)
    {
        Cards = cards;
        Bid = bid;
    }
}