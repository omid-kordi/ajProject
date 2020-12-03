using System;
using System.Collections.Generic;
using System.Text;

namespace ajWebSite.Common.DTOs.Common
{
    public class SepResponseDTO
    {
        public string State { get; set; }
        public string ResNum { get; set; }
        public string MID { get; set; }
        public string RefNum { get; set; }
        public string CID { get; set; }
        public string TRACENO { get; set; }
        public string RRN { get; set; }
        public string SecurePan { get; set; }


        public bool TransactionConfirmed { get; set; }
        public string Description { get; set; }

        public string StateDesc()
        {
            string result = "";
            switch (State)
            {
                case "Canceled By User":
                    result = "کاربر از پرداخت هزینه منصرف شده و تراکنش را لغو کرده است";
                    break;
                case "Invalid Amount":
                    result = "مبلغ سند برگشتی، از مبلغ تراکنش اصلی بیشتر است";
                    break;
                case "Invalid Transaction":
                    result = "درخواست برگشت یک تراکنش رسیده است، در حالی که تراکنش اصلی پیدا نمی شود";
                    break;
                case "No Such Issuer":
                    result = "چنین صادرکننده کارتی وجود ندارد";
                    break;
                case "Expired Card Pick Up":
                    result = "از تاریخ انقضای کارت گذشته است و کارت دیگر معتبر نیست";
                    break;
                case "Allowable PIN Tries Exceeded Pick Up":
                    result = "رمز کارت 3 مرتبه اشتباه وارد شده است و در نتیجه کارت غیر فعال خواهد شد";
                    break;
                case "Incorrect PIN":
                    result = "خریدار رمز کارت را اشتباه وارد کرده است";
                    break;
                case "Exceeds Withdrawal Amount Limit":
                    result = "مبلغ بیش از سقف برداشت می باشد.";
                    break;
                case "Transaction Cannot Be Completed":
                    result = "تراکنش Authorize شده است (شماره PIN  و PAN درست هستند) ولی امکان سند خوردن وجود ندارد";
                    break;
                case "Response Received Too Late":
                    result = "تراکنش در شبکه بانکی Timeout خورده است.";
                    break;
                case "Suspected Fraud Pick Up":
                    result = "خریدار یا فیلد CVV2 و یا فیلد ExpDate را اشتباه زده است. (یا اصلا وارد نکرده است)";
                    break;
                case "No Sufficient Funds":
                    result = "موجودی به اندازه کافی در حساب وجود ندارد";
                    break;
                case "Issuer Down Slm":
                    result = "سیستم کارت بانک صادر کننده در وضعیت عملیاتی نیست";
                    break;
                case "TME Error":
                    result = "کلیه خطاهای دیگر بانکی باعث ایجاد چنین خطایی می گردد";
                    break;
            }
            return result;
        }

        public string TransactionChecking(int resultId)
        {
            string errorMsg = "";
            switch (resultId)
            {

                case -1:		//TP_ERROR
                    errorMsg = "بروز خطا درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-1";
                    break;
                case -2:		//ACCOUNTS_DONT_MATCH

                    errorMsg = "بروز خطا در هنگام تاييد رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-2";
                    break;
                case -3:		//BAD_INPUT

                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-3";
                    break;
                case -4:		//INVALID_PASSWORD_OR_ACCOUNT

                    errorMsg = "خطاي دروني سيستم درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-4";
                    break;
                case -5:		//DATABASE_EXCEPTION

                    errorMsg = "خطاي دروني سيستم درهنگام بررسي صحت رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-5";
                    break;
                case -7:		//ERROR_STR_NULL

                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-7";
                    break;
                case -8:		//ERROR_STR_TOO_LONG

                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-8";
                    break;
                case -9:		//ERROR_STR_NOT_AL_NUM

                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-9";
                    break;
                case -10:	//ERROR_STR_NOT_BASE64

                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-10";
                    break;
                case -11:	//ERROR_STR_TOO_SHORT

                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-11";
                    break;
                case -12:		//ERROR_STR_NULL

                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-12";
                    break;
                case -13:		//ERROR IN AMOUNT OF REVERS TRANSACTION AMOUNT

                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-13";
                    break;
                case -14:	//INVALID TRANSACTION

                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-14";
                    break;
                case -15:	//RETERNED AMOUNT IS WRONG

                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-15";
                    break;
                case -16:	//INTERNAL ERROR

                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-16";
                    break;
                case -17:	// REVERS TRANSACTIN FROM OTHER BANK

                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-17";
                    break;
                case -18:	//INVALID IP

                    errorMsg = "خطا در پردازش رسيد ديجيتالي در نتيجه خريد شما تاييد نگرييد" + "-18";
                    break;

            }
            return errorMsg;
        }
    }


}
