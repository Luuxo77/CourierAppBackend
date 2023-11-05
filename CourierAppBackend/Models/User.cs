﻿
namespace CourierAppBackend.Models;

public enum Role
{
    User,
    OfficeWorker,
    Courier
}
public class User : Base
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public Address DefaultSourceAddress { get; set; } = null!;
    public Role Role { get; set; }
    public ICollection<Inquiry>? Inquiries { get; set; }
}
