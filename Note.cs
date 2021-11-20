using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class Note
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string DateOfBirth { get; set; }
        public string Organization { get; set; }
        public string Position { get; set; }
        public string Remark { get; set; }

        public static Dictionary<string, Validation> fieldsValidation = new Dictionary<string, Validation>()
        {
            ["Name"] = new Validation(true, 1, 20, "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя -".ToArray()),
            ["Surname"] = new Validation(true, 1, 20, "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя -".ToArray()),
            ["SecondName"] = new Validation(false, 0, 20, "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя -".ToArray()),
            ["Phone"] = new Validation(true, 5, 11, "0123456789".ToArray()),
            ["Country"] = new Validation(false, 0, 20, "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя -".ToArray()),
            ["DateOfBirth"] = new Validation(false, 10, 10, "0123456789.".ToArray()),
            ["Organization"] = new Validation(false, 0, 20, "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя -".ToArray()),
            ["Position"] = new Validation(false, 0, 20, "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя -".ToArray()),
            ["Remark"] = new Validation(false, 0, 200, "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789 ,.?!()\\+-=№@'\"&$;:^".ToArray()),
            ["Id"] = new Validation(true, 1, 10, "0123456789".ToArray())
        };

        public override string ToString()
        {
            return "\n\tID: " + Id +
                "\n\tФамилия: " + Surname +
                "\n\tИмя: " + Name +
                "\n\tОтчество: " + SecondName +
                "\n\tНомер телефона: " + Phone +
                "\n\tСтрана: " + Country +
                "\n\tДата рождения: " + DateOfBirth +
                "\n\tОрганизация: " + Organization +
                "\n\tДолжность: " + Position +
                "\n\tПримечание: " + Remark;
        }

        public string ToShortString()
        {
            return Id + " " + Surname + " " + Name + " " + Phone;
        }

    }
}
