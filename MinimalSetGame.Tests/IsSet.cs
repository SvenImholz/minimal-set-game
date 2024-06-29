using MinimalSetGame.Api.Entities;
using MinimalSetGame.Api.Enums;

namespace MinimalSetGame.Tests;

public class IsSet
{
    [SetUp]
    public void Setup() {}

    [Test]
    public void IsSet_ReturnsTrue_WhenEverythingIsDifferent()
    {
        var gameId = new Guid();
        var cards = new List<Card>
        {
            new Card(
            gameId,
            Color.Red,
            Fill.Outlined,
            Number.One,
            Shape.Diamond),

            new Card(
            gameId,
            Color.Green,
            Fill.Striped,
            Number.Two,
            Shape.Oval),

            new Card(
            gameId,
            Color.Purple,
            Fill.Solid,
            Number.Three,
            Shape.Squiggle)
        };

        var result = Set.IsSet(cards);

        Assert.That(result, Is.True);
    }

    [Test]
    public void IsSet_ReturnsTrue_WhenEverythingIsTheSame()
    {
        var gameId = new Guid();
        var cards = new List<Card>
        {
            new Card(
            gameId,
            Color.Red,
            Fill.Outlined,
            Number.One,
            Shape.Diamond),

            new Card(
            gameId,
            Color.Red,
            Fill.Outlined,
            Number.One,
            Shape.Diamond),

            new Card(
            gameId,
            Color.Red,
            Fill.Outlined,
            Number.One,
            Shape.Diamond),
        };

        var result = Set.IsSet(cards);

        Assert.That(result, Is.True);
    }

    [Test]
    public void IsSet_ReturnsTrue_WhenOnePropertyIsTheSame()
    {
        var gameId = new Guid();
        var cards = new List<Card>
        {
            new Card(
            gameId,
            Color.Red,
            Fill.Outlined,
            Number.One,
            Shape.Diamond),

            new Card(
            gameId,
            Color.Green,
            Fill.Striped,
            Number.One,
            Shape.Oval),

            new Card(
            gameId,
            Color.Purple,
            Fill.Solid,
            Number.One,
            Shape.Squiggle),
        };

        var result = Set.IsSet(cards);

        Assert.That(result, Is.True);
    }

    [Test]
    public void IsSet_ReturnsFalse_WhenTwoColorsAreTheSame()
    {
        var gameId = new Guid();
        var cards = new List<Card>
        {
            new Card(
            gameId,
            Color.Red,
            Fill.Outlined,
            Number.One,
            Shape.Diamond),

            new Card(
            gameId,
            Color.Red,
            Fill.Striped,
            Number.Two,
            Shape.Oval),

            new Card(
            gameId,
            Color.Purple,
            Fill.Solid,
            Number.Three,
            Shape.Squiggle),
        };

        var result = Set.IsSet(cards);

        Assert.That(result, Is.False);
    }

    [Test]
    public void IsSet_ReturnsFalse_WhenTwoShapesAreTheSame()
    {
        var gameId = new Guid();
        var cards = new List<Card>
        {
            new Card(
            gameId,
            Color.Red,
            Fill.Outlined,
            Number.One,
            Shape.Diamond),

            new Card(
            gameId,
            Color.Green,
            Fill.Striped,
            Number.One,
            Shape.Diamond),

            new Card(
            gameId,
            Color.Purple,
            Fill.Solid,
            Number.One,
            Shape.Squiggle),
        };

        var result = Set.IsSet(cards);

        Assert.That(result, Is.False);
    }

    [Test]
    public void IsSet_ReturnsFalse_WhenTwoFillsAreTheSame()
    {
        var gameId = new Guid();
        var cards = new List<Card>
        {
            new Card(
            gameId,
            Color.Red,
            Fill.Outlined,
            Number.One,
            Shape.Diamond),

            new Card(
            gameId,
            Color.Green,
            Fill.Outlined,
            Number.Two,
            Shape.Oval),

            new Card(
            gameId,
            Color.Purple,
            Fill.Solid,
            Number.Three,
            Shape.Squiggle),
        };

        var result = Set.IsSet(cards);

        Assert.That(result, Is.False);
    }

    [Test]
    public void IsSet_ReturnsFalse_WhenTwoNumbersAreTheSame()
    {
        var gameId = new Guid();
        var cards = new List<Card>
        {
            new Card(
            gameId,
            Color.Red,
            Fill.Outlined,
            Number.One,
            Shape.Diamond),

            new Card(
            gameId,
            Color.Green,
            Fill.Striped,
            Number.One,
            Shape.Oval),

            new Card(
            gameId,
            Color.Purple,
            Fill.Solid,
            Number.Three,
            Shape.Squiggle),
        };

        var result = Set.IsSet(cards);

        Assert.That(result, Is.False);
    }

    [Test]
    public void IsSet_ReturnsFalse_WhenNumberOfCardsIsMoreThanThree()
    {
        var gameId = new Guid();
        var cards = new List<Card>
        {
            new Card(
            gameId,
            Color.Red,
            Fill.Outlined,
            Number.One,
            Shape.Diamond),
            new Card(
            gameId,
            Color.Green,
            Fill.Striped,
            Number.Two,
            Shape.Oval),
            new Card(
            gameId,
            Color.Purple,
            Fill.Solid,
            Number.Three,
            Shape.Squiggle),
            new Card(
            gameId,
            Color.Red,
            Fill.Outlined,
            Number.One,
            Shape.Diamond),
        };
        var result = Set.IsSet(cards);

        Assert.That(result, Is.False);
    }

    [Test]
    public void IsSet_ReturnsFalse_WhenNumberOfCardsIsLessThanThree()
    {
        var gameId = new Guid();
        var cards = new List<Card>
        {
            new Card(
            gameId,
            Color.Red,
            Fill.Outlined,
            Number.One,
            Shape.Diamond),
            new Card(
            gameId,
            Color.Green,
            Fill.Striped,
            Number.Two,
            Shape.Oval),
        };
        var result = Set.IsSet(cards);

        Assert.That(result, Is.False);
    }

    [Test]
    public void IsSet_ReturnsFalse_WhenNumberThereAreNoCards()
    {
        List<Card> cards = [];
        var result = Set.IsSet(cards);

        Assert.That(result, Is.False);
    }



}
