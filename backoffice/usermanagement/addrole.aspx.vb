
Partial Class usermanagement_addrole
    Inherits System.Web.UI.Page
    Dim Clsm As New mainclass
    Dim rid As Integer
    Dim qstring As String
    Dim consql As New SqlConnection
    Dim Parameters As New Hashtable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        trsuccess.Visible = False
        trerror.Visible = False
        trnotice.Visible = False
        If Page.IsPostBack = False Then
            Try
                Parameters.Clear()
                Clsm.datalistDatashow_Parameter(DlAccess, "select * from ModuleMaster where status=1 order by displayorder", Parameters)
                showList()
                tr_per.Visible = False
                If Val(Request.QueryString("roleid")) <> 0 Then
                    DlAccess.Visible = True
                    qstring = Replace(Request.QueryString("roleid"), "'", "''")
                    Parameters.Clear()
                    Parameters.Add("@roleid", Val(qstring))
                    Clsm.MoveRecord_Parameter(Me, roleid.Parent, "Select * from RoleMaster where roleid =@roleid", Parameters)
                    Dim dscheck As DataSet
                    Dim i, j As Integer
                    Parameters.Clear()
                    Parameters.Add("@roleid", Val(qstring))
                    dscheck = Clsm.senddataset_Parameter("select * from Role_details where roleid=@roleid", Parameters)

                    Dim item As DataListItem

                    For Each item In DlAccess.Items
                        Dim txtmid As TextBox = CType(item.FindControl("txtmid"), TextBox)
                        Dim GridView2 As GridView = CType(item.FindControl("GridView2"), GridView)
                        For i = 0 To GridView2.Rows.Count - 1
                            Dim chkbx2 As CheckBox = GridView2.Rows(i).FindControl("chkselect")

                            For j = 0 To dscheck.Tables(0).Rows.Count - 1
                                If GridView2.Rows(i).Cells(0).Text = dscheck.Tables(0).Rows(j).Item("formid") Then
                                    If dscheck.Tables(0).Rows(j).Item("viewform") = True Then
                                        chkbx2.Checked = True
                                    End If
                                End If
                            Next
                        Next
                    Next
                End If
            Catch ex As Exception
                trerror.Visible = True
                lblerror.Text = ex.Message.ToString
            End Try
        End If
    End Sub

    Protected Sub checkedall()
        '********************************
        Dim i As Integer
        Dim item As DataListItem
        For Each item In DlAccess.Items
            Dim GridView2 As GridView = CType(item.FindControl("GridView2"), GridView)
            For i = 0 To GridView2.Rows.Count - 1
                Dim chkbx2 As CheckBox = GridView2.Rows(i).FindControl("chkselect")
                Dim selectall As CheckBox = GridView2.HeaderRow.FindControl("selectall")
                If selectall.Checked = True Then
                    chkbx2.Checked = True
                ElseIf selectall.Checked = False Then
                    chkbx2.Checked = False
                End If
            Next
        Next
    End Sub

    Protected Sub showList()
        DlAccess.Visible = True
        tr_per.Visible = True
        Dim i, r As Integer
        Dim item As DataListItem
        For Each item In DlAccess.Items
            Dim GridView2 As GridView = CType(item.FindControl("GridView2"), GridView)
            For i = 0 To GridView2.Rows.Count - 1
                Dim chkbx2 As CheckBox = GridView2.Rows(i).FindControl("chkselect")
                chkbx2.Checked = False
            Next
        Next
    End Sub
    Friend Sub datalistgrdeachitem(ByVal var As Integer)
        Try
            Dim item As DataListItem
            Dim i, ctr As Integer
            Parameters.Clear()
            Parameters.Add("@rid", Val(rid))
            Clsm.ExecuteQry_Parameter("delete from Role_details where roleid=@rid", Parameters)
            consql.ConnectionString = Clsm.strconnect
            consql.Open()

            For Each item In DlAccess.Items
                Dim txtmid As TextBox = CType(item.FindControl("txtmid"), TextBox)
                Dim GridView2 As GridView = CType(item.FindControl("GridView2"), GridView)
                Dim lblMName As Label = CType(item.FindControl("lblMName"), Label)
                For i = 0 To GridView2.Rows.Count - 1
                    Dim chkbx2 As CheckBox = GridView2.Rows(i).FindControl("chkselect")
                    Dim fmid As String = GridView2.Rows(i).Cells(0).Text.ToString()

                    If chkbx2.Checked Then
                        Dim objcmd3 As SqlCommand = New SqlCommand("Role_detailsSP", consql)
                        objcmd3.CommandType = CommandType.StoredProcedure
                        objcmd3.Parameters.AddWithValue("@roleid", rid)
                        objcmd3.Parameters.AddWithValue("@formid", fmid)
                        objcmd3.Parameters.AddWithValue("@viewform", 1)
                        objcmd3.Parameters.AddWithValue("@mode", 1)
                        objcmd3.ExecuteNonQuery()

                    Else
                        Dim objcmd3 As SqlCommand = New SqlCommand("Role_detailsSP", consql)
                        objcmd3.CommandType = CommandType.StoredProcedure
                        objcmd3.Parameters.AddWithValue("@roleid", rid)
                        objcmd3.Parameters.AddWithValue("@formid", fmid)
                        objcmd3.Parameters.AddWithValue("@viewform", 0)
                        objcmd3.Parameters.AddWithValue("@mode", 1)
                        objcmd3.ExecuteNonQuery()
                    End If

                Next
            Next
        Catch ex As Exception
            trerror.Visible = True
            lblerror.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub DlAccess_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DlAccess.ItemCommand
        Dim btnhide As ImageButton = e.Item.FindControl("btnhide")
        Dim btnshow As ImageButton = e.Item.FindControl("btnshow")
        Dim GridView2 As GridView = e.Item.FindControl("GridView2")
        Dim gridSubDepartment As GridView = e.Item.FindControl("gridSubDepartment")
        Dim grdNewDepartment As GridView = e.Item.FindControl("grdNewDepartment")

        Dim gridcampus As GridView = e.Item.FindControl("gridcampus")

        If e.CommandName = "show" Then
            btnhide.Visible = True
            btnshow.Visible = False
            GridView2.Visible = True
            gridSubDepartment.Visible = True
            gridcampus.Visible = True
            grdNewDepartment.Visible = True

        End If
        If e.CommandName = "hide" Then
            GridView2.Visible = False
            gridSubDepartment.Visible = False
            btnhide.Visible = False
            btnshow.Visible = True
            gridcampus.Visible = False
            grdNewDepartment.Visible = False
        End If
        
    End Sub
    Protected Sub DlAccess_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DlAccess.ItemDataBound
        Dim GridView2 As GridView = e.Item.FindControl("GridView2")
        Dim gridSubDepartment As GridView = e.Item.FindControl("gridSubDepartment")
        Dim gridcampus As GridView = e.Item.FindControl("gridcampus")
        Dim grdNewDepartment As GridView = e.Item.FindControl("grdNewDepartment")

        Dim btnhide As ImageButton = e.Item.FindControl("btnhide")
        Dim btnshow As ImageButton = e.Item.FindControl("btnshow")
        Dim txtmid As TextBox = e.Item.FindControl("txtmid")
        Parameters.Clear()
        Parameters.Add("@Moduleid", Val(txtmid.Text))
        Clsm.GridviewData_Parameter(GridView2, "SELECT distinct fmas.FormCaption, fmas.Formid FROM  FormMaster fmas INNER JOIN ModuleMaster mmas ON fmas.Moduleid = mmas.Moduleid where mmas.status=1 and fmas.status=1 and mmas.Moduleid=@Moduleid", Parameters)
        GridView2.Visible = False
        If txtmid.Text = 19 Then
            Parameters.Clear()
            Clsm.GridviewData_Parameter(gridSubDepartment, "select cm.collageid,(cm.collagename+'-('+cp.campus_name+')') as collagename from collage_master cm inner join campus cp on cm.campusid=cp.campusid   where cm.status=1  order by cp.displayorder, cm.displayorder", Parameters)
            gridSubDepartment.Visible = False
        End If
        If txtmid.Text = 41 Then
            Parameters.Clear()
            Clsm.GridviewData_Parameter(gridcampus, "select campusid,campus_name from campus  where status=1  order by displayorder", Parameters)
            gridcampus.Visible = False
        End If
        If txtmid.Text = 9 Then
            Parameters.Clear()
            Clsm.GridviewData_Parameter(grdNewDepartment, "select cm.collagename+'-('+c.campus_name+')' as collagename,d.DeptName,c.campus_name,d.deptid from Department_Master d inner join  collage_master cm on d.schoolid=cm.collageid inner join  campus c on cm.campusid=c.campusid left outer join department_management dm on dm.deptid=d.deptid where 1=1 order by c.displayorder,cm.displayorder,d.displayorder", Parameters)
            grdNewDepartment.Visible = False
        End If
        


    End Sub



    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Or e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Visible = False
        End If
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("currenttheme") Is Nothing = False Then
            Page.Theme = Session("currenttheme")
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try

            If Page.IsValid Then
                If Clsm.MasterSave(Me, roleid.Parent, 3, mainclass.Mode.modeCheckDuplicate, "RoleMasterSP", Session("UserId")) > 0 Then
                    trnotice.Visible = True
                    lblnotice.Text = "This Role is already exist."
                    Exit Sub
                End If

                If Val(roleid.Text) = 0 Then
                    rolestatus.Checked = True
                    rid = Clsm.MasterSave(Me, roleid.Parent, 3, mainclass.Mode.modeAdd, "RoleMasterSP", Session("UserId"))

                    '***************** for log history*********************

                    Clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(rolename.Text), Convert.ToString(rid), Convert.ToString("RoleMaster"), Convert.ToString("0"), "RoleMaster")

                    '*********************** end for log history*******************************
                    datalistgrdeachitem(Val(rid))
                    SaveDepartmentDetails(Val(rid))
                    SaveCampusDetails(Val(rid))
                    SaveNewDepartmentDetails(Val(rid))
                    'Clsm.Clearall(roleid.Parent)
                    trsuccess.Visible = True
                    lblsuccess.Text = "Role added successfully."
                Else
                    rid = Clsm.MasterSave(Me, roleid.Parent, 3, mainclass.Mode.modeModify, "RoleMasterSP", Session("UserId"))
                    '***************** for log history*********************

                    Clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(rolename.Text), Convert.ToString(rid), Convert.ToString("RoleMaster"), Convert.ToString("0"), "RoleMaster")

                    '*********************** end for log history*******************************
                    datalistgrdeachitem(Val(rid))
                    SaveDepartmentDetails(Val(rid))
                    SaveCampusDetails(Val(rid))
                    SaveNewDepartmentDetails(Val(rid))
                    Response.Redirect("viewrole.aspx?edit=edit")
                End If
            End If
        Catch er As Exception
            trerror.Visible = True
            lblerror.Text = er.Message.ToString
        End Try
        rolestatus.Checked = True
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Val(roleid.Text) = 0 Then
            'Clsm.Clearall(roleid.Parent)
        Else
            Response.Redirect("viewrole.aspx")
        End If
        rolestatus.Checked = True
    End Sub

    Protected Sub selectall_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        System.Threading.Thread.Sleep(1000)
        checkedall()
    End Sub

    Protected Sub SaveDepartmentDetails(ByVal RId As Integer)

        roleid.Text = RId.ToString()
        Dim i As Integer = 0
        For Each dl As DataListItem In DlAccess.Items
            Dim txtmid As TextBox = DirectCast(dl.FindControl("txtmid"), TextBox)

            If txtmid.Text = 19 Then

                Parameters.Clear()
                Parameters.Add("@rid", Val(RId))
                Clsm.ExecuteQry_Parameter("delete from collage_Management where roleid=@rid", Parameters)

                Dim gridSubDepartment As GridView = DirectCast(dl.FindControl("gridSubDepartment"), GridView)
                For k As Integer = 0 To gridSubDepartment.Rows.Count - 1
                    Dim lbldeptid As Label = gridSubDepartment.Rows(k).FindControl("lbldeptid")
                    Dim chkselect As CheckBox = gridSubDepartment.Rows(k).FindControl("chkselect")
                    If chkselect.Checked = True Then
                        Dim objcmd As SqlCommand = New SqlCommand("collage_managementSP", consql)
                        objcmd.CommandType = CommandType.StoredProcedure
                        objcmd.Parameters.AddWithValue("@collageid", Val(lbldeptid.Text))
                        objcmd.Parameters.AddWithValue("@roleid", RId)
                        objcmd.Parameters.AddWithValue("@status", 1)
                        objcmd.Parameters.AddWithValue("@Uname", "admin")
                        objcmd.Parameters.AddWithValue("@mode", 1)
                        objcmd.ExecuteNonQuery()
                    End If

                Next

            End If
            i = i + 1
        Next

    End Sub

    Protected Sub SaveCampusDetails(ByVal RId As Integer)

        roleid.Text = RId.ToString()
        Dim i As Integer = 0
        For Each dl As DataListItem In DlAccess.Items
            Dim txtmid As TextBox = DirectCast(dl.FindControl("txtmid"), TextBox)

            If txtmid.Text = 41 Then

                Parameters.Clear()
                Parameters.Add("@rid", Val(RId))
                Clsm.ExecuteQry_Parameter("delete from campusrole_Management where roleid=@rid", Parameters)

                Dim gridcampus As GridView = DirectCast(dl.FindControl("gridcampus"), GridView)
                For k As Integer = 0 To gridcampus.Rows.Count - 1
                    Dim lblcampusid As Label = gridcampus.Rows(k).FindControl("lblcampusid")
                    Dim chkselect As CheckBox = gridcampus.Rows(k).FindControl("chkselect")
                    If chkselect.Checked = True Then
                        Dim objcmd As SqlCommand = New SqlCommand("campusrole_ManagementSP", consql)
                        objcmd.CommandType = CommandType.StoredProcedure
                        objcmd.Parameters.AddWithValue("@campusid", Val(lblcampusid.Text))
                        objcmd.Parameters.AddWithValue("@roleid", RId)
                        objcmd.Parameters.AddWithValue("@status", 1)
                        objcmd.Parameters.AddWithValue("@Uname", "sadmin")
                        objcmd.Parameters.AddWithValue("@mode", 1)
                        objcmd.ExecuteNonQuery()
                    End If

                Next

            End If
            i = i + 1
        Next

    End Sub
    Protected Sub SaveNewDepartmentDetails(ByVal RId As Integer)

        roleid.Text = RId.ToString()
        Dim i As Integer = 0
        For Each dl As DataListItem In DlAccess.Items
            Dim txtmid As TextBox = DirectCast(dl.FindControl("txtmid"), TextBox)

            If txtmid.Text = 9 Then

                Parameters.Clear()
                Parameters.Add("@rid", Val(RId))
                Clsm.ExecuteQry_Parameter("delete from Department_management where roleid=@rid", Parameters)

                Dim gridcampus As GridView = DirectCast(dl.FindControl("grdNewDepartment"), GridView)
                For k As Integer = 0 To gridcampus.Rows.Count - 1
                    Dim lblcampusid As Label = gridcampus.Rows(k).FindControl("lbldeptid")
                    Dim chkselect As CheckBox = gridcampus.Rows(k).FindControl("chkselect")
                    If chkselect.Checked = True Then
                        Dim objcmd As SqlCommand = New SqlCommand("department_ManagementSP", consql)
                        objcmd.CommandType = CommandType.StoredProcedure
                        objcmd.Parameters.AddWithValue("@deptid", Val(lblcampusid.Text))
                        objcmd.Parameters.AddWithValue("@roleid", RId)
                        objcmd.Parameters.AddWithValue("@status", 1)
                        objcmd.Parameters.AddWithValue("@Uname", "sadmin")
                        objcmd.Parameters.AddWithValue("@mode", 1)
                        objcmd.ExecuteNonQuery()
                    End If

                Next

            End If
            i = i + 1
        Next

    End Sub

    Protected Sub gridSubDepartment_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dsdepartment As DataSet
            Parameters.Clear()
            Dim qstring = Request.QueryString("roleid")
            Parameters.Add("@roleid", Val(qstring))
            dsdepartment = Clsm.senddataset_Parameter("select * from collage_Management where roleid=@roleid", Parameters)
            Dim lbldeptid As Label = e.Row.FindControl("lbldeptid")
            Dim chkselect As CheckBox = e.Row.FindControl("chkselect")
            For j As Integer = 0 To dsdepartment.Tables(0).Rows.Count - 1
                If lbldeptid.Text = dsdepartment.Tables(0).Rows(j).Item("collageid") Then
                    chkselect.Checked = True
                End If
            Next
        End If
    End Sub


    Protected Sub gridcampus_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dsdepartment As DataSet
            Parameters.Clear()
            Dim qstring = Request.QueryString("roleid")
            Parameters.Add("@roleid", Val(qstring))
            dsdepartment = Clsm.senddataset_Parameter("select * from campusrole_Management where roleid=@roleid", Parameters)
            Dim lblcampusid As Label = e.Row.FindControl("lblcampusid")
            Dim chkselect As CheckBox = e.Row.FindControl("chkselect")
            For j As Integer = 0 To dsdepartment.Tables(0).Rows.Count - 1
                If lblcampusid.Text = dsdepartment.Tables(0).Rows(j).Item("campusid") Then
                    chkselect.Checked = True
                End If
            Next
        End If
    End Sub
    Protected Sub grdNewDepartment_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dsdepartment As DataSet
            Parameters.Clear()
            Dim qstring = Request.QueryString("roleid")
            Parameters.Add("@roleid", Val(qstring))
            dsdepartment = Clsm.senddataset_Parameter("select * from Department_management where roleid=@roleid", Parameters)
            Dim lbldeptid As Label = e.Row.FindControl("lbldeptid")
            Dim chkselect As CheckBox = e.Row.FindControl("chkselect")
            For j As Integer = 0 To dsdepartment.Tables(0).Rows.Count - 1
                If lbldeptid.Text = dsdepartment.Tables(0).Rows(j).Item("deptid") Then
                    chkselect.Checked = True
                End If
            Next
        End If
    End Sub

End Class
