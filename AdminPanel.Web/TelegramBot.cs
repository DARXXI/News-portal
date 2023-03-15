using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bots.Http;


namespace AdminPanel.Web
{
    class TelegramBot
    {
        public static TelegramBotClient bot = new TelegramBotClient("6072159438:AAHpHgZdUrtsk9tnWLHEBhT7W6jYKsew6Mc");
        public static long ChatId { get; set; }
        public CancellationTokenSource cts = new();        

        ReceiverOptions receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        //Task<User> me = await bot.GetMeAsync();
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            var messageGet = update.Message;
            ChatId = messageGet.Chat.Id;
            if (messageGet != null) 
            {
                Message mes = await bot.SendTextMessageAsync(
                chatId: ChatId,
                text: "You said:\n" + messageGet.Text,
                cancellationToken: cancellationToken);
            }
        }
        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
        public static async Task SendMessageAsync(CancellationToken cancellationToken, AdminPanel.Domain.Entities.Message message)
        {
            Message mes = await bot.SendTextMessageAsync(
            chatId: ChatId,
            text: message.Content,
            cancellationToken: cancellationToken);
        }
            
        async public void RunAsync()
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);
            
            bot.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );
            await Task.Run(()=> Console.ReadLine());
            cts.Cancel();
        }
    }
}