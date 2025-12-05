# MaxApiLibrary

## C# библиотека для взаимодействия с API мессенджера [MAX](https://max.ru/)

Подробную документацию API MAX см. [здесь](https://dev.max.ru/docs)

> [!WARNING]
> Внимание! Библиотека находится в состоянии разработки (WIP), и создатель библиотеки не гарантирует стабильную работу
> всех методов.

### Установка

#### NuGet
NuGet-версия будет опубликована позже.

#### Установка вручную
Для установки вручную:
1. Перейдите на [страницу релизов](https://github.com/ClickerOfThings/MaxApiLibrary/releases/latest);
2. Скачайте архив с последней версией библиотеки;
3. Распакуйте файлы в любую папку. Удобнее всего распаковывать в папку с разрабатываемым проектом;
4. При помощи настроек IDE настройте зависимость на файл `MaxApiLibrary.dll`, либо в файл `.csproj` добавьте следующие строки:
```xml
<ItemGroup>
  <Reference Include="MaxApiLibrary">
    <HintPath>..\Libraries\MaxApiLibrary\MaxApiLibrary.dll</HintPath>
  </Reference>
</ItemGroup>
```

### Пример использования библиотеки

#### Иницализация бота

```csharp
var baseClient = new MaxBotApi("MAX_BOT_TOKEN");
```

Для токена бота рекомендуется использовать переменные сред (environment variables), либо другие виды хранения secrets:

```csharp
var baseClient = new MaxBotApi(Environment.GetEnvironmentVariable("MAX_BOT_TOKEN") ??
    throw new ArgumentException("Missing an environment variable 'MAX_BOT_TOKEN' containing bot's token"));
```

Также, в конструкторе можно указать свои `HttpClient` и `CancellationToken`

#### Пример отправления сообщения

```csharp
await baseClient.Messages.SendMessageAsync(new SendMessageRequest()
    {
        Text = $"Добрый день!"
    }
);
```

Методы в библиотеке повторяют методы, приведённые в документации к API, вплоть до структуры данных. В основном для
POST-запросов
создаётся объект класса наподобие "XXXRequest", в котором надо указывать необходимые поля.

#### Пример отправления файла

Для упрощения работы с файлами, в библиотеке есть метод-расширение `SendMessageAsync`, вызываемый из `MaxBotApi`:

```csharp
await baseClient.SendMessageAsync(new SendMessageRequest()
    {
        Text = "Сообщение с видео",
    }, [new SendMessageBaseClientExtensions.FileWithType("video.mp4", UploadTypes.Video)],
    chatId: chatId);
```

Иначе можно загружать файлы вручную через метод `UploadFileAsync` в группе методов `upload`.

Метод `SendMessageAsync` использует добавленные ранее в `SendMessageRequest` вложения, поэтому возможно добавлять, например,
клавиатуру вместе с изображением:
```csharp
await baseClient.SendMessageAsync(new SendMessageRequest()
    {
        Text = "Сообщение с видео",
        Attachments =
        [
            new InlineKeyboardAttachmentRequest()
            {
                Payload = new InlineKeyboardAttachmentRequest.InlineKeyboardPayloadRequest()
                {
                    Buttons =
                    [
                        [
                            new CallbackButton()
                            {
                                Payload = "payload",
                                Text = "Текст кнопки"
                            }
                        ]
                    ]
                }
            }
        ]
    }, [new SendMessageBaseClientExtensions.FileWithType("video.mp4", UploadTypes.Video)],
    chatId: chatId);
```

Видео будет отправлено вместе с кнопками клавиатуры. Технически `Attachment` с видео будет добавлено после `Attachment`
с клавиатурой.

#### Лицензия
Библиотека распространяется под лицензией [Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0)
