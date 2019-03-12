using System;
using System.Collections.Generic;
using System.Web;

namespace WebApplication1.Views
{
    public class T_SCHEDULE
    {
        private int scheduleId {get; set;} 

        private DateTime deleteDate{get; set;}

        private string deleteFlg{get; set;}

        private int deleteUser{get; set;}

        private string description{get; set;}

        private int editAuthority{get; set;}

        private DateTime endDateTime{get; set;}

        private DateTime insertDate{get; set;}

        private int insertUser{get; set;}

        private string note{get; set;}

        private string releaseFlg{get; set;}

        private DateTime startDateTime{get; set;}

        private string title{get; set;}

        private int titleColor{get; set;}

        private DateTime updateDate{get; set;}

        private int updateUser{get; set;}

        public T_SCHEDULE(int scheduleId, DateTime startDateTime, DateTime endDateTime,
            string title, int titleColor, string description, string note)
        {
            scheduleId = this.scheduleId;
            startDateTime = this.startDateTime;
            endDateTime = this.endDateTime;
            title = this.title;
            titleColor = this.titleColor;
            description = this.description;
            note = this.note;
        }
    }
}