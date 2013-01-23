namespace MvcDemo.Models
{
    public class Spec
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RescuerSpec
    {
        public RescuerSpec()
        {
            Tehnogenschik = new Spec[0];
            Cynologist = new Spec[0];
            Tourist = new Spec[0];
        }

        public int Id { get; set; }
        public int RescuerProfileId { get; set; }

        /// <summary>
        /// Альпинисти
        /// </summary>
        public Spec Alpinist { get; set; }

        /// <summary>
        /// Жетон за спасение в горах
        /// </summary>
        public bool AlpinistToken { get; set; }

        /// <summary>
        /// Пловец-спасатель
        /// </summary>
        public Spec RescueSwimmer { get; set; }

        /// <summary>
        /// Водолаз (разр 4 - 7)
        /// </summary>
        public Spec Vodolaz { get; set; }

        /// <summary>
        /// Дайвер
        /// </summary>
        public Spec Diver { get; set; }

        /// <summary>
        /// Сертификат дайвера
        /// </summary>
        public string DiverCertificate { get; set; }

        /// <summary>
        /// Кинолог
        /// </summary>
        public Spec[] Cynologist { get; set; }

        /// <summary>
        /// Спелеолог
        /// </summary>
        public Spec Speleologist { get; set; }

        /// <summary>
        /// Техногенщик
        /// </summary>
        public Spec[] Tehnogenschik { get; set; }

        /// <summary>
        /// Турист
        /// </summary>
        public Spec[] Tourist { get; set; }
    }
}