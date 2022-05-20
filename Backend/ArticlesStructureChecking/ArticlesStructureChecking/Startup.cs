using ArticlesStructureChecking.Application.Token;
using ArticlesStructureChecking.Application.Token.AcessToken;
using ArticlesStructureChecking.Application.Token.ClientCredentialsToken;
using ArticlesStructureChecking.Application.Token.Oidc;
using ArticlesStructureChecking.Application.Token.RefreshToken;
using ArticlesStructureChecking.Domain.Entities.User;
using ArticlesStructureChecking.Domain.OpenIddict;
using ArticlesStructureChecking.Infrastructure.DataAccess;
using ArticlesStructureChecking.Initializers;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Validation.AspNetCore;
using System.Reflection;

namespace ArticlesStructureChecking
{
    public static class Startup
    {
        private static readonly List<Assembly> AllAssemblies = new();

		public static void ConfigureInitializers(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAsyncInitializer<OidcInitializer>();
		}

		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ArticlesStructureCheckingDbContext>(options =>
				options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped<DbContext, ArticlesStructureCheckingDbContext>();
		}

		public static void ConfigureOidc(this IServiceCollection services, IConfiguration configuration)
		{
			var oidcConfigSection = configuration.GetSection(OidcConfiguration.OidcConfigurationName);
			services.AddIdentity<User, Role>(options =>
			{
				options.ClaimsIdentity.RoleClaimType = "role";
			})
				.AddEntityFrameworkStores<ArticlesStructureCheckingDbContext>()
				.AddDefaultTokenProviders();
			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 1;
				options.Password.RequiredUniqueChars = 0;
			});
			services.Configure<OidcConfiguration>(oidcConfigSection);
			services.AddOpenIddict()
				.AddCore(options =>
				{
					options.UseEntityFrameworkCore()
						.UseDbContext<DbContext>()
						.ReplaceDefaultEntities<OpenIddictApplication,
							OpenIddictAuthorization, OpenIddictScope, OpenIddictToken, string>();
				})
				.AddServer(options =>
				{

					options.AllowPasswordFlow();
					options.AllowRefreshTokenFlow();
					options.AllowClientCredentialsFlow();
					options.AddEphemeralEncryptionKey()
						.AddEphemeralSigningKey();

					options.SetTokenEndpointUris(
						"/identity/token");

					options.SetIntrospectionEndpointUris("/identity/introspect");

					var oidcConfiguration = oidcConfigSection.Get<OidcConfiguration>();

					options.SetAccessTokenLifetime(TimeSpan.FromMinutes(oidcConfiguration.AccessTokenLifeTimeMinutes));
					options.SetRefreshTokenLifetime(TimeSpan.FromDays(14));
					options.SetRefreshTokenReuseLeeway(TimeSpan.FromDays(14));

					options.UseAspNetCore()
						.EnableAuthorizationEndpointPassthrough()
						.EnableTokenEndpointPassthrough()
						.EnableUserinfoEndpointPassthrough()
						.DisableTransportSecurityRequirement();
					options.DisableAccessTokenEncryption();
				})
				.AddValidation(options =>
				{
					options.UseLocalServer();
					options.UseAspNetCore();
				});

			services.AddScoped<OidcClaimsPrincipalProvider>();

			services.AddTransient<ITokenHandler, RefreshTokenHandler>();
			services.AddTransient<ITokenHandler, ClientCredentialsHandler>();
			services.AddTransient<ITokenHandler, ArticleStructureCheckingAccessTokenHandler>();
		}

		public static void ConfigureAuthentication(this IServiceCollection services)
		{
			services.AddAuthentication(options =>
			{
				options.DefaultScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
				options.DefaultAuthenticateScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
			});

			services.AddTransient<IPasswordHasher<User>, PasswordHasher>();
		}

		public static void AddMediatR(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
			serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));
			serviceCollection.AddMediatR(typeof(Startup));
		}
	}
}
