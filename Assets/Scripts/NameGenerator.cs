using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator
{
    private List<string> maleNames = new List<string>
    {
        "Аввакум","Аваз","Агап","Агафон","Август","Августин","Аггей","Авраам","Абрам","Аарон","Автандил","Авдей","Авдей","Азарий","Арам","Аркадий","Арий","Аристарх","Арно","Арон","Арнольд","Арсен, Арсений","Архип","Артур","Артем","Артемий","Акакий","Алан","Ален","Аким","Альберт","Альфред","Александр",
        "Давид","Дамир","Даниил","Динасий","Дорофей","Дмитрий","Дональд","Донат","Денис","Демид","Демьян","Джордан",
        "Марат","Марк","Мариан","Мартин","Мартын","Май","Макар","Максим","Максимилиан","Мануил","Матвей","Мадлен","Мирон","Мирослав","Милан","Мисаил","Михаил","Митрофан","Мичлов","Моисей","Модест","Мстислав","Мурат","Муслим","Мефодий","Мечислав","Мечеслав",
        "Тарас","Талик","Таис","Тамаз","Трифон","Трофим","Тигран","Тимон","Тимофей","Тимур","Тит","Тихон","Терентий","Тельман","Теодор",
        "Иван","Ибрагим","Игнат","Игнатий","Игорь","Израиль","Измаил","Изяслав","Ираклий","Иржи","Иларион","Илларион","Илиан","Ион","Ипполит","Иннокентий","Ионос","Ионас","Иосиф","Исаак","Исаакий","Исидор","Иероним",
        "Казимир","Карл","Карен","Клавдий","Кирилл","Клим","Климент","Ким","Клод","Клемент","Корнилий","Корней","Конрад","Конкордий","Константин","Кондрат","Ксаннф","Кузьма"
    };




    public string Name;
    public NameGenerator()
    {
        Name = GetRandomName();
    }

    private string GetRandomName()
    {
        string fullName = maleNames[Random.Range(0, maleNames.Count)] + " " + GetFatherName(maleNames[Random.Range(0, maleNames.Count)]);
        return fullName;
    }

    private string GetFatherName(string fatherName)
    {
        string randFather = "";
        string fatherEnd = fatherName.Substring(fatherName.Length - 2);
        string fatherRoot = fatherName.Replace(fatherEnd, "");
        switch (fatherEnd)
        {
            case "ий": randFather = fatherRoot + "ьевич"; break;
            case "ов": randFather = fatherRoot + "ович"; break;
            case "ль": randFather = fatherRoot + "льевич"; break;
            case "ма": randFather = fatherRoot + "мович"; break;
            case "ей": randFather = fatherRoot + "еевич"; break;
            case "ва": randFather = fatherRoot + "вович"; break;
            case "ья": randFather = fatherRoot + "ьич"; break;
            case "ай": randFather = fatherRoot + "евич"; break;
            case "ел": randFather = fatherRoot + "ельевич"; break;
            default: randFather += fatherName + "ович"; break;
        }
        return randFather;
    }
}
