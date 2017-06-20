using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;

namespace WcfService.Repositories
{
    public class TokenRepository
    {
        private readonly GuestBookEntities _guestBookEntities;

        public TokenRepository(GuestBookEntities guestbookEntities)
        {
            _guestBookEntities = guestbookEntities;
        }

        public void Authenticate(string tokenStr)
        {
            if (!HasToken(tokenStr))
            {
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }
        }

        public bool HasToken(string tokenStr)
        {
            Token token = _guestBookEntities.Tokens.FirstOrDefault(x => x.token1 == tokenStr);
            return token != null;
        }

        public Token CreateTemporaryToken()
        {
            Token tempToken = new Token
            {
                token1 = Guid.NewGuid().ToString(),
                creation_date = DateTime.Now,
                expiration_date = DateTime.Now.AddMinutes(30)
            };

            _guestBookEntities.Tokens.Add(tempToken);

            return tempToken;
        }

        public Token CreateToken(string id, string tokenStr)
        {
            Token token = _guestBookEntities.Tokens.FirstOrDefault(x => x.token1 == tokenStr);

            if (token != null)
            {
                // Ensure the token hasn't expired yet
                if (DateTime.Now > token.expiration_date)
                {
                    return null;
                }
            }

            Token newToken = new Token
            {
                employee_id = int.Parse(id),
                token1 = Guid.NewGuid().ToString().Replace("-", ""),
                creation_date = DateTime.Now
            };

            _guestBookEntities.Entry(newToken).State = EntityState.Added;
            _guestBookEntities.SaveChanges();

            return newToken;
        }

        public List<Token> GetTokens()
        {
           return _guestBookEntities.Set<Token>().ToList();
        }
    }
}