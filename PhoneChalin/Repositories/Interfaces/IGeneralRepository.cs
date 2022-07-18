using System;
using System.Collections.Generic;
using System.Net;

namespace PhoneChalin.Repositories.Interfaces
{
    public interface IGeneralRepository<TModel, TPrimaryKey>
        where  TModel : class
    {
        // GET
        List<TModel> Get();

        // GET Using Paramenter By ID (Primary Key)
        TModel Get(TPrimaryKey Id);

        // POST
        HttpStatusCode Post(TModel model);

        // PUT
        HttpStatusCode Put(TModel model);

        // DELETE
        HttpStatusCode Delete(TPrimaryKey Id);
    }
}
