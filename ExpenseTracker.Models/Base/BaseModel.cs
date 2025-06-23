using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models.Base;

public abstract class BaseModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? CreatedDate { get; set; }
    public string? UpdatedDate { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public string? Note { get; set; }
    public bool IsActive { get; set; } = true;
    public virtual void SetDateTime()
    {
        if (Id != null && Id != 0)
        {
            UpdatedDate = DateTime.Now.ToString();
        }
        else
        {
            CreatedDate = DateTime.Now.ToString();
        }
        Console.WriteLine("CreatedDate: "+CreatedDate);
        Console.WriteLine("UpdatedDate: "+UpdatedDate);
        Console.WriteLine("ID:"+Id);
    }
    public virtual void SetUser(int userId)
    {
        if (Id != null && Id != 0)
        {
            UpdatedDate = DateTime.Now.ToString();
            UpdatedBy = userId;
        }
        else
        {
            CreatedDate = DateTime.Now.ToString();
            CreatedBy = userId;
        }
    }  
}