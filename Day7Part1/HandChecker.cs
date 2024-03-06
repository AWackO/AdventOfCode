public enum HandType
{
    HighCard,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    FullHouse,
    FourOfAKind,
    FiveOfAKind,
}

internal class HandChecker
{
    private readonly string _cardOrder;
    private readonly string _jokers;

    public HandChecker(string cardOrder, string jokers)
    {
        _cardOrder = cardOrder;
        _jokers = jokers;
    }

    public int GetOrderedHandResult(List<Hand> hands)
    {
        var parsedHands = hands.Select(ParseHand);
        var orderedHands = parsedHands.OrderBy(hand => hand.handType).ThenBy(hand => hand.rank);
        var result = orderedHands.Select((hand, index) => hand.bid * (index + 1)).Sum();
        return result;
    }

    private (HandType handType, int rank, int bid) ParseHand(Hand hand)
    {
        HandType handType = HandType.FiveOfAKind;
        var handWithoutJokers = _jokers is not "" ? hand.Cards.Replace(_jokers, "") : hand.Cards;
        var numJokers = hand.Cards.Length - handWithoutJokers.Length;
        var groups =
            handWithoutJokers
            .GroupBy(cards => cards)
            .Select(cards => cards.Count())
            .OrderByDescending(cards => cards)
            .ToArray();

        if (groups.Length > 0)
        {
            groups[0] += numJokers;
            handType = groups switch
            {
            [5, ..] => HandType.FiveOfAKind,
            [4, ..] => HandType.FourOfAKind,
            [3, 2, ..] => HandType.FullHouse,
            [3, ..] => HandType.ThreeOfAKind,
            [2, 2, ..] => HandType.TwoPair,
            [2, ..] => HandType.OnePair,
                _ => HandType.HighCard,
            };
        }

        var rank = hand.Cards
                    .Select((card, index) => _cardOrder.IndexOf(card) * (int)Math.Pow(13, 5 - index))
                    .Sum();

        return (handType, rank, hand.Bid);
    }
}