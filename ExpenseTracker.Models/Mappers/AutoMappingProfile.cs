using System;
using AutoMapper;
using ExpenseTracker.Models.Dtos.Request;
using ExpenseTracker.Models.Dtos.Response;

namespace ExpenseTracker.Models.Mappers;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        CreateMap<Expense, ExpenseResponse>();
        CreateMap<ExpenseRequest, Expense>();

        CreateMap<Category, CategoryResponse>();
        CreateMap<CategoryRequest, Category>();
    }
}
