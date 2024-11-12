using OrderApp.Class;
using System.Data;

namespace OrderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пример входных данных для теста
            DataRow rstMeterReq = null; // Данные заявки
            int userID = 0;
            int profileID = 0;
            int tradeAgentID = 0;
            string dCardNum = "";

            try
            {
                long orderID = CreateOrderByMetReq(rstMeterReq, userID, profileID, tradeAgentID, dCardNum);
                Console.WriteLine($"Заказ успешно создан с ID: {orderID}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // Метод для создания заказа по методу CreateOrderByMetReq
        public static long CreateOrderByMetReq(DataRow rstMeterReq, int userID = 0, int profileID = 0, int tradeAgentID = 0, string dCardNum = "")
        {
            long orderID = 0;
            string commandNumber;
            double exchangeRate;
            int paymentConditionID;

            // Создаем объекты для работы
            var objOrder = new Order();
            var objUser = new User();
            var objProfile = new Profile();
            var objCurrency = new Currency();

            // Настройка начальных значений заказа
            Console.WriteLine("Инициализация заказа...");

            // Получение командного номера и курса валюты
            commandNumber = objCurrency.GetCommandNumberByDate(DateTime.Today);
            exchangeRate = objCurrency.GetExchangeRate(DateTime.Today, "EUR");
            paymentConditionID = GetPaymentConditionID("STDSC");

            // Загрузка профиля пользователя
            var profile = profileID != 0 ? objUser.LoadProfile(profileID) : objUser.LoadProfileByUserID(userID);
            if (profile != null)
            {
                userID = profile.ManagerID;
            }

            // Заполнение информации о заказе
            objOrder.OrderDate = DateTime.Today;
            objOrder.Contact = rstMeterReq?["strContact"]?.ToString();
            objOrder.Address = rstMeterReq?["strPost"]?.ToString();
            objOrder.Email = rstMeterReq?["strEmail"]?.ToString();
            objOrder.Phone = rstMeterReq?["strPhone"]?.ToString();
            objOrder.TradeAgentID = tradeAgentID;
            objOrder.DiscountCard = dCardNum;

            // Дополнительные настройки заказа
            objOrder.PaymentConditionID = paymentConditionID;
            objOrder.ExchangeRate = exchangeRate;
            objOrder.CommandNumber = commandNumber;

            // Создание этапов для заказа
            var stages = new List<Stage>
            {
                new Stage { Name = "Оформление", PlannedDate = DateTime.Today.AddDays(1) },
                new Stage { Name = "Изготовление", PlannedDate = DateTime.Today.AddDays(3) },
                new Stage { Name = "Комплектование", PlannedDate = DateTime.Today.AddDays(5) },
                new Stage { Name = "Доставка", PlannedDate = DateTime.Today.AddDays(7) }
            };

            // Сохранение заказа в БД (эмуляция)
            orderID = SaveOrder(objOrder, stages);

            return orderID;
        }

        // Эмуляция сохранения заказа
        public static long SaveOrder(Order order, List<Stage> stages)
        {
            Console.WriteLine("Сохранение заказа...");
            foreach (var stage in stages)
            {
                Console.WriteLine($"Этап: {stage.Name}, Плановая дата: {stage.PlannedDate}");
            }
            // Возвращаем случайный ID заказа для эмуляции сохранения
            return new Random().Next(1000, 9999);
        }

        // Эмуляция метода получения ID условий оплаты
        public static int GetPaymentConditionID(string key)
        {
            Console.WriteLine($"Получение ID условий оплаты для ключа: {key}");
            return 123; // Эмуляция ID
        }
    }
}
