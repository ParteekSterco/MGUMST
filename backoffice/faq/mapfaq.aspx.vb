
Partial Class backoffice_faq_mapfaq
    Inherits System.Web.UI.Page

    Dim clsm As New mainclass
    Dim Parameters As New Hashtable
    Dim AUserSession As HttpCookie
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        trerror.Visible = False
        trsuccess.Visible = False
        trnotice.Visible = False
        If Request.Cookies("AUserSession") Is Nothing = True Then
            AUserSession = New HttpCookie("AUserSession")
        Else
            AUserSession = Request.Cookies("AUserSession")
        End If
        If Page.IsPostBack = False Then

            'Parameters.Clear()
            'clsm.Fillcombo_Parameter("select DeptName,subdeptid from Subdepartment_Master where status=1 order by DeptName", Parameters, sdeptid)

            'Parameters.Clear()
            'clsm.Fillcombo_Parameter("select levelname,levelid from CourseLevel_Master order by displayorder", Parameters, levelid)
            'branch()
            fillgrid()
            'filldepartgrid()
        End If
    End Sub
    'Sub branch()
    '    Parameters.Clear()
    '    Dim strsql As String = "select streamname,streamid from stream_master where status=1"
    '    'If Val(levelid.SelectedValue) > 0 Then
    '    'Parameters.Add("@levelid", Val(levelid.SelectedValue))
    '    'strsql &= " and levelid=@levelid"
    '    'End If
    '    strsql &= " order by streamname"
    '    clsm.Fillcombo_Parameter(strsql, Parameters, streamid)
    '    streamid.Items(0).Text = "Select Branch"
    'End Sub
    'Protected Sub levelid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles levelid.SelectedIndexChanged
    '    branch()
    '    fillgrid()

    'End Sub
    'Sub filldepartgrid()
    '    Parameters.Clear()
    '    Dim strsql As String = "Select DeptName,deptid,subdeptid from Subdepartment_Master where Status=1 "

    '    strsql &= " order by displayorder"
    '    clsm.datalistDatashow_Parameter(dl_depart, strsql, Parameters)
    '    ' checkgriddepart()
    'End Sub

    'Sub checkgriddepart()
    '    ' **************for attribute check***************
    '    Parameters.Clear()
    '    Parameters.Add("@faqid", Val(Request.QueryString("faqid")))
    '    Dim ds1 As DataSet = clsm.senddataset_Parameter("select faqid,subdeptid from map_faq_department where faqid=@faqid", Parameters)

    '    Dim j As Integer
    '    If ds1.Tables(0).Rows.Count > 0 Then
    '        For j = 0 To ds1.Tables(0).Rows.Count - 1
    '            For Each rptrsch As DataListItem In dl_depart.Items

    '                Dim lblsubdeptid As Label = rptrsch.FindControl("lblsubdeptid")
    '                Dim lbldepart As Label = rptrsch.FindControl("lbldepart")
    '                Dim checkfeaturedep As CheckBox = rptrsch.FindControl("checkfeaturedep")
    '                If Val(Request.QueryString("faqid")) = Val(ds1.Tables(0).Rows(j)("faqid")) And Val(lblsubdeptid.Text) = Val(ds1.Tables(0).Rows(j)("subdeptid")) Then
    '                    checkfeaturedep.Checked = True
    '                    lbldepart.Attributes.Add("Style", "color: black;font-weight:bold;")
    '                End If
    '            Next
    '        Next
    '    End If
    '    ' **************************************
    'End Sub

    Sub fillgrid()
        Parameters.Clear()
        Dim strsql As String = "Select courseid,coursename from Course where Status=1 "
        'If Val(levelid.SelectedValue) > 0 Then
        '    Parameters.Add("@levelid", Val(levelid.SelectedValue))
        '    strsql &= " and levelid=@levelid"
        'End If
        'If Val(streamid.SelectedValue) > 0 Then

        '    Parameters.Add("@streamid", Val(streamid.SelectedValue))
        '    strsql &= " and streamid=@streamid"

        'End If
        strsql &= " order by displayorder"
        clsm.datalistDatashow_Parameter(dl_sgroup, strsql, Parameters)
        checkgrid()
    End Sub
    Sub checkgrid()
        ' **************for attribute check***************
        Parameters.Clear()
        Parameters.Add("@faqid", Val(Request.QueryString("faqid")))
        Dim ds1 As DataSet = clsm.senddataset_Parameter("select faqid,courseid from map_faq_course where faqid=@faqid", Parameters)

        Dim j As Integer
        If ds1.Tables(0).Rows.Count > 0 Then
            For j = 0 To ds1.Tables(0).Rows.Count - 1
                For Each rptrsch As DataListItem In dl_sgroup.Items

                    Dim lblcourseid As Label = rptrsch.FindControl("lblcourseid")
                    Dim lblcourse As Label = rptrsch.FindControl("lblcourse")
                    Dim checkfeature As CheckBox = rptrsch.FindControl("checkfeature")
                    If Val(Request.QueryString("faqid")) = Val(ds1.Tables(0).Rows(j)("faqid")) And Val(lblcourseid.Text) = Val(ds1.Tables(0).Rows(j)("courseid")) Then
                        checkfeature.Checked = True
                        lblcourse.Attributes.Add("Style", "color: black;font-weight:bold;")
                    End If
                Next
            Next
        End If
        ' **************************************
    End Sub

    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Try
            map_cat_product()
            ' map_faq_depart()

            'clsm.SendMail(HttpContext.Current.Request.Url.AbsoluteUri.ToString())

        Catch ex As Exception
            trerror.Visible = True
            lblerror.Text = ex.Message.ToString
        End Try
    End Sub

    Sub map_cat_product()
        For Each row1 As DataListItem In dl_sgroup.Items
            Dim lblcourseid As Label = row1.FindControl("lblcourseid")
            Dim checkfeature As CheckBox = row1.FindControl("checkfeature")
            If checkfeature.Checked = True Then
                Parameters.Clear()
                If clsm.Checking_Parameter(" select mcid from map_faq_course where  faqid=" & Val(Request.QueryString("faqid")) & "  and courseid=" & Val(lblcourseid.Text) & "", Parameters) = False Then

                    Parameters.Clear()
                    clsm.ExecuteQry_Parameter("insert into map_faq_course (subdeptid,courseid,faqid) values(" & Val(0) & "," & Val(lblcourseid.Text) & "," & Val(Request.QueryString("faqid")) & ")", Parameters)

                End If
            Else
                Parameters.Clear()
                clsm.ExecuteQry_Parameter("delete from map_faq_course where faqid=" & Val(Request.QueryString("faqid")) & " and  courseid=" & Val(lblcourseid.Text) & "  ", Parameters)
            End If
            trsuccess.Visible = True
            lblsuccess.Text = "Course/Department Map Successfully."
        Next

        fillgrid()

    End Sub


End Class






