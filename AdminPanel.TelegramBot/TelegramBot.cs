using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bots.Http;
using System;
using AdminPanel.Repository.Repositories;

namespace AdminPanel.TelegramBot
{
    public class TelegramBot
    {
        public static TelegramBotClient bot = new TelegramBotClient("6072159438:AAHpHgZdUrtsk9tnWLHEBhT7W6jYKsew6Mc");
        public CancellationTokenSource cts = new();

        ReceiverOptions receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        //TODO
        //public void Dispose()
        //{
        //    SendMessageAsync(() => new CancellationToken(), t => new AdminPanel.Domain.Entities.Message() { Content = "Connection lost!"},  );
        //}
        //TODO установка ChatId, текущему пользователю
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            var message = update.Message;

            if (message.Text != null)
            {
                Message mes = await bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "you wrote" + message.Text,
                cancellationToken: cancellationToken);
            }
            //_userRepository.FindOrCreate()
            if (message.Text == "/start")
            {
                Message mes = await bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Connection Established!",
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

        public static async Task SendMessageAsync(CancellationToken cancellationToken, AdminPanel.Domain.Entities.Message message, long chatId)
        {
            Message mes = await bot.SendTextMessageAsync(
            chatId: chatId,
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

