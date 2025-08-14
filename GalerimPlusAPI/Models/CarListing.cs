using GalerimPlusAPI.Enums;

namespace GalerimPlusAPI.Models;

public class SelectedFeature
{
    public string FeatureId { get; set; } = null!;
    public string GroupId { get; set; } = null!;
}

public class PriceHistoryEntry
{
    public long Date { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = null!;
}

public class ListingRemoveInfo
{
    public string ByUid { get; set; } = null!;
    public string ByRole { get; set; } = null!; // "user" or "admin"
    public string Reason { get; set; } = null!; // "sold", "user-deactivated", "violates-rules", "other"
    public string? Note { get; set; }
    public string? Feedback { get; set; }
    public long At { get; set; } // UTC timestamp
}

public class CarListingNote
{
    public string Id { get; set; } = null!;
    public string CreatedBy { get; set; } = null!;
    public string NameSurname { get; set; } = null!;
    public string Role { get; set; } = null!; // "user" | "admin"
    public string Text { get; set; } = null!;
    public long At { get; set; } // timestamp
}

public class Location
{
    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;
    public string District { get; set; } = null!;
}

public class Mileage
{
    public double Value { get; set; }
    public string Unit { get; set; } = null!;
}

public class Price
{
    public decimal Amount { get; set; }
    public string Currency { get; set; } = null!;
}

public class Seller
{
    public string Uid { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Location { get; set; }
    public string? MemberSince { get; set; }
    public bool? VerifiedSeller { get; set; }
    public List<string>? Badges { get; set; }
    public ContactPreferences? ContactPreferences { get; set; }
}

public class ContactPreferences
{
    public bool AllowDirectPhone { get; set; }
    public bool? AllowPhoneMessaging { get; set; } // eski property
    public bool AllowWebsiteMessaging { get; set; }
}

public class CarListingImages
{
    public List<string> Front { get; set; } = new();
    public List<string> Rear { get; set; } = new();
    public List<string> Side { get; set; } = new();
    public List<string> Interior { get; set; } = new();
    public List<string> Engine { get; set; } = new();
    public List<string> Console { get; set; } = new();
    public List<string> Other { get; set; } = new();
}

public class CarListing
{
    public string Id { get; set; } = null!;
    public string ListingId { get; set; } = null!;
    public string ListingNo { get; set; } = null!;
    public ListingType ListingType { get; set; }
    public ListingStatus Status { get; set; }
    public string ListingEnv { get; set; } = null!; // "development" | "production"
    public string Title { get; set; } = null!;
    public string VariantTitle { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string? Description { get; set; }
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string CarModel { get; set; } = null!;
    public string? Submodel { get; set; }
    public int Year { get; set; }
    public string ColorId { get; set; } = null!;
    public List<CarListingNote>? Notes { get; set; }
    public string? ItemCondition { get; set; }
    public List<ApprovedImage>? ApprovedImages { get; set; }
    public List<RejectedImage>? RejectedImages { get; set; }
    public string? EngineVolume { get; set; }
    public string? EnginePower { get; set; }
    public string? DriveType { get; set; }
    public string BodyType { get; set; } = null!;
    public string SteeringType { get; set; } = null!;
    public string TransmissionType { get; set; } = null!;
    public string FuelType { get; set; } = null!;
    public bool IsPriceHidden { get; set; }
    public bool IsNegotiable { get; set; }
    public bool? IsExchange { get; set; }
    public CarListingImages Images { get; set; } = new();
    public string ImageUrl { get; set; } = null!;
    public string? RejectionReason { get; set; }
    public ListingRemoveInfo? Remove { get; set; }
    public List<SelectedFeature>? SelectedEquipmentFeatures { get; set; }
    public Location Location { get; set; } = new();
    public Mileage Mileage { get; set; } = new();
    public Price Price { get; set; } = new();
    public Price? ExchangePrice { get; set; }
    public List<PriceHistoryEntry>? PriceHistory { get; set; }
    public long ListingDate { get; set; }
    public long PublishDate { get; set; }
    public long? UpdatedAt { get; set; }
    public long ExpiryDate { get; set; }
    public int ViewCount { get; set; }
    public int FavoriteCount { get; set; }
    public Seller Seller { get; set; } = new();
}

public class ApprovedImage
{
    public string Category { get; set; } = null!; // örn: "Interior"
    public string Src { get; set; } = null!;
    public string? Note { get; set; }
}

public class RejectedImage
{
    public string Category { get; set; } = null!;
    public string Src { get; set; } = null!;
    public string? Reason { get; set; }
}

public class ListingMessage
{
    public string Id { get; set; } = null!;
    public string Type { get; set; } = null!; // "inquiry" | "offer" | "system_alert" | "other"
    public string Sender { get; set; } = null!;
    public string Content { get; set; } = null!;
    public long At { get; set; }
    public bool IsRead { get; set; }
}
