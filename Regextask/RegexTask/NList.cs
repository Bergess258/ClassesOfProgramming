using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuhovLab1
{
    //NList это однонаправленный список для переменных метода, который был создан чтобы хранить два строковых значения.
    //Можешь просто как аналог использовать List со своим классом, в котором хранится две строковые переменных.
    //Я подробней расскажу об этой фишке на следующем уроке, а сейчас использую list, либо этот класс, если разберешься сам.
    public class NList
    {
        public string type; //тип ссылки переменной ref/out/ или без всего
        public string method; // ее тип(double,string)
        public NList next;//запись о следующем элементе в списке
        public NList(string t, string p)
        {
            type = p;
            method = t;
        }
        public void Add(string t, string p)
        {
            //добавление в список
            //создаю локальную переменную, которая хранит ссылку, на текущее значение, чтобы не испортить значение в классе(если просто использовать переменную next то мы не сможем вернуться к первоночальному значению(мы его сотрем))
            NList temp = this;
            //из-за ссылки у нас изменения в temp типа добавить в next или изменить где-то значение будут влиять на первоначальную переменную
            while (true)
            {

                if (temp.next == null) { temp.next = new NList(t, p); break; }
                temp = temp.next;
            }
        }
        public override string ToString()
        {
            //приведение к строке
            string s = "";
            NList temp = this;
            while (true)
            {
                if (temp == null) break;
                s += temp.method + " " + temp.type+ " |";
                temp = temp.next;
            }
            s = s.Remove(s.Length - 1);
            return s;
        }
    }
}
