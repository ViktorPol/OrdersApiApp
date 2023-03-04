using OrdersApiApp.Service.ClientService;
using OrdersApiApp.Model.Entity;
using OrdersApiApp.Model;
using OrdersApiApp.Service.OrderService;
using OrdersApiApp.Service.ProductService;
using OrdersApiApp.Service.OrderProductService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IDaoClient, DbDaoClient>();
builder.Services.AddTransient<IDaoOrder, DbDaoOrder>();
builder.Services.AddTransient<IDaoProduct, DbDaoProduct>();
builder.Services.AddTransient<IDaoOrderProduct, DbDaoOrderProduct>();
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapGet("/client/all", async (HttpContext context, IDaoClient dao) =>
{
    return await dao.GetAllClients();
});
app.MapPost("/client/add", async (HttpContext context, Client client, IDaoClient dao) =>
{
    return await dao.AddClient(client);
});

app.MapPost("client/update", async (HttpContext context, Client client, IDaoClient dao) =>
{
    return await dao.UpdateClient(client);
});

app.MapPost("client/delete", async (HttpContext context, Client client, IDaoClient dao) =>
{
    return await dao.DeleteClient(client.Id);
});


app.MapGet("/order/all", async (HttpContext context, IDaoOrder dao) =>
{
    return await dao.GetAllOrders();
});
app.MapPost("/order/add", async (HttpContext context, Order order, IDaoOrder dao) =>
{
    return await dao.AddOrder(order);
});

app.MapPost("order/update", async (HttpContext context, Order order, IDaoOrder dao) =>
{
    return await dao.UpdateOrder(order);
});

app.MapPost("order/delete", async (HttpContext context, Order order, IDaoOrder dao) =>
{
    return await dao.DeleteOrder(order.Id);
});


app.MapGet("/product/all", async (HttpContext context, IDaoProduct dao) =>
{
    return await dao.GetAllProducts();
});
app.MapPost("/product/add", async (HttpContext context, Product product, IDaoProduct dao) =>
{
    return await dao.AddProduct(product);
});

app.MapPost("product/update", async (HttpContext context, Product product, IDaoProduct dao) =>
{
    return await dao.UpdateProduct(product);
});

app.MapPost("rpoduct/delete", async (HttpContext context, Product product, IDaoProduct dao) =>
{
    return await dao.DeleteProduct(product.Id);
});


app.MapGet("/product/all", async (HttpContext context, IDaoProduct dao) =>
{
    return await dao.GetAllProducts();
});
app.MapPost("/product/add", async (HttpContext context, Product product, IDaoProduct dao) =>
{
    return await dao.AddProduct(product);
});

app.MapPost("product/update", async (HttpContext context, Product product, IDaoProduct dao) =>
{
    return await dao.UpdateProduct(product);
});

app.MapPost("product/delete", async (HttpContext context, Product product, IDaoProduct dao) =>
{
    return await dao.DeleteProduct(product.Id);
});


app.MapGet("/orderproduct/all", async (HttpContext context, IDaoOrderProduct dao) =>
{
    return await dao.GetAllOrderProducts();
});
app.MapPost("/orderproduct/add", async (HttpContext context, OrderProduct orderproduct, IDaoOrderProduct dao) =>
{
    return await dao.AddOrderProduct(orderproduct);
});

app.MapPost("orderproduct/update", async (HttpContext context, OrderProduct orderproduct, IDaoOrderProduct dao) =>
{
    return await dao.UpdateOrderProduct(orderproduct);
});

app.MapPost("orderproduct/delete", async (HttpContext context, OrderProduct orderproduct, IDaoOrderProduct dao) =>
{
    return await dao.DeleteOrderProduct(orderproduct.Id);
});

app.Run();
