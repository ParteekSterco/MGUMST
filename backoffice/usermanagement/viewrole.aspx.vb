
Partial Class BackOffice_usermanagement_viewrole
    Inherits System.Web.UI.Page
    Dim Clsm As New mainclass
    Dim Parameters As New Hashtable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        trerror.Visible = False
        trsuccess.Visible = False
        trnotice.Visible = False
        If Page.IsPostBack = False Then
            If Request.QueryString("edit") = "edit" Then
                trsuccess.Visible = True
                lblsuccess.Text = "Role updated successfully."
            End If
            gridshow()
        End If
    End Sub
    Protected Sub gridshow()
        Dim Strqry As String
        Parameters.Clear()
        Strqry = "select * from RoleMaster where roleid not in(1,6) order by rolename"
        Clsm.GridviewData_Parameter(GridView1, Strqry, Parameters)
        If GridView1.Rows.Count = 0 Then
            trnotice.Visible = True
            lblnotice.Text = "Roles not found."
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "btnedit" Then
           
            Response.Redirect("addrole.aspx?roleid=" & Val(e.CommandArgument) & "")
        End If
        If e.CommandName = "lnkstatus" Then
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
            Dim str As String = CType(row.Cells(2), DataControlFieldCell).Text
            Parameters.Clear()
            Parameters.Add("@roleid", Val(e.CommandArgument))
            If str = "False" Then
                Clsm.ExecuteQry_Parameter("update RoleMaster set rolestatus=1 where roleid=@roleid", Parameters)
            ElseIf str = "True" Then
                Clsm.ExecuteQry_Parameter("update RoleMaster set rolestatus=0 where roleid=@roleid", Parameters)
            End If
            trsuccess.Visible = True
            lblsuccess.Text = "Status changed successfully."
            gridshow()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lnkstatus As ImageButton = e.Row.FindControl("lnkstatus")
            If e.Row.Cells(2).Text = "True" Then
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_unblock.png"
                lnkstatus.ToolTip = "Active"
            ElseIf e.Row.Cells(2).Text = "False" Then
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_block.png"
                lnkstatus.ToolTip = "Inactive"
            End If
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" & Session("altColor") & "'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'")
        End If

        If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(2).Visible = False
        End If
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("currenttheme") Is Nothing = False Then
            Page.Theme = Session("currenttheme")
        End If
    End Sub
End Class
