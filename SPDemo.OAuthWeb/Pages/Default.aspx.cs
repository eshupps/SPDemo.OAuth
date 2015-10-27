using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.IdentityModel;
using Microsoft.IdentityModel.S2S.Protocols.OAuth2;
using Microsoft.IdentityModel.S2S.Tokens;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace SPDemo.OAuthWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Uri redirectUrl;
            switch (SharePointContextProvider.CheckRedirectionStatus(Context, out redirectUrl))
            {
                case RedirectionStatus.Ok:
                    return;
                case RedirectionStatus.ShouldRedirect:
                    Response.Redirect(redirectUrl.AbsoluteUri, endResponse: true);
                    break;
                case RedirectionStatus.CanNotRedirect:
                    Response.Write("An error occurred while processing your request.");
                    Response.End();
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string spAppToken = TokenHelper.GetContextTokenFromRequest(HttpContext.Current.Request);
            requestTokenValue.InnerText = spAppToken;

            SharePointContextToken spToken = ReadToken(spAppToken);
            requestTokenContents.InnerHtml = spToken.ToString().Replace(",", "<br/>");

            string hostWeb = Page.Request["SPHostUrl"];
            Uri hostUri = new Uri(hostWeb);
            string accessToken = TokenHelper.GetAccessToken(spToken,hostUri.Authority).AccessToken;
            accessTokenValue.InnerText = accessToken;

            JwtSecurityTokenHandler tokenHandler = new System.IdentityModel.Tokens.JwtSecurityTokenHandler();
            SecurityToken st = tokenHandler.ReadToken(accessToken);
            accessTokenContents.InnerHtml = st.ToString().Replace(",", "<br/>");

        }

        private SharePointContextToken ReadToken(string ContextToken)
        {
            JsonWebSecurityTokenHandler tokenHandler = TokenHelper.CreateJsonWebSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.ReadToken(ContextToken);
            JsonWebSecurityToken jsonToken = securityToken as JsonWebSecurityToken;
            SharePointContextToken token = SharePointContextToken.Create(jsonToken);
            return token;
        }

    }
}