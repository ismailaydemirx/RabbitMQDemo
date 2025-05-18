using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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

Console.WriteLine("Waiting for messages...");

var consumer = new AsyncEventingBasicConsumer(channel);
consumer.ReceivedAsync += async (sender, eventArgs) =>
{
    byte[] body = eventArgs.Body.ToArray();
    string message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Recieved: {message}");

    await ((AsyncEventingBasicConsumer)sender).Channel.BasicAckAsync(eventArgs.DeliveryTag, multiple: false);
};

await channel.BasicConsumeAsync("message", autoAck: false, consumer);

Console.ReadLine();