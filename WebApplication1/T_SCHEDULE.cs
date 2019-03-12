using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using static System.Collections.Generic.LinkedList<WebApplication1.T_SCHEDULE>;

namespace WebApplication1
{
    public class T_SCHEDULE
    {
        public int scheduleId {get; set;}

        public DateTime deleteDate{get; set;}

        public string deleteFlg{get; set;}

        public int deleteUser{get; set;}

        public string description{get; set;}

        public int editAuthority{get; set;}

        public DateTime endDateTime{get; set;}

        public int endOclock { get; set; }
        public int endMinute { get; set; }

        public DateTime insertDate{get; set;}

        public int insertUser{get; set;}

        public string note{get; set;}

        public string releaseFlg{get; set;}

        public DateTime startDateTime{get; set;}

        public int startYear { get; set; }
        public int startMonth { get; set; }
        public int startDay { get; set; }
        public int startOclock { get; set; }
        public int startMinute { get; set; }

        public string title{get; set;}

        public int titleColor{get; set;}

        public DateTime updateDate{get; set;}

        public int updateUser{get; set;}

        public T_SCHEDULE() { }

        public IEnumerator GetEnumerator()
        {
            // IEnumerableを実装するクラスEnumeratorのインスタンスを返す
            return new Enumerator();
        }
    }
}
