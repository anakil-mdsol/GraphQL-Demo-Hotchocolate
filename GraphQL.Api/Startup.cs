using GraphQL.Data;
using GraphQL.Interfaces;
using GraphQL.Services;
using GraphQlApi.GraphQl.Mutations;
using GraphQlApi.GraphQl.Queries;
using GraphQlApi.GraphQl.Types;
using GraphQlApi.GraphQl.Types.InputTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQlApi
{
    public class Startup
    {
        public IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)

        {
            services
                .AddGraphQLServer()

                .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<ProductQuery>()
                .AddTypeExtension<OrderQuery>()

                .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<ProductMutation>()
                .AddTypeExtension<OrderMutation>()

                .AddType<OrderType>()
                .AddType<ProductType>()

                .AddType<AddOrderInputType>()
                .AddType<AddProductInputType>()

                .AddProjections();

            services.AddControllers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            ////Services
            services.AddTransient<IProduct, ProductService>();
            services.AddTransient<IOrder, OrderService>();

            services.AddDataServices(configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext appDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            appDbContext.Database.EnsureCreated();

            app.UseGraphQLVoyager("/ui/voyager");
        }
    }
}