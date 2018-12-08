using System;
using System.Collections.Generic;
using System.Text;

namespace AdventofCode {
    public class GuardDataTable {
        public List<GuardData> data { get; private set; }

        public GuardDataTable() {
            data = new List<GuardData>();
        }

        public void AddData(GuardData guardData) {
            if (data.Count == 0) {
                data.Add(guardData);
                return;
            }

            for (int i = 0; i < data.Count; i++) {
                if (DateTime.Compare(guardData.dateTime, data[i].dateTime) < 0) {
                    data.Insert(i, guardData);
                    return;
                }
            }

            data.Add(guardData);
        }
    }

    public class GuardData {
        public DateTime dateTime { get; private set; }
        public string text { get; private set; }

        public GuardData(string data) {
            int year = Convert.ToInt32(data.Substring(1, 4));
            int month = Convert.ToInt32(data.Substring(6, 2));
            int day = Convert.ToInt32(data.Substring(9, 2));
            int hour = Convert.ToInt32(data.Substring(12, 2));
            int minute = Convert.ToInt32(data.Substring(15, 2));
            dateTime = new DateTime(year, month, day, hour, minute, 0);
            text = data.Substring(19);
        }

        public override string ToString() {
            return $"dateTime: {dateTime}; Text: {text}";
        }
    }

    public class GuardSchedule {
        public DateTime dateTime { get; private set; }
        public int guardId { get; private set; }
        public bool[] isAwake { get; private set; }

        public GuardSchedule(int id, DateTime dt) {
            guardId = id;
            dateTime = dt;

            isAwake = new bool[60];

            for (int i = 0; i < 60; i++)
                isAwake[i] = true;
        }

        public void SetAsleep(int start, int end) {
            for (int i = start; i < end; i++)
                isAwake[i] = false;
        }

        public override string ToString() {
            string returnString = $"{dateTime.Month}-{dateTime.Day}\t#{guardId}\t";

            for (int i = 0; i < 60; i++)
                returnString += isAwake[i] ? '.' : '#';

            return returnString;
        }
    }

    public class GuardInfo {
        public int guardId { get; private set; }
        public int[] minutesAsleep { get; private set; }

        public GuardInfo(int id) {
            guardId = id;

            minutesAsleep = new int[60];

            for (int i = 0; i < 60; i++)
                minutesAsleep[i] = 0;
        }

        public void AddInfo(GuardSchedule schedule) {
            for (int i = 0; i < 60; i++)
                minutesAsleep[i] += schedule.isAwake[i] ? 0 : 1;
        }

        public int TimeSlept() {
            int total = 0;

            for (int i = 0; i < 60; i++)
                total += minutesAsleep[i];

            return total;
        }

        public int MinuteAsleep() {
            int mostAsleep = 0;

            for (int i = 1; i < 60; i++)
                if (minutesAsleep[mostAsleep] < minutesAsleep[i])
                    mostAsleep = i;

            return mostAsleep;
        }

        public int MostAsleep() {
            int i = 0;

            for (int j = 1; j < 60; j++)
                if (minutesAsleep[i] < minutesAsleep[j])
                    i = j;

            return i;
        }

        public override string ToString() {
            string returnString = $"ID: {guardId} - ";

            for (int i = 0; i < 60; i++) {
                returnString += $"{minutesAsleep[i]} ";
            }

            return returnString;
        }
    }
}
