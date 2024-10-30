using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using _11._6_BOT.Configuration;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using _11._6_BOT.Utilites;
using _11._6_BOT.Services;

namespace _11._6_BOT.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        public static string command;

        public TextMessageController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":

                    // Объект, представляющий кнопки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($"Счет символов в строке", $"countChars"),
                        InlineKeyboardButton.WithCallbackData($"Сумма целых чисел" , $"sumInt")
                    });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b>Бот имеет 2 функции:</b> {Environment.NewLine}" +
                         $"{Environment.NewLine}<b>1.</b> <i>Считает количество символов в тексте.</i>" +
                         $"{Environment.NewLine}<b>2.</b> <i>Суммирует целые числа, записанные через пробел.</i>{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));
                    break;
                default:
                    break;
            }

            switch (command)
            {
                case "countChars":
                    await _telegramClient.SendTextMessageAsync(message.From.Id, Calc.CalcLength(message.Text));
                    break;
                case "sumInt":
                    await _telegramClient.SendTextMessageAsync(message.From.Id, Calc.CalcSum(message.Text));
                    break;
                default:
                    break;
            }
        }
    }
}
