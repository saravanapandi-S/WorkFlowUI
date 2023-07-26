using DataManager;
using DataTier;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nvocc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        DocumentManager Manag = new DocumentManager();
        private readonly IConfiguration _configuration;

        public object Server { get; private set; }
        public object MimeMapping { get; private set; }

        public BookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("EnquiryMasterBind")]
        public List<MyBookingSource> GetEnquiryNo(MyBookingSource Data)
        {
            BookingManager cm = new BookingManager();
            List<MyBookingSource> st = cm.EnquiryNumber(Data);
            return st;
        }

        [HttpPost("BookingListView")]
        public List<MyBookingSource> ExistingBooking(MyBookingSource Data)
        {
            BookingManager cm = new BookingManager();
            List<MyBookingSource> st = cm.ExistingBookingvalues(Data);
            return st;
        }

        [HttpPost("InsertFromEnquiry")]
        public List<MyEnquiry> InsertDirectEnqBooking(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.InsertDirectEnqBooking(Data);
            return st;
        }


        [HttpPost("ExistingBookingBind")]
        public List<MYBookingNew> ExistingBookingBind(MYBookingNew Data)
        {
            BookingManager cm = new BookingManager();
            List<MYBookingNew> st = cm.ExistingBookingEditView(Data);
            return st;
        }

        [HttpPost("ExistingBookingCntrTypeBind")]
        public List<MyEnquiry> ExistingBookingCntrTypeBind(MyEnquiry Data)
        {
            BookingManager cm = new BookingManager();
            List<MyEnquiry> st = cm.ExistingBookingCntrTypeBind(Data);
            return st;
        }

        [HttpPost("ExistingBookingHazardousBind")]
        public List<MyEnquiry> ExistingBookingHazardousBind(MyEnquiry Data)
        {
            BookingManager cm = new BookingManager();
            List<MyEnquiry> st = cm.ExistingBookingHazardousBind(Data);
            return st;
        }

        [HttpPost("ExistingBookingOutGaugeBind")]
        public List<MyEnquiry> ExistingBookingOutGaugeBind(MyEnquiry Data)
        {
            BookingManager cm = new BookingManager();
            List<MyEnquiry> st = cm.ExistingBookingOutGaugesBind(Data);
            return st;
        }

        [HttpPost("ExistingBookingRefferBind")]
        public List<MyEnquiry> ExistingBookingRefferBind(MyEnquiry Data)
        {
            BookingManager cm = new BookingManager();
            List<MyEnquiry> st = cm.ExistingBookingRefferBind(Data);
            return st;
        }

        [HttpPost("ExistingEnquiryShimpmentPOLBind")]
        public List<MyEnquiry> ExistingEnquiryShimpmentPOLBind(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryShimpmentPOLBind(Data);
            return st;
        }

        [HttpPost("ExistingEnquiryShimpmentPODBind")]
        public List<MyEnquiry> ExistingEnquiryShimpmentPODBind(MyEnquiry Data)
        {
            EnquiryMaster cm = new EnquiryMaster();
            List<MyEnquiry> st = cm.ExistingEnquiryShimpmentPODBind(Data);
            return st;
        }

        [HttpPost("ExistingBookingFreightRateBind")]
        public List<MyEnquiry> ExistingBookingFreightRateBind(MyEnquiry Data)
        {
            BookingManager cm = new BookingManager();
            List<MyEnquiry> st = cm.ExistingBookingFreightRateBind(Data);
            return st;
        }

        [HttpPost("ExistingBookingSlotRateBind")]
        public List<MyEnquiry> ExistingBookingSlotRateBind(MyEnquiry Data)
        {
            BookingManager cm = new BookingManager();
            List<MyEnquiry> st = cm.ExistingBookingSlotRateBind(Data);
            return st;
        }


        [HttpPost("ExistingBookingShimpmentPOLBind")]
        public List<MyEnquiry> ExistingBookingShimpmentPOLBind(MyEnquiry Data)
        {
            BookingManager cm = new BookingManager();
            List<MyEnquiry> st = cm.ExistingBookingShimpmentPOLBind(Data);
            return st;
        }

        [HttpPost("ExistingBookingShimpmentPODBind")]
        public List<MyEnquiry> ExistingBookingShimpmentPODBind(MyEnquiry Data)
        {
            BookingManager cm = new BookingManager();
            List<MyEnquiry> st = cm.ExistingBookingShimpmentPODBind(Data);
            return st;
        }


        [HttpPost("BookingInsert")]
        public List<MyEnquiry> BookingInsert(MyEnquiry Data)
        {
            BookingManager cm = new BookingManager();
            List<MyEnquiry> st = cm.InsertBookingMaster(Data);
            return st;
        }

        [HttpPost("BookinglevelListView")]
        public List<MyBookingSource> ExistingBookinglevel(MyBookingSource Data)
        {
            BookingManager cm = new BookingManager();
            List<MyBookingSource> st = cm.ExistingBookinglevelvalues(Data);
            return st;
        }

        [HttpPost("bookingStatusUpdate")]
        public List<MYBookingNew> bookingStatusUpdate(MYBookingNew Data)
        {
            BookingManager cm = new BookingManager();
            List<MYBookingNew> st = cm.InsertBkgStatusUpdate(Data);
            return st;
        }

        [HttpPost("PaymentCenterBind")]
        public List<MYBookingNew> PaymentCenterBindValues(MYBookingNew Data)
        {
            BookingManager cm = new BookingManager();
            List<MYBookingNew> st = cm.PaymentCenterBindData(Data);
            return st;
        }


    }
}
