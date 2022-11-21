using Blog.Web.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace Blog.Web.Pages.Admin;

public partial class LogIn
{
    private string Username { get; set; } = string.Empty;

    private string Password { get; set; } = string.Empty;

    // [Inject]
    // public UserManager<User> UserManager { get; set; } = null!;
    
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    private void Authenticate()
    {
        // var user = await UserManager.FindByNameAsync(Username);
        //
        // if (user is null)
        // {
        //     // Display some detail about not being able to log in
        //     return;
        // }
        //
        // var singInResult = await SignInManager.CheckPasswordSignInAsync(user, Password, false);
        // if (!singInResult.Succeeded)
        // {
        //     //Message = "Invalid password";
        // }
        // else
        // {
        //     await SignInManager.SignInAsync(user, false); // Error occurs here
        // }

        NavigationManager.NavigateTo("/admin/dashboard");
    }   
}