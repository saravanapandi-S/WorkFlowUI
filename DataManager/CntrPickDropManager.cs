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



namespace DataManager
{
    public class CntrPickDropManager
    {
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion

        #region Constructor Method
        public CntrPickDropManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region  CNTRPICKDROP

        List<MyCntrPickDrop> ListCntrPickDrop = new List<MyCntrPickDrop>();
        public List<MyCntrPickDrop> BindPickUpDropTypesList(MyCntrPickDrop Data)
        {
            DataTable dt = GetBindPickUpDropTypesList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrPickDrop.Add(new MyCntrPickDrop
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListCntrPickDrop;
        }

        public DataTable GetBindPickUpDropTypesList(MyCntrPickDrop Data)
        {

            string _Query = "select *  from NVO_Generalmaster where Status=1 and Seqno=80 order by ID ";
            return GetViewData(_Query, "");


        }
        public List<MyCntrPickDrop> BindPickUpDropTypesDropList(MyCntrPickDrop Data)
        {
            DataTable dt = GetBindPickUpDropTypesDropList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrPickDrop.Add(new MyCntrPickDrop
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListCntrPickDrop;
        }

        public DataTable GetBindPickUpDropTypesDropList(MyCntrPickDrop Data)
        {
            string _Query = "select *  from NVO_Generalmaster where Status=1 and Seqno=81 order by ID ";
            return GetViewData(_Query, "");


        }
        public List<MyCntrPickDrop> BindStorageLocationList(MyCntrPickDrop Data)
        {
            DataTable dt = GetBindStorageLocationList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrPickDrop.Add(new MyCntrPickDrop
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["StorageLoc"].ToString()
                });
            }
            return ListCntrPickDrop;
        }

        public DataTable GetBindStorageLocationList(MyCntrPickDrop Data)
        {
            string _Query = "select *  from NVO_StorageLocationMaster where StatusID=1 and officeID= " + Data.OfficeLocationID;
            return GetViewData(_Query, "");
        }

        public List<MyCntrPickDrop> BindCntrTypesList(MyCntrPickDrop Data)
        {
            DataTable dt = GetBindCntrTypesList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrPickDrop.Add(new MyCntrPickDrop
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrType = dt.Rows[i]["Size"].ToString()
                });
            }
            return ListCntrPickDrop;
        }

        public DataTable GetBindCntrTypesList(MyCntrPickDrop Data)
        {
            string _Query = "select * from NVO_tblCntrTypes ";
            return GetViewData(_Query, "");
        }

        public List<MyCntrPickDrop> BindOwningTypesList(MyCntrPickDrop Data)
        {
            DataTable dt = GetBindOwningTypesList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrPickDrop.Add(new MyCntrPickDrop
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    GeneralName = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListCntrPickDrop;
        }

        public DataTable GetBindOwningTypesList(MyCntrPickDrop Data)
        {
            string _Query = "select *  from NVO_Generalmaster where Status=1 and Seqno=69 order by ID ";
            return GetViewData(_Query, "");
        }

        public List<MyCntrPickDrop> BindCntrNosList(MyCntrPickDrop Data)
        {
            DataTable dt = GetBindCntrNosList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrPickDrop.Add(new MyCntrPickDrop
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString()
                });
            }
            return ListCntrPickDrop;
        }

        public DataTable GetBindCntrNosList(MyCntrPickDrop Data)
        {
            string _Query = " SELECT * FROM NVO_Containers WHERE ISPICKUP=1 ";
            return GetViewData(_Query, "");
        }


        public List<MyCntrPickDrop> BindISOCodesByTypeList(MyCntrPickDrop Data)
        {
            DataTable dt = GetBindISOCodesByTypeList(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrPickDrop.Add(new MyCntrPickDrop
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString()
                });
            }
            return ListCntrPickDrop;
        }

        public DataTable GetBindISOCodesByTypeList(MyCntrPickDrop Data)
        {
            string _Query = "select * from NVO_tblCntrTypes where ID=" + Data.CntrTypeID;
            return GetViewData(_Query, "");
        }

        public List<MyCntrPickDrop> InsertCntrPickDropSave(MyCntrPickDrop Data)
        {


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

                    var Validation = "";
                    var ValidationTest = "";
                    if (Data.TransactionStatus == 1)
                    {
                        string[] Array = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " select top(1) NVO_Containers.ID from NVO_Containers where CntrNo='" + CharSplit[1] + "' and ISPickUp=1 ";
                            int CntrID = 0;
                            CntrID = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (CntrID != 0)
                            {
                                Validation += "Container Already Picked:" + CharSplit[1];
                                ValidationTest += " Container Already Picked:" + CharSplit[1];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation,
                                    AlertMegId = "4",
                                });
                                return ListCntrPickDrop;
                            }
                        }

                    }
                    var SeqID = 0;
                    if (Data.ID == 0)
                    {
                        SeqID = 1;
                        if (Data.TransactionStatus == 1)
                        {
                            string AutoGen = GetMaxseqNumber("CntrPick", "1", Data.SessionFinYear);
                            Cmd.CommandText = "select 'PICK'  + (select LocationCode from NVO_OfficeMaster where ID = " + Data.OfficeLocationID + ") + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                            Data.Reference = Cmd.ExecuteScalar().ToString();
                        }
                        if (Data.TransactionStatus == 2)
                        {
                            string AutoGen = GetMaxseqNumber("CntrDrop", "1", Data.SessionFinYear);
                            Cmd.CommandText = "select 'DROP' + (select LocationCode from NVO_OfficeMaster where ID = " + Data.OfficeLocationID + ")  + ('" + Data.SessionFinYear.Substring(Data.SessionFinYear.Length - 2) + "') + RIGHT('0' + RTRIM(MONTH(getdate())), 2) + right('0000' + convert(varchar(4)," + AutoGen + "), 4)";
                            Data.Reference = Cmd.ExecuteScalar().ToString();
                        }
                    }


                    Cmd.CommandText = " IF((select count(*) from NVO_CntrPickDrop where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_CntrPickDrop(Reference,TransactionStatus,RefDate,OfficeLocationID,PickDropTypeID,PickDropLocID,OwnPrincipleID,OprPrincipleID,PrincipleAgent,Remarks,AttachFile,UserID,CreatedOn,OwnCustomerID) " +
                                     " values (@Reference,@TransactionStatus,@RefDate,@OfficeLocationID,@PickDropTypeID,@PickDropLocID,@OwnPrincipleID,@OprPrincipleID,@PrincipleAgent,@Remarks,@AttachFile,@UserID,@CreatedOn,@OwnCustomerID) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_CntrPickDrop SET Reference=@Reference,TransactionStatus=@TransactionStatus,RefDate=@RefDate,OfficeLocationID=@OfficeLocationID,PickDropTypeID=@PickDropTypeID,PickDropLocID=@PickDropLocID,OwnPrincipleID=@OwnPrincipleID,OprPrincipleID=@OprPrincipleID,PrincipleAgent=@PrincipleAgent,Remarks=@Remarks,AttachFile=@AttachFile,UserID=@UserID,CreatedOn=@CreatedOn,OwnCustomerID=@OwnCustomerID where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Reference", Data.Reference));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TransactionStatus", Data.TransactionStatus));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@RefDate", Data.RefDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeLocationID", Data.OfficeLocationID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickDropTypeID", Data.PickDropTypeID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PickDropLocID", Data.PickDropLocID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OwnPrincipleID", Data.OwnPrincipleID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OprPrincipleID", Data.OprPrincipleID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PrincipleAgent", Data.PrincipleAgent));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@Remarks", Data.Remarks));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@AttachFile", Data.AttachFile));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@OwnCustomerID", Data.OwnCustomerID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedOn", System.DateTime.Now));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();
                    Cmd.CommandText = "select ident_current('NVO_CntrPickDrop')";
                    if (Data.CntrID == 0)
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());
                    else
                        Data.ID = Data.ID;


                    if (Data.Items != null)
                    {
                        string[] ArrayAt = Data.Items.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < ArrayAt.Length; i++)
                        {
                            var CharSplit = ArrayAt[i].ToString().TrimEnd(',').Split(',');
                            Cmd.CommandText = " IF((select count(*) from NVO_CntrPickDropCntrs where RefID=@RefID and CID=@CID)<=0) " +
                             " BEGIN " +
                             " INSERT INTO  NVO_CntrPickDropCntrs(RefID,CntrNo,CntrTypeID,CntrType,ISOCodeID,ISOCode,OwningTypeID,OwningType,TransactionStatus) " +
                             " values(@RefID,@CntrNo,@CntrTypeID,@CntrType,@ISOCodeID,@ISOCode,@OwningTypeID,@OwningType,@TransactionStatus)  " +
                             " END  " +
                             " ELSE " +
                             " UPDATE NVO_CntrPickDropCntrs SET RefID=@RefID,CntrNo=@CntrNo,CntrTypeID=@CntrTypeID,CntrType=@CntrType,ISOCodeID=@ISOCodeID,ISOCode=@ISOCode,OwningTypeID=@OwningTypeID,OwningType=@OwningType,TransactionStatus=@TransactionStatus where RefID=@RefID and CID=@CID ";

                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@RefID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrNo", CharSplit[1].ToUpper()));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrtypeID", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Cntrtype", CharSplit[3]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCodeID", CharSplit[4]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCode", CharSplit[5]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@OwningTypeID", CharSplit[6]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@OwningType", CharSplit[7]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@TransactionStatus", Data.TransactionStatus));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                            var CntrNos = 0;
                            Cmd.CommandText = "select ID from NVO_Containers where CntrNo=@CntrNo ";
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@CntrNo", CharSplit[1].ToUpper()));

                            if (CntrNos != 0)
                            {
                                CntrNos = Int32.Parse(Cmd.ExecuteScalar().ToString());
                            }

                            else
                            {
                                CntrNos = 0;
                            }
                            if (CntrNos == 0)
                            {

                                Cmd.CommandText = " INSERT INTO  NVO_Containers(CntrNo,TypeID,Statuscode,ISOCodeID,CurrentPortID,PickUpLocID,PickUpDate,PickUpRefID,PickUpRef,IsPickUp,UserID,StatusCodeID,OwnLineID,OperatingLineID,OwningTypeID,CurrentOfficeLocID,CurrentDtMovement) " +
                           " values(@CntrNo,@TypeID,@Statuscode,@ISOCodeID,@CurrentPortID,@PickUpLocID,@PickUpDate,@PickUpRefID,@PickUpRef,@IsPickUp,@UserID,@StatusCodeID,@OwnLineID,@OperatingLineID,@OwningTypeID,@CurrentOfficeLocID,@CurrentDtMovement) ";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpRefID", Data.ID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpDate", Data.RefDate));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@TypeID", CharSplit[2]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ISOCodeID", CharSplit[4]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCodeID", 25));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "PICKED UP"));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.PickDropLocID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpLocID", Data.PickDropLocID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpRef", Data.Reference));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@OwnLineID", Data.OwnPrincipleID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@OperatingLineID", Data.OprPrincipleID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@OwningTypeID", CharSplit[6]));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentOfficeLocID", Data.OfficeLocationID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDtMovement", Data.RefDate));
                                if (Data.TransactionStatus == 1)
                                {
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsPickUp", 1));
                                }
                                else
                                {
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsPickUp", 1));
                                }
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();

                                Cmd.CommandText = "SELECT Ident_current('NVO_Containers')";
                                Data.CntrID = Int32.Parse(Cmd.ExecuteScalar().ToString());

                                Cmd.CommandText = " INSERT INTO  NVO_Containertxns(ContainerID,LocationID,Statuscode,DtMovement,UserID,ReferenceID,StatusCodeID,OfficeLocationID) " +
                          " values (@ContainerID,@LocationID,@Statuscode,@DtMovement,@UserID,@ReferenceID,@StatusCodeID,@OfficeLocationID) ";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", Data.CntrID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCodeID", 25));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@StatusCode", "PICKED UP"));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.PickDropLocID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", Data.RefDate));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ReferenceID", Data.ID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeLocationID", Data.OfficeLocationID));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();

                                Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                                var LastMovementID = Int32.Parse(Cmd.ExecuteScalar().ToString());

                                Cmd.CommandText = "UPDATE NVO_Containers SET LastmovementID=@LastmovementID where ID=@ID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.CntrID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", LastMovementID));


                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();
                            }

                            else
                            {


                                Cmd.CommandText = " Update NVO_Containers set CurrentPortID=@CurrentPortID,DropOffRefID=@DropOffRefID,DropOffRef=@DropOffRef,DropOffDate=@DropOffDate,DropOffLocID=@DropOffLocID,IsPickUp=@IsPickUp,Statuscode=@Statuscode,StatuscodeID=@StatuscodeID,CurrentDtMovement=@CurrentDtMovement,CurrentOfficeLocID=@CurrentOfficeLocID WHERE ID=@ID ";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", CntrNos));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentPortID", Data.PickDropLocID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffRefID", Data.ID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffRef", Data.Reference));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffDate", Data.RefDate));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DropOffLocID", Data.PickDropLocID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Statuscode", "DROPPED"));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@StatuscodeID", 8));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@PickUpLocID", Data.PickDropLocID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentOfficeLocID", Data.OfficeLocationID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@CurrentDtMovement", Data.RefDate));
                                if (Data.TransactionStatus == 1)
                                {
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsPickUp", 1));
                                }
                                else
                                {
                                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IsPickUp", 0));
                                }
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();

                                Cmd.CommandText = " INSERT INTO  NVO_Containertxns(ContainerID,LocationID,Statuscode,DtMovement,UserID,StatuscodeID,ReferenceID,OfficeLocationID) " +
                        " values (@ContainerID,@LocationID,@Statuscode,@DtMovement,@UserID,@StatuscodeID,@ReferenceID,@OfficeLocationID) ";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ContainerID", CntrNos));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", Data.UserID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@Statuscode", "DROPPED"));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@StatuscodeID", 8));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@LocationID", Data.PickDropLocID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@DtMovement", Data.RefDate));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ReferenceID", Data.ID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@OfficeLocationID", Data.OfficeLocationID));
                                result = Cmd.ExecuteNonQuery();
                                Cmd.Parameters.Clear();

                                Cmd.CommandText = "select Ident_current('NVO_ContainerTxns')";
                                var LastMovementID = Int32.Parse(Cmd.ExecuteScalar().ToString());

                                Cmd.CommandText = "UPDATE NVO_Containers SET LastmovementID=@LastmovementID where ID=@ID";
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.CntrID));
                                Cmd.Parameters.Add(_dbFactory.GetParameter("@LastmovementID", LastMovementID));
                            }
                        }
                    }

                    Cmd.CommandText = "INSERT INTO  NVO_LogDetails(PageName,CreatedOn,CreatedBy,SeqNo,LogInID,TextValues) " +
                           " values (@PageName,@CreatedOn,@CreatedBy,@SeqNo,@LogInID,@TextValues)";
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PageName", "PICKUPDROP"));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedBy", Data.UserID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@CreatedOn", (DateTime.Parse(System.DateTime.Now.Date.ToString()))));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@SeqNo", SeqID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@LogInID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@TextValues", ""));
                    result = Cmd.ExecuteNonQuery();

                    trans.Commit();

                    ListCntrPickDrop.Add(new MyCntrPickDrop
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    });
                    return ListCntrPickDrop;

                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCntrPickDrop.Add(new MyCntrPickDrop
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListCntrPickDrop;
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
        public List<MyCntrPickDrop> BindCntrPickDropListView(MyCntrPickDrop Data)
        {
            DataTable dt = GetBindCntrPickDropListView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrPickDrop.Add(new MyCntrPickDrop
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Reference = dt.Rows[i]["Reference"].ToString(),
                    RefDate = dt.Rows[i]["RefDate"].ToString(),
                    TranStatus = dt.Rows[i]["TranStatus"].ToString(),
                    PickDropType = dt.Rows[i]["PickDropType"].ToString(),
                    OwnPrinciple = dt.Rows[i]["OwnPrinciple"].ToString(),
                    Loc = dt.Rows[i]["Loc"].ToString(),
                    T20Count = dt.Rows[i]["T20Count"].ToString(),
                    T40Count = dt.Rows[i]["T40Count"].ToString(),
                    TotalCount = dt.Rows[i]["TotalCount"].ToString(),
                });
            }
            return ListCntrPickDrop;
        }


        public DataTable GetBindCntrPickDropListView(MyCntrPickDrop Data)
        {
            string strWhere = "";

            string _Query = "Select * from ViewCntrPickDrop ";

            if (Data.Reference != "" && Data.Reference != null)
                if (strWhere == "")
                    strWhere += _Query + " where Reference like '%" + Data.Reference.ToString().Trim() + "%'";
                else
                    strWhere += " and Reference like '%" + Data.Reference.ToString().Trim() + "%'";

            if (Data.OfficeLocationID.ToString() != "" && Data.OfficeLocationID.ToString() != null && Data.OfficeLocationID.ToString() != "0" && Data.OfficeLocationID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where OfficeLocationID =" + Data.OfficeLocationID.ToString() + "";
                else
                    strWhere += " and OfficeLocationID =" + Data.OfficeLocationID.ToString() + "";

            if (Data.PickDropTypeID.ToString() != "" && Data.PickDropTypeID.ToString() != null && Data.PickDropTypeID.ToString() != "0" && Data.PickDropTypeID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where PickDropTypeID =" + Data.PickDropTypeID.ToString() + "";
                else
                    strWhere += " and PickDropTypeID =" + Data.PickDropTypeID.ToString() + "";

            if (Data.PickDropLocID.ToString() != "" && Data.PickDropLocID.ToString() != null && Data.PickDropLocID.ToString() != "0" && Data.PickDropLocID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where PickDropLocID =" + Data.PickDropLocID.ToString() + "";
                else
                    strWhere += " and PickDropLocID =" + Data.PickDropLocID.ToString() + "";

            if (Data.OwnPrincipleID.ToString() != "" && Data.OwnPrincipleID.ToString() != null && Data.OwnPrincipleID.ToString() != "0" && Data.OwnPrincipleID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where OwnPrincipleID =" + Data.OwnPrincipleID.ToString() + "";
                else
                    strWhere += " and OwnPrincipleID =" + Data.OwnPrincipleID.ToString() + "";

            if (Data.ReferenceFrom != "" && Data.ReferenceFrom != null)
                if (strWhere == "")
                    strWhere += _Query + " where RefDatev >= '" + DateTime.Parse(Data.ReferenceFrom).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and RefDatev >= '" + DateTime.Parse(Data.ReferenceFrom).ToString("MM/dd/yyyy") + "'";

            if (Data.ReferenceTill != "" && Data.ReferenceTill != null)
                if (strWhere == "")
                    strWhere += _Query + " where RefDatev <= '" + DateTime.Parse(Data.ReferenceTill).ToString("MM/dd/yyyy") + "'";
                else
                    strWhere += " and RefDatev <= '" + DateTime.Parse(Data.ReferenceTill).ToString("MM/dd/yyyy") + "'";

            if (Data.TransactionStatus.ToString() != "" && Data.TransactionStatus.ToString() != null && Data.TransactionStatus.ToString() != "0" && Data.TransactionStatus.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where TransactionStatus =" + Data.TransactionStatus.ToString() + "";
                else
                    strWhere += " and TransactionStatus =" + Data.TransactionStatus.ToString() + "";



            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere + " ORDER BY ID DESC ", "");

        }

        public List<MyCntrPickDrop> BindCntrPickDropListEdit(MyCntrPickDrop Data)
        {
            DataTable dt = GetBindCntrPickDropListEdit(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrPickDrop.Add(new MyCntrPickDrop
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Reference = dt.Rows[i]["Reference"].ToString(),
                    RefDate = dt.Rows[i]["RefDateV"].ToString(),
                    PickDropTypeID = Int32.Parse(dt.Rows[i]["PickDropTypeID"].ToString()),
                    PickDropLocID = Int32.Parse(dt.Rows[i]["PickDropLocID"].ToString()),
                    OwnCustomerID = Int32.Parse(dt.Rows[i]["OwnCustomerID"].ToString()),
                    OprPrincipleID = Int32.Parse(dt.Rows[i]["OprPrincipleID"].ToString()),
                    OfficeLocationID = Int32.Parse(dt.Rows[i]["OfficeLocationID"].ToString()),
                    OwnPrincipleID = Int32.Parse(dt.Rows[i]["OwnPrincipleID"].ToString()),
                    TransactionStatus = Int32.Parse(dt.Rows[i]["TransactionStatus"].ToString()),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                    PrincipleAgent = dt.Rows[i]["PrincipleAgent"].ToString(),
                });
            }
            return ListCntrPickDrop;
        }

        public DataTable GetBindCntrPickDropListEdit(MyCntrPickDrop Data)
        {
            string _Query = "select convert(varchar, RefDate, 23) as RefDateV,* from NVO_CntrPickDrop where ID=" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyCntrPickDrop> BindCntrPickDropCntrsEdit(MyCntrPickDrop Data)
        {
            DataTable dt = GetBindCntrPickDropCntrsEdit(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrPickDrop.Add(new MyCntrPickDrop
                {
                    CID = Int32.Parse(dt.Rows[i]["CID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    CntrType = dt.Rows[i]["CntrType"].ToString(),
                    CntrTypeID = Int32.Parse(dt.Rows[i]["CntrTypeID"].ToString()),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString(),
                    ISOCodeID = Int32.Parse(dt.Rows[i]["ISOCodeID"].ToString()),
                    OwningTypeID = Int32.Parse(dt.Rows[i]["OwningTypeID"].ToString()),
                    OwningType = dt.Rows[i]["OwningType"].ToString(),

                });
            }
            return ListCntrPickDrop;
        }

        public DataTable GetBindCntrPickDropCntrsEdit(MyCntrPickDrop Data)
        {
            string _Query = "SELECT * FROM NVO_CntrPickDropCntrs where RefID =" + Data.ID;
            return GetViewData(_Query, "");
        }

        public List<MyCntrPickDrop> OfficeLocByUserMaster(MyCntrPickDrop Data)
        {

            DataTable dt = GetOfficeLocByUserMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrPickDrop.Add(new MyCntrPickDrop
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CustomerName = dt.Rows[i]["OfficeLoc"].ToString().ToUpper()
                });
            }
            return ListCntrPickDrop;
        }

        public DataTable GetOfficeLocByUserMaster(MyCntrPickDrop Data)
        {
            string _Query = " select DISTINCT OM.ID,OM.OfficeLoc from NVO_UserDetails UD " +
                             " INNER JOIN NVO_UserOfficeLocs UL ON UL.UserID = UD.ID " +
                             " INNER JOIN NVO_OfficeMaster OM ON OM.ID = UL.OfficeLocID WHERE UD.ID=" + Data.UserID;
            return GetViewData(_Query, "");
        }


        public List<MyCntrPickDrop> InsertExcelContainersSave(MyCntrPickDrop Data)
        {


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
                    if (Data.ItemsCntr != null)
                    {
                        var Validation = "";
                        var ValidationTest = "";

                        string[] Arraycntr = Data.ItemsCntr1.ToString().TrimEnd(',').Split(',');

                        for (int i = 0; i < Arraycntr.Length; i++)
                        {

                            for (int j = i + 1; j < Arraycntr.Length; j++)
                            {


                                if (Arraycntr[i] == Arraycntr[j])
                                {

                                    Validation += "Duplicate Container";
                                    ListCntrPickDrop.Add(new MyCntrPickDrop
                                    {
                                        // ID = Data.ID,
                                        AlertMessage = Arraycntr[i] + "-" + Validation
                                    });
                                    return ListCntrPickDrop;
                                }
                            }
                        }


                        string[] Array = Data.ItemsCntr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array.Length; i++)
                        {
                            var CharSplit = Array[i].ToString().TrimEnd(',').Split(',');


                            if (CharSplit[0].Length != 11)
                            {
                                Validation += "Container No must be in 11 Digits:" + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;
                            }


                            Cmd.CommandText = " select top(1) NVO_Containers.ID from NVO_Containers where CntrNo='" + CharSplit[0] + "' and ISPickUp=1 ";
                            int CntrID = 0;
                            CntrID = Convert.ToInt32(Cmd.ExecuteScalar());
                            if (CntrID != 0)
                            {
                                Validation += "Container Already Picked:" + CharSplit[0];
                                ValidationTest += " Container Already Picked:" + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;
                            }

                            if (CharSplit[1] != "20GP" && CharSplit[1] != "40GP" && CharSplit[1] != "40HC" && CharSplit[1] != "20FR" &&
                                 CharSplit[1] != "40FR" && CharSplit[1] != "20OT" && CharSplit[1] != "40OT" && CharSplit[1] != "20RF" &&
                                  CharSplit[1] != "40RF" && CharSplit[1] != "20HC" && CharSplit[1] != "20TK" && CharSplit[1] != "40TK")
                            {
                                Validation += "Container Type Not Exist for : " + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;

                            }
                            if (CharSplit[1] == "20GP" && CharSplit[2] != "22G1")
                            {
                                Validation += "ISO Code Not Matching for : " + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;
                            }
                            if (CharSplit[1] == "40GP" && CharSplit[2] != "42G1")
                            {
                                Validation += "ISO Code Not Matching for : " + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;
                            }
                            if (CharSplit[1] == "40HC" && CharSplit[2] != "45G1")
                            {
                                Validation += "ISO Code Not Matching for : " + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;
                            }
                            if (CharSplit[1] == "20FR" && CharSplit[2] != "22P3")
                            {
                                Validation += "ISO Code Not Matching for : " + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;
                            }
                            if (CharSplit[1] == "40FR" && CharSplit[2] != "42P3")
                            {
                                Validation += "ISO Code Not Matching for : " + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;
                            }
                            if (CharSplit[1] == "20OT" && CharSplit[2] != "22U1")
                            {
                                Validation += "ISO Code Not Matching for : " + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;
                            }
                            if (CharSplit[1] == "40OT" && CharSplit[2] != "42U1")
                            {
                                Validation += "ISO Code Not Matching for : " + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;
                            }
                            if (CharSplit[1] == "20RF" && CharSplit[2] != "22R1")
                            {
                                Validation += "ISO Code Not Matching for : " + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;
                            }
                            if (CharSplit[1] == "40RF" && CharSplit[2] != "42R1")
                            {
                                Validation += "ISO Code Not Matching for : " + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;
                            }
                            if (CharSplit[1] == "20HC" && CharSplit[2] != "25G0")
                            {
                                Validation += "ISO Code Not Matching for : " + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;
                            }
                            if (CharSplit[1] == "20TK" && CharSplit[2] != "20T7")
                            {
                                Validation += "ISO Code Not Matching for : " + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;
                            }
                            if (CharSplit[1] == "40TK" && CharSplit[2] != "42T2")
                            {
                                Validation += "ISO Code Not Matching for : " + CharSplit[0];
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    ID = Data.ID,
                                    AlertMessage = Validation
                                });
                                return ListCntrPickDrop;
                            }
                        }
                        //else
                        //{
                        string[] Arraysave = Data.ItemsCntr.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Arraysave.Length; i++)
                        {
                            var CharSplitsave = Arraysave[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = "select top(1) ID from NVO_tblCntrTypes where NVO_tblCntrTypes.Size='" + CharSplitsave[1] + "'";
                            int TypeID = 0;
                            TypeID = Convert.ToInt32(Cmd.ExecuteScalar());

                            Cmd.CommandText = "select top(1) Size from NVO_tblCntrTypes where NVO_tblCntrTypes.Size='" + CharSplitsave[1] + "'";
                            object Type = "";
                            Type = Cmd.ExecuteScalar();

                            Cmd.CommandText = "select top(1) ID from NVO_tblCntrTypes where NVO_tblCntrTypes.ISOCode='" + CharSplitsave[2] + "'";
                            int ISOCOdeID = 0;
                            ISOCOdeID = Convert.ToInt32(Cmd.ExecuteScalar());

                            Cmd.CommandText = "select top(1) ISOCOde from NVO_tblCntrTypes where NVO_tblCntrTypes.ISOCode='" + CharSplitsave[2] + "'";
                            object ISOCOde = "";
                            ISOCOde = Cmd.ExecuteScalar();

                            Cmd.CommandText = "select top(1) ID from NVO_Generalmaster where Status = 1 and Seqno = 69 AND GeneralName='" + CharSplitsave[3] + "'";
                            int OwnTypeID = 0;
                            OwnTypeID = Convert.ToInt32(Cmd.ExecuteScalar());

                            Cmd.CommandText = "select top(1) GeneralName from NVO_Generalmaster where Status = 1 and Seqno = 69 AND GeneralName='" + CharSplitsave[3] + "'";

                            object OwnType = "";
                            OwnType = Cmd.ExecuteScalar();
                            if (CharSplitsave[0] != "")
                            {
                                ListCntrPickDrop.Add(new MyCntrPickDrop
                                {
                                    CID = 0,
                                    CntrNo = CharSplitsave[0],
                                    CntrType = Type.ToString(),
                                    CntrTypeID = Int32.Parse(TypeID.ToString()),
                                    ISOCode = ISOCOde.ToString(),
                                    ISOCodeID = Int32.Parse(ISOCOdeID.ToString()),
                                    OwningTypeID = Int32.Parse(OwnTypeID.ToString()),
                                    OwningType = OwnType.ToString(),

                                });
                            }
                        }



                    }
                    //trans.Commit();


                    return ListCntrPickDrop;

                }

                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListCntrPickDrop.Add(new MyCntrPickDrop { AlertMessage = ex.Message, UploadStatusID = "Uploaded file has error" });
                    return ListCntrPickDrop;
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

        #endregion

        #region CntrTrace

        public List<MyCntrPickDrop> BindCntrNosListValues(MyCntrPickDrop Data)
        {
            DataTable dt = GetBindCntrNosListValues(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrPickDrop.Add(new MyCntrPickDrop
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString()
                });
            }
            return ListCntrPickDrop;
        }

        public DataTable GetBindCntrNosListValues(MyCntrPickDrop Data)
        {
            string _Query = " SELECT * FROM NVO_Containers";
            return GetViewData(_Query, "");
        }

        List<MyCntrTrace> ListCntrTrace = new List<MyCntrTrace>();
        public List<MyCntrTrace> BindCntrTraceView(MyCntrTrace Data)
        {
            DataTable dt = GetBindCntrTraceView(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListCntrTrace.Add(new MyCntrTrace
                {
                    ID = Int32.Parse(dt.Rows[i]["ContainerID"].ToString()),
                    CntrNo = dt.Rows[i]["CntrNo"].ToString(),
                    MoveType = dt.Rows[i]["MoveType"].ToString(),
                    StorageLoc = dt.Rows[i]["StorageLoc"].ToString(),
                    LoadStatus = dt.Rows[i]["LoadStatus"].ToString(),
                    DtMovement = dt.Rows[i]["DtMovement"].ToString(),
                    ReferenceNo = dt.Rows[i]["ReferenceNo"].ToString(),
                    BookingNo = dt.Rows[i]["BookingNo"].ToString(),
                    BOLNo = dt.Rows[i]["BOLNov"].ToString(),
                    VesVoy = dt.Rows[i]["VesVoy"].ToString(),
                    InventoryType = dt.Rows[i]["InventoryType"].ToString(),
                    OwningLine = dt.Rows[i]["OwningLine"].ToString(),
                    OperatingLine = dt.Rows[i]["OperatingLine"].ToString(),
                    ContainerType = dt.Rows[i]["ContainerType"].ToString(),
                    ISOCode = dt.Rows[i]["ISOCode"].ToString(),
                    OwningType = dt.Rows[i]["OwningType"].ToString(),
                });
            }
            return ListCntrTrace;
        }


        public DataTable GetBindCntrTraceView(MyCntrTrace Data)
        {
            string strWhere = "";

            string _Query = "Select Left(BOLNo,19) as BOLNov,* from ViewContainerTrace ";



            if (Data.CntrID.ToString() != "" && Data.CntrID.ToString() != null && Data.CntrID.ToString() != "0" && Data.CntrID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where ContainerID =" + Data.CntrID.ToString() + "";
                else
                    strWhere += " and ContainerID =" + Data.CntrID.ToString() + "";


            if (strWhere == "")
                strWhere = _Query;
            return GetViewData(strWhere + " order By ID DESC ", "");

        }

        #endregion
        public string GetMaxseqNumber(string Prefix, string GeoLocId, string SessionFinYear)
        {
            DbConnection con = null;

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                DbCommand cmd = _dbFactory.GetCommand();
                cmd.Connection = con;

                int sno = 0;
                string Seqno = "0";

                cmd.CommandText = "select Max(ISNULL(" + Prefix + ",0)) from NVO_SeqNo where GeoLocId=" + GeoLocId + " and intYear=" + SessionFinYear;
                Seqno = cmd.ExecuteScalar().ToString();
                if (Seqno == "")
                {
                    sno = int.Parse("1");
                    Seqno = "1";
                }
                else if (Seqno == "0")
                    sno = int.Parse("1");
                else if (Seqno != "0")
                    sno = int.Parse(Seqno) + 1;

                cmd.CommandText = " IF ((SELECT COUNT(*) FROM NVO_SeqNo WHERE GeoLocId=" + GeoLocId + " and intYear = " + SessionFinYear + ")<=0)" +
                                   " BEGIN  " +
                                   " INSERT INTO NVO_SeqNo(GeoLocId," + Prefix + ",intYear)Values(" + GeoLocId + "," + sno.ToString() + ", " + SessionFinYear + ") " +
                                   " END " +
                                   " ELSE " +
                                   " UPDATE NVO_SeqNo SET " + Prefix + "=" + sno.ToString() + " where GeoLocId=" + GeoLocId + " and intYear = " + SessionFinYear;
                int result = cmd.ExecuteNonQuery();

                return Seqno.ToString();
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
        #region get values
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

        public string Getvalue(string Query)
        {
            DbConnection con = null;
            try
            {
                string Result = "";
                if (Query != "")
                {
                    con = _dbFactory.GetConnection();
                    con.Open();
                    DbCommand cmd = _dbFactory.GetCommand();
                    cmd.Connection = con;
                    cmd.CommandText = Query;
                    object objresult = cmd.ExecuteScalar();
                    if (objresult != null)
                        Result = objresult.ToString();

                }
                return Result;

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

