using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MVMovies.BUS
{
    public class Users
    {
        private readonly DTO.AppSettings _appSettings;
        LogManagement.ILogger _logger = new LogManagement.Logger();

        public Users(DTO.AppSettings appSettings)
        {
            _appSettings = appSettings;
        }


        public DTO.Users loginUser(string userName, string password)
        {
            DTO.Users _user;
            try
            {
                _user = (from a in _appSettings.dbContext.Users
                        where a.IsDeleted == false && a.UserName == userName && a.Password == password
                         select new DTO.Users()
                        {
                            ID = a.ID,
                            UserName = a.UserName
                        }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.add(_appSettings.logConfigFile, "Error:" + ex.InnerException);
                _user = new DTO.Users();
            }
            return _user;
        }
    }
}
