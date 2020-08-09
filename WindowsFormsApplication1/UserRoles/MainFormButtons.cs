using SeqKartLibrary;
using System;
using System.Windows.Forms;

public class MainFormButtons
{
    public static void Roles(string ProgCode, string CurrentUser,
        ToolStripButton btnAdd,
        ToolStripButton btnEdit = null,
        ToolStripButton btnDelete = null,
        ToolStripButton btnPrint = null)
    {
        string Query4Controls = String.Format("SELECT     ProgAdd_F, ProgUpd_F, ProgDel_F, ProgRep_p, ProgRep_p,ProgSpl_U FROM         UserProgAccess WHERE     (ProgActive is Null or progActive= 'Y') AND (ProgCode = N'" + ProgCode + "') AND (UserName = N'{0}'); ", CurrentUser);

        using (var Tempds = ProjectFunctionsUtils.GetDataSet(Query4Controls))
        {
            if (Tempds != null)
            {
                if (Tempds.Tables[0].Rows.Count > 0)
                {
                    if (btnAdd != null)
                    {
                        if (Tempds.Tables[0].Rows[0]["ProgAdd_F"].ToString() == "-1")
                        {
                            btnAdd.Enabled = true;
                        }
                        else
                        {
                            btnAdd.Enabled = false;
                        }
                    }

                    if (btnEdit != null)
                    {
                        if (Tempds.Tables[0].Rows[0]["ProgUpd_F"].ToString() == "-1")
                        {
                            btnEdit.Enabled = true;
                        }
                        else
                        {
                            btnEdit.Enabled = false;
                        }
                    }


                    if (btnDelete != null)
                    {
                        if (Tempds.Tables[0].Rows[0]["ProgDel_F"].ToString() == "-1")
                        {
                            btnDelete.Enabled = true;
                        }
                        else
                        {
                            btnDelete.Enabled = false;
                        }
                    }


                    if (btnPrint != null)
                    {
                        if (Tempds.Tables[0].Rows[0]["ProgRep_p"].ToString() == "-1")
                        {
                            btnPrint.Enabled = true;
                        }
                        else
                        {
                            btnPrint.Enabled = false;
                        }
                    }

                }
            }
        }
    }
}