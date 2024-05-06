namespace WebApi.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WebApi.Entities;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
// This attribute is used to authorize the user as a receptionist
public class AuthorizeRecepAttribute : Attribute, IAuthorizationFilter
{
	public void OnAuthorization(AuthorizationFilterContext context)
	{
		// skip authorization if action is decorated with [AllowAnonymous] attribute
		var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
		if (allowAnonymous)
			return;
		// We also skip authorization if the user is a Medecin
		var allowMed = context.ActionDescriptor.EndpointMetadata.OfType<AuthorizeMedAttribute>().Any();
		if (allowMed)
			return;


		// authorization
		var user = (User)context.HttpContext.Items["User"];
		if (user == null)
			context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
		// We can also check the user's role here ( user.Role == "Réceptionniste" )
		else if (user.Role != UserRole.Réceptionniste)
			context.Result = new JsonResult(new { message = "Forbidden" }) { StatusCode = StatusCodes.Status403Forbidden };

	}
}