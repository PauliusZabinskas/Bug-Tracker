using Backend.Auth;
using Backend.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public static class AuthEndpoints
{

    public static void MapAuthEndpoints(this WebApplication app)
    {
        

        app.MapPost("/auth/register", async ([FromBody] RegisterUserDto registerUserDto, [FromServices] UserManager<ApplicationUser> userManager) =>
        {
            var user = new ApplicationUser
            {
                UserName = registerUserDto.UserName,
                Email = registerUserDto.FullName,
                FullName = registerUserDto.FullName,  // assuming the FullName is same as Email
                Role = "Default"  // set the Role to "Default" as a placeholder
            };

            var result = await userManager.CreateAsync(user, registerUserDto.Password);

            if (result.Succeeded)
            {
                return Results.Created($"/auth/register/{user.UserName}", user);
            }

            return Results.BadRequest(result.Errors);
        });

        app.MapPost("/auth/login", async ([FromBody] LoginDto loginDto, [FromServices] SignInManager<ApplicationUser> signInManager) =>
        {
            var result = await signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

            if (result.Succeeded)
            {
                return Results.Ok(new { message = "Login successful" });
            }

            return Results.BadRequest(new { message = "Invalid login attempt" });
        });

        app.MapPost("/auth/change-password", async ([FromBody] ChangePasswordDto changePasswordDto, [FromServices] UserManager<ApplicationUser> userManager, [FromServices] IHttpContextAccessor httpContextAccessor) =>
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);

            if (user == null)
            {
                return Results.NotFound(new { message = "User not found" });
            }

            var result = await userManager.ChangePasswordAsync(user, changePasswordDto.CurrentPassword,
             changePasswordDto.NewPassword);

            if (result.Succeeded)
            {
                return Results.Ok(new { message = "Password changed successfully" });
            }

            return Results.BadRequest(result.Errors);
        }).RequireAuthorization();

        app.MapPost("/auth/forgot-password", async ([FromBody] ForgotPasswordRequestDto forgotPasswordRequestDto, [FromServices] UserManager<ApplicationUser> userManager) =>
            {
                var user = await userManager.FindByNameAsync(forgotPasswordRequestDto.UserName);

                if (user == null)
                {
                    // You may want to return a successful response here to prevent user enumeration
                    return Results.Ok(new { message = "If the account exists, a password reset email has been sent." });
                }

                var token = await userManager.GeneratePasswordResetTokenAsync(user);

                // Here you should implement the actual logic for sending the reset password email to the user
                // The email should contain the token and a link where the user can reset the password

                return Results.Ok(new { message = "If the account exists, a password reset email has been sent." });
            });

        app.MapPost("/auth/reset-password", async ([FromBody] ResetPasswordDto resetPasswordDto, [FromServices] UserManager<ApplicationUser> userManager) =>
        {
            var user = await userManager.FindByNameAsync(resetPasswordDto.UserName);

            if (user == null)
            {
                return Results.BadRequest(new { message = "Invalid reset token or user." });
            }

            var result = await userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.NewPassword);

            if (result.Succeeded)
            {
                return Results.Ok(new { message = "Password reset successfully" });
            }

            return Results.BadRequest(new { message = "Invalid reset token or user." });
        });

    }
}
