public static class IdentitySeeder
{
    
    public async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin")); 
        }
        var admin = await userManager.FindByNameAsync("Tshepiso");

        if (admin == null)
        {
            admin = new ApplicationUser
            {
                UserName = "Tshepiso",
                Email = "ndimatshepiso7@gmail.com" // @ any company your conferenceRooms is hosted by 
            };

            await userManager.CreateAsync(admin , "Tshepiso123!");
            await userManager.AddToRoleAsync(admin, "Admin");
    }
}

}