using HomeService.Domain.Core.PaymentAgg.Data;
using HomeService.Domain.Core.PaymentAgg.Services;
using HomeService.Domain.Core.ServiceAgg.Data;
using HomeService.Domain.Core.ServiceAgg.Services;
using HomeService.Domain.Core.UserAgg.Data;
using HomeService.Domain.Core.UserAgg.Services;
using HomeService.Domain.Services.PaymentAgg;
using HomeService.Domain.Services.ServiceAgg;
using HomeService.Domain.Services.UserAgg;
using HomeService.Infrastructure.DataAccess.Repository.EFCore.Repositories.PaymentAgg;
using HomeService.Infrastructure.DataAccess.Repository.EFCore.Repositories.ServiceAgg;
using HomeService.Infrastructure.DataAccess.Repository.EFCore.Repositories.UserAgg;
using HomeService.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace HomeService.EndPoint.WebMVC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Add Repositories
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentStatusRepository, PaymentStatusRepository>();
            services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceRequestRepository, ServiceRequestRepository>();
            services.AddScoped<IExpertSkillRepository, ExpertSkillRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IServiceImageRepository, ServiceImageRepository>();
            services.AddScoped<IServiceRequestImageRepository, ServiceRequestImageRepository>();
            services.AddScoped<IServiceRequestStatusRepository, ServiceRequestStatusRepository>();
            services.AddScoped<IServiceSugesstionRepository, ServiceSuggestionRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IProfileImageRepository, ProfileImageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Add Services
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceDetailService, InvoiceDetailService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentStatusService, PaymentStatusService>();
            services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IServiceRequestService, ServiceRequestService>();
            services.AddScoped<IExpertSkillService, ExpertSkillService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IServiceImageService, ServiceImageService>();
            services.AddScoped<IServiceRequestImageService, ServiceRequestImageService>();
            services.AddScoped<IServiceRequestStatusService, ServiceRequestStatusService>();
            services.AddScoped<IServiceSugesstionService, ServiceSugesstionService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IProfileImageService, ProfileImageService>();
            services.AddScoped<IUserService, UserService>();

            // Add AutoMapper
            services.AddAutoMapper(typeof(Program));

            // Add MemoryCache
            services.AddMemoryCache();

            // Add Serilog for logging
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Seq("http://localhost:5341") 
                .CreateLogger();

            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));

            return services;

        }
    }
}
