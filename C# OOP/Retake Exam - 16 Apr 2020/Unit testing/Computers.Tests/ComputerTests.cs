namespace Computers.Tests
{
    using System;

    using NUnit.Framework;

    public class ComputerTests
    {
        private Part part1;
        private Part part2;
        private Computer computer1;
        private Computer computer2;

        [SetUp]
        public void Setup()
        {
            this.part1 = new Part("RAM", 10);
            this.part2 = new Part("Video", 20);
            this.computer1 = new Computer("Dell");
            this.computer2 = new Computer("HP");
        }

        [Test]
        public void TestPartConstructor()
        {
            var part = new Part("Test", 10);

            Assert.That(part.Name, Is.EqualTo("Test"));
            Assert.That(part.Price, Is.EqualTo(10));
        }

        [Test]
        public void TestComputerConstructor()
        {
            this.computer1.AddPart(part1);

            Assert.That(computer1.Name, Is.EqualTo("Dell"));
            Assert.That(computer1.Parts.Count, Is.EqualTo(1));
        }

        [Test]
        public void ThrowExceptionWhenNameIsNullOrWhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => this.computer1 = new Computer(null));
            Assert.Throws<ArgumentNullException>(() => this.computer2 = new Computer("     "));
        }

        [Test]
        public void CheckPartsTotalPrice()
        {
            computer1.AddPart(part1);
            computer1.AddPart(part2);

            Assert.That(computer1.TotalPrice, Is.EqualTo(30));
        }

        [Test]
        public void ThrowExceptionWhenPartIsNull()
        {
            part1 = null;

            Assert.Throws<InvalidOperationException>(() => this.computer1.AddPart(part1));
        }

        [Test]
        public void ReturnTrueWhenRemovePart()
        {
            computer1.AddPart(part1);

            Assert.That(() => computer1.RemovePart(part1), Is.EqualTo(true));
        }

        [Test]
        public void ReturnFalseWhenDontRemovePart()
        {
            computer1.AddPart(part1);

            Assert.That(() => computer1.RemovePart(part2), Is.EqualTo(false));
        }

        [Test]
        public void GetPartShouldReturnCorrectPart()
        {
            computer1.AddPart(part1);
            computer1.AddPart(part2);

            Assert.That(() => computer1.GetPart("RAM"), Is.EqualTo(part1));
        }

        [Test]
        public void GetPartShouldReturnNullWhenPartNotExist()
        {
            computer1.AddPart(part1);
            computer1.AddPart(part2);

            Assert.That(() => computer1.GetPart("Test"), Is.EqualTo(null));
        }
    }
}