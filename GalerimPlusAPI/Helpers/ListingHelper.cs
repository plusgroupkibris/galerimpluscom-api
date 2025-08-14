using GalerimPlusAPI.Enums;
using GalerimPlusAPI.Models;

namespace GalerimPlusAPI.Helpers;

public static class ListingHelpers
{
    public static bool HasPriceChanged(CarListing listing)
    {
        if (listing.PriceHistory == null || listing.PriceHistory.Count <= 1)
            return false;

        var first = listing.PriceHistory.First();
        var last = listing.PriceHistory.Last();
        return first.Amount != last.Amount;
    }

    public static bool HasPriceDecreased(CarListing listing)
    {
        if (listing.PriceHistory == null || listing.PriceHistory.Count <= 1)
            return false;

        var first = listing.PriceHistory.First();
        var last = listing.PriceHistory.Last();
        return last.Amount < first.Amount;
    }

    public static bool HasPriceIncreased(CarListing listing)
    {
        if (listing.PriceHistory == null || listing.PriceHistory.Count <= 1)
            return false;

        var first = listing.PriceHistory.First();
        var last = listing.PriceHistory.Last();
        return last.Amount > first.Amount;
    }

    public static decimal GetPriceChangePercentage(CarListing listing)
    {
        if (listing.PriceHistory == null || listing.PriceHistory.Count <= 1)
            return 0;

        var first = listing.PriceHistory.First();
        var last = listing.PriceHistory.Last();
        if (first.Amount == 0) return 0;
        return ((last.Amount - first.Amount) / first.Amount) * 100;
    }

    public static bool IsActive(CarListing listing) => listing.Status == ListingStatus.Active;
    public static bool IsPending(CarListing listing) => listing.Status == ListingStatus.Pending;
    public static bool IsSold(CarListing listing) => listing.Status == ListingStatus.Sold;
    public static bool IsExpired(CarListing listing) => listing.Status == ListingStatus.Expired;
    public static bool IsRejected(CarListing listing) => listing.Status == ListingStatus.Rejected;
    public static bool IsInactive(CarListing listing) => listing.Status == ListingStatus.Inactive;
}
