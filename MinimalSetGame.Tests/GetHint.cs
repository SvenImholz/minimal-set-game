using MinimalSetGame.Api.Controllers;
using MinimalSetGame.Api.Entities;
using MinimalSetGame.Api.Enums;
using MinimalSetGame.Api.Services;

namespace MinimalSetGame.Tests;

public class GetHint
{
    [SetUp]
    public void Setup() {}

    [Test]
    public void GetHint_ReturnsHint_WhenHintIsAvailable()
    {
        var gameId = new Guid();
        var cards = new List<Card>
        {
            new Card
            {
                GameId = gameId,
                Color = Color.Red,
                Fill = Fill.Outlined,
                Number = Number.One,
                Shape = Shape.Diamond,
                IsDrawn = true
            },

          // todo add more cards
        };
        var game = new Game(gameId)
        {
            Deck = cards
        };

        var result = GameService.GetHint(game);

        Assert.That(result, Is.Not.Null);
    }
}
