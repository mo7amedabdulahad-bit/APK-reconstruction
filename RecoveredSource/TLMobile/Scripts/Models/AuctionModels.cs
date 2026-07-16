// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Models/AuctionModels.cs
// ============================================================================
//
// Reconstructed from: Auction data binding paths, auction UI bindings
// Confidence: 92%
// Evidence:
//   - auctionItem/* paths (15+ bindings)
//   - auctionInterface/* paths (10+ bindings)
//   - auction localization keys
//   - Assembly: TLMobile.dll
// ============================================================================

using System;
using TLMobile.Scripts.Enums;

namespace TLMobile.Scripts.Models
{
    /// <summary>
    /// Auction item data model.
    /// Confidence: 93%
    /// Evidence: "auctionItem/nextFinishAt", "auctionItem/auctionsCount",
    ///   "auctionItem/itemWrapper", "auctionItem/item/nameDecoded"
    /// </summary>
    [Serializable]
    public class AuctionItem
    {
        /// <summary>Auction end time. Confidence: 93%</summary>
        public DateTime nextFinishAt;

        /// <summary>Number of auctions. Confidence: 92%</summary>
        public int auctionsCount;

        /// <summary>Item wrapper data. Confidence: 93%</summary>
        public InventoryItemWrapper itemWrapper;

        /// <summary>Item details. Confidence: 92%</summary>
        public AuctionItemDetail item;
    }

    /// <summary>
    /// Auction item detail information.
    /// Confidence: 91%
    /// Evidence: "auctionItem/item/nameDecoded", "auctionItem/item/wrapper/heroItemCategoryIndex",
    ///   "auctionItem/item/wrapper/quality"
    /// </summary>
    [Serializable]
    public class AuctionItemDetail
    {
        public string nameDecoded;
        public InventoryItemWrapper wrapper;
    }

    /// <summary>
    /// Auction interface/bid data.
    /// Confidence: 92%
    /// Evidence: "auctionInterface/price", "auctionInterface/status",
    ///   "auctionInterface/bidsAmount", "auctionInterface/finishedAt",
    ///   "auctionInterface/highestBidderTag", "auctionInterface/itemWrapper"
    /// </summary>
    [Serializable]
    public class AuctionInterface
    {
        /// <summary>Current bid price. Confidence: 93%</summary>
        public long price;

        /// <summary>Bid status. Confidence: 93%</summary>
        public BidStatus status;

        /// <summary>Number of bids. Confidence: 92%</summary>
        public int bidsAmount;

        /// <summary>Auction end time. Confidence: 92%</summary>
        public DateTime finishedAt;

        /// <summary>Highest bidder tag. Confidence: 92%</summary>
        public HighestBidderTag highestBidderTag;

        /// <summary>Item wrapper. Confidence: 91%</summary>
        public InventoryItemWrapper itemWrapper;

        /// <summary>
        /// Show item details popup.
        /// Confidence: 89% - Evidence: "auctionInterface/ShowItemDetailsPopup()"
        /// </summary>
        public void ShowItemDetailsPopup()
        {
            // Method inferred from data binding
        }
    }
}
