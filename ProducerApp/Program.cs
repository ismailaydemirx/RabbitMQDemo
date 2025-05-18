using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

channel.QueueDeclareAsync(
    queue: "message",
    durable: true, // to not lose messages if RabbitMQ crashes
    exclusive: false, // only one consumer can consume the queue
    autoDelete: false, // the queue will not be deleted when the connection is closed
    arguments: null // no additional arguments
    );

for (int i = 0; i < 10; i++)
{
    var message = $"{DateTime.UtcNow} - {Guid.CreateVersion7()}";
    var body = Encoding.UTF8.GetBytes(message);

    await channel.BasicPublishAsync(
        exchange: string.Empty,
        routingKey: "message",
        mandatory: false,
        basicProperties: new BasicProperties { Persistent = true },
        body: body
        );

    Console.WriteLine($" [x] Sent {message}");

    await Task.Delay(2000);
}