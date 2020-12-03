using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ajWebSite.Common.Enums
{
    public enum AuctionType
    {
        [Description("خودرو")] Vehicle = 1,
        //Commodity = 2,
    }

    public enum CarState
    {
        #region بدون پلاک
        [Description("آماده تحویل")] ReadyToDeliver = 11,
        [Description("بازدید فنی مجدد")] CarInspection = 12,
        #endregion

        #region پلاک دار
        [Description("آماده شماره گذاری و فک پلاک")] ReadyToPlaque = 21,
        [Description("حمل از طریق خودرو بر جهت رفع اشکالات")] CarryToRepair = 22,
        #endregion





    }

    public enum AuctionState
    {
        [Description("تکمیل نشده")] NotComplete = 0,
        [Description("منتظر شروع")]  NotPropagated = 1,
        [Description("درحال انتشار")]  InProgress = 2,
        [Description("پایان انتشار")] EndResponse = 3,
        [Description("تکیمل وجه برنده اول")] Winner1 = 4,
        [Description("تکمیل وجه برنده دوم")] Winner2 = 5,
        [Description("پایان فرصت تکمیل وجه")] WinnerActionEnd = 9,
        [Description("نهایی شده")] Finished = 10,

    }
    public enum BusinessType
    { 
        [Description("نمایشی")] forShow = 1,
        [Description("ایتم فروشگاهی")] forShop = 2,
    }
    public enum ReleaseType
    {
        [Description("منشر نشده")] notReleased = 1,
        [Description("منشر شده")] Released = 2,
        [Description("انشار کامل")] fullReleased = 3,

    }
    public enum FileBinaryType
    {
        [Description("هیچکدام")] none = 0,
        [Description("فایل تصویری")] picture = 1,
        [Description("فایل صوتی")] audio = 2,
        [Description("دیتا")] binary = 3,
        [Description("پی دی اف")] pdf = 4,
        [Description("فایل Word")] document = 5,
        [Description("دیگر")] other = 6,
    }
    public enum AttachmentType
    {
        [Description("گروه مقالات")] newsArticleGroup = 1,
        [Description("سالن ها")] salonAttachments = 3,
        [Description("بدنه مقاله")] articleBudy = 2
    }
    public enum GroupType
    {
        [Description("گروه مقالات")]newsArticleGroup=1
    }
    public enum AuctionFindWinnerState
    {
        [Description("غیرفعال")] None = 0,
        [Description("برنده اول مشخص شده")] Winner1 = 1,
        [Description("برنده دوم مشخص شده")] Winner2 = 2,
    }

    public enum AuctionResponseItemState
    {
        [Description("پرداخت نشده")] NotPaid = 0,
        [Description("پرداخت سپرده")] ReservePaid = 1,
        [Description("پرداخت نهایی")] FullPaid = 2,
    }
}
