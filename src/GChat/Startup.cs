using GChat.Authentication;
using GChatAPI.Data;
using GChatAPI.Data.DataLoader;
using GChatAPI.Graphql.Chats;
using GChatAPI.Graphql.Messages;
using GChatAPI.Graphql.Users;
using GChatAPI.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GChat
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        public IHostEnvironment HostingEnvironment { get; private set; }

        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            this.Configuration = configuration;
            this.HostingEnvironment = hostEnvironment;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomJWTAuth(this.Configuration);
            services.AddAuthorization(this.Configuration);

            services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlite("Data Source=data.db"));

            services.AddGraphQLServer()
                .AddAuthorization()
                .AddSocketSessionInterceptor<AuthSocketInterceptor>()
                // DataLoaders
                .AddDataLoader<ChatByIdDataLoader>()
                .AddDataLoader<MessageByIdDataLoader>()
                .AddDataLoader<UserByIdDataLoader>()
                // Datatypes
                .AddType<ChatType>()
                .AddType<MessageType>()
                .AddType<UserType>()
                // Querytype
                .AddQueryType(d => d.Name("Query"))                    
                    .AddTypeExtension<UserQueries>()
                    .AddTypeExtension<MessageQueries>()
                    .AddTypeExtension<ChatQueries>()
                // MutationType
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<AuthMutations>()
                    .AddTypeExtension<UserMutations>()
                    .AddTypeExtension<ChatMutations>()
                    .AddTypeExtension<MessageMutations>();
                
                // .AddSubscriptionType(d => d.Name("Subscription"));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
