using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Aurora.Models
{
    public class timeLength
    {
        public int Id { get; set; }
        public string? Length { get; set; }
        public double Pricing { get; set; } //musi być double zamiast float?
    }

}
