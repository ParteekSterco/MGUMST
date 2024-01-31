
Partial Class backoffice_Blogs_viewauthormaster
    Inherits System.Web.UI.Page

    Dim Strnew As String
    Dim Strtrue As String
    Dim clsm As New mainclass
    Dim Parameters As New Hashtable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        trerror.Visible = False
        trsuccess.Visible = False
        trnotice.Visible = False
        If Not Page.IsPostBack Then
            Label1.Visible = False

            If Request.QueryString("edit") = "edit" Then
                trsuccess.Visible = True
                lblsuccess.Text = "Record(s) updated successfully."
            End If
            gridshow()
        End If
    End Sub
    Private Function Pad(ByVal numberOfSpaces As Int32) As String
        Dim Spaces As String

        For items As Int32 = 1 To numberOfSpaces
            Spaces &= "&nbsp;&nbsp;&raquo;&nbsp;"
        Next
        Return Server.HtmlDecode(Spaces)
    End Function
    Private Sub gridshow()
        Dim strq As String = "select * from AuthorMaster where 1=1"

        strq &= " order by displayorder desc"
        clsm.GridviewDatashow(GridView1, strq)

        If GridView1.Rows.Count = 0 Then
            trnotice.Visible = True
            lblnotice.Text = "Records not found."
        End If
    End Sub
    
   
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Label1.Visible = False
        If e.CommandName = "lnkstatus" Then
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
            Dim str As String = CType(row.Cells(4), DataControlFieldCell).Text
            Parameters.Clear()
            Parameters.Add("@AutId", Val(e.CommandArgument))
            If str = "False" Then
                clsm.ExecuteQry_Parameter("update AuthorMaster set status=1 where AutId=@AutId", Parameters)

            ElseIf str = "True" Then
                clsm.ExecuteQry_Parameter("update AuthorMaster set status=0 where AutId=@AutId", Parameters)

            End If
            gridshow()
            trsuccess.Visible = True
            lblsuccess.Text = "Status changed successfully !!!"

        End If

        If e.CommandName = "btnedit" Then
            Response.Redirect("addauthor.aspx?AutId=" & e.CommandArgument)
        End If
        If e.CommandName = "btndel" Then
            Parameters.Clear()
            Parameters.Add("@AutId", Val(e.CommandArgument))
            clsm.ExecuteQry_Parameter("delete from AuthorMaster where AutId=@AutId", Parameters)
            gridshow()
            trsuccess.Visible = True
            lblsuccess.Text = "Record(s) deleted successfully."
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lnkstatus As ImageButton = e.Row.FindControl("lnkstatus")
            If e.Row.Cells(4).Text = "True" Then
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_unblock.png"
                lnkstatus.ToolTip = "Active"
            ElseIf e.Row.Cells(4).Text = "False" Then
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_block.png"
                lnkstatus.ToolTip = "Inactive"
            End If

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" & Server.HtmlDecode(Session("altColor")) & "'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'")
        End If
        If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(4).Visible = False
        End If
    End Sub

End Class
