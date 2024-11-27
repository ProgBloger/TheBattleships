using Microsoft.Extensions.DependencyInjection;
using TheBattleShips.Application;
using TheBattleShips.Application.Entities;

var services = new ServiceCollection();

// Register services
services.AddTransient<ShipsInitializer>();
services.AddTransient<IOProcessor>();
services.AddTransient<GameBoard>();

// Build the service provider
var serviceProvider = services.BuildServiceProvider();

// Resolve and use the service
var gameBoard = serviceProvider.GetRequiredService<GameBoard>();
gameBoard.Initialize();
gameBoard.Play();