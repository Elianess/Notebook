using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    /*
    * Очередное приключение в Рейд-режиме ждёт! Условия и задачи текущей стадии находятся в файле Conditions.txt.
    */

    public class Notebook
    {
        public Dictionary<int, Note> allNotes = new Dictionary<int, Note>();

        private static void Greetings()
        {
            Console.WriteLine("Добро пожаловать в нашу записную книжку!\n" +
                "\t- для создания новой записи введите команду: create.\n" +
                "\t- для просмотра записи введите команду: show.\n" +
                "\t- для редактирования записи введите команду: edit.\n" +
                "\t- для удаления записи введите команду: del.\n" +
                "\t- для просмотра списка всех записей введите команду: all.\n" +
                "\t- для выхода из программы введите команду: exit.\n");
        }

        private void Action()
        {
            string str = "";
            do
            {
                Greetings();

                Console.Write("Введите команду: ");
                str = Console.ReadLine();


                while (true)
                {
                    if (str == "create")
                    {
                        Console.WriteLine("Создание");
                        CreateNote();
                        break;
                    }
                    else if (str == "show")
                    {
                        Console.WriteLine("Показ");
                        ReadNote();
                        break;
                    }
                    else if (str == "edit")
                    {
                        Console.WriteLine("Редактирование");
                        UpdateNote();
                        break;
                    }
                    else if (str == "del")
                    {
                        Console.WriteLine("Удаление");
                        DeleteNote();
                        break;
                    }
                    else if (str == "all")
                    {
                        Console.WriteLine("Всё");
                        ShowAllNotes();
                        break;
                    }
                    else if (str == "exit")
                    {
                        Console.WriteLine("Выход");
                        Console.WriteLine("Пока-пока!");
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("Данной команды не найдено! Попробуйте ещё раз: ");
                        str = Console.ReadLine();
                    }
                }
            } while (str != "exit");
        }

        private void CreateNote()
        {
            Note note = new Note();

            note.Id = allNotes.Count();
            note.Surname = ReadUntilValidationPass("Surname");
            note.Name = ReadUntilValidationPass("Name");
            note.SecondName = ReadUntilValidationPass("SecondName");
            note.Phone = ReadUntilValidationPass("Phone");
            note.Country = ReadUntilValidationPass("Country");
            note.DateOfBirth = ReadUntilValidationPass("DateOfBirth");
            note.Organization = ReadUntilValidationPass("Organization");
            note.Position = ReadUntilValidationPass("Position");
            note.Remark = ReadUntilValidationPass("Remark");

            allNotes.Add(note.Id, note);
        }

        private void ReadNote()
        {
            Console.Write("Введите Id записи: ");
            string id = Console.ReadLine();

            if (int.TryParse(id, out int x))
            {
                if (allNotes.ContainsKey(x))
                    Console.WriteLine(allNotes[x]);
                else
                    Console.WriteLine("Данной записи не найдено!");
            }
            else
                Console.WriteLine("Введен некорректный идентификатор!");
        }

        private void UpdateNote()
        {
            Console.Write("Укажите ID записи для редактирования: ");
            string ID = Console.ReadLine();

            if (int.TryParse(ID, out int newID))
            {
                bool trFl = true;
                while (trFl)
                {

                    if (!allNotes.ContainsKey(newID))
                    {
                        Console.WriteLine("Данной записи не найдено!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine(allNotes[newID]);

                        Console.WriteLine("Какое поле необходимо отредактировать?" +
                            "\n\t1 - Фамилия" +
                            "\n\t2 - Имя" +
                            "\n\t3 - Отчество" +
                            "\n\t4 - Телефон" +
                            "\n\t5 - Страна" +
                            "\n\t6 - Дата рождения" +
                            "\n\t7 - Организация" +
                            "\n\t8 - Должность" +
                            "\n\t9 - Примечание");
                        Console.Write("Введите цифру для выбора или cancel для завершения редактирования: ");

                        string num = "";
                        while (num == "")
                        {
                            num = Console.ReadLine();

                            if (num == "cancel")
                                return;

                            switch (num)
                            {
                                case "1":
                                    allNotes[newID].Surname = ReadUntilValidationPass("Surname");
                                    break;
                                case "2":
                                    allNotes[newID].Name = ReadUntilValidationPass("Name");
                                    break;
                                case "3":
                                    allNotes[newID].SecondName = ReadUntilValidationPass("SecondName");
                                    break;
                                case "4":
                                    allNotes[newID].Phone = ReadUntilValidationPass("Phone");
                                    break;
                                case "5":
                                    allNotes[newID].Country = ReadUntilValidationPass("Country");
                                    break;
                                case "6":
                                    allNotes[newID].DateOfBirth = ReadUntilValidationPass("DateOfBirth");
                                    break;
                                case "7":
                                    allNotes[newID].Organization = ReadUntilValidationPass("Organization");
                                    break;
                                case "8":
                                    allNotes[newID].Position = ReadUntilValidationPass("Position");
                                    break;
                                case "9":
                                    allNotes[newID].Remark = ReadUntilValidationPass("Remark");
                                    break;
                                default:
                                    Console.Write("Команда не найдена! Введите ещё раз: ");
                                    num = "";
                                    break;
                            }
                        }

                        Console.Write("Поле изменено! Продолжить редактирование записи? (yes/no): ");

                        bool yesNo = true;
                        while (yesNo)
                        {
                            num = Console.ReadLine();
                            if (num == "yes")
                            {
                                yesNo = false;
                            }
                            else if (num == "no")
                            {
                                Console.Clear();
                                yesNo = false;
                                return;
                            }
                            else
                                Console.Write("Пожалуйста введите yes или no: ");
                        }
                        Console.Clear();
                    }
                }
            }
            else
                Console.WriteLine("Введен некорректный идентификатор!");
        }

        private void DeleteNote()
        {
            Console.Write("Введите Id записи для удаления: ");
            string id = Console.ReadLine();

            if (int.TryParse(id, out int x))
            {
                if (allNotes.ContainsKey(x))
                {
                    allNotes.Remove(x);
                    Console.WriteLine("Запись " + x + " удалена!");
                }
                else
                    Console.WriteLine("Данной записи не найдено!");
            }
            else
                Console.WriteLine("Введен некорректный идентификатор!");
        }

        private void ShowAllNotes()
        {
            foreach (KeyValuePair<int, Note> item in allNotes)
                Console.WriteLine(item.Value.ToShortString());
        }

        private string ReadUntilValidationPass(string name)
        {
            while (true)
            {
                Console.Write("Введите " + name + ": ");
                string newName = Console.ReadLine();

                if (Note.fieldsValidation[name].TryValidate(newName, out string error))
                {
                    if (string.IsNullOrEmpty(newName))
                        return null;
                    else
                        return newName;
                }
                else
                    Console.WriteLine(error);
            }
        }

        public static void Main(string[] args)
        {
            Notebook notebook = new Notebook();
            notebook.Action();
        }
    }
}