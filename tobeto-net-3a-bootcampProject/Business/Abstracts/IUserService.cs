using Core.Utilities.Results;
using Core.Utilities.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IUserService
{
    Task<DataResult<User>> GetById(int id);
    Task<DataResult<User>> GetByMail(string email);

}
