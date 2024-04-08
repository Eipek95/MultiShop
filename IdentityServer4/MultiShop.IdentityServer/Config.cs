// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new[]
        {
            new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadFullPermission"}},
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"}},
            new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"}},
            new ApiResource("ResourceComment"){Scopes={"CommentFullPermission"}},
            new ApiResource("ResourcePayment"){Scopes={"PaymentFullPermission"}},
            new ApiResource("ResourceImage"){Scopes={"ImagesFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };


        public static IEnumerable<ApiScope> ApiScopes => new[] {
            //catalog
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadFullPermission","Reading authority for catalog operations"),

            //discount
            new ApiScope("DiscountFullPermission","Reading authority for discount operations"),

            //order
            new ApiScope("OrderFullPermission","Reading authority for order operations"),
            
            //order
            new ApiScope("CargoFullPermission","Full authority for cargo operations"),


            //basket
            new ApiScope("BasketFullPermission","Full authority for basket operations"),
            
            
            //ocelot
            new ApiScope("OcelotFullPermission","Full authority for ocelot operations"),
            
            
            //comment
            new ApiScope("CommentFullPermission","Full authority for comment operations"),
            
            
            //payment
            new ApiScope("PaymentFullPermission","Full authority for payment operations"),
            
            
            //image
            new ApiScope("ImagesFullPermission","Full authority for image operations"),

            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new[]
        {
            //visitor
            new Client
            {
                ClientId="MultiShopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                //AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission", "DiscountFullPermission", "OcelotFullPermission", "CommentFullPermission" , "ImagesFullPermission" }
            },

            //Manager
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                //AllowedGrantTypes=GrantTypes.ClientCredentials,
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission", "CatalogReadFullPermission", "OcelotFullPermission", "CommentFullPermission", "PaymentFullPermission", "ImagesFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,}
            },

            //admin
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                //AllowedGrantTypes=GrantTypes.ClientCredentials, -->token alırken granttype bu olursa kullanıcı adı şifreye gerek kalmadan alır
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,//usera bağlı token oluşturma
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={
                    "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission", "CatalogReadFullPermission","CargoFullPermission","BasketFullPermission","OcelotFullPermission",
                    "CommentFullPermission","PaymentFullPermission","ImagesFullPermission",

                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                },
                AccessTokenLifetime=600 //10dk
            }
        };
    }
}