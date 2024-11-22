using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MinimalApi.Models
{
    
    public record Todo( Guid id, string title, bool Done);//record usado já como construtor 
    
}
