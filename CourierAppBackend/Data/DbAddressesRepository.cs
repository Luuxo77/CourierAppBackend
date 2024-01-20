﻿using CourierAppBackend.Abstractions.Repositories;
using CourierAppBackend.Models.Database;
using CourierAppBackend.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CourierAppBackend.Data;

public class DbAddressesRepository(CourierAppContext context) 
    : IAddressesRepository
{
    public async Task<Address> AddAddress(AddressDTO addressDTO)
    {
        var address = await context.Addresses.FirstOrDefaultAsync(x => 
                                        x.City == addressDTO.City &&
                                        x.PostalCode == addressDTO.PostalCode &&
                                        x.Street == addressDTO.Street &&
                                        x.HouseNumber == addressDTO.HouseNumber &&
                                        x.ApartmentNumber == addressDTO.ApartmentNumber);
        if (address is not null)
            return address;
        Address newAddress = new()
        {
            ApartmentNumber = addressDTO.ApartmentNumber,
            City = addressDTO.City,
            PostalCode = addressDTO.PostalCode,
            Street = addressDTO.Street,
            HouseNumber = addressDTO.HouseNumber,
        };
        await context.Addresses.AddAsync(newAddress);
        await context.SaveChangesAsync();
        return newAddress;
    }
}