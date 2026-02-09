using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

public class CalculatorContext : IdentityDbContext<ApplicationUser>
{
    public CalculatorContext(DbContextOptions<CalculatorContext> options)
        : base(options)
    {
        
    }

    
}