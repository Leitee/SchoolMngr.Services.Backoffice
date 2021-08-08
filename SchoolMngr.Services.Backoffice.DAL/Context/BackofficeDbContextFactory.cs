﻿namespace SchoolMngr.Services.Backoffice.DAL.Context
{
    using Codeit.NetStdLibrary.Base.Abstractions.DataAccess;
    using Codeit.NetStdLibrary.Base.DataAccess;
    using Microsoft.EntityFrameworkCore;
    using SchoolMngr.Infrastructure.Shared.Configuration;

    public class BackofficeDbContextFactory : DesignTimeDbContextFactoryBase<BackofficeDbContext>
    {
        public BackofficeDbContextFactory(DALSettings settings) : base(settings)
        {
        }

        protected override BackofficeDbContext CreateNewInstance(DbContextOptions<BackofficeDbContext> options)
        {
            return new BackofficeDbContext(options);
        }

        protected override IPersistenceBuilder CreatePersistenceBuilder(DALSettings settings)
        {
            return EFPersistenceBuilder.Build(settings);
        }
    }
}