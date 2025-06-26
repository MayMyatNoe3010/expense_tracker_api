using System;
using ExpenseTracker.Models.Dtos.Response;

namespace ExpenseTracker.DataAccess.MockData;

public static class MockTransactionData
{
    public static async Task<List<TransactionResponse>> GetMockTransactionResponses()
    {
        await Task.Delay(100); // Simulate async behavior

        return new List<TransactionResponse>
        {
            new()
            {
                Id = 1,
                Title = "Groceries",
                Amount = 45.99,
                CreatedDate = DateTime.Parse("2025-06-20"),
                Category = new CategoryResponse { Id = 1, Name = "Food", Icon = "utensils", Color = "#FF6F61" },
                TransactionType = TransactionType.expense
            },
            new()
            {
                Id = 2,
                Title = "Taxi to work",
                Amount = 12.50,
                CreatedDate = DateTime.Parse("2025-06-19"),
                Category = new CategoryResponse { Id = 2, Name = "Transport", Icon = "car", Color = "#6B5B95" },
                TransactionType = TransactionType.expense
            },
            new()
            {
                Id = 3,
                Title = "Netflix Subscription",
                Amount = 15.99,
                CreatedDate = DateTime.Parse("2025-06-18"),
                Category = new CategoryResponse { Id = 3, Name = "Entertainment", Icon = "film", Color = "#88B04B" },
                TransactionType = TransactionType.expense
            },
            new()
            {
                Id = 4,
                Title = "Gas Station",
                Amount = 35.00,
                CreatedDate = DateTime.Parse("2025-06-17"),
                Category = new CategoryResponse { Id = 4, Name = "Fuel", Icon = "gas-pump", Color = "#FFA07A" },
                TransactionType = TransactionType.expense
            },
            new()
            {
                Id = 5,
                Title = "Lunch at Cafe",
                Amount = 18.75,
                CreatedDate = DateTime.Parse("2025-06-16"),
                Category = new CategoryResponse { Id = 1, Name = "Food", Icon = "utensils", Color = "#FF6F61" },
                TransactionType = TransactionType.expense
            },
            new()
            {
                Id = 6,
                Title = "Gym Monthly Fee",
                Amount = 29.00,
                CreatedDate = DateTime.Parse("2025-06-15"),
                Category = new CategoryResponse { Id = 5, Name = "Health", Icon = "heartbeat", Color = "#92A8D1" },
                TransactionType = TransactionType.expense
            },
            new()
            {
                Id = 7,
                Title = "Electric Bill",
                Amount = 65.00,
                CreatedDate = DateTime.Parse("2025-06-14"),
                Category = new CategoryResponse { Id = 6, Name = "Utilities", Icon = "bolt", Color = "#F7CAC9" },
                TransactionType = TransactionType.expense
            },
            new()
            {
                Id = 8,
                Title = "WiFi Subscription",
                Amount = 42.00,
                CreatedDate = DateTime.Parse("2025-06-13"),
                Category = new CategoryResponse { Id = 6, Name = "Utilities", Icon = "bolt", Color = "#F7CAC9" },
                TransactionType = TransactionType.expense
            },
            new()
            {
                Id = 9,
                Title = "Salary",
                Amount = 1000.00,
                CreatedDate = DateTime.Parse("2025-06-12"),
                Category = new CategoryResponse { Id = 1, Name = "Salary", Icon = "utensils", Color = "#FF6F61" },
                TransactionType = TransactionType.income
            },
            new()
            {
                Id = 10,
                Title = "Tranportation Charges",
                Amount = 200.00,
                CreatedDate = DateTime.Parse("2025-06-11"),
                Category = new CategoryResponse { Id = 2, Name = "Transport", Icon = "car", Color = "#6B5B95" },
                TransactionType = TransactionType.income
            }
        };
    }
}

