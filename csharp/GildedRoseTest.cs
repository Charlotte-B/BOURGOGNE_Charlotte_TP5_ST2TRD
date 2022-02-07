using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        // No Specific Product //
        [Test] 
        public void SellInWhenDayIsOverForNoSpecificProduct()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Product", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
        }
        
        [Test]
        public void QualityWhenDayIsOverForNoSpecificProduct()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Product", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].Quality);
        }
        
        [Test]
        public void QualityWhenOverExpirationDayForNoSpecificProduct()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Product", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);
        }
        
        [Test]
        public void QualityIsZeroWhenDayIsOverForNoSpecificProduct()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Product", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
        
        [Test]
        //The quality must not be higher than 50
        //Quality must be reset to 50
        //This is not the case
        public void QualityIsMaxWhenDayIsOverForNoSpecificProduct()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Product", SellIn = 10, Quality = 52 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }
        
        
        // Aged Brie //
        
        [Test] 
        public void QualityForAgedBrieIncreaseWhenDayIsOver()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(11, Items[0].Quality);
        }
        
        [Test] 
        public void SellInForAgedBrieWhenDayIsOver()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
        }
        
        [Test] 
        public void QualityForAgedBrieWhenSellInIsNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(12, Items[0].Quality);
        }
        
        
        // Sulfuras //
        
        [Test] //SellIn of Sulfuras is always 0
        //This is not the case
        public void SellInForSulfurasWhenDayIsOver()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras", SellIn = 0, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].SellIn);
        }
        
        [Test] //SellIn of Sulfuras is always 0
        //This is not the case
        public void SellInForSulfurasWhenSellInIsNotInitializedTo0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras", SellIn = 10, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].SellIn);
        }
        
        [Test] //Quality of Sulfuras is always 80
        //This is not the case
        public void QualityForSulfurasWhenDayIsOver()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras", SellIn = 10, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
        }
        
        [Test] //Quality of Sulfuras is always 80
        //This is not the case
        public void QualityForSulfurasWhenQualityIsNotInitializedTo80()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
        }
        
        
        
        // Conjured //
        
        [Test]
        public void SellInForConjuredWhenDayIsOver()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
        }
        
        [Test] // Quality must decrease by -2
        //This is not the case (decrease by -1)
        public void QualityForConjuredWhenDayIsOver()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);
        }
        
        [Test]
        public void QualityForConjuredWhenOverExpirationDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);
        }
        
        [Test]
        public void QualityForConjuredWhenQualityIsZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = -1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
        
        [Test] //The quality must not be higher than 50
        //Quality must be reset to 50
        //This is not the case
        public void QualityForConjuredWhenQualityIsMax()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 10, Quality = 54 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }
        
        
        
        // Backstage passes //

        [Test] 
        public void SellInForBackstagePassesWhenDayIsOver ()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
        }
        
        [Test] //Quality must increase by +1 when SellIn > 10
        //This is not the case (decrease by -1)
        public void QualityForBackstagePassesWhenSellInSuperior10()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 11, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(11, Items[0].Quality);
        }
        
        [Test] //Quality must increase by +2 when 5 < SellIn =< 10
        //This is not the case (decrease by -1)
        public void QualityForBackstagePassesWhenSellInBetween5And10()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(12, Items[0].Quality);
        }
        
        [Test] //Quality must increase by +3 when 0 =< SellIn =< 5
        //This is not the case (decrease by -1)
        public void QualityForBackstagePassesWhenSellInBetween0And5()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(13, Items[0].Quality);
        }
        
        [Test] //The quality must be 0 after the concert
        //This is not the case (decrease by -2)
        public void QualityForBackstagePassesWhenOverExpirationDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
        
        
        
        
        [Test] //Quality must be reset to 0
        //This is not the case (But was:  -2)
        public void QualityForBackstagePassesWhenQualityIsNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 20, Quality = -2 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
        
        [Test] //Quality must be reset to 0
        //This is not the case (But was:  51)
        public void QualityForBackstagePassesWhenQualityIsMax()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 20, Quality = 52 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }
    }
}
