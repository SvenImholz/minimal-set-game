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
    public void GetHint_ReturnsHint_WhenThereIsOnePossibleSet()
    {
        var gameId = new Guid();
        var cards = new List<Card>
        {
            new Card // This card is part of a set
            {
                GameId = gameId,
                Color = Color.Red,
                Fill = Fill.Outlined,
                Number = Number.One,
                Shape = Shape.Diamond,
                IsDrawn = true
            },
            new Card // This card is part of a set
            {
                GameId = gameId,
                Color = Color.Green,
                Fill = Fill.Solid,
                Number = Number.Two,
                Shape = Shape.Squiggle,
                IsDrawn = true
            },
            new Card
            {
                GameId = gameId,
                Color = Color.Green,
                Fill = Fill.Solid,
                Number = Number.Two,
                Shape = Shape.Squiggle,
                IsDrawn = true
            },
            new Card
            {
                GameId = gameId,
                Color = Color.Red,
                Fill = Fill.Striped,
                Number = Number.Three,
                Shape = Shape.Diamond,
                IsDrawn = true
            },
            new Card
            {
                GameId = gameId,
                Color = Color.Purple,
                Fill = Fill.Solid,
                Number = Number.One,
                Shape = Shape.Oval,
                IsDrawn = true
            },
            new Card // This card is part of a set
            {
                GameId = gameId,
                Color = Color.Purple,
                Fill = Fill.Striped,
                Number = Number.Three,
                Shape = Shape.Oval,
                IsDrawn = true
            },
        };
        var game = new Game(gameId)
        {
            Deck = cards
        };

        var result = GameService.GetHint(game);

        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetHint_ReturnsNull_WhenThePossibleCardsAreAlreadyASetOrNotASet()
    {
        var gameId = new Guid();
        var cards = new List<Card>
        {
            new Card // Already in a Set
            {
                GameId = new Guid(),
                Color = Color.Red,
                Fill = Fill.Outlined,
                Number = Number.One,
                Shape = Shape.Diamond,
                IsDrawn = true
            },
            new Card // Already in a Set
            {
                GameId = new Guid(),
                Color = Color.Green,
                Fill = Fill.Solid,
                Number = Number.Two,
                Shape = Shape.Squiggle,
                IsDrawn = true
            },
            new Card //Already in a Set
            {
                GameId = new Guid(),
                Color = Color.Purple,
                Fill = Fill.Striped,
                Number = Number.Three,
                Shape = Shape.Oval,
                IsDrawn = true
            },
            new Card // Not a Set with the remaining cards
            {
                GameId = new Guid(),
                Color = Color.Green,
                Fill = Fill.Solid,
                Number = Number.Two,
                Shape = Shape.Squiggle,
                IsDrawn = true
            },
            new Card // Not a Set with the remaining cards
            {
                GameId = new Guid(),
                Color = Color.Red,
                Fill = Fill.Striped,
                Number = Number.Three,
                Shape = Shape.Diamond,
                IsDrawn = true
            },
            new Card // Not a Set with the remaining cards
            {
                GameId = new Guid(),
                Color = Color.Purple,
                Fill = Fill.Solid,
                Number = Number.One,
                Shape = Shape.Oval,
                IsDrawn = true
            },

        };

        var set = new Set(gameId, [cards[0], cards[1], cards[2]]);

        var game = new Game(gameId)
        {
            Deck = cards,
            Sets = [set]
        };

        var result = GameService.GetHint(game);

        Assert.That(result, Is.Null);
    }
}
