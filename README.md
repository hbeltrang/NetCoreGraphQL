# NetCoreGraphQL
.Net Core 6 WebAPI with GraphQL and EntityFramework
#graphql is the same name in the program class
#https://localhost:7169/graphql/
# query

query{
  products(order: { price:ASC }){
    productCode,
    productName,price
  }
}
