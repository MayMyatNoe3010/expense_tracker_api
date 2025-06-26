using System;
using AutoMapper;
using ExpenseTracker.Models.Dtos.Request;
using ExpenseTracker.Models.Dtos.Response;

namespace ExpenseTracker.Models.Mappers;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        CreateMap<Transaction, TransactionResponse>();
        CreateMap<TransactionRequest, Transaction>();

        CreateMap<Category, CategoryResponse>();
        CreateMap<CategoryRequest, Category>();
    }
}
