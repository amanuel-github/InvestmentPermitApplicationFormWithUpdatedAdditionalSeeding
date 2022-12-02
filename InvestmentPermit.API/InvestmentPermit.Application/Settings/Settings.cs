using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace InvestmentPermit.Domain.Settings
{
    public class Settings
    {
        public int ExpirationPeriod = 9000;
        IConfiguration _configuration;
        public Settings(IConfiguration configuration)
        {
            _configuration = configuration;
            int expirationPeriod;
            if (Int32.TryParse(configuration["Caching:ExpirationPeriod"], NumberStyles.Any, NumberFormatInfo.InvariantInfo, out expirationPeriod))
            {
                ExpirationPeriod = expirationPeriod;
            }
        }

        public string ManagerKeyWord
        {
            get
            {
                return _configuration["UploadRelatedKeys:Manager"];
            }
        }
        public string ManagerUploadPath
        {
            get
            {
                return _configuration["UploadRelatedKeys:ManagerPhotoUploadPath"];
            }
        }
        public string DocumentUploadPath
        {
            get
            {
                return _configuration["UploadRelatedKeys:DocumentUploadPath"];
            }
        }
        public string JpgFileType
        {
            get
            {
                return _configuration["UploadRelatedKeys:JpgFileType"];
            }
        }
    }
}
