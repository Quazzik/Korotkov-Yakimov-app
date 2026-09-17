namespace SlagModeServer.DTOs
{
    public class TabeOutputData
    {
        /// <summary>
        /// Основность шлака CaO / SiO2
        /// </summary>
        public double slagBasicity1 { get; set; }

        /// <summary>
        /// Основность шлака (CaO + MgO) / SiO2
        /// </summary>
        public double slagBasicity2 { get; set; }

        /// <summary>
        /// Основность шлака (CaO + MgO) / (SiO2 + Al2O3)
        /// </summary>
        public double slagBasicity3 { get; set; }

        /// <summary>
        /// Основность шлака по Куликову
        /// </summary>
        public double slagBasicityKulikov { get; set; }

        /// <summary>
        ///  Расчётный выход шлака
        /// </summary>
        public double slagOut { get; set; }

        /// <summary>
        /// Расход материалов
        /// </summary>
        public double materialCons { get; set; }

        /// <summary>
        /// Всего агломерата с фабрик
        /// </summary>
        public double totalAglo { get; set; }

        /// <summary>
        /// Всего ЖРМ
        /// </summary>
        public double totalMat;

        /// <summary>
        /// Доля алгомерата с фабрик 2 и 3
        /// </summary>
        public double propAglo23 { get; set; }

        /// <summary>
        /// Доля алгомерата с фабрики 4
        /// </summary>
        public double propAglo4 { get; set; }

        /// <summary>
        /// Доля местного алгомерата
        /// </summary>
        public double propAglo234
        {
            get => _propAglo234;
            set
            {
                _propAglo234 = propAglo23 + propAglo4;
            }
        }

        private double _propAglo234;
        /// <summary>
        /// Доля окатышей с ССГПО
        /// </summary>
        public double propSsgpo { get; set; }

        /// <summary>
        /// Доля окатышей с Лебединского ГОК
        /// </summary>
        public double propLeb { get; set; }

        /// <summary>
        /// Доля окатышей с Качканарского ГОК
        /// </summary>
        public double propKach { get; set; }

        /// <summary>
        /// Доля окатышей с Михайловского ГОК
        /// </summary>
        public double propMix { get; set; }

        /// <summary>
        /// Доля руды
        /// </summary>
        public double propOre { get; set; }

        /// <summary>
        /// Доля сварочного шлака
        /// </summary>
        public double propWeldSlag { get; set; }

        /// <summary>
        /// Доля доменного присада
        /// </summary>
        public double propBFAddict { get; set; }

        /// <summary>
        /// Доля королька (который королек)
        /// </summary>
        public double propMinInclude { get; set; }

        public double totalProp
        {
            get => _totalProp;
            set
            {
                _totalProp = propAglo23 + propAglo4 + propSsgpo + propLeb + propKach + propMix + propOre + propWeldSlag + propBFAddict + propMinInclude;
            }
        }

        private double _totalProp;

        /// <summary>
        /// Вязкость при 1400
        /// </summary>
        public double Viscosity_1400 { get; set; }

        /// <summary>
        /// Вязкость при 1450
        /// </summary>
        public double Viscosity_1450 { get; set; }

        /// <summary>
        /// Вязкость при 1500
        /// </summary>
        public double Viscosity_1500 { get; set; }

        /// <summary>
        /// Вязкость при 1550
        /// </summary>
        public double Viscosity_1550 { get; set; }

        /// <summary>
        /// Температура шлака при 7 пуаз
        /// </summary>
        public double Temp_7_puaz { get; set; }

        /// <summary>
        /// Параметры градиента
        /// </summary>
        public double Gradient_7_25 { get; set; }
        public double Gradient_1400_1500 { get; set; }

        /// <summary>
        /// Температура шлака
        /// </summary>
        public double SlagTemperature { get; set; }

        /// <summary>
        /// Температура шлака(при 25 пуаз), °С
        /// </summary>
        public double slagTemperature_25puaz { get; set; }

        /// <summary
        /// Вязкость шлака при текущей температуре
        /// </summary>
        public double CurrSlagViscosity { get; set; }

        /// <summary>
        /// Расчетный выход шлака по балансу шлакообразующих
        /// </summary>
        public double BalSlagMass { get; set; }

        /// <summary>
        /// Выход шлака (баланс СаО) 
        ///</summary>
        public double CaOBalSlagMass { get; set; }

        ///<summary>
        /// Масса серы, вносимая в печь, кг/т чугуна
        /// </summary>
        public double TotalSInOre { get; set; }

        ///<summary>
        /// Коэффициент активности серы в чугуне
        /// </summary>
        public double SActivity { get; set; }

        ///<summary>
        /// Коэффициент распределения серы
        /// </summary>
        public double SDistribution { get; set; }

        ///<summary>
        /// Содержание серы в чугуне, %
        /// </summary>
        public double SContentInCastIron { get; set; }

        ///<summary>
        /// Температура чугуна (не понимаю нужно ли его выводить)
        /// </summary>
        public double CastIronTemp { get; set; }
    }
}
