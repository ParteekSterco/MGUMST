
Partial Class BackOffice_usermanagement_adduser
    Inherits System.Web.UI.Page
    Dim Clsm As New mainclass
    Dim Parameters As New Hashtable
    Dim encry As New Enc_Decyption()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        trsuccess.Visible = False
        trerror.Visible = False
        trnotice.Visible = False
        If Page.IsPostBack = False Then

            Parameters.Clear()
            Clsm.Fillcombo_Parameter("select rolename,roleid from rolemaster where rolestatus=1 and  roleid not in(1,6) order by rolename", Parameters, Roleid)
            gridshow()
        End If
    End Sub
    Protected Sub gridshow()
        Dim str As String
        Parameters.Clear()
        str = "select B.*, r.rolename from bousermaster b inner join rolemaster r on r.roleid=b.roleid where b.trid not in (1,2) order by b.userid"
        Clsm.GridviewData_Parameter(GridView1, str, Parameters)
        If GridView1.Rows.Count = 0 Then
            trnotice.Visible = True
            lblnotice.Text = "Users not found."
        End If
    End Sub

    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Try
            If Page.IsValid = True Then
                If Clsm.MasterSave(Me, TrId.Parent, 11, mainclass.Mode.modeCheckDuplicate, "bousermasterSP", Session("UserId")) = True Then
                    trnotice.Visible = True
                    lblnotice.Text = "Duplicacy not allowed."
                    gridshow()
                    Exit Sub
                End If
                If Val(TrId.Text) = 0 Then
                    Status.Checked = True
                    Name.Text = Roleid.SelectedItem.Text
                    themeid.Text = "1"
                    UserPassword.Text = encry.AES_Encrypt(UserPassword.Text, "@9899848281")
                    Dim var As String = Clsm.MasterSave(Me, TrId.Parent, 11, mainclass.Mode.modeAdd, "bousermasterSP", Session("UserId"))

                    Clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(Userid.Text), Convert.ToString(var), Convert.ToString("AddUser"), Convert.ToString("0"), "AddUser")


                    Clsm.ClearallPanel(Me, TrId.Parent)
                    trsuccess.Visible = True
                    lblsuccess.Text = "User added successfully."
                Else
                    UserPassword.Text = encry.AES_Encrypt(UserPassword.Text, "@9899848281")
                    Dim var As String = Clsm.MasterSave(Me, TrId.Parent, 11, mainclass.Mode.modeModify, "bousermasterSP", Session("UserId"))

                    Clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(Userid.Text), Convert.ToString(var), Convert.ToString("AddUser"), Convert.ToString("0"), "AddUser")
                    trsuccess.Visible = True
                    lblsuccess.Text = "User updated successfully."
                    Clsm.ClearallPanel(Me, TrId.Parent)
                End If
                gridshow()
            End If
        Catch ex As Exception
            trerror.Visible = True
            lblerror.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Clsm.ClearallPanel(Me, TrId.Parent)
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "btnedit" Then
            Parameters.Clear()
            Clsm.MoveRecord_Parameter(Me, TrId.Parent, "select * from bousermaster where trid=" & Val(e.CommandArgument) & "", Parameters)
            'Clsm.MoveRecord_Parameter(Me, TrId.Parent, "select * from bousermaster where trid=" & Val(e.CommandArgument) & "", Parameters)
            UserPassword.Text = encry.AES_Decrypt(Convert.ToString(UserPassword.Text), "@9899848281")
            UserPassword.Attributes.Add("value", UserPassword.Text)
        End If
        If e.CommandName = "lnkstatus" Then
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
            Dim str As String = CType(row.Cells(4), DataControlFieldCell).Text
            Parameters.Clear()
            Parameters.Add("@trid", Val(e.CommandArgument))
            If str = "False" Then
                Clsm.ExecuteQry_Parameter("update bousermaster set status=1 where trid=@trid", Parameters)
            Else
                Clsm.ExecuteQry_Parameter("update bousermaster set status=0 where trid=@trid", Parameters)
            End If
            trsuccess.Visible = True
            lblsuccess.Text = "Status changed successfully."
            gridshow()
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
        End If
        If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Or e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(4).Visible = False
        End If
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("currenttheme") Is Nothing = False Then
            Page.Theme = Session("currenttheme")
        End If
    End Sub

End Class
