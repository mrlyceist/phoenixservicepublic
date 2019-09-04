namespace PhoenixService.Domain
{
    public enum VoiceServiceTaskState
    {
        /// <summary>
        /// Готов
        /// </summary>
        Ready = 0,
        /// <summary>
        /// Неудача
        /// </summary>
        Failed = 1,
        /// <summary>
        /// В процессе
        /// </summary>
        Ongoing = 2,
        /// <summary>
        /// Отказ абонента
        /// </summary>
        Postponed = 3,
        /// <summary>
        /// Дозвон
        /// </summary>
        Performed = 4,
        /// <summary>
        /// Потеря телефонной линии
        /// </summary>
        TelephonyErrorSuspend = 5,
        /// <summary>
        /// Перевод на оператора
        /// </summary>
        Transfer = 6,
        /// <summary>
        /// Неизвестное состояние
        /// </summary>
        Unknown = 7,
        /// <summary>
        /// Задача отправлена на сервер
        /// </summary>
        SendToServer = 8,
        /// <summary>
        /// Отправлена SMS
        /// </summary>
        Sms = 9,
    }
}