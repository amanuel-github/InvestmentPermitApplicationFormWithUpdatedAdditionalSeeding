using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPermit.Infrastructure.Seed
{
    using global::InvestmentPermit.Domain.Entities;
    using global::InvestmentPermit.Infrastructure.DBContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    namespace InvestmentPermit.Infrastructure.Seed
    {
        public interface IDatabaseInitializer
        {
            Task SeedAsync();
        }

        public class DatabaseInitializer : IDatabaseInitializer
        {
            private readonly InvestmentPermitDbContext _context;
            private readonly ILogger _logger;

            public DatabaseInitializer(InvestmentPermitDbContext context,ILogger<DatabaseInitializer> logger)
            {
                
                _context = context;
                _logger = logger;
            }

            virtual public async Task SeedAsync()
            {
                //// return;
                await _context.Database.MigrateAsync().ConfigureAwait(false);

              
                try
                {
                    _logger.LogInformation("Seeding Adress Information");

                    if (!await _context.Regions.AnyAsync())
                    {

                        await CreateRegionAsync("Tigray", "10", "this is tigray region");
                        await CreateRegionAsync("Amhara", "20", "this is amhara region");
                        await CreateRegionAsync("Gambella", "30", "this is gambella region ");
                    }
                    if (!await _context.Zones.AnyAsync())
                    {

                        await CreateZoneAsync("Tigray-Zone-One", "11", "this is tigray zone one", "10");
                        await CreateZoneAsync("Tigray-Zone-Two", "12", "this is tigray region zone two", "10");
                        await CreateZoneAsync("Amhara-Zone-One", "21", "this is amhara zone one", "20");
                        await CreateZoneAsync("Amhara-Zone-two", "22", "this is amhara zone two", "20");
                        await CreateZoneAsync("Gambella-Zone-One", "31", "this is gambella zone one", "30");
                        await CreateZoneAsync("Gambella-Zone-two", "32", "this is gambella zone two", "30");
                    }
                    if (!await _context.Woredas.AnyAsync())
                    {
                        await CreateWoredaAsync("Gambella-Zone-One-Woreda-One", "33", "this is gambella zone one", "31");
                        await CreateWoredaAsync("Tigray-Zone-One-Woreda-One", "13", "this is Tigray zone one woreda one", "11");
                        await CreateWoredaAsync("Gambella-Zone-Two-Woreda-Two", "34", "this is gambella zone one woreda two ", "32");
                        await CreateWoredaAsync("Amhara-Zone-two -Woreda-One", "23", "this is amhara zone two woreda one", "22");
                        await CreateWoredaAsync("Tigray-Zone-One-Woreda-One", "18", "this is Tigray zone one woreda one", "12");
                        await CreateWoredaAsync("Gambella-Zone-Two-Woreda-Two", "39", "this is gambella zone one woreda two ", "32");
                        await CreateWoredaAsync("Amhara-Zone-two -Woreda-One", "28", "this is amhara zone two woreda one", "22");
                    }
                    if (!await _context.Kebelles.AnyAsync())
                    {
                        await CreateKebelleAsync("Gambella-Zone-One-Woreda-One-kebelle-One", "35", "this is gambella zone one woreda one kebelle one", "33");
                        await CreateKebelleAsync("Tigray-Zone-One-Woreda-One-kebelle-one", "14", "this is Tigray zone one woreda one kebelle one", "13");
                        await CreateKebelleAsync("Gambella-Zone-Two-Woreda-Two-kebelle-two", "33", "this is gambella zone one woreda two kebelle two ", "34");
                        await CreateKebelleAsync("Amhara-Zone-two -Woreda-One-kebelle-one", "24", "this is amhara zone two woreda one kebelle one ", "23");

                        await CreateKebelleAsync("Gambella-Zone-One-Woreda-One-kebelle-One", "39", "this is gambella zone one woreda one kebelle one", "33");
                        await CreateKebelleAsync("Tigray-Zone-One-Woreda-One-kebelle-one", "16", "this is Tigray zone one woreda one kebelle one", "13");
                        await CreateKebelleAsync("Gambella-Zone-Two-Woreda-Two-kebelle-two", "300", "this is gambella zone one woreda two kebelle two ", "34");
                        await CreateKebelleAsync("Amhara-Zone-two -Woreda-One-kebelle-one", "222", "this is amhara zone two woreda one kebelle one ", "23");
                    }

                    if (!await _context.Nationalities.AnyAsync())
                    {
                        await CreateNationalityAsync("Ethiopia", "this is ethiopia");
                        await CreateNationalityAsync("Brazil", "this is Brazil");
                        await CreateNationalityAsync("Kenya", "this is Kenya");
                        await CreateNationalityAsync("Chili", "this is Chili");
                        await CreateNationalityAsync("Mexisico", "this is Mexcisco");
                    }
                    _logger.LogInformation("Seeding completed");
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    throw new Exception(ex.Message);
                }
                //}
            }


            private async Task CreateRegionAsync(string Name, string IdentificationCode, string Description)
            {
                Region region = new Region
                {
                    Name = Name,
                    IdentifactionCode = IdentificationCode,
                    Description = Description
                };

                try
                {
                    
                        await _context.Regions.AddAsync(region);

                        await _context.SaveChangesAsync();
                    

                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    throw new Exception(ex.Message);
                }
            }
            private async Task CreateWoredaAsync(string Name, string IdentificationCode, string Description, string ParentIdentificationCode)
            {
                Woreda woreda = new Woreda
                {
                    Name= Name,
                    IdentifactionCode= IdentificationCode,
                    Description= Description,
                    ParentIdentifactionCode = ParentIdentificationCode
                };

                try
                {
                    
                        await _context.Woredas.AddAsync(woreda);

                        await _context.SaveChangesAsync();
                    
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    throw new Exception(ex.Message);
                }
            }
            private async Task CreateNationalityAsync(string Name , string Description)
            {
                Nationality nationality = new Nationality
                {
                    Name = Name,
                    Description = Description
                };

                try
                {
                    
                        await _context.Nationalities.AddAsync(nationality);

                        await _context.SaveChangesAsync();
                    
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    throw new Exception(ex.Message);
                }
            }
            private async Task CreateKebelleAsync(string Name, string IdentificationCode, string Description, string ParentIdentificationCode)
            {
                Kebelle kebelle = new Kebelle
                {
                    Name = Name,
                    IdentifactionCode = IdentificationCode,
                    Description = Description,
                    ParentIdentifactionCode = ParentIdentificationCode
                };

                try
                {
                        await _context.Kebelles.AddAsync(kebelle);

                        await _context.SaveChangesAsync();
                    
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    throw new Exception(ex.Message);
                }
            }
            private async Task CreateZoneAsync(string Name, string IdentificationCode, string Description, string ParentIdentificationCode)
            {
                Zone zone = new Zone
                {
                    Name = Name,
                    IdentifactionCode = IdentificationCode,
                    Description = Description,
                    ParentIdentifactionCode = ParentIdentificationCode
                };

                try
                {
                    
                        await _context.Zones.AddAsync(zone);

                        await _context.SaveChangesAsync();
                    
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    throw new Exception(ex.Message);
                }
            }

        }
    }
}
