using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bots.Http;
using System;


namespace AdminPanel.TelegramBot
{
    public class TelegramBot
    {
        public static TelegramBotClient bot = new TelegramBotClient("6072159438:AAHpHgZdUrtsk9tnWLHEBhT7W6jYKsew6Mc");
        //TODO массив
        public static long ChatId { get; set; }
        public CancellationTokenSource cts = new();

        ReceiverOptions receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        //TODO получение ChatId
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            var message = update.Message;
            ChatId = message.Chat.Id;
            if (message.Text == "/start")
            {
                Message mes = await bot.SendTextMessageAsync(
                chatId: ChatId,
                text: "You said:\n" + message.Text,
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

            System.Console.WriteLine(ErrorMessage);
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
            System.Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            bot.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );
            await Task.Run(() => System.Console.ReadLine());
            cts.Cancel();
        }
    }
}

