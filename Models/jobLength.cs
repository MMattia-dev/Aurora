using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Aurora.Models
{
    public class jobLength
    {
        public int Id { get; set; }

        public string? Length { get; set; }
    }
}
