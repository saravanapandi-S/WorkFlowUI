using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using DataBaseFactory;
using System.Data;
using System.Data.Common;
using DataTier;
using System.Data.SqlClient;
using com.itextpdf.text.pdf;

namespace DataManager
{
    public class ImpBLManager
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public ImpBLManager()
        {
            _dbFactory = new SQLFactory();

        }

        public List<MyImpBL> ImpBLInsert(MyImpBL Data)
        {
            List<MyImpBL> ListBL = new List<MyImpBL>();
            DbConnection con = null;
            DbTransaction trans;
            DataTable dtchk = GetImportBLExValues(Data);
            if (Data.ID == 0)
            {
                if (dtchk.Rows.Count >= 1)
                {

                    ListBL.Add(new MyImpBL
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "BOL Number Already Exists"
                    });
                    return ListBL;

                }
            }

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    Cmd.CommandText = " IF((select count(*) from NVO_ImpBL where ID=@ID)<=0) " +
                                       " BEGIN " +
                                       " INSERT INTO  NVO_ImpBL(BLNumber,BLStatusID,OfficeID,PrincipalID,VesselID,VoyageID,POLAgentID,POOID,POLID,PODID,FPODID,ImpTsID,NexPortTS,Shipper,ShipperAddress,ShipperEmail,Consignee,ConsigneeAddress,ConsigneeEmail,Notify,NotifyAddress,NotifyEmail,Notify2,Notify2Address,Notify2Email,Marks,Description,FreightTermID,FreightPaybleAt,BLTypeID,FreeDays,SourceID,SalesPersonID,EnqID,CurrentDate,BLDate) " +
                                       " values (@BLNumber,@BLStatusID,@OfficeID,@PrincipalID,@VesselID,@VoyageID,@POLAgentID,@POOID,@POLID,@PODID,@FPODID,@ImpTsID,@NexPortTS,@Shipper,@ShipperAddress,@ShipperEmail,@Consignee,@ConsigneeAddress,@ConsigneeEmail,@Notify,@NotifyAddress,@NotifyEmail,@Notify2,@Notify2Address,@Notify2Email,@Marks,@Description,@FreightTermID,@FreightPaybleAt,@BLTypeID,@FreeDays,@SourceID,@SalesPersonID,@EnqID,@CurrentDate,@BLDate) " +
                                       " END  " +
                                       " ELSE " +
                                       " UPDATE NVO_ImpBL SET BLNumber=@BLNumber,BLStatusID=@BLStatusID,OfficeID=@OfficeID,PrincipalID=@PrincipalID,VesselID=@VesselID,VoyageID=@VoyageID,POLAgentID=@POLAgentID,POOID=@POOID,POLID=@POLID,PODID=@PODID,FPODID=@FPODID,ImpTsID=@ImpTsID,NexPortTS=@NexPortTS,Shipper=@Shipper,ShipperAddress=@ShipperAddress,ShipperEmail=@ShipperEmail,Consignee=@Consignee,ConsigneeAddress=@ConsigneeAddress,ConsigneeEmail=@ConsigneeEmail,Notify=@Notify,NotifyAddress=@NotifyAddress," +
                                       " NotifyEmail=@NotifyEmail,Notify2=@Notify2,Notify2Address=@Notify2Address,Notify2Email=@Notify2Email,Marks=@Marks,Description=@Description,FreightTermID=@FreightTermID,FreightPaybleAt=@FreightPaybleAt,BLTypeID=@BLTypeID,FreeDays=@FreeDays,SourceID=@SourceID,SalesPersonID=@SalesPersonID,EnqID=@EnqID,CurrentDate=@CurrentDate,BLDate=@BLDate where ID=@ID and ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLNumber", Data.BLNumber));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLStatusID", Data.BLStatusID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeID", Data.OfficeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PrincipalID", Data.PrincipalID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselID", Data.VesselID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageID", Data.VoyageID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POLAgentID", Data.POLAgentID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POOID", Data.POOID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@POLID", Data.POLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PODID", Data.PODID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FPODID", Data.FPODID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ImpTsID", Data.ImportTS));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NexPortTS", Data.TransNextID));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Shipper", Data.Shipper));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperAddress", Data.ShipperAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperEmail", Data.ShipperEmail));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Consignee", Data.Consignee));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeAddress", Data.ConsigneeAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeEmail", Data.ConsigneeEmail));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify", Data.Notify));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyAddress", Data.NotifyAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyEmail", Data.NotifyEmail));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify2", Data.Notify2));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify2Address", Data.Notify2Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify2Email", Data.Notify2Email));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Marks", Data.Marks));

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Description", Data.Description));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreightTermID", Data.FreightTermID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreightPaybleAt", Data.FreightPaybleAt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLTypeID", Data.BLTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@FreeDays", Data.FreeDays));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SourceID", Data.SourceID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SalesPersonID", Data.SalesPersonID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EnqID", Data.EnqID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLDate", Data.BLDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_ImpBL')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }




                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_ImpBLContainerDtls where CntrNo=@CntrNo and BLID=@BLID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ImpBLContainerDtls(BLID,CntrID,CntrNo,CntrType,SealNo,KGSWeight,NetWeight,NoofPkgs,CBMVolume,HHSCode,OperatingLine,OwningLine) " +
                                     " values (@BLID,@CntrID,@CntrNo,@CntrType,@SealNo,@KGSWeight,@NetWeight,@NoofPkgs,@CBMVolume,@HHSCode,@OperatingLine,@OwningLine) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ImpBLContainerDtls SET BLID=@BLID,CntrID=@CntrID,CntrNo=@CntrNo,CntrType=@CntrType,SealNo=@SealNo,KGSWeight=@KGSWeight," +
                                     " NetWeight=@NetWeight,NoofPkgs=@NoofPkgs,CBMVolume=@CBMVolume,HHSCode=@HHSCode,OperatingLine=@OperatingLine,OwningLine=@OwningLine where CntrNo=@CntrNo and BLID=@BLID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", 0));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrNo", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrType", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@SealNo", CharSplit[3]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@KGSWeight", CharSplit[4]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NetWeight", CharSplit[5]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@NoofPkgs", CharSplit[6]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CBMVolume", CharSplit[7]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@HHSCode", CharSplit[8]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@OperatingLine", CharSplit[9]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@OwningLine", CharSplit[10]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    ListBL.Add(new MyImpBL
                    {
                        AlertMessage = "Record Saved Successfully"
                    }); ;
                    return ListBL;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListBL.Add(new MyImpBL
                    {
                        AlertMessage = ex.Message
                    }); ;
                    return ListBL;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }


        public DataTable GetImportBLExValues(MyImpBL Data)
        {


            string _Query = "select * from NVO_ImpBL where BLNumber = '" + Data.BLNumber + "' ";
            return GetViewData(_Query, "");
        }


        public List<MyImpBL> ContainerALLDetails(MyImpBL Data)
        {
            List<MyImpBL> ListBL = new List<MyImpBL>();
            DataTable dt = GetContainerALLDetails();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBL.Add(new MyImpBL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),


                });

            }
            return ListBL;
        }


        public DataTable GetContainerALLDetails()
        {
            string _Query = " select Id,CntrNo from NVO_Containers";
            return GetViewData(_Query, "");
        }

        public List<MyImpBL> ImpBLview(MyImpBL Data)
        {
            List<MyImpBL> ListBL = new List<MyImpBL>();
            DataTable dt = GetImpBLView(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBL.Add(new MyImpBL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    AgencyName = dt.Rows[i]["AgencyName"].ToString(),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    Voyage = dt.Rows[i]["Voyage"].ToString(),
                    POL = dt.Rows[i]["POL"].ToString(),
                    FPOD = dt.Rows[i]["FPOD"].ToString(),



                }); ;

            }
            return ListBL;
        }

        public DataTable GetImpBLView(MyImpBL Data)
        {
            string _Query = " SELECT ID,BLNumber, " +
                            " (select count(CntrNo) from NVO_ImpBLContainerDtls where BLID =NVO_ImpBL.ID) as CntrNo,Consignee,VesselID," +
                            " (SELECT TOP(1) AgencyName FROM NVO_AgencyMaster where NVO_AgencyMaster.Id =NVO_ImpBL.POLAgentID) as AgencyName, " +
                            " (select top(1) VesselName from NVO_VesselMaster where NVO_VesselMaster.ID=NVO_ImpBL.VesselID)as VesselName," +
                            " (select top(1)  VoyageNo from NVO_Voyage where NVO_Voyage.ID=NVO_ImpBL.VoyageID) as Voyage," +
                            " (select top(1) PortName from NVO_PortMaster where ID = POLID) as POL," +
                            " (select top(1) PortName from NVO_PortMaster where ID = FPODID) as FPOD " +
                            " FROM NVO_ImpBL where NVO_ImpBL.Id =" + Data.BLID;
            return GetViewData(_Query, "");
        }


        public List<MyImpBL> ExistingImpBL(MyImpBL Data)
        {
            List<MyImpBL> ListBL = new List<MyImpBL>();
            DataTable dt = GetExistingImpBLView(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBL.Add(new MyImpBL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["BLNumber"].ToString(),
                    BLStatusID = dt.Rows[i]["BLStatusID"].ToString(),
                    OfficeID = dt.Rows[i]["OfficeID"].ToString(),
                    PrincipalID = dt.Rows[i]["PrincipalID"].ToString(),
                    VesselID = dt.Rows[i]["VesselID"].ToString(),
                    VoyageID = dt.Rows[i]["VoyageID"].ToString(),
                    POLAgentID = dt.Rows[i]["POLAgentID"].ToString(),
                    POOID = dt.Rows[i]["POOID"].ToString(),
                    POLID = dt.Rows[i]["POLID"].ToString(),
                    PODID = dt.Rows[i]["PODID"].ToString(),
                    FPODID = dt.Rows[i]["FPODID"].ToString(),
                    ImportTS = dt.Rows[i]["ImpTsID"].ToString(),
                    NexPortTS = dt.Rows[i]["NexPortTS"].ToString(),
                    Shipper = dt.Rows[i]["Shipper"].ToString(),
                    ShipperAddress = dt.Rows[i]["ShipperAddress"].ToString(),
                    ShipperEmail = dt.Rows[i]["ShipperEmail"].ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    ConsigneeAddress = dt.Rows[i]["ConsigneeAddress"].ToString(),
                    ConsigneeEmail = dt.Rows[i]["ConsigneeEmail"].ToString(),
                    Notify = dt.Rows[i]["Notify"].ToString(),
                    NotifyAddress = dt.Rows[i]["NotifyAddress"].ToString(),
                    NotifyEmail = dt.Rows[i]["NotifyEmail"].ToString(),
                    Notify2Address = dt.Rows[i]["Notify2Address"].ToString(),
                    Notify2Email = dt.Rows[i]["Notify2Email"].ToString(),
                    Marks = dt.Rows[i]["Marks"].ToString(),
                    Description = dt.Rows[i]["Description"].ToString(),
                    FreightTermID = dt.Rows[i]["FreightTermID"].ToString(),
                    FreightPaybleAt = dt.Rows[i]["FreightPaybleAt"].ToString(),
                    BLTypeID = dt.Rows[i]["BLTypeID"].ToString(),
                    FreeDays = dt.Rows[i]["FreeDays"].ToString(),
                    SourceID = dt.Rows[i]["SourceID"].ToString(),
                    SalesPersonID = dt.Rows[i]["SalesPersonID"].ToString(),



                });

            }
            return ListBL;
        }


        public DataTable GetExistingImpBLView(MyImpBL Data)
        {
            string _Query = "select * from NVO_ImpBL where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyImpBLCntr> ExistingImpBLCntr(MyImpBLCntr Data)
        {
            List<MyImpBLCntr> ListBL = new List<MyImpBLCntr>();
            DataTable dt = GetExistingImpBLCntrView(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBL.Add(new MyImpBLCntr
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    CntrType = dt.Rows[i]["CntrTypes"].ToString(),
                    CntrTypeID = dt.Rows[i]["CntrType"].ToString(),
                    SealNo = dt.Rows[i]["SealNo"].ToString(),
                    GrossWeight = dt.Rows[i]["KgsWeight"].ToString(),
                    NetWeight = dt.Rows[i]["NetWeight"].ToString(),
                    NoofPakage = dt.Rows[i]["NoofPkgs"].ToString(),
                    Volume = dt.Rows[i]["CBMVolume"].ToString(),
                    HSCCode = dt.Rows[i]["HHSCode"].ToString(),
                    OpertingLine = dt.Rows[i]["OwningLine"].ToString(),
                    OwnerLiner = dt.Rows[i]["OperatingLine"].ToString(),
                    IsFinal = 0
                });

            }
            return ListBL;
        }

        public DataTable GetExistingImpBLCntrView(MyImpBLCntr Data)
        {
            string _Query = " select ID,CntrNo,CntrType, (select top(1) Size from NVO_TblCntrTypes  where ID =CntrType) as CntrTypes,SealNo,KgsWeight,NetWeight,NoofPkgs,CBMVolume,HHSCode,OwningLine,OperatingLine  from NVO_ImpBLContainerDtls where BLID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyImpBL> InsertImpBLContainer(MyImpBL Data)
        {
            List<MyImpBL> ListBLView = new List<MyImpBL>();
            int r1 = 0;
            int r2 = 0;
            DbConnection con = null;
            DbTransaction trans;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {
                    Cmd.CommandText = " UPDATE NVO_ImpBLContainerDtls SET HazarOpt=@HazarOpt,HAZClass=@HAZClass,IMCOCode=@IMCOCode,OOGOpt=@OOGOpt,Lenght=@Lenght,Width=@Width," +
                                      " Height=@Height,RefferOpt=@RefferOpt,Temperature=@Temperature,Humidity=@Humidity,Ventilation=@Ventilation where BLID=@BLID";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@HazarOpt", Data.HazarOpt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@HAZClass", Data.HAZClass));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IMCOCode", Data.IMCOCode));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OOGOpt", Data.OOGOpt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Lenght", Data.Lenght));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Width", Data.Width));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Height", Data.Height));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RefferOpt", Data.RefferOpt));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Temperature", Data.Temperature));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Humidity", Data.Humidity));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Ventilation", Data.Ventilation));
                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    trans.Commit();
                    ListBLView.Add(new MyImpBL
                    {
                        ID = Data.ID,
                        AlertMessage = "Record Updated sucessfully " + Data.BLNumber,
                        BLNumber = Data.BLNumber

                    });
                    return ListBLView;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListBLView.Add(new MyImpBL { AlertMessage = ex.Message });
                    return ListBLView;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }


        public List<MyImpBL> ExistingImpBLCntrValues(MyImpBL Data)
        {
            List<MyImpBL> ListBL = new List<MyImpBL>();
            DataTable dt = GetExistingImpBLCntrvView(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBL.Add(new MyImpBL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLID = dt.Rows[i]["BLID"].ToString(),
                    HazarOpt = dt.Rows[i]["HazarOpt"].ToString(),
                    HAZClass = dt.Rows[i]["HAZClass"].ToString(),
                    IMCOCode = dt.Rows[i]["IMCOCode"].ToString(),
                    Lenght = dt.Rows[i]["Lenght"].ToString(),
                    OOGOpt = dt.Rows[i]["OOGOpt"].ToString(),
                    Width = dt.Rows[i]["Width"].ToString(),
                    Height = dt.Rows[i]["Height"].ToString(),
                    RefferOpt = dt.Rows[i]["RefferOpt"].ToString(),
                    Temperature = dt.Rows[i]["Temperature"].ToString(),
                    Humidity = dt.Rows[i]["Humidity"].ToString(),
                    Ventilation = dt.Rows[i]["Ventilation"].ToString(),

                });

            }
            return ListBL;
        }


        public DataTable GetExistingImpBLCntrvView(MyImpBL Data)
        {
            string _Query = "select * from NVO_ImpBLContainerDtls where ID=" + Data.ID + " and CntrNo='" + Data.CntrNo + "'";
            return GetViewData(_Query, "");
        }


        public List<MyImpBL> ImpHBLInsert(MyImpBL Data)
        {
            List<MyImpBL> ListBL = new List<MyImpBL>();
            DbConnection con = null;
            DbTransaction trans;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    Cmd.CommandText = " IF((select count(*) from NVO_ImpHBL where BLID=@BLID and ID=@ID)<=0) " +
                                       " BEGIN " +
                                       " INSERT INTO  NVO_ImpHBL(BLID,HBLNumber,Shipper,ShipperAddress,ShipperEmail,Consignee,ConsigneeAddress,ConsigneeEmail,Notify,NotifyAddress,NotifyEmail,Notify2,Notify2Address,Notify2Email,Marks,Description) " +
                                       " values (@BLID,@HBLNumber,@Shipper,@ShipperAddress,@ShipperEmail,@Consignee,@ConsigneeAddress,@ConsigneeEmail,@Notify,@NotifyAddress,@NotifyEmail,@Notify2,@Notify2Address,@Notify2Email,@Marks,@Description) " +
                                       " END  " +
                                       " ELSE " +
                                       " UPDATE NVO_ImpHBL SET BLID=@BLID,HBLNumber=@HBLNumber,Shipper=@Shipper,ShipperAddress=@ShipperAddress,ShipperEmail=@ShipperEmail,Consignee=@Consignee,ConsigneeAddress=@ConsigneeAddress,ConsigneeEmail=@ConsigneeEmail," +
                                       " Notify=@Notify,NotifyAddress=@NotifyAddress,NotifyEmail=@NotifyEmail,Notify2=@Notify2,Notify2Address=@Notify2Address,Notify2Email=@Notify2Email,Marks=@Marks,Description=@Description where BLID=@BLID and ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@HBLNumber", Data.BLNumber));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Shipper", Data.Shipper));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperAddress", Data.ShipperAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ShipperEmail", Data.ShipperEmail));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Consignee", Data.Consignee));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeAddress", Data.ConsigneeAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ConsigneeEmail", Data.ConsigneeEmail));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify", Data.Notify));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyAddress", Data.NotifyAddress));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@NotifyEmail", Data.NotifyEmail));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify2", Data.Notify2));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify2Address", Data.Notify2Address));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Notify2Email", Data.Notify2Email));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Marks", Data.Marks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Description", Data.Description));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDate", System.DateTime.Now));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_ImpHBL')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    }




                    string[] Array1 = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_ImpHBLContainerDtls where CntrID=@CntrID and BLID=@BLID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_ImpHBLContainerDtls(BLID,HBLID,CntrID) " +
                                     " values (@BLID,@HBLID,@CntrID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_ImpHBLContainerDtls SET BLID=@BLID,HBLID=@HBLID,CntrID=@CntrID where CntrID=@CntrID and BLID=@BLID";

                        Cmd.Parameters.Add(_dbFactory.GetParameter("@BLID", Data.BLID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@HBLID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrID", CharSplit[0]));
                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();
                    }


                    trans.Commit();
                    ListBL.Add(new MyImpBL
                    {
                        AlertMessage = "Record Saved Successfully"
                    }); ;
                    return ListBL;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListBL.Add(new MyImpBL
                    {
                        AlertMessage = ex.Message
                    }); ;
                    return ListBL;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }


        public List<MyImpBL> ImpHBLValues(MyImpBL Data)
        {
            List<MyImpBL> ListBL = new List<MyImpBL>();
            DataTable dt = GeImpHBLNo(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBL.Add(new MyImpBL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["HBLNumber"].ToString(),


                });

            }
            return ListBL;
        }


        public DataTable GeImpHBLNo(MyImpBL Data)
        {
            string _Query = " select ID,HBLNumber from  NVO_ImpHBL where BLID= " + Data.BLID;
            return GetViewData(_Query, "");
        }


        public List<MyImpBL> ExistingImpHBL(MyImpBL Data)
        {
            List<MyImpBL> ListBL = new List<MyImpBL>();
            DataTable dt = GetExistingImpHBLView(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBL.Add(new MyImpBL
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    BLNumber = dt.Rows[i]["HBLNumber"].ToString(),

                    Shipper = dt.Rows[i]["Shipper"].ToString(),
                    ShipperAddress = dt.Rows[i]["ShipperAddress"].ToString(),
                    ShipperEmail = dt.Rows[i]["ShipperEmail"].ToString(),
                    Consignee = dt.Rows[i]["Consignee"].ToString(),
                    ConsigneeAddress = dt.Rows[i]["ConsigneeAddress"].ToString(),
                    ConsigneeEmail = dt.Rows[i]["ConsigneeEmail"].ToString(),
                    Notify = dt.Rows[i]["Notify"].ToString(),
                    NotifyAddress = dt.Rows[i]["NotifyAddress"].ToString(),
                    NotifyEmail = dt.Rows[i]["NotifyEmail"].ToString(),
                    Notify2Address = dt.Rows[i]["Notify2Address"].ToString(),
                    Notify2Email = dt.Rows[i]["Notify2Email"].ToString(),
                    Marks = dt.Rows[i]["Marks"].ToString(),
                    Description = dt.Rows[i]["Description"].ToString(),
                });

            }
            return ListBL;
        }

        public DataTable GetExistingImpHBLView(MyImpBL Data)
        {
            string _Query = "select * from NVO_ImpHBL where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }


        public List<MyImpBLCntr> ExistingImpHBLCntr(MyImpBLCntr Data)
        {
            List<MyImpBLCntr> ListBL = new List<MyImpBLCntr>();
            DataTable dt = GetExistingImpHBLCntrView(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBL.Add(new MyImpBLCntr
                {
                    CID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    CntrType = dt.Rows[i]["CntrTypes"].ToString(),
                    SealNo = dt.Rows[i]["SealNo"].ToString(),
                    GrossWeight = dt.Rows[i]["KgsWeight"].ToString(),
                    NetWeight = dt.Rows[i]["NetWeight"].ToString(),
                    NoofPakage = dt.Rows[i]["NoofPkgs"].ToString(),
                    Volume = dt.Rows[i]["CBMVolume"].ToString(),
                    HSCCode = dt.Rows[i]["HHSCode"].ToString(),
                    OpertingLine = dt.Rows[i]["OwningLine"].ToString(),
                    OwnerLiner = dt.Rows[i]["OperatingLine"].ToString(),
                    IsFinal = Int32.Parse(dt.Rows[i]["IsFinal"].ToString()),

                });

            }
            return ListBL;
        }

        public DataTable GetExistingImpHBLCntrView(MyImpBLCntr Data)
        {
            //string _Query = " select ID,CntrNo,CntrType, (select top(1) Size from NVO_TblCntrTypes  where ID =CntrType) as CntrTypes,SealNo,KgsWeight,NetWeight,NoofPkgs,CBMVolume,HHSCode,OwningLine,OperatingLine, " +
            //                " isnull((select case when isnull(CntrID,0)= 0 then 0 else 1 end from NVO_ImpHBLContainerDtls where  NVO_ImpHBLContainerDtls.CntrID=Imp.ID  and NVO_ImpHBLContainerDtls.BLID= Imp.BLID and NVO_ImpHBLContainerDtls.HBLID=" + Data.ID + " ),0) as IsFinal " +
            //                " from NVO_ImpBLContainerDtls Imp where BLID=" + Data.BLID;

            string _Query = " select ID,CntrNo,CntrType, (select top(1) Size from NVO_TblCntrTypes  where ID =CntrType) as CntrTypes,SealNo," +
                            " KgsWeight,NetWeight,NoofPkgs,CBMVolume,HHSCode,OwningLine,OperatingLine,'0' as IsFinal from NVO_ImpBLContainerDtls Imp " +
                            " where BLID= " + Data.BLID + "  and ID  not in (select CntrID from NVO_ImpHBLContainerDtls where BLID = " + Data.BLID + ") " +
                            " union " +
                            " select Imp.ID,CntrNo,CntrType, (select top(1) Size from NVO_TblCntrTypes  where ID =CntrType) as CntrTypes,SealNo," +
                            " KgsWeight,NetWeight,NoofPkgs,CBMVolume,HHSCode,OwningLine,OperatingLine,'1' as IsFinal from NVO_ImpBLContainerDtls Imp " +
                            " inner join NVO_ImpHBLContainerDtls on NVO_ImpHBLContainerDtls.BLID=Imp.BLID and NVO_ImpHBLContainerDtls.CntrID=Imp.ID where  HBLID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyImpBLCntr> ExistingImpHBLCheckCntr(MyImpBLCntr Data)
        {
            List<MyImpBLCntr> ListBL = new List<MyImpBLCntr>();
            DataTable dt = GetExistingImpHBLCntrCheckView(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBL.Add(new MyImpBLCntr
                {
                    CID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    CntrType = dt.Rows[i]["CntrTypes"].ToString(),
                    SealNo = dt.Rows[i]["SealNo"].ToString(),
                    GrossWeight = dt.Rows[i]["KgsWeight"].ToString(),
                    NetWeight = dt.Rows[i]["NetWeight"].ToString(),
                    NoofPakage = dt.Rows[i]["NoofPkgs"].ToString(),
                    Volume = dt.Rows[i]["CBMVolume"].ToString(),
                    HSCCode = dt.Rows[i]["HHSCode"].ToString(),
                    OpertingLine = dt.Rows[i]["OwningLine"].ToString(),
                    OwnerLiner = dt.Rows[i]["OperatingLine"].ToString(),
                    IsFinal = Int32.Parse(dt.Rows[i]["IsFinal"].ToString()),

                });

            }
            return ListBL;
        }

        public DataTable GetExistingImpHBLCntrCheckView(MyImpBLCntr Data)
        {
            string _Query = " select ID,CntrNo,CntrType, (select top(1) Size from NVO_TblCntrTypes  where ID =CntrType) as CntrTypes,SealNo,KgsWeight,NetWeight,NoofPkgs,CBMVolume,HHSCode,OwningLine,OperatingLine,'0' as IsFinal " +
                            " from NVO_ImpBLContainerDtls Imp where BLID=" + Data.BLID + " and ID  not in (select CntrID from NVO_ImpHBLContainerDtls where BLID = " + Data.BLID + ")";
            return GetViewData(_Query, "");
        }

        public List<MyImpBLCntr> ImpEnquiryNo(MyImpBLCntr Data)
        {
            List<MyImpBLCntr> ListBL = new List<MyImpBLCntr>();
            DataTable dt = GetImpEnquiryNo(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListBL.Add(new MyImpBLCntr
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    EnquiryNo = dt.Rows[i]["EnquiryNo"].ToString(),


                });

            }
            return ListBL;
        }

        public DataTable GetImpEnquiryNo(MyImpBLCntr Data)
        {
            string _Query = "select ID,EnquiryNo,* from NVO_Enquiry where  EnquiryStatusID= 2";
            return GetViewData(_Query, "");
        }
        public DataTable GetViewData(string Query, string CmdType)
        {
            DbConnection con = null;
            DataTable DT = null;
            try
            {
                if (Query != "")
                {
                    con = _dbFactory.GetConnection();
                    con.Open();

                    DbCommand cmd = _dbFactory.GetCommand();
                    cmd.Connection = con;

                    if (CmdType == "SP")
                        cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = Query;
                    DbDataAdapter adapter = _dbFactory.GetAdapter();
                    adapter.SelectCommand = cmd;
                    DT = new DataTable();
                    adapter.Fill(DT);
                }
                return DT;

            }


            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }
        #endregion

    }
}
