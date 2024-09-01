using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticTask1 {
    class Program {
        static void Main(string[] args) {
            var VacationDictionary = new Dictionary<string, List<DateTime>>() {
                ["Иванов Иван Иванович"] = new List<DateTime>(), ["Петров Петр Петрович"] = new List<DateTime>(),
                ["Юлина Юлия Юлиановна"] = new List<DateTime>(), ["Сидоров Сидор Сидорович"] = new List<DateTime>(),
                ["Павлов Павел Павлович"] = new List<DateTime>(), ["Георгиев Георг Георгиевич"] = new List<DateTime>()
            };
            //Upd. типизация листа
            var AviableWorkingDaysOfWeekWithoutWeekends = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            // Список отпусков сотрудников
            List<DateTime> Vacations = new List<DateTime>();
            var AllVacationCount = 0;
            List<DateTime> dateList = new List<DateTime>();
            List<DateTime> SetDateList = new List<DateTime>();
            //upd. вынос объявления переменных за пределы цыкла
            Random gen = new Random();
            Random step = new Random();
            DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime end = new DateTime(DateTime.Today.Year, 12, 31);
            foreach (var VacationList in VacationDictionary) {
                //upd. удаление ненужной переменной workerName
                dateList = VacationList.Value;
                int vacationCount = 28;
                while (vacationCount > 0) {
                    int range = (end - start).Days;
                    //upd. правка региста метода AddDays
                    var startDate = start.AddDays(gen.Next(range));
                    if (AviableWorkingDaysOfWeekWithoutWeekends.Contains(startDate.DayOfWeek.ToString())) {
                        string[] vacationSteps = { "7", "14" };
                        int vacIndex = gen.Next(vacationSteps.Length);
                        var endDate = new DateTime(DateTime.Now.Year, 12, 31);
                        //upd. изменение типизации float на int
                        int difference = 0;
                        //upd. изменение проверки разделения отпусков
                        if (vacationCount >= 14 && vacationSteps[vacIndex] == "14") {
                            endDate = startDate.AddDays(14);
                            difference = 14;
                        } else {
                            endDate = startDate.AddDays(7);
                            difference = 7;
                        }
                        // Проверка условий по отпуску
                        bool CanCreateVacation = false;
                        // upd. корректировка проверки пересечения отпусков
                        if (!Vacations.Any(element => element < endDate && element.AddDays(7) > startDate)) {
                            CanCreateVacation = true;
                        }
                        if (CanCreateVacation) {
                            for (DateTime dt = startDate; dt < endDate; dt = dt.AddDays(1)) {
                                Vacations.Add(dt);
                                dateList.Add(dt);
                            }
                            AllVacationCount++;
                            //upd. исправлен подсчет оставшихся дней отпусков
                            vacationCount -= difference;
                        }
                    }
                }
            }
            foreach (var VacationList in VacationDictionary) {
                SetDateList = VacationList.Value;
                Console.WriteLine("Дни отпуска " + VacationList.Key + " : ");
                //upd. вывод только даты
                for (int i = 0; i < SetDateList.Count; i++) { Console.WriteLine(SetDateList[i].ToShortDateString()); }
            }
            Console.ReadKey();
        }
    }
}